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

    public async Task Adicionar(Cliente cliente)
    {
        if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

        await _clienteRepository.Adicionar(cliente);
    }

    public async Task Atualizar(Cliente cliente)
    {
        if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;
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
