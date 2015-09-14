using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Repositorio;

namespace ControleRural.Aplicacao
{
    public class PessoaAplicacao
    {
        private readonly PessoaRepositorio pRepo;

        public PessoaAplicacao(PessoaRepositorio repo)
        {
            pRepo = repo;
        }

        public void Save(PessoaVM entidade,string id)
        {
            pRepo.Save(entidade,id);
        }

        public PessoaVM GetById(string id,string usuarioId)
        {
          return  pRepo.GetById(id,usuarioId);
        }

        public IEnumerable<PessoaVM> GetAll(string usuarioId)
        {
            return pRepo.GetAll(usuarioId);
        }

        public void Update(PessoaVM entidade)
        {
            pRepo.Update(entidade);
        }
    }
}