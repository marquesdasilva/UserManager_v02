using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_DAL.DbConnection
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ProfileRole> ProfileRole { get; set; }
        public DbSet<Department> Department { get; set; }
        //outras tabelas

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
        {
            ModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            ModelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Relacao Recursiva entre Deparment e Deparment
            ModelBuilder.Entity<Department>().HasOptional(e => e.RootDepartment).WithMany(e => e.ChildDepartments).HasForeignKey(e => e.TopDepartmentId).WillCascadeOnDelete(false);

            ////Fazer inserts, updates e deletes atraves de SP's
            ModelBuilder.Entity<User>().MapToStoredProcedures();
            ModelBuilder.Entity<Role>().MapToStoredProcedures();
            ModelBuilder.Entity<Profile>().MapToStoredProcedures();
            ModelBuilder.Entity<ProfileRole>().MapToStoredProcedures();
            ModelBuilder.Entity<Department>().MapToStoredProcedures();
        }

        public System.Data.Entity.DbSet<UsersManager_v02_DAL.Entities.Metadata.AccessMetadata> AccessMetadatas { get; set; }
    }
}
