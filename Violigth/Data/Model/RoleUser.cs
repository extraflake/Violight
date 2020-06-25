using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violigth.Data.Base;

namespace Violigth.Data.Model
{
    public class RoleUser : BaseModel
    {
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }

        public RoleUser(int user, int role)
        {
            this.User_Id = user;
            this.Role_Id = role;
        }

        public RoleUser() { }
    }
}
