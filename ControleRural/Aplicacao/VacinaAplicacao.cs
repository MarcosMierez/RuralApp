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

        public IEnumerable<VacinaVM> GetAll()
        {
            return repo.GetAll();
        }

        public void Save(VacinaVM vacina)
        {
            repo.Save(vacina);
        }

        public VacinaVM GetById(string Id)
        {
            return repo.GetById(Id);
        }

        public void Update(VacinaVM vacina)
        {
            repo.Update(vacina);
        }
    }
}