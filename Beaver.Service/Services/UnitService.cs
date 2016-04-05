using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class UnitService : BaseService<Unit>, IUnitService
    {
        public UnitService(BeaverContext context) : base(context)
        {
        }

        public IUnitService Clone()
        {
            return new UnitService(new BeaverContext());
        }
    }
}