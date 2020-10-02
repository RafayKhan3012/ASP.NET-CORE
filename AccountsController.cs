using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Models;

namespace Practice.Controllers
{
    public class AccountsController : Controller
    {
        private readonly LocalDBContext DB;
        public AccountsController(LocalDBContext context)
        {
            DB = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(TblUsers model)
        {
            TblUsers Result = DB.TblUsers.Where(x => x.Name == model.Name).FirstOrDefault();
            if (Result!=null)
            {

                HttpContext.Session.SetString("User", Result.Name);
            }
            return View();
        }
    }
}
