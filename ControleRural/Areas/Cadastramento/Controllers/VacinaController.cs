using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRural.Aplicacao;
using ControleRural.Areas.Cadastramento.Models;

namespace ControleRural.Areas.Cadastramento.Controllers
{
    public class VacinaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View(new VacinaVM());
        }
        [HttpPost]
        public ActionResult Cadastrar(VacinaVM vacina)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(vacina);
        }

        public ActionResult Editar(string id)
        {

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Editar(VacinaVM vacina)
        {
            if (ModelState.IsValid)
            {
                Construtor.VacinaApp().Update(vacina);
                return RedirectToAction("Index");
            }
            return View(vacina);
        }
    }
}