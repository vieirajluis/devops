using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreEFCore
{
    public class SampleData
    {
        internal static async Task InitializeMyContexts(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                Console.WriteLine("Ensuring database has been created...");
                
                var db = serviceScope.ServiceProvider.GetService<TestContext>();
                await db.Database.OpenConnectionAsync();
                if (!db.Database.EnsureCreated())
                {
                    Console.WriteLine("There may be another table in this database already, attempting to create with a workaround");
                    RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)db.Database.GetService<IDatabaseCreator>();
                    databaseCreator.CreateTables();
                }
            }
            await InitializeContext(serviceProvider);
        }

        private static async Task InitializeContext(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<TestContext>();
                await db.Database.OpenConnectionAsync();
                if (db.TestData.Any())
                {
                    return;
                }

                AddData<TestData>(db, new TestData() { Id = 1, Data = "Test Data 1 - EF Core TestContext" });
                AddData<TestData>(db, new TestData() { Id = 2, Data = "Test Data 2 - EF Core TestContext" });
                db.SaveChanges();
            }
        }

        private static void AddData<TData>(DbContext db, object item) where TData: class
        {
            db.Entry(item).State = EntityState.Added;
        }
    }
}
