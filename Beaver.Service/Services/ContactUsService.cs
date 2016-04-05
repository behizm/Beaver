using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class ContactUsService : BaseService<ContactUs>, IContactUsService
    {
        public ContactUsService(BeaverContext context) : base(context)
        {
        }

        public IContactUsService Clone()
        {
            return new ContactUsService(new BeaverContext());
        }
    }
}