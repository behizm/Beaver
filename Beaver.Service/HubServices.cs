using System;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using Beaver.Service.Data;
using Beaver.Service.Interfaces;
using Beaver.Service.Models.ResultModels;
using Beaver.Service.Resources;
using Beaver.Service.Services;

namespace Beaver.Service
{
    public static class HubServices
    {
        private static readonly BeaverContext Context;

        static HubServices()
        {
            Context = new BeaverContext();
        }

        public static OperationResult SaveChanges()
        {
            try
            {
                Context.SaveChanges();
                return OperationResult.Success;
            }
            catch (DbEntityValidationException exception)
            {
                return OperationResult.Failed(exception, ErrorMessages.Services_General_InvalidData);
            }
            catch (Exception exception)
            {
                return OperationResult.Failed(exception, ErrorMessages.Services_General_OperationError);
            }
        }
        public static async Task<OperationResult> SaveChangesAsync()
        {
            var operationResult = OperationResult.Success;
            var task = Task.Run(() =>
            {
                try
                {
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    operationResult = OperationResult.Failed(exception.Message, ErrorMessages.Services_General_InvalidData);
                }
                catch (Exception exception)
                {
                    operationResult = OperationResult.Failed(exception.Message, ErrorMessages.Services_General_OperationError);
                }
            });
            await task;
            return operationResult;
        }

        public static IAccountingService Accounting { get; } = new AccountingService(Context);
        public static IApartmentService Apartment { get; } = new ApartmentService(Context);
        public static IConfigService Config { get; } = new ConfigService(Context);
        public static IConnectionService Connection { get; } = new ConnectionService(Context);
        public static IContactUsService ContactUs { get; } = new ContactUsService(Context);
        public static ICostService Cost { get; } = new CostService(Context);
        public static INoticeService Notice { get; } = new NoticeService(Context);
        public static IUnitService Unit { get; } = new UnitService(Context);
    }
}
