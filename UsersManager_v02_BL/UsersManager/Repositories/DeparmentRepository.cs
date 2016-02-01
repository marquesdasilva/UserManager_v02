using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UsersManager_v02_BL.DesignPatternHelpers;
using UsersManager_v02_DAL.DbConnection;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_BL.UsersManager.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        public DepartmentRepository(DatabaseContext Ctx) : base(Ctx)
        {
        }

        //public IEnumerable<Tipo da entidade que vais criar (int,string,string,bool,string,bool)> GetUsers(string sortOrder, string searchString, int pageSize = 10, int page = 1)
        //{
        //    return this.Get(null,null,"RootDepartment").Select(c => new
        //            {
        //                c.Id,
        //                c.Name,
        //                NamePai = c.RootDepartment.Name,
        //                c.IsActive,
        //                c.Description,
        //                IsAcessos = c.Accesses
        //                                    .Where(a => a.DepartmentId == c.Id)
        //                                    .Select(a => 1).FirstOrDefault() == 1
        //            }).ToList();
        //}
    }
}
