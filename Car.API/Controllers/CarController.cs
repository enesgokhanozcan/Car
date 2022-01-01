using Car.API.Infrastructure;
using Car.Model;
using Car.Model.Product;
using Car.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IProductService productService;
        public CarController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpPost]
        [Route("Insert")]
        public General<ProductDetail> Insert([FromBody] InsertProduct newCar)
        {
            General<ProductDetail> response = new();
            response = productService.Insert(newCar);
            return response;
        }
        [HttpPut]
        [Route("Update")]
        public General<ProductDetail> Update([FromBody] InsertProduct updateCar)
        {
            General<ProductDetail> response = new();
            response = productService.Update(updateCar);
            return response;
        }
        [HttpGet]
        [Route("List")]
        public General<ListProduct> List([FromBody] int pageSize,int currentPage)
        {
            General<ListProduct> response = new();
            response = productService.List(pageSize,currentPage);
            return response;
        }
        [HttpGet]
        [Route("Listing")]
        public General<ProductDetail> GetProducts()
        {
            return productService.GetProducts();
        }
        [HttpGet("{id:int}")]
        public General<ProductDetail> GetById(int id)
        {
            General<ProductDetail> response = new();
            return response;
        }
        [HttpGet]
        [Route("Sort")]
        public General<ProductDetail> Sort([FromQuery] string sortProduct)
        {
            return productService.Sort(sortProduct);
        }
        [HttpGet]
        [Route("Filter")]
        public General<ProductDetail> Filter([FromQuery] string filterProduct)
        {
            return productService.Filter(filterProduct);
        }
        [HttpGet]
        [Route("Pagination")]
        public General<ProductDetail> Pagination([FromQuery] int productPage, [FromQuery] int displayPage)
        {
            return productService.Pagination(productPage, displayPage);
        }
    }
}
