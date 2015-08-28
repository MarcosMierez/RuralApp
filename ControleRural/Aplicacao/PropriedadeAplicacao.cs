using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Repositorio;

namespace ControleRural.Aplicacao
{
  
    public class PropriedadeAplicacao
    {
        private readonly PropriedadeRepositorio pRepo;

        public PropriedadeAplicacao(PropriedadeRepositorio rp)
        {
            pRepo = rp;
        }

        public IEnumerable<PropriedadeViewModel> ListarTodos()
        {
            return pRepo.ListarTodos();
        } 
        public void Salvar(PropriedadeViewModel propriedade)
        {
            pRepo.Salvar(propriedade);
        }

        public PropriedadeViewModel ListarId(string id)
        {
            return pRepo.ListarId(id);
        }

        public void Editar(PropriedadeViewModel propriedade)
        {
            pRepo.Editar(propriedade);
        }
    }
}