using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StudentManagement21A2.Helpers;
using StudentManagement21A2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Controllers
{
    public class AccountsController : Controller
    {
        private IConfiguration _config;

        CommonHelper _helper;

        public AccountsController(IConfiguration config)
        {
            _config = config;
            _helper = new CommonHelper(_config);
        }
        public void EntryIntoSession(string UserName)
        {
          
            HttpContext.Session.SetString("UserName", UserName);
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel vm)
        {
            if(string.IsNullOrEmpty(vm.UserName) && string.IsNullOrEmpty(vm.Password))
            {
                ViewBag.ErrorMsg = "Login lub hasło są puste";
                return View();
            }
            else
            {
                bool IsFind = SignInMethod(vm.UserName, vm.Password);
                bool Admin = SignInMethodAdmin(vm.UserName, vm.Password);
                if (Admin == true)
                {
                    ViewBag.Success = "Zalogowano pomyślnie jako admin";

                    return RedirectToAction("Index", "All_Cars_Rents");
                }
                else
                {
                    if (IsFind == true)
                    {
                        ViewBag.Success = "Zalogowano pomyślnie";
                        EntryIntoSession(vm.UserName);
                        return RedirectToAction("Index", "clients");
                    }
                }
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            String UserExistsQuery = $"Select * from   [dbo].[RegisterViewModels] where UserName ='{vm.UserName}'";
            bool UserExists = _helper.UserAlreadyExists(UserExistsQuery);
            if(UserExists == true)
            {
                ViewBag.Error = "Podana nazwa już istnieje";
                return View();
            }
            String Query = "Insert into [dbo].[RegisterViewModels](UserName,"+$"Password) values ('{vm.UserName}','{vm.Password}')";
            int result = _helper.DMLTransaction(Query);
            if(result>0)
            {
                EntryIntoSession(vm.UserName);
                
                ViewBag.Success = "Zarejestrowano pomyślnie";
                return RedirectToAction("Index","home");
            }
            return View();
        }

        private bool SignInMethod(string userName, string password)
        {
            bool flag = false;
            string query = $"select * from [dbo].[RegisterViewModels] where UserName='{userName}' and Password='{password}' ";
            var userDetails = _helper.GetUserByUserName(query);
            if(userDetails.UserName != null)
            {
                flag = true;
                HttpContext.Session.SetString("UserName", userDetails.UserName);
            }
            else
            {
                ViewBag.ErrorMsg = "Nieprawidłowy login lub hasło";
            }
            return flag;
        }

        private bool SignInMethodAdmin(string UserName,String Password)
        {
            bool flag = false;
            
            if (UserName == "Admin"&& Password == "Admin")
            {
                flag = true;
            }
            else
            {
                ViewBag.ErrorMsg = "Nieprawidłowy login lub hasło";
            }
            return flag;



        }
    }



}
