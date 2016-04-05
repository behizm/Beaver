using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class ApartmentService : BaseService<Apartment>, IApartmentService
    {
        public ApartmentService(BeaverContext context) : base(context)
        {
        }

        public IApartmentService Clone()
        {
            return new ApartmentService(new BeaverContext());
        }
    }
}