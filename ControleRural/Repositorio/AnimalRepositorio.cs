﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Areas.Cadastramento.Models;
using ControleRural.Models;
using Dapper;

namespace ControleRural.Repositorio
{
    public class AnimalRepositorio : ICrud<AnimalVM>
    {
        private readonly Contexto bd = new Contexto();
        public void Save(AnimalVM entidade)
        {
            var animalMd = retornaMd(entidade);
            bd.SqlBd.Query(
                "insert into animal (NumeroBrinco,NomeAnimal,Sexo,Raca,Categoria,Aptidao,SisBov,SisBovPai,SisBovMae,DataNascimento,NirfNascimento,NirfAtual) " +
                "values(@id,@nome,@sx,@raca,@ct,@ap,@sb,@sbP,@sbM,@dN,@nN,@nA)", new
                {
                    id = animalMd.NumeroBrinco,
                    nome = animalMd.NomeAnimal,
                    sx = animalMd.Sexo,
                    raca = animalMd.Raca,
                    ct = animalMd.Categoria,
                    ap = animalMd.Aptidao,
                    sb = animalMd.SisBov,
                    sbP = animalMd.SisBovPai,
                    sbM = animalMd.SisBovMae,
                    dN = animalMd.DataNascimento,
                    nN = animalMd.NirfNascimento,
                    nA = animalMd.NirfAtual
                });
        }
        public void Save(AnimalVM entidade, string IdUsuario)
        {
            var animalMd = retornaMd(entidade);
            bd.SqlBd.Query(
                "insert into animal (NumeroBrinco,NomeAnimal,Sexo,Raca,Categoria,Aptidao,SisBov,SisBovPai,SisBovMae,DataNascimento,NirfNascimento,NirfAtual,IdUsuario,Vacinas,PropriedadeId,Aquisicao) " +
                "values(@id,@nome,@sx,@raca,@ct,@ap,@sb,@sbP,@sbM,@dN,@nN,@nA,@uId,@vac,@prop,@aqui)", new
                {
                    id = animalMd.NumeroBrinco,
                    nome = animalMd.NomeAnimal,
                    sx = animalMd.Sexo,
                    raca = animalMd.Raca,
                    ct = animalMd.Categoria,
                    ap = animalMd.Aptidao,
                    sb = animalMd.SisBov,
                    sbP = animalMd.SisBovPai,
                    sbM = animalMd.SisBovMae,
                    dN = animalMd.DataNascimento,
                    nN = animalMd.NirfNascimento,
                    nA = animalMd.NirfAtual,
                    uId = IdUsuario,
                    vac = "vacinas",
                    prop = animalMd.PropriedadeId,
                    aqui = animalMd.Aquisicao

                });
        }
        public AnimalVM GetById(string id)
        {
            var animalVM = retornaVM(bd.SqlBd.Query<Animal>(
                "select NumeroBrinco,NomeAnimal,Sexo,Raca,Categoria,Aptidao,SisBov,SisBovPai,SisBovMae,DataNascimento,NirfNascimento,NirfAtual,PropriedadeId from animal where NumeroBrinco = @aId", new { aId = id })
                .FirstOrDefault());
            animalVM.NomePropriedade = bd.SqlBd.Query<string>("select nomePropriedade from propriedade,animal where animal.PropriedadeId = @prop and propriedade.Id = @prop ",
                new { prop = animalVM.PropriedadeId }).FirstOrDefault();
            return animalVM;
        }

        public IEnumerable<AnimalVM> GetAll()
        {
            var animalBd = bd.SqlBd.Query<Animal>(
                  "select NumeroBrinco,NomeAnimal,Sexo,Raca,Categoria,Aptidao,SisBov,SisBovPai,SisBovMae,DataNascimento,NirfNascimento,NirfAtual from animal")
                  .ToList();
            var animalVM = new List<AnimalVM>();
            foreach (var a in animalBd)
            {
                animalVM.Add(retornaVM(a));
            }
            return animalVM;
        }

        public void Update(AnimalVM entidade)
        {
            var animal = retornaMd(entidade);
            bd.SqlBd.Query("update animal set NumeroBrinco = @nB, " +
                           "NomeAnimal = @nA ," +
                           "Sexo = @sx ," +
                           "Raca = @raca ," +
                           "Categoria = @ct, " +
                           "Aptidao = @ap ," +
                           "SisBov = @sB , " +
                           "SisBovPai = @sP, " +
                           "SisBovMae = @sM ," +
                           "DataNascimento = @dN ," +
                           "NirfNascimento = @nN , " +
                           "NirfAtual = @nfA, " +
                           "Vacinas  = @vac , " +
                           "PropriedadeId = @prop ," +
                           "Photo = @pt   where NumeroBrinco = @nB and IdUsuario = @id ",
                new
                {
                    nB = animal.NumeroBrinco,
                    nA = animal.NomeAnimal,
                    sx = animal.Sexo,
                    raca = animal.Raca,
                    ct = animal.Categoria,
                    ap = animal.Aptidao,
                    sB = animal.SisBov,
                    sP = animal.SisBovPai,
                    sM = animal.SisBovMae,
                    dN = animal.DataNascimento,
                    nN = animal.NirfNascimento,
                    nfA = animal.NirfAtual,
                    id = animal.IdUsuario,
                    vac = animal.Vacinas,
                    prop = animal.PropriedadeId,
                    pt = animal.Photo
                });
        }
        private static string carregaVacinas(List<string> vacinas)
        {
            if (!vacinas.Any())
            {
                return "";
            }
            var tempPermissao = "";
            foreach (var permissao in vacinas)
            {
                tempPermissao += permissao + ",";
            }
            return tempPermissao.Remove(tempPermissao.Length - 1);
        }
        private Animal retornaMd(AnimalVM animal)
        {
            return new Animal()
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
                Photo = animal.PhotoPath,
                PropriedadeId = animal.PropriedadeId,
                Aquisicao = animal.Aquisicao
            };
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
                  PhotoPath = animal.Photo,
                  PropriedadeId = animal.PropriedadeId,
                  Aquisicao = animal.Aquisicao


              };
        }
    }
}