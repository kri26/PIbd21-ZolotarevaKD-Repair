using RepairDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace RepairDatabaseImplement
{
    public class RepairDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IMFQ926R\SQLEXPRESS;Initial Catalog=RepairDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Material> Materials { set; get; }
        public virtual DbSet<RepairWork> RepairWorks { set; get; }
        public virtual DbSet<RepairWorkMaterial> RepairWorkMaterials { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
        public virtual DbSet<MessageInfo> MessageInfos { set; get; }

    }
}
