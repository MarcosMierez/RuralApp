using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRural.Aplicacao;
using ControleRural.Helpers;
using ControleRural.Models;

namespace ControleRural.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email,string Senha)
        {
            if (Construtor.UsuarioApp().LogarUsuario(Email, Senha))
            {
                return RedirectToAction("Index","Painel");
            }
            
            return View();
        }

        public ActionResult RegistrarUsuario()
        {
            return View(new Usuario());
        }
        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Construtor.UsuarioApp().Save(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);
        }
       
    }
}