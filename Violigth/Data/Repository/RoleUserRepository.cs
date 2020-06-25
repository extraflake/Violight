using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Context;
using Violigth.Data.Model;
using Violigth.Data.Repository.Interface;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository
{
    public class RoleUserRepository : IRoleUserRepository
    {
        MyContext myContext = new MyContext();

        public RoleUser Check(int param1, int param2)
        {
            var check = myContext.RoleUsers.Include("User").Include("Role").SingleOrDefault(x => x.User_Id == param1 && x.Role_Id == param2);
            return check;
        }

        public bool Delete(int id)
        {
            var pull = Get(id);
            myContext.RoleUsers.Remove(pull);
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<RoleUserVM> Get()
        {
            var get = myContext.Database.SqlQuery<RoleUserVM>("exec SP_Retrieve_User_Roles").ToList();
            return get;
        }

        public RoleUser Get(int id)
        {
            var get = myContext.RoleUsers.SingleOrDefault(x => x.Id == id);
            return get;
        }

        public bool Insert(RoleUser roleUser)
        {
            var push = new RoleUser(roleUser.User_Id, roleUser.Role_Id);
            myContext.RoleUsers.Add(push);
            var result = myContext.SaveChanges();
            return result > 0;
        }
    }
}