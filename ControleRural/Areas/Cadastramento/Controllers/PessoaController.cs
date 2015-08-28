using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRural.Aplicacao;
using ControleRural.Areas.Cadastramento.Models;

namespace ControleRural.Areas.Cadastramento.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            return View(Construtor.PessoaApp().GetAll().ToList());
        }

        public ActionResult Cadastro()
        {
            return View(new PessoaVM());
        }
        [HttpPost]
        public ActionResult Cadastro(PessoaVM pessoa)
        {
            if (!ModelState.IsValid)
            {
                Construtor.PessoaApp().Save(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public ActionResult Update(string id)
        {
            if (id!=null)
            {
              var pessoa = Construtor.PessoaApp().GetById(id);
                if (pessoa.Apelido!=null)
                {
                    return View(pessoa);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(PessoaVM pessoa)
        {
            if (ModelState.IsValid)
            {
                Construtor.PessoaApp().Update(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }
    }
}