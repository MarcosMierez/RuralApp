using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Repositorio;

namespace ControleRural.Aplicacao
{
    public class VacinaAplicacao
    {
        public readonly VacinaRepositorio repo;

        public VacinaAplicacao(VacinaRepositorio vrepo)
        {
            repo = vrepo;
        }

        public IEnumerable<VacinaVM> GetAll(string usuarioId)
        {
            return repo.GetAll(usuarioId);
        }

        public void Save(VacinaVM vacina, string id)
        {
            repo.Save(vacina,id);
        }

        public VacinaVM GetById(string Id,string usuarioId)
        {
            return repo.GetById(Id,usuarioId);
        }

        public void Update(VacinaVM vacina)
        {
            repo.Update(vacina);
        }
    }
}