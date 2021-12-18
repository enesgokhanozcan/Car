using AutoMapper;
using Car.DB.Entities.DataContext;
using Car.Model;
using Car.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Product
{
    public class ProductService : IProductService
    {

        private readonly IMapper mapper;
        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public General<ProductDetail> GetById()
        {
            throw new NotImplementedException();
        }

        public General<ProductDetail> Insert(InsertProduct newProduct)
        {
            var result = new General<ProductDetail>() { IsSuccess = false };
            var model = mapper.Map<Car.DB.Entities.Car>(newProduct);
            using (var srv = new CarContext())
            {
                model.Idate = System.DateTime.Now;
                model.Name = model.DisplayName;
                model.Iuser = 1;
                srv.Car.Add(model);
                srv.SaveChanges();
                result.Entity = mapper.Map<ProductDetail>(model);
                result.IsSuccess = true;
            }
            return result;
        }

        public General<ListProduct> List()
        {
            throw new NotImplementedException();
        }
    }
}
