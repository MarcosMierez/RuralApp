using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Repositorio;

namespace ControleRural.Aplicacao
{
    public class PessoaAplicacao:ICrud<PessoaVM>
    {
        private readonly PessoaRepositorio pRepo;

        public PessoaAplicacao(PessoaRepositorio repo)
        {
            pRepo = repo;
        }

        public void Save(PessoaVM entidade)
        {
            pRepo.Save(entidade);
        }

        public PessoaVM GetById(string id)
        {
          return  pRepo.GetById(id);
        }

        public IEnumerable<PessoaVM> GetAll()
        {
            return pRepo.GetAll();
        }

        public void Update(PessoaVM entidade)
        {
            pRepo.Update(entidade);
        }
    }
}