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
            
        }
        public void Save(VacinaVM entidade, string id)
        {
            bd.SqlBd.Query("insert into vacina (Id,NumeroLote,DataCompra,TipoVacina,Vencimento,Quantidade,IdUsuario,Observacao) " +
                           "values (@id,@nL,@dC,@tV,@v,@Qtd,@uId,@obs)", new
                           {
                               id = entidade.Id,
                               nL = entidade.NumeroLote,
                               dC = entidade.DataCompra,
                               tV = entidade.TipoVacina,
                               v = entidade.Vencimento,
                               Qtd = entidade.Quantidade,
                               uId=entidade.IdUsuario,
                               obs=entidade.Observacao
                           });
        }
        public VacinaVM GetById(string id,string usuarioId)
        {
            return retornaVm(
                bd.SqlBd.Query<Vacina>(
                    "Select Id,NumeroLote,DataCompra,TipoVacina,Vencimento,Quantidade,IdUsuario,Observacao from vacina where id = @vId and IdUsuario = @uId",
                    new {vId = id,uId = usuarioId})
                    .FirstOrDefault());
        }
        public IEnumerable<VacinaVM> GetAll(string usuarioId)
        {
            var vacinaBD =
                bd.SqlBd.Query<Vacina>("Select Id,NumeroLote,DataCompra,TipoVacina,Vencimento,Quantidade from vacina where IdUsuario = @uId",new{uId=usuarioId})
                    .ToList();
            var vacinaVM = vacinaBD.Select(v => retornaVm(v)).ToList();
            return vacinaVM;
        }
        public void Update(VacinaVM entidade)
        {
            bd.SqlBd.Query(
                "update vacina set NumeroLote = @nl , DataCompra = @dc, TipoVacina = @tv, Vencimento = @v, Quantidade = @qtd , Observacao = @obs where Id = @id and IdUsuario = @uId",
                new
                {
                    id=entidade.Id,
                    nl = entidade.NumeroLote,
                    dc = entidade.DataCompra,
                    tv = entidade.TipoVacina,
                    v = entidade.Vencimento,
                    qtd = entidade.Quantidade,
                    uId=entidade.IdUsuario,
                    obs=entidade.Observacao
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
                Vencimento = vacina.Vencimento,
                IdUsuario = vacina.IdUsuario,
                Observacao = vacina.Observacao,
                
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
                Vencimento = vacina.Vencimento,
                IdUsuario = vacina.IdUsuario,
                Observacao = vacina.Observacao


            };
        }


        public IEnumerable<VacinaVM> GetAll()
        {
            throw new NotImplementedException();
        }


        public VacinaVM GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}