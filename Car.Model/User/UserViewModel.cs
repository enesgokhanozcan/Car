using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Model.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get ; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Idatetime { get; set; }

    }
}
