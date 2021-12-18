using AutoMapper;
using Car.Model.Product;

namespace Car.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car.Model.User.UserCreateModel, Car.DB.Entities.User>();
            CreateMap<Car.DB.Entities.User, Car.Model.User.UserCreateModel>();


            CreateMap<Car.Model.User.UserLoginModel, Car.DB.Entities.User>();
            CreateMap<Car.DB.Entities.User, Car.Model.User.UserLoginModel>();

            CreateMap<Car.Model.User.UserUpdateModel, Car.DB.Entities.User>();
            CreateMap<Car.DB.Entities.User, Car.Model.User.UserUpdateModel>();

            CreateMap<Car.Model.User.UserViewModel, Car.DB.Entities.User>();
            CreateMap<Car.DB.Entities.User, Car.Model.User.UserViewModel>();

            CreateMap<InsertProduct, Car.DB.Entities.Car>();
            CreateMap<Car.DB.Entities.Car, ProductDetail>();
        }
    }
}
