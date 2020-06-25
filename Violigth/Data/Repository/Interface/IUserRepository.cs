using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        IEnumerable<RoleUserVM> GetDropdown();
        IEnumerable<User> GetbyParam(string param);
        User GetbyId(long id);
        User Check(string param);
        bool Insert(UserVM userVM);
        bool Update(int id, UserVM userVM);
        bool Delete(int id);
    }
}
