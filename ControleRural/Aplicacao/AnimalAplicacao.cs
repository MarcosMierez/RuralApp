using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Repositorio;

namespace ControleRural.Aplicacao
{
    public class AnimalAplicacao
    {
        private readonly AnimalRepositorio repo;

        public AnimalAplicacao(AnimalRepositorio animal)
        {
            repo = animal;
        }

        public IEnumerable<AnimalVM> GetAll()
        {
            return repo.GetAll();
        }

        public AnimalVM GetById(string id)
        {
            return repo.GetById(id);
        }

        public void Save(AnimalVM animal)
        {
            repo.Save(animal);
        }

        public void Update(AnimalVM animal)
        {
            repo.Update(animal);
        }
    }
}