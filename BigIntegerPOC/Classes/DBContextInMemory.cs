using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigIntegerPOC.Classes
{
  public class DBContextInMemory : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseInMemoryDatabase(databaseName: "RepositoryDb");
    }
    public DbSet<BigIntegerItem> BigIntegerItems { get; set; }
  }

  public class BigIntegerItem
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ItemKey { get; set; } //64 bit int auto increment primary key
    public string ItemValue { get; set; } //string representation of the Big Integer
  }
}
