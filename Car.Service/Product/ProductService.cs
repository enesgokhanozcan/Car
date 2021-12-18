using AutoMapper;
using Car.DB.Entities.DataContext;
using Car.Model;
using Car.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public General<ProductDetail> Pagination(int productPage, int displayPage)
        {
            throw new NotImplementedException();
        }

        public General<ProductDetail> Sort(string sortProduct)
        {
            var result = new General<ProductDetail>();
            using (var srv = new CarContext())
            {
                var product = srv.Car.Where(x => x.IsActive && !x.IsDeleted);
                switch (sortProduct)
                {
                    case "Name":
                        product = product.OrderBy(x => x.Name);
                        break;
                    case "DescendingName":
                        product = product.OrderByDescending(p => p.Name);
                        break;
                    case "Price":
                        product = product.OrderBy(p => p.Price);
                        break;
                    case "DescendingPrice":
                        product = product.OrderByDescending(p => p.Price);
                        break;
                }
                result.List = mapper.Map<List<ProductDetail>>(product);
                result.IsSuccess = true;
            }
            return result;
        }
        public General<ProductDetail> Filter(string filterProduct)
        {
            var result = new General<ProductDetail>();
            using (var srv = new CarContext())
            {
                var product = srv.Car.Where(x => !x.IsDeleted);
                if (!String.IsNullOrEmpty(filterProduct))
                {
                    product = product.Where(i => i.Name.StartsWith(filterProduct));
                }
                else
                {
                    return result;
                }
                result.List = mapper.Map<List<ProductDetail>>(product);
                result.IsSuccess = true;
            }
            return result;
        }
    }
}
