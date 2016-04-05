using Beaver.Service.Data;
using Beaver.Service.Data.Entities;
using Beaver.Service.Interfaces;

namespace Beaver.Service.Services
{
    internal class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(BeaverContext context) : base(context)
        {
        }

        public INoticeService Clone()
        {
            return new NoticeService(new BeaverContext());
        }
    }
}