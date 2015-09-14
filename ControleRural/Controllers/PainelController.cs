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
    [Authorize]
    public class PainelController : Controller
    {
        private Usuario usuario = Seguranca.Usuario();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrarCompra()
        {
            @ViewBag.criacoes = Construtor.UsuarioApp().MinhasCriacoes(usuario.ID,"","","");
            return View(new RegistroAnimal());
        }

        [HttpPost]
        public ActionResult RegistrarCompra(RegistroAnimal registro)
        {
            if (ModelState.IsValid)
            {
                registro.UsuarioId = usuario.ID;
                Construtor.UsuarioApp().RegistrarAtividade(registro);
                return RedirectToAction("Index");
            }
            @ViewBag.criacoes = Construtor.UsuarioApp().MinhasCriacoes(usuario.ID, "", "", "");
            return View(registro);
        }


        public ActionResult MinhasCriacoes()
        {
            return View(Construtor.UsuarioApp().MinhasCriacoes(usuario.ID,"","",""));
        }
        [HttpPost]
        public ActionResult MinhasCriacoes(string filtro,string busca,string filtroRefinado)
        {
            return View(Construtor.UsuarioApp().MinhasCriacoes(usuario.ID,filtro,busca,filtroRefinado));
        }
        public ActionResult Detalhe(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("MinhasCriacoes");
            }
            var propriedades = Construtor.UsuarioApp().MinhasPropriedades(usuario.ID);
            ViewBag.propriedades = new SelectList(propriedades, "id", "nomepropriedade");
            return View(Construtor.UsuarioApp().EditarAnimal(id, usuario.ID));
        }
        [HttpPost]
        public ActionResult Detalhe(AnimalVM animal)
        {
            var propriedades = Construtor.UsuarioApp().MinhasPropriedades(usuario.ID);
            ViewBag.propriedades = new SelectList(propriedades, "id", "nomepropriedade");
            var animalModel = Construtor.UsuarioApp().EditarAnimal(animal.NumeroBrinco, usuario.ID);
            animal.PhotoPath = animalModel.PhotoPath;
            if (ModelState.IsValid && animalModel != null)
            {
                if (animal.Photo != null)
                {
                    animal.PhotoPath = UploadPhoto.UploadPhotos(animal.Photo, animal.Categoria, animalModel.PhotoPath);
                }
                animal.IdUsuario = usuario.ID;
                Construtor.AnimalApp().Update(animal);
                return RedirectToAction("MinhasCriacoes");
            }
            return View(animal);
        }
        public ActionResult RegistrarAnimal()
        {
            var propriedades = Construtor.UsuarioApp().MinhasPropriedades(usuario.ID);
            ViewBag.propriedades = new SelectList(propriedades, "id", "nomepropriedade");
            return View(new AnimalVM());
        }
        [HttpPost]
        public ActionResult RegistrarAnimal(AnimalVM animal)
        {
            if (ModelState.IsValid)
            {
                Construtor.AnimalApp().Save(animal, usuario.ID);
                return RedirectToAction("Index");
            }
            var propriedades = Construtor.UsuarioApp().MinhasPropriedades(usuario.ID);
            ViewBag.propriedades = new SelectList(propriedades, "id", "nomepropriedade");
            return View(animal);
        }
        public ActionResult RegistrarPropriedade()
        {
            return View(new PropriedadeViewModel());
        }
        [HttpPost]
        public ActionResult RegistrarPropriedade(PropriedadeViewModel propriedade)
        {
            if (ModelState.IsValid)
            {
                propriedade.UsuarioId = usuario.ID;
                Construtor.PropriedadeApp().Salvar(propriedade, usuario.ID);
                return RedirectToAction("Index");
            }

            return View(propriedade);
        }
        public ActionResult RegistrarFornecedor()
        {
            return View(new PessoaVM());
        }
        [HttpPost]
        public ActionResult RegistrarFornecedor(PessoaVM pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.IdUsuario = usuario.ID;
                Construtor.PessoaApp().Save(pessoa, usuario.ID);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }
        public ActionResult RegistrarVacina()
        {
            return View(new VacinaVM());
        }
        [HttpPost]
        public ActionResult RegistrarVacina(VacinaVM vacina)
        {
            if (ModelState.IsValid)
            {
                vacina.IdUsuario = usuario.ID;
                Construtor.VacinaApp().Save(vacina, usuario.ID);
                return RedirectToAction("EstoqueVacinas");
            }
            return View(vacina);
        }
        public ActionResult Relatorios()
        {
            return View();
        }
        public ActionResult EditarVacina(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("EstoqueVacinas");

            }
            var tempVacina = Construtor.VacinaApp().GetById(id, usuario.ID);
            if (tempVacina.IdUsuario == usuario.ID)
            {
                return View(tempVacina);
            }
            return RedirectToAction("EstoqueVacinas");
        }
        [HttpPost]
        public ActionResult EditarVacina(VacinaVM vacina)
        {
            if (ModelState.IsValid && vacina.IdUsuario == usuario.ID)
            {
                Construtor.VacinaApp().Update(vacina);
                return RedirectToAction("EstoqueVacinas");
            }
            return View(vacina);
        }
        public ActionResult EstoqueVacinas()
        {
            return View(Construtor.VacinaApp().GetAll(usuario.ID).ToList());
        }

        public ActionResult Fornecedores()
        {
            return View(Construtor.PessoaApp().GetAll(usuario.ID));
        }

        public ActionResult DetalheFornecedor(string id)
        {
            return View(Construtor.PessoaApp().GetById(id, usuario.ID));
        }
    }
}