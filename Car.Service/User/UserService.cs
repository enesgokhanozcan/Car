using AutoMapper;
using Car.DB.Entities.DataContext;
using Car.Model;
using Car.Model.User;
using System.Linq;

namespace Car.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public General <UserViewModel>Login(UserLoginModel loginUser)
        {
            General<UserViewModel> result = new();
            using (var srv = new CarContext())
            {
                var _data = srv.User.FirstOrDefault(a => !a.IsDeleted && a.IsActive && a.UserName == loginUser.UserName && a.Password == loginUser.Password);
                if (_data is not null)
                {
                    result.IsSuccess = true;
                    result.Entity = mapper.Map<UserViewModel>(_data);
                }
            }

            return result;
        }
        public General<UserViewModel> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public General<UserViewModel> Get()
        {
            throw new System.NotImplementedException();
        }

        public General<UserViewModel> Insert(UserCreateModel newUser)
        {
            var result = new General<UserViewModel>() { IsSuccess = false};
            var model = mapper.Map<Car.DB.Entities.User>(newUser);
            using (var srv = new CarContext())
            {
                model.Idatetime = System.DateTime.Now;
                srv.User.Add(model);
                srv.SaveChanges();
                result.Entity = mapper.Map<UserViewModel>(model);
                result.IsSuccess = true;
            }
            return result;
        }

        //public General<UserViewModel> Login(UserLoginModel user)
        //{
        //    throw new System.NotImplementedException();
        //}

        public General<UserViewModel> Update(UserUpdateModel updatedUser, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
