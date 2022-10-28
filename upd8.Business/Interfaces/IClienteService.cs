﻿using upd8.Business.Models;

namespace upd8.Business.Interfaces;

public interface IClienteService : IDisposable
{
    Task Adicionar(Cliente cliente);
    Task Atualizar(Cliente cliente);
    Task Remover(Guid id);
}
