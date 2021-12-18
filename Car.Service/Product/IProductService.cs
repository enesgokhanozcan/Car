using Car.Model;
using Car.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Product
{
    public interface IProductService
    {
        public General<ListProduct> List();
        public General<ProductDetail> Insert(InsertProduct newProduct);
        public General<ProductDetail> GetById();
        public General<ProductDetail> Sort(string sortProduct);
        public General<ProductDetail> Filter(string filterProduct);
        public General<ProductDetail> Pagination(int productPage, int displayPage);

    }
}
