﻿using CA.Core.Domain;
using CA.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Manager.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteManager(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente?> GetClienteAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
        }
    }
}