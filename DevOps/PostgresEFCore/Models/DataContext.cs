using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresEFCore
{
  
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<TestData> TestData { get; set; }
        }

        [Table("EFCoreTestData")]
        public class TestData
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }

            public string Data { get; set; }
        }
    
}
