using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRural.Aplicacao;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Helpers;
using ControleRural.Models;

namespace ControleRural.Controllers
{
    public class PainelController : Controller
    {
        private Usuario usuario = Seguranca.Usuario();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MinhasCriacoes()
        {
            return View(Construtor.UsuarioApp().MinhasCriacoes(usuario.ID));
        }

        public ActionResult Detalhe(string id)
        {

            return View(Construtor.UsuarioApp().EditarAnimal(id, usuario.ID));
        }
        [HttpPost]
        public ActionResult Detalhe(AnimalVM animal)
        {
            if (ModelState.IsValid)
            {
                animal.IdUsuario = usuario.ID;
                Construtor.AnimalApp().Update(animal);
                return RedirectToAction("MinhasCriacoes");
            }
            return View(animal);
        }

        public ActionResult RegistrarAnimal()
        {
            return View(new AnimalVM());
        }
        [HttpPost]
        public ActionResult RegistrarAnimal(AnimalVM animal)
        {
            if (ModelState.IsValid)
            {
                Construtor.AnimalApp().Save(animal,usuario.ID);
                return RedirectToAction("Index");
            }
            return View(animal);
        }

    }
}