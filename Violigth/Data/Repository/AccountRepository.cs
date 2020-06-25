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
    public class AccountRepository : IAccountRepository
    {
        MyContext myContext = new MyContext();

        public Account Get(string id)
        {
            var get = myContext.Accounts.Find(id);
            return get;
        }

        public bool Insert(AccountVM accountVM)
        {
            string myPassword = accountVM.Password;
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
            accountVM.Password = myHash;
            var push = new Account(accountVM);
            myContext.Accounts.Add(push);
            var result = myContext.SaveChanges();
            return result > 0;
        }

        public bool Update(string id, AccountVM accountVM)
        {
            var pull = Get(id);
            pull.Password = accountVM.Password;
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result > 0;
        }
    }
}
