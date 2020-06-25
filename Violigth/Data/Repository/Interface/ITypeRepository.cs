using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface ITypeRepository
    {
        IEnumerable<Model.Type> Get();
        IEnumerable<Model.Type> GetbyParam(string param);
        Model.Type GetbyId(int id);
        Model.Type Check(string param);
        bool Insert(TypeVM typeVM);
        bool Update(int id, TypeVM typeVM);
        bool Delete(int id);
    }
}
