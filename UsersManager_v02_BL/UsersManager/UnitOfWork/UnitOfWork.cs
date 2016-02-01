using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManager_v02_BL.DesignPatternHelpers;
using UsersManager_v02_BL.UsersManager.Repositories;
using UsersManager_v02_DAL.DbConnection;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_BL.UsersManager.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public DatabaseContext Context = new DatabaseContext();

        private UserRepository UserRep;
        private AccessRepository AccessRep;
        private DepartmentRepository DepartmentRep;
        private ProfileRepository ProfileRep;
        private ProfileRoleRepository ProfileRoleRep;
        private RoleRepository RoleRep;

        public UserRepository UserRepository
        {
            get
            {

                if (this.UserRep == null)
                {
                    this.UserRep = new UserRepository(Context);
                }
                return UserRep;
            }
        }

        public AccessRepository AccessRepository
        {
            get
            {

                if (this.AccessRep == null)
                {
                    this.AccessRep = new AccessRepository(Context);
                }
                return AccessRep;
            }
        }

        public DepartmentRepository DepartmentRepository
        {
            get
            {

                if (this.DepartmentRep == null)
                {
                    this.DepartmentRep = new DepartmentRepository(Context);
                }
                return DepartmentRep;
            }
        }

        public ProfileRepository ProfileRepository
        {
            get
            {

                if (this.ProfileRep == null)
                {
                    this.ProfileRep = new ProfileRepository(Context);
                }
                return ProfileRep;
            }
        }

        public ProfileRoleRepository ProfileRoleRepository
        {
            get
            {

                if (this.ProfileRoleRep == null)
                {
                    this.ProfileRoleRep = new ProfileRoleRepository(Context);
                }
                return ProfileRoleRep;
            }
        }

        public RoleRepository RoleRepository
        {
            get
            {

                if (this.RoleRep == null)
                {
                    this.RoleRep = new RoleRepository(Context);
                }
                return RoleRep;
            }
        }

        public void Save()
        {
            Context.SaveChanges();

        }

        private bool Disposed = false;
        protected virtual void Dispose(bool Disposing)
        {
            if (!this.Disposed)
            {
                if (Disposing)
                {
                    Context.Dispose();
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
