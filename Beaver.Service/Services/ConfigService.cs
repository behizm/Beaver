using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class ConfigService : BaseService<Config>, IConfigService
    {
        public ConfigService(BeaverContext context) : base(context)
        {
        }

        public IConfigService Clone()
        {
            return new ConfigService(new BeaverContext());
        }
    }
}