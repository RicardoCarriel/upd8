using upd8.Business.Models;

namespace upd8.Business.Interfaces;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<Cliente> ObterClienteId(Guid id);
}
