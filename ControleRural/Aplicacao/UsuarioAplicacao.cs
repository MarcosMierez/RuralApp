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
            _contexto = new Contexto();
        }

        public bool LogarUsuario(string email, string senha)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
            {
                var tempUsuario =
               _contexto.SqlBd.Query<Usuario>("select nome,id,email,permissao from usuario where email = @e and senha = @s",
                   new { e = email, s = senha }).FirstOrDefault();
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

        public IEnumerable<AnimalVM> MinhasCriacoes(string usuarioId, string filtro, string busca, string filtroRefinado)
        {
            var animalVmList = new List<AnimalVM>();
            const string query = "select NumeroBrinco,NomeAnimal,Sexo,Raca,Aptidao,IdUsuario,PropriedadeId,Aquisicao from animal where IdUsuario = @id ";
            if (string.IsNullOrEmpty(filtro) && string.IsNullOrEmpty(busca) && string.IsNullOrEmpty(filtroRefinado))
            {
                 animalVmList = _contexto.SqlBd.Query<AnimalVM>(query + " order by Aquisicao desc",
                 new { id = usuarioId })
                 .ToList();
            }
            else if (!string.IsNullOrEmpty(busca) && !string.IsNullOrEmpty(filtroRefinado))

            {
                animalVmList = _contexto.SqlBd.Query<AnimalVM>(query +"and "+filtroRefinado+" = '"+busca+"'",
                    new {id = usuarioId,campo=filtroRefinado,seach=busca})
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(filtro))
            {
                animalVmList = _contexto.SqlBd.Query<AnimalVM>(query + " order by " + filtro,
                    new { id = usuarioId })
                    .ToList();
            }
            foreach (var animal in animalVmList)
            {
                animal.NomePropriedade = _contexto.SqlBd.Query<string>("select nomePropriedade from propriedade,animal where animal.PropriedadeId = @prop and propriedade.Id = @prop ",
                new { prop = animal.PropriedadeId }).FirstOrDefault();
            }
            return animalVmList;
        }

        public AnimalVM EditarAnimal(string brincoId, string usuarioId)
        {
            var animalBd = _contexto.SqlBd.Query<Animal>(
                "select NumeroBrinco,NomeAnimal,Sexo,Raca,Categoria,Aptidao,SisBov,SisBovPai,SisBovMae,DataNascimento,NirfNascimento,NirfAtual,Vacinas,Photo from animal where NumeroBrinco = @aId and IdUsuario = @uId",
                new { aId = brincoId, uId = usuarioId })
                .FirstOrDefault();
            return retornaVM(animalBd);
        }

        public IEnumerable<PropriedadeViewModel> MinhasPropriedades(string usuarioId)
        {
            return
                _contexto.SqlBd.Query<PropriedadeViewModel>(
                    "select id,nomePropriedade from propriedade where UsuarioId = @uId", new {uId = usuarioId}).ToList();
        }

        public void RegistrarAtividade(RegistroAnimal registro)
        {
            _contexto.SqlBd.Query(
                "insert into registroanimal (Id,IdAnimal,UsuarioId,Natureza,Data,Valor) values (@id,@a,@u,@n,@d,@v)",
                new
                {
                    id = registro.ID,
                    a = registro.IdAnimal,
                    u = registro.UsuarioId,
                    n = registro.Natureza,
                    d = registro.Data,
                    v = registro.Valor
                });

            var animalVm = new AnimalVM()
            {
                IdUsuario = registro.UsuarioId,
                NumeroBrinco = registro.IdAnimal,
                Aquisicao = registro.Data,
                Categoria = registro.Categoria
            };
            if (registro.Natureza=="Compra")
            {
                Construtor.AnimalApp().Save(animalVm,registro.UsuarioId);
            }
        } 
        static private List<string> carregaVacinas(string vacinas)
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
                Vacinas = carregaVacinas(animal.Vacinas),
                PhotoPath = animal.Photo
            };
        }

    }
}