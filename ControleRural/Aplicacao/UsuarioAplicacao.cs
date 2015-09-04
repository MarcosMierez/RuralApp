using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Helpers;
using ControleRural.Models;
using ControleRural.Repositorio;
using Dapper;

namespace ControleRural.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly UsuarioRepositorio _uRepositorio;
        private readonly Contexto _contexto;
        public UsuarioAplicacao(UsuarioRepositorio ur)
        {
            _uRepositorio = ur;
            _contexto=new Contexto();
        }

        public bool LogarUsuario(string email, string senha)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
            {
                 var tempUsuario =
                _contexto.SqlBd.Query<Usuario>("select nome,id,email,permissao from usuario where email = @e and senha = @s",
                    new {e = email, s = senha}).FirstOrDefault();
                if (tempUsuario != null && !string.IsNullOrEmpty(tempUsuario.Email))
                {
                    Seguranca.GerearSessaoDeUsuario(tempUsuario);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Save(Usuario usuario)
        {
            _uRepositorio.Save(usuario);
        }

        public IEnumerable<AnimalVM> MinhasCriacoes(string usuarioId)
        {
           return _contexto.SqlBd.Query<AnimalVM>(
                "select NumeroBrinco,NomeAnimal,Sexo,Raca,Aptidao,IdUsuario from animal where IdUsuario = @id",
                new {id = usuarioId})
                .ToList();
        }

        public AnimalVM EditarAnimal(string brincoId,string usuarioId)
        {
            var animalBd = _contexto.SqlBd.Query<Animal>(
                "select NumeroBrinco,NomeAnimal,Sexo,Raca,Categoria,Aptidao,SisBov,SisBovPai,SisBovMae,DataNascimento,NirfNascimento,NirfAtual,Vacinas from animal where NumeroBrinco = @aId and IdUsuario = @uId",
                new {aId = brincoId, uId = usuarioId})
                .FirstOrDefault();
            return retornaVM(animalBd);
        }

      static  private List<string> carregaVacinas(string vacinas)
        {
            return string.IsNullOrEmpty(vacinas) ? new List<string>() : vacinas.Split(',').ToList();
        }

        private AnimalVM retornaVM(Animal animal)
        {
            return new AnimalVM()
            {
                Aptidao = animal.Aptidao,
                Categoria = animal.Categoria,
                DataNascimento = animal.DataNascimento,
                NirfAtual = animal.NirfAtual,
                NirfNascimento = animal.NirfNascimento,
                NomeAnimal = animal.NomeAnimal,
                NumeroBrinco = animal.NumeroBrinco,
                Raca = animal.Raca,
                Sexo = animal.Sexo,
                SisBov = animal.SisBov,
                SisBovMae = animal.SisBovMae,
                SisBovPai = animal.SisBovPai,
                IdUsuario = animal.IdUsuario,
                Vacinas = carregaVacinas(animal.Vacinas)
            };
        }

    }
}