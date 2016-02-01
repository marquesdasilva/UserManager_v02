using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManager_v02_BL.DesignPatternHelpers
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
