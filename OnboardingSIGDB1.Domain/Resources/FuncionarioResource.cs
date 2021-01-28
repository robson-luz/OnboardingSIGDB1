using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Resources
{
    public static class FuncionarioResource
    {
        public const string CampoDescricaoObrigatorio = "Campo 'Descrição' é obrigatório";
        public const string CampoDescricaoDeveTerMenosQue250 = "Campo 'Descrição' deve ter menos que 250 caracteres.";

        public const string CargoNaoCadastrado = "Cargo a ser vinculado não está cadastrado.";
        public const string FuncionarioSemEmpresa = "Não é possível vincular um cargo a um funcionário sem empresa.";
        public const string FuncionarioJaPossuiCargo = "Funcionário já possui o cargo a ser vinculado.";

        public const string EmpresaNaoCadastrada = "Empresa a ser vinculada não está cadastrada.";
        public const string NPossivelAlterarVinculoJaPossuiEmpresa = "Não é possível alterar o vínculo de um funcionário que já está em uma empresa.";
    }
}
