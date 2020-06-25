using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> Get();
        IEnumerable<Item> GetbyParam(string param);
        Item GetbyId(int id);
        Item Check(string param);
        bool Insert(ItemVM itemVM);
        bool Update(int id, ItemVM itemVM);
        bool Delete(int id);
    }
}
