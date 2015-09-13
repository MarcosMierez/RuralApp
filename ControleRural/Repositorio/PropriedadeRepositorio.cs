using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Models;
using Dapper;

namespace ControleRural.Repositorio
{
    public class PropriedadeRepositorio
    {
        private Contexto bd = new Contexto();
        public void Salvar(PropriedadeViewModel propriedade,string usuarioId)
        {
            var propModel = retornaPropriedade(propriedade);
            bd.SqlBd.Query(
                "insert into propriedade (id,nomepropriedade,endereco,numero,complemento,bairro,cidade,cep,telefone,fax,responsavel,aquisicao,UsuarioId) " +
                "values (@id,@nome,@endereco,@numero,@complemento,@bairro,@cidade,@cep,@telefone,@fax,@responsavel,@aquisicao,@uId)",
                new
                {
                    id = propModel.Id,
                    nome = propModel.NomePropriedade,
                    endereco = propModel.Endereco,
                    numero = propModel.Numero,
                    complemento = propModel.Complemento,
                    bairro = propModel.Bairro,
                    cidade = propModel.Cidade,
                    cep = propModel.Cep,
                    telefone = propModel.Telefone,
                    fax = propModel.Fax,
                    responsavel = propModel.Responsavel,
                    aquisicao = propModel.Aquisicao,
                    uId=usuarioId

                });
        }

        public PropriedadeViewModel ListarId(string id)
        {
           return retornaPropriedadeViewModel(bd.SqlBd.Query<Propriedade>(
                "select id,nomepropriedade,endereco,numero,complemento,bairro,cidade,cep,telefone,fax,responsavel,aquisicao from propriedade where Id = @idPropriedade", new { idPropriedade=id})
                .FirstOrDefault());
        }

        public void Editar(PropriedadeViewModel propriedade)
        {
            var prop = retornaPropriedade(propriedade);
            bd.SqlBd.Query("update propriedade set nomepropriedade = @prop , " +
                           " endereco = @end, " +
                           " numero = @num , " +
                           "complemento = @com, " +
                           "bairro = @bar, " +
                           "cidade = @cid," +
                           " cep = @cep," +
                           " telefone = @tel," +
                           " fax = @fax, " +
                           "responsavel = @res," +
                           " aquisicao = @aqui where id = @propId",
                new
                {
                    propId = prop.Id,
                    prop = prop.NomePropriedade,
                    end = prop.Endereco,
                    num = prop.Numero,
                    com = prop.Complemento,
                    bar = prop.Bairro,
                    cid = prop.Cidade,
                    cep = prop.Cep,
                    tel = prop.Telefone,
                    fax = prop.Fax,
                    res = prop.Responsavel,
                    aqui = prop.Aquisicao
                });
        }

        public IEnumerable<PropriedadeViewModel> ListarTodos()
        {
            var propriedadeBd = bd.SqlBd.Query<Propriedade>(
                "select id,nomepropriedade,endereco,numero,complemento,bairro,cidade,cep,telefone,fax,responsavel,aquisicao from propriedade")
                .ToList();
            var propriedadeVM = new List<PropriedadeViewModel>();
            foreach (var prop in propriedadeBd)
            {
               propriedadeVM.Add(retornaPropriedadeViewModel(prop));
            }
            return propriedadeVM;
        } 

        private Propriedade retornaPropriedade(PropriedadeViewModel propriedade)
        {
            return new Propriedade()
            {
                Id = propriedade.Id,
                Aquisicao = propriedade.Aquisicao,
                Bairro = propriedade.Bairro,
                Cep = propriedade.Cep,
                Cidade = propriedade.Cidade,
                Complemento = propriedade.Complemento,
                Endereco = propriedade.Endereco,
                Fax = propriedade.Fax,
                NomePropriedade = propriedade.NomePropriedade,
                Numero = propriedade.Numero,
                Responsavel = propriedade.Responsavel,
                Telefone = propriedade.Telefone,
                UsuarioId = propriedade.UsuarioId
            };
        }
        private PropriedadeViewModel retornaPropriedadeViewModel(Propriedade propriedade)
        {
            return new PropriedadeViewModel()
            {
                Id = propriedade.Id,
                Aquisicao = propriedade.Aquisicao,
                Bairro = propriedade.Bairro,
                Cep = propriedade.Cep,
                Cidade = propriedade.Cidade,
                Complemento = propriedade.Complemento,
                Endereco = propriedade.Endereco,
                Fax = propriedade.Fax,
                NomePropriedade = propriedade.NomePropriedade,
                Numero = propriedade.Numero,
                Responsavel = propriedade.Responsavel,
                Telefone = propriedade.Telefone,
                UsuarioId = propriedade.UsuarioId
            };
        }
    }
}