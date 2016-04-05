using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class AccountingService : BaseService<Accounting>, IAccountingService
    {
        public AccountingService(BeaverContext context) : base(context)
        {
        }

        public IAccountingService Clone()
        {
            return new AccountingService(new BeaverContext());
        }
    }
}