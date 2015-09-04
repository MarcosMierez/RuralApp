using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRural.Aplicacao;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Helpers;

namespace ControleRural.Areas.Cadastramento.Controllers
{
    public class AnimalController : Controller
    {
       [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(Construtor.AnimalApp().GetAll());
        }

        public ActionResult Cadastrar()
        {
            return View(new AnimalVM());
        }
        [HttpPost]
        public ActionResult Cadastrar(AnimalVM animal)
        {
            if (ModelState.IsValid)
            {
                Construtor.AnimalApp().Save(animal,Seguranca.Usuario().ID);
                return RedirectToActionPermanent("Index","Painel",new{Areas=""});
            }
            return View(animal);
        }

        public ActionResult Editar(string id)
        {
            if (id!=null)
            {
                var tempAn = Construtor.AnimalApp().GetById(id);
                if (tempAn.Aptidao!=null)
                {
                return View(tempAn);                    
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Editar(AnimalVM animal)
        {
            if (ModelState.IsValid)
            {
                Construtor.AnimalApp().Update(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }
        
    }
}