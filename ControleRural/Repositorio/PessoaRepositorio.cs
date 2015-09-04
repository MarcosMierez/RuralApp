using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Models;
using Dapper;

namespace ControleRural.Repositorio
{
    public class PessoaRepositorio:ICrud<PessoaVM>
    {
        private Contexto bd=new Contexto();
        public void Save(PessoaVM entidade)
        {
            var md = retornaMd(entidade);
            bd.SqlBd.Query(
                "insert into pessoa (id,nome,apelido,pessoajf,cpf,cnpj,endereco,numero,bairro,cep,cidade,inscestadual,telefone,fax,email) " +
                "values(@id,@nome,@apelido,@pjf,@cpf,@cnpj,@end,@num,@bai,@cep,@cid,@ins,@tel,@fax,@email)",
                new
                {
                    id = md.Id,
                    nome = md.Nome,
                    apelido = md.Apelido,
                    pjf = md.PessoaJf,
                    cpf = md.Cpf,
                    cnpj = md.Cnpj,
                    end = md.Endereco,
                    num = md.Numero,
                    bai = md.Bairro,
                    cep = md.Cep,
                    cid = md.Cidade,
                    ins = md.InscEstadual,
                    tel = md.Telefone,
                    fax = md.Fax,
                    email = md.Email
                });
        }
        public void Save(PessoaVM entidade,string id)
        {
           var md = retornaMd(entidade);
            bd.SqlBd.Query(
                "insert into pessoa (id,nome,apelido,pessoajf,cpf,cnpj,endereco,numero,bairro,cep,cidade,inscestadual,telefone,fax,email,UsuarioId) " +
                "values(@id,@nome,@apelido,@pjf,@cpf,@cnpj,@end,@num,@bai,@cep,@cid,@ins,@tel,@fax,@email,@uId)",
                new
                {
                    id = md.Id,
                    nome = md.Nome,
                    apelido = md.Apelido,
                    pjf = md.PessoaJf,
                    cpf = md.Cpf,
                    cnpj = md.Cnpj,
                    end = md.Endereco,
                    num = md.Numero,
                    bai = md.Bairro,
                    cep = md.Cep,
                    cid = md.Cidade,
                    ins = md.InscEstadual,
                    tel = md.Telefone,
                    fax = md.Fax,
                    email = md.Email,
                    uId = id
                });
        }

        public PessoaVM GetById(string id)
        {
            return
                retornaVm(
                    bd.SqlBd.Query<Pessoa>(
                        "select id,apelido,pessoajf,cpf,cnpj,nome,numero,endereco,bairro,cep,cidade,inscestadual,telefone,fax,email from pessoa where id = @idP",
                        new {idP = id}).FirstOrDefault());
        }

        public IEnumerable<PessoaVM> GetAll()
        {
         var pessoaBd=bd.SqlBd.Query<Pessoa>(
                "select id,apelido,pessoajf,cpf,cnpj,nome,numero,endereco,bairro,cep,cidade,inscestadual,telefone,fax,email from pessoa")
                .ToList();
            var pessoasVM = new List<PessoaVM>();
            foreach (var p  in pessoaBd)
            {
                pessoasVM.Add(retornaVm(p));
            }
            return pessoasVM;
        }

        public void Update(PessoaVM entidade)
        {
            bd.SqlBd.Query("update pessoa set apelido = @ap," +
                           " pessoajf = @pjf," +
                           " cpf = @cpf," +
                           " cnpj = @cnpj," +
                           " nome = @nome," +
                           " endereco = @end," +
                           " numero = @num," +
                           " bairro = @bai," +
                           " cep = @cep," +
                           " cidade = @cid," +
                           " inscestadual = @insc ," +
                           " telefone = @tel," +
                           " email = @email," +
                           " fax = @fax where id = @Uid", new
                           {
                               Uid=entidade.Id,
                               ap = entidade.Apelido,
                               pjf = entidade.PessoaJf,
                               cpf = entidade.Cpf,
                               cnpj = entidade.Cnpj,
                               nome = entidade.Nome,
                               end = entidade.Endereco,
                               num = entidade.Numero,
                               bai = entidade.Bairro,
                               cep = entidade.Cep,
                               cid = entidade.Cidade,
                               insc = entidade.InscEstadual,
                               tel = entidade.Telefone,
                               email = entidade.Email,
                               fax = entidade.Fax
                           });
        }

        private PessoaVM retornaVm(Pessoa pessoa)
        {
          return  new PessoaVM()
            {
                Nome = pessoa.Nome,
                Apelido = pessoa.Apelido,
                Bairro = pessoa.Bairro,
                Cep = pessoa.Cep,
                Cidade = pessoa.Cidade,
                Cnpj = pessoa.Cnpj,
                Cpf = pessoa.Cpf,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Fax = pessoa.Fax,
                PessoaJf = pessoa.PessoaJf,
                Id = pessoa.Id,
                InscEstadual = pessoa.InscEstadual,
                Numero = pessoa.Numero,
                Telefone = pessoa.Telefone,
                IdUsuario = pessoa.IdUsuario
            };
        }
        private Pessoa retornaMd(PessoaVM pessoa)
        {
            return new Pessoa()
            {
                Nome = pessoa.Nome,
                Apelido = pessoa.Apelido,
                Bairro = pessoa.Bairro,
                Cep = pessoa.Cep,
                Cidade = pessoa.Cidade,
                Cnpj = pessoa.Cnpj,
                Cpf = pessoa.Cpf,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Fax = pessoa.Fax,
                PessoaJf = pessoa.PessoaJf,
                Id = pessoa.Id,
                InscEstadual = pessoa.InscEstadual,
                Numero = pessoa.Numero,
                Telefone = pessoa.Telefone,
                IdUsuario = pessoa.IdUsuario
            };
        }
    }
}