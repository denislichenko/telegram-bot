using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Logic;

namespace TelegramBot.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class BotPanelController : Controller
    {
        public IActionResult Index()
        {
            bool status = BotConfiguration.Status; 
            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }

        public IActionResult IncomeMessages()
        {
            return View();
        }

        public IActionResult Admins()
        {
            return View();
        }

        public IActionResult Cats()
        {
            return View();
        }

        public IActionResult Wallpapers()
        {
            return View();
        }

    }
}