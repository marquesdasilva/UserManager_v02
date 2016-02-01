using UsersManager_v02_BL.DesignPatternHelpers;
using UsersManager_v02_DAL.DbConnection;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_BL.UsersManager.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>
    {
        public ProfileRepository(DatabaseContext Ctx) : base(Ctx)
        {

        }
    }
}
