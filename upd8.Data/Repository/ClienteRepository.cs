using Microsoft.EntityFrameworkCore;
using upd8.Business.Interfaces;
using upd8.Business.Models;
using upd8.Data.context;

namespace upd8.Data.Repository;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(Upd8DbContext context) : base(context)
    {
    }

    public async Task<Cliente> ObterClienteId(Guid id)
    {
        return await Db.Clientes.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
