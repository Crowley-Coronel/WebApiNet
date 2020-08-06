using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using AttributeRouting;
using BusinessEntities;
using BusinessServices;



namespace AplicacionWeb.Controllers
{
    [AttributeRouting.RoutePrefix("api")]
    public class ProductController : ApiController
    {
        private readonly IProductServices _productServices;
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        //public ProductController()
        
        public ProductController(IProductServices productServices)
        {
            //_productServices = new ProductServices();
            _productServices = productServices;

        }
        #endregion
        // GET api/product
        [HttpGet]
        [HttpRoute("product")]
        public HttpResponseMessage Get()
        {
            var products = _productServices.GetAllProducts();
            var productEntities = products as List<ProductEntity> ?? products.ToList();
            if (productEntities.Any()) return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }
        // GET api/product/5
        [HttpGet]
        [HttpRoute("product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var product = _productServices.GetProductById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
        // POST api/product
        public int Post([FromBody] ProductEntity productEntity)
        {
            return _productServices.CreateProduct(productEntity);
        }
        // PUT api/product/5
        public bool Put(int id, [FromBody] ProductEntity productEntity)
        {
            if (id > 0)
            {
                return _productServices.UpdateProduct(id, productEntity);
            }
            return false;
        }
        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _productServices.DeleteProduct(id);
            return false;
        }
    }
}