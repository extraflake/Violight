using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Base;
using Violigth.Data.ViewModel;

namespace Violigth.Data.Model
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }

        public bool IsTerminated { get; set; }

        public User() { }

        public User(UserVM userVM)
        {
            this.FirstName = userVM.FirstName;
            this.LastName = userVM.LastName;
            this.Email = userVM.Email;
            this.JoinDate = DateTimeOffset.Now.LocalDateTime;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(UserVM userVM)
        {
            this.Id = userVM.Id;
            this.FirstName = userVM.FirstName;
            this.LastName = userVM.LastName;
            this.Email = userVM.Email;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Delete()
        {
            this.IsDelete = true;
            this.IsTerminated = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
