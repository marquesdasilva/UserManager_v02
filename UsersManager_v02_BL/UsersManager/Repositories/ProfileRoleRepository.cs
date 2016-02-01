using UsersManager_v02_BL.DesignPatternHelpers;
using UsersManager_v02_DAL.DbConnection;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_BL.UsersManager.Repositories
{
    public class ProfileRoleRepository : GenericRepository<ProfileRole>
    {
        public ProfileRoleRepository(DatabaseContext Ctx) : base(Ctx)
        {

        }
    }
}
