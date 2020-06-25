using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Repository.Interface
{
    public interface IAccountRepository
    {
        Account Get(string id);
        bool Insert(AccountVM accountVM);
        bool Update(string id, AccountVM accountVM);
    }
}
