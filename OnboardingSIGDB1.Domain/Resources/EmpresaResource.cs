using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Resources
{
    public static class EmpresaResource
    {
        public const string CampoNomeObrigatorio = "Campo 'Nome' é obrigatório.";
        public const string CampoNomeDeveTerMenosQue150 = "Campo 'Nome' deve ter menos que 150 caracteres.";
        public const string CampoCnpjObrigatorio = "Campo'Cnpj' é obrigatório.";
        public const string CampoCnpjForaDoTamanhoPadrao = "Campo'Cpnj' está fora do tamanho padrão.";
        public const string CampoDataFundacaoInvalido = "Campo 'Data Fundação' inválido.";
    }
}
