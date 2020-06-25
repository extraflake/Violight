using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> Get();
        IEnumerable<Role> GetbyParam(string param);
        Role GetbyId(int id);
        Role Check(string param);
        bool Insert(RoleVM roleVM);
        bool Update(int id, RoleVM roleVM);
        bool Delete(int id);
    }
}
