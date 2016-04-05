using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class CostService : BaseService<Cost>, ICostService
    {
        public CostService(BeaverContext context) : base(context)
        {
        }

        public ICostService Clone()
        {
            return new CostService(new BeaverContext());
        }
    }
}