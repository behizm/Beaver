using System.Data.Entity;

namespace Beaver.Service.Data
{
    internal class BeaverContextInitializer : CreateDatabaseIfNotExists<BeaverContext>
    {
        protected override void Seed(BeaverContext context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }
}
