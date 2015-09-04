using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControleRural.Repositorio;

namespace ControleRural.Aplicacao
{
    public class Construtor
    {
        public static PropriedadeAplicacao PropriedadeApp()
        {
            return new PropriedadeAplicacao(new PropriedadeRepositorio());
        }
        public static PessoaAplicacao PessoaApp()
        {
            return new PessoaAplicacao(new PessoaRepositorio());
        }

        public static AnimalAplicacao AnimalApp()
        {
            return new AnimalAplicacao(new AnimalRepositorio());
        }

        public static VacinaAplicacao VacinaApp()
        {
            return new VacinaAplicacao(new VacinaRepositorio());
        }

        public static UsuarioAplicacao UsuarioApp()
        {
            return new UsuarioAplicacao(new UsuarioRepositorio());
        }
    }
}