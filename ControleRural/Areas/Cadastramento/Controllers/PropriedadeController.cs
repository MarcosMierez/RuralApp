using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRural.Aplicacao;
using ControleRural.Areas.Cadastramento.Models;

namespace ControleRural.Areas.Cadastramento.Controllers
{
    public class PropriedadeController : Controller
    {
        // GET: Cadastramento/Propriedade
        public ActionResult Index()
        {
            return View(Construtor.PropriedadeApp().ListarTodos());
        }//pagina inicial

        public ActionResult RegistrarPropriedade()
        {
            return View(new PropriedadeViewModel());
        }
        [HttpPost]
        public ActionResult RegistrarPropriedade(PropriedadeViewModel propriedade)
        {
            return View();
        }

        public ActionResult Editar(string id)
        {
            if (id != null)
            {
                return View(Construtor.PropriedadeApp().ListarId(id));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Editar(PropriedadeViewModel propriedade)
        {
            if (ModelState.IsValid)
            {
             Construtor.PropriedadeApp().Editar(propriedade);
                return RedirectToAction("Index");
            }
            return View(propriedade);
        }

    }
}