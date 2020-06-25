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
    public class CategoryRepository : ICategoryRepository
    {
        MyContext myContext = new MyContext();

        public Category Check(string param)
        {
            var get = myContext.Categories.Include("Type").SingleOrDefault(x => x.Name == param);
            return get;
        }

        public bool Delete(int id)
        {
            var pull = GetbyId(id);
            pull.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            pull.IsDelete = true;
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<Category> Get()
        {
            var get = myContext.Categories.Where(x => x.IsDelete == false).ToList().OrderBy(x => x.Name);
            return get;
        }

        public Category GetbyId(int id)
        {
            var get = myContext.Categories.FirstOrDefault(x => x.Id == id);
            return get;
        }

        public IEnumerable<Category> GetbyParam(string param)
        {
            var get = myContext.Categories.Where(x => (x.Id.ToString().Contains(param) || x.Name.Contains(param)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(CategoryVM categoryVM)
        {
            var check = Check(categoryVM.Name);
            if (check != null)
            {
                return false;
            }
            else
            {
                var push = new Category(categoryVM);
                myContext.Categories.Add(push);
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }

        public bool Update(int id, CategoryVM categoryVM)
        {
            var check = Check(categoryVM.Name);
            if (check != null)
            {
                return false;
            }
            else
            {
                var pull = GetbyId(id);
                pull.Update(categoryVM.Id, categoryVM);
                myContext.Entry(pull).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }
    }
}
