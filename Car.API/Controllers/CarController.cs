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
        public General<ProductDetail> Insert([FromBody] InsertProduct newCar)
        {
            General<ProductDetail> response = new();
            response = productService.Insert(newCar);
            return response;
        }
        [HttpGet]
        public General<ListProduct> GetList()
        {
            General<ListProduct> response = new();
            return response;
        }
        [HttpGet("{id:int}")]
        public General<ProductDetail> GetById(int id)
        {
            General<ProductDetail> response = new();
            return response;
        }
    }
}
