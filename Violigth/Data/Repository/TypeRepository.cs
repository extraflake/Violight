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
    public class TypeRepository : ITypeRepository
    {
        MyContext myContext = new MyContext();

        public Model.Type Check(string param)
        {
            var get = myContext.Types.FirstOrDefault(x => x.Name == param);
            return get;
        }

        public bool Delete(int id)
        {
            var pull = GetbyId(id);
            pull.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            pull.IsDelete = true;
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<Model.Type> Get()
        {
            var get = myContext.Types.Where(x => x.IsDelete == false).ToList().OrderBy(x => x.Name);
            return get;
        }

        public Model.Type GetbyId(int id)
        {
            var get = myContext.Types.FirstOrDefault(x => x.Id == id);
            return get;
        }

        public IEnumerable<Model.Type> GetbyParam(string param)
        {
            var get = myContext.Types.Where(x => (x.Id.ToString().Contains(param) || x.Name.Contains(param)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(TypeVM typeVM)
        {
            var check = Check(typeVM.Name);
            if (check != null)
            {
                return false;
            }
            else
            {
                var push = new Model.Type(typeVM);
                myContext.Types.Add(push);
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }

        public bool Update(int id, TypeVM typeVM)
        {
            var check = Check(typeVM.Name);
            if (check != null)
            {
                return false;
            }
            else
            {
                var pull = GetbyId(id);
                pull.Update(typeVM);
                myContext.Entry(pull).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }
    }
}
