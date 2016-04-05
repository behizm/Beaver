using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class ConnectionService : BaseService<Connection>, IConnectionService
    {
        public ConnectionService(BeaverContext context) : base(context)
        {
        }

        public IConnectionService Clone()
        {
            return new ConnectionService(new BeaverContext());
        }
    }
}