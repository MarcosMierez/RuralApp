using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Models;
using Dapper;

namespace ControleRural.Repositorio
{
    public class VacinaRepositorio:ICrud<VacinaVM>
    {
        private readonly Contexto bd = new Contexto();
        public void Save(VacinaVM entidade)
        {
            bd.SqlBd.Query("insert into vacina (Id,NumeroLote,DataCompra,TipoVacina,Vencimento,Quantidade) " +
                           "values (@id,@nL,@dC,@tV,@v,@Qtd)", new
                           {
                               id = entidade.Id,
                               nL = entidade.NumeroLote,
                               dC = entidade.DataCompra,
                               tV = entidade.TipoVacina,
                               v = entidade.Vencimento,
                               Qtd = entidade.Quantidade
                           });
        }

        public VacinaVM GetById(string id)
        {
            return retornaVm(
                bd.SqlBd.Query<Vacina>(
                    "Select Id,NumeroLote,DataCompra,TipoVacina,Vencimento,Quantidade from vacina where id = @vId",
                    new {vId = id})
                    .FirstOrDefault());
        }

        public IEnumerable<VacinaVM> GetAll()
        {
            var vacinaBD =
                bd.SqlBd.Query<Vacina>("Select Id,NumeroLote,DataCompra,TipoVacina,Vencimento,Quantidade from vacina")
                    .ToList();
            var vacinaVM = vacinaBD.Select(v => retornaVm(v)).ToList();
            return vacinaVM;
        }

        public void Update(VacinaVM entidade)
        {
            bd.SqlBd.Query(
                "update vacina set NumeroLote = @nl , DataCompra = @dc, TipoVacina = @tv, Vencimento = @v, Quantidade = @qtd  where Id = @id",
                new
                {
                    id=entidade.Id,
                    nl = entidade.NumeroLote,
                    dc = entidade.DataCompra,
                    tv = entidade.TipoVacina,
                    v = entidade.Vencimento,
                    qtd = entidade.Quantidade
                });
        }

        private VacinaVM retornaVm(Vacina vacina)
        {
            return new VacinaVM()
            {
                Id = vacina.Id,
                DataCompra = vacina.DataCompra,
                NumeroLote = vacina.NumeroLote,
                Quantidade = vacina.Quantidade,
                TipoVacina = vacina.TipoVacina,
                Vencimento = vacina.Vencimento
            };
        }
        private Vacina retornaMd(VacinaVM vacina)
        {
            return new Vacina()
            {
                Id = vacina.Id,
                DataCompra = vacina.DataCompra,
                NumeroLote = vacina.NumeroLote,
                Quantidade = vacina.Quantidade,
                TipoVacina = vacina.TipoVacina,
                Vencimento = vacina.Vencimento
            };
        }
    }
}