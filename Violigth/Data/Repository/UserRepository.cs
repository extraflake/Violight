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
    public class UserRepository : IUserRepository
    {
        MyContext myContext = new MyContext();

        public User Check(string param)
        {
            var check = myContext.Users.SingleOrDefault(x => x.Email.Equals(param));
            return check;
        }

        public bool Delete(int id)
        {
            var delete = GetbyId(id);
            delete.Delete();
            myContext.Entry(delete).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<User> Get()
        {
            var get = myContext.Users.Where(x => x.IsTerminated == false).ToList();
            return get;
        }

        public IEnumerable<RoleUserVM> GetDropdown()
        {
            var get = myContext.Database.SqlQuery<RoleUserVM>("exec SP_Retrieve_User").ToList();
            return get;
        }

        public User GetbyId(long id)
        {
            var get = myContext.Users.SingleOrDefault(x => x.Id == id);
            return get;
        }

        public IEnumerable<User> GetbyParam(string param)
        {
            var get = myContext.Users.Where(x => x.FirstName.Contains(param) || x.LastName.Contains(param)).ToList();
            return get;
        }

        public bool Insert(UserVM userVM)
        {
            var push = new User(userVM);
            var check = Check(userVM.Email);
            if (check == null)
            {
                myContext.Users.Add(push);
                var resultuser = myContext.SaveChanges();
                return resultuser > 0;
            }
            else
            {
                check.IsTerminated = false;
                check.IsDelete = false;
                myContext.Entry(check).State = EntityState.Modified;
                var resultupdate = myContext.SaveChanges();
                return resultupdate > 0;
            }
        }

        public bool Update(int id, UserVM userVM)
        {
            var pull = GetbyId(id);
            if (pull == null)
            {
                return false;
            }
            else
            {
                pull.Update(userVM);
                myContext.Entry(pull).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
        }
    }
}
