using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Models;
using Dapper;

namespace ControleRural.Repositorio
{
    public class UsuarioRepositorio:ICrud<Usuario>
    {
        private readonly Contexto _bd = new Contexto();
        public void Save(Usuario entidade)
        {
            _bd.SqlBd.Query(
                "insert into usuario (id,email,senha,nome,permissao) values(@id,@email,@senha,@nome,@permissao)", new
                {
                    id = entidade.ID,
                    email = entidade.Email,
                    senha = entidade.Senha,
                    nome = entidade.Nome,
                    permissao = "usuario"
                });
        }

        public Usuario GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entidade)
        {
            throw new NotImplementedException();
        }
    }
}