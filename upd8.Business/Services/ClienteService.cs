using upd8.Business.Interfaces;
using upd8.Business.Models;
using upd8.Business.Models.Validations;

namespace upd8.Business.Services;

public class ClienteService : BaseService, IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteService(IClienteRepository clienteRepository,
        INotificador notificador) : base(notificador)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> Adicionar(Cliente cliente)
    {
        if (_clienteRepository.Buscar(c => c.Cpf == cliente.Cpf).Result.Any())
        {
            Notificar("CPF já Existente.");
            return false;
        }
            
        await _clienteRepository.Adicionar(cliente);
        return true;
    }

    public async Task Atualizar(Cliente cliente)
    {
        await _clienteRepository.Atualizar(cliente);
    }

    public void Dispose()
    {
        _clienteRepository?.Dispose();
    }

    public async Task Remover(Guid id)
    {
        await _clienteRepository.Remover(id);
    }
}
