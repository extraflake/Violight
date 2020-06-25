using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface IRoleUserRepository
    {
        IEnumerable<RoleUserVM> Get();
        RoleUser Get(int id);
        RoleUser Check(int param1, int param2);
        bool Insert(RoleUser roleUser);
        bool Delete(int id);
    }
}
