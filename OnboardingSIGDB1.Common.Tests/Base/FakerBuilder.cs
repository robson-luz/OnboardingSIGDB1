using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Common.Tests.Base
{
    public class FakerBuilder
    {
        private static string _linguagem;

        public static FakerBuilder Novo()
        {
            _linguagem = "pt_BR";

            return new FakerBuilder();
        }

        public FakerBuilder ComLinguagem(string linguagem)
        {
            _linguagem = linguagem;

            return this;
             
        }

        public Faker Build()
        {
            return new Faker(_linguagem);
        }
    }
}
