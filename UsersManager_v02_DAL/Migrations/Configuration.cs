namespace UsersManager_v02_DAL.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersManager_v02_DAL.DbConnection.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UsersManager_v02_DAL.DbConnection.DatabaseContext Context)
        {
            //var AdminUser = new User
            //{
            //    Name = "Administrator",
            //    Username = "admin",
            //    Password = "123",
            //    EmailAdress = "administrator@database.com",
            //    CreatedAt = DateTime.Parse("2010-09-01"),
            //    CreatedBy = null,
            //    UpdatedBy = null,
            //    UpdatedAt = null,
            //    IsActive = true
            //};

            //Context.User.AddOrUpdate(p => p.Username,AdminUser);
            //Context.SaveChanges();

            //var Users = new List<User>
            //{
            //    new User {  Name = "Alexander Carson", Username="acarson", Password="123", EmailAdress = "alexander.carson@database.com", CreatedAt = DateTime.Now , CreatedBy = AdminUser.Id,UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new User {  Name = "Meredith Alonso", Username="malonso", Password="123", EmailAdress = "meredith.alonso@database.com", CreatedAt =  DateTime.Now , CreatedBy = AdminUser.Id,UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new User {  Name = "Arturo Anand", Username="aanand", Password="123", EmailAdress = "arturo.anand@database.com", CreatedAt =  DateTime.Now , CreatedBy = AdminUser.Id,UpdatedBy = null, UpdatedAt = null, IsActive = true},
            //    new User {  Name = "Gytis Barzdukas", Username="gbarzdukas", Password="123", EmailAdress = "gytis.barzdukas@database.com", CreatedAt = DateTime.Now , CreatedBy = AdminUser.Id,UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new User {  Name = "Yan Li", Username="yli", Password="123", EmailAdress = "yan.li@database.com", CreatedAt =  DateTime.Now , CreatedBy = AdminUser.Id,UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //};

            //Users.ForEach(s => Context.User.AddOrUpdate(p => p.Username,s));
            //Context.SaveChanges();

            //List<Role> roles = new List<Role>
            //{
            //    new Role {  Name = "NewRolePermission", Description = "Permissão para criação de nova permissão", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "EditRolePermission", Description = "Permissão para editar uma permissão", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "DeleteRolePermission", Description = "Permissão para apagar uma permissão", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "ViewRolePermission", Description = "Permissão para visualizar uma permissão", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "NewProfilePermission", Description = "Permissão para criação de novo perfil", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "EditProfilePermission", Description = "Permissão para editar um perfil", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "DeleteProfilePermission", Description = "Permissão para apagar um perfil", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true },
            //    new Role {  Name = "ViewProfilePermission", Description = "Permissão para visualizar um perfil", CreatedBy = AdminUser.Id, CreatedAt= DateTime.Now, IsActive = true }
            //};

            //roles.ForEach(s=> Context.Role.AddOrUpdate(p => p.Name, s));
            //Context.SaveChanges();

            //var profiles = new List<Profile>
            //{
            //    new Profile { Name = "Administrator", Description = "Profile with all permissons.", CreatedBy = AdminUser.Id, CreatedAt = DateTime.Now, UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new Profile { Name = "User Managment", Description = "Profile only with permission to activate/desactivate users.", CreatedBy = AdminUser.Id, CreatedAt = DateTime.Now, UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new Profile { Name = "Common", Description = "Profile only with permission to see your own user informations.", CreatedBy = AdminUser.Id, CreatedAt = DateTime.Now, UpdatedBy = null, UpdatedAt = null, IsActive = true }
            //};

            //profiles.ForEach(s => Context.Profile.AddOrUpdate(p => p.Name, s));
            //Context.SaveChanges();

            //var AdministrationDeparment = new Department
            //{
            //    Name = "Administration",
            //    Description = "Root department of the organization.",
            //    TopDepartmentId = null,
            //    CreatedAt = DateTime.Parse("2010-09-01"),
            //    CreatedBy = AdminUser.Id,
            //    UpdatedBy = null,
            //    UpdatedAt = null,
            //    IsActive = true
            //};

            //Context.Department.AddOrUpdate(p => p.Name, AdministrationDeparment);
            //Context.SaveChanges();

            //var departments = new List<Department>
            //{
            //    new Department { Name = "Financial", Description = "Quality assurance of the financial status.", TopDepartmentId = AdministrationDeparment.Id, CreatedBy = AdminUser.Id, CreatedAt = DateTime.Now, UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new Department { Name = "Mathematics", Description = "Mathemitcs research and courses.", TopDepartmentId = AdministrationDeparment.Id, CreatedBy = AdminUser.Id, CreatedAt = DateTime.Now, UpdatedBy = null, UpdatedAt = null, IsActive = true },
            //    new Department { Name = "Engineering", Description = "Engineering department.", TopDepartmentId = AdministrationDeparment.Id, CreatedBy = AdminUser.Id, CreatedAt = DateTime.Now, UpdatedBy = null, UpdatedAt = null, IsActive = true }
            //};

            //departments.ForEach(s => Context.Department.AddOrUpdate(p => p.Name, s));
            //Context.SaveChanges();
        }
    }
}
