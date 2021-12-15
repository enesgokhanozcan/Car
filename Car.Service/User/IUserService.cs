using Car.Model;
using Car.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.User
{
    public interface  IUserService
    {
        public General<UserViewModel> Login(UserLoginModel user);
        public General<UserViewModel> Insert(UserCreateModel newUser);
        public General<UserViewModel> Update(UserUpdateModel updatedUser, int id);
        public General<UserViewModel> Delete(int id);
        public General<UserViewModel> Get();

    }
}
