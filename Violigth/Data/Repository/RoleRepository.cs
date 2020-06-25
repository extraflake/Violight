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
    public class RoleRepository : IRoleRepository
    {
        MyContext myContext = new MyContext();

        public Role Check(string param)
        {
            var get = myContext.Roles.SingleOrDefault(x => x.Name == param);
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

        public IEnumerable<Role> Get()
        {
            var get = myContext.Roles.Where(x => x.IsDelete == false).ToList().OrderBy(x => x.Name);
            return get;
        }

        public Role GetbyId(int id)
        {
            var get = myContext.Roles.FirstOrDefault(x => x.Id == id);
            return get;
        }

        public IEnumerable<Role> GetbyParam(string param)
        {
            var get = myContext.Roles.Where(x => (x.Id.ToString().Contains(param) || x.Name.Contains(param)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(RoleVM roleVM)
        {
            var check = Check(roleVM.Name);
            if (check != null)
            {
                check.IsDelete = false;
                myContext.Entry(check).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
            else
            {
                var push = new Role(roleVM);
                myContext.Roles.Add(push);
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }

        public bool Update(int id, RoleVM roleVM)
        {
            var check = Check(roleVM.Name);
            if (check != null)
            {
                return false;
            }
            else
            {
                var pull = GetbyId(id);
                pull.Update(roleVM.Id, roleVM);
                myContext.Entry(pull).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }
    }
}
