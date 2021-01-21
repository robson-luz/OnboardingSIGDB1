﻿using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities.Empresas;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services
{
    public class ArmazenadorDeEmpresa
    {
        private readonly IEmpresaRepository _empresaRepository;

        public ArmazenadorDeEmpresa(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public void Armazenar(EmpresaDto dto)
        {
            var empresaExistente = _empresaRepository.ObterPorCnpj(dto.Cnpj);

            //lembrar de colocar validações

            if (dto.Id == 0)
            {
                Empresa empresa = new Empresa(dto.Nome, dto.Cnpj, dto.DataFundacao.Value);

                _empresaRepository.Adicionar(empresa);
            }
            else
            {
                Empresa empresa = _empresaRepository.ObterPorId(dto.Id);

                empresa.AlterarNome(dto.Nome);
                empresa.AlterarCnpj(dto.Cnpj);
                empresa.AlterarDataFundacao(dto.DataFundacao.Value);

                _empresaRepository.Atualizar(empresa);
            }
        }

        public void Remover(int id)
        {
            Empresa empresa = _empresaRepository.ObterPorId(id);

            //lembrar de colocar validações

            if(empresa != null)
                _empresaRepository.Remover(empresa);
        }
    }
}
