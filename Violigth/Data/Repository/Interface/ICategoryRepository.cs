using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        IEnumerable<Category> GetbyParam(string param);
        Category GetbyId(int id);
        Category Check(string param);
        bool Insert(CategoryVM categoryVM);
        bool Update(int id, CategoryVM categoryVM);
        bool Delete(int id);
    }
}
