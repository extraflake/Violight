using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Model
{
    public class Account
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }

        public Account() { }

        public Account(AccountVM accountVM)
        {
            this.Id = accountVM.Id;
            this.Password = accountVM.Password;
        }

        public void Update(string id, AccountVM accountVM)
        {
            this.Id = id;
            this.Password = accountVM.Password;
        }
    }
}
