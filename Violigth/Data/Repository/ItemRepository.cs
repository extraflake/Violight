using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Context;
using Violigth.Data.Model;
using Violigth.Data.Repository.Interface;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();

        public Item Check(string param)
        {
            var get = myContext.Items.Include("Category").FirstOrDefault(x => x.Name == param);
            return get;
        }

        public bool Delete(int id)
        {
            var delete = GetbyId(id);
            myContext.Items.Remove(delete);
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<Item> Get()
        {
            var get = myContext.Items.Include("Category").ToList().OrderBy(x => x.Name).OrderBy(x => x.Category.Name);
            return get;
        }

        public Item GetbyId(int id)
        {
            var get = myContext.Items.FirstOrDefault(x => x.Id == id);
            return get;
        }

        public IEnumerable<Item> GetbyParam(string param)
        {
            var get = myContext.Items.Where(x => x.Id.ToString().Contains(param) || x.Name.Contains(param) || x.Price.ToString().Contains(param) || x.Stock.ToString().Contains(param)).ToList();
            return get;
        }

        public bool Insert(ItemVM itemVM)
        {
            var check = Check(itemVM.Name);
            if(check != null)
            {
                return false;
            }
            else
            {
                var get = myContext.Categories.Find(itemVM.Category);
                var push = new Item(itemVM);
                push.Category = get;
                myContext.Items.Add(push);
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }

        public bool Update(int id, ItemVM itemVM)
        {
            var pull = GetbyId(id);
            var get = myContext.Categories.Find(itemVM.Category);
            pull.Update(itemVM);
            pull.Category = get;
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result > 0;
        }
    }
}
