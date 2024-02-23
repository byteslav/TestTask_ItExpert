using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Handlers.Commands;
using TestTask.Application.Handlers.Queries;
using TestTask.WebApi.Dto;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get(int? code, string? value)
        {
            var query = new GetProductsQuery(code, value);
            var products = await _mediator.Send(query);

            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsToReturn;
        }

        //// GET api/<ProductsController>/5
        //[HttpGet("{id}")]
        //public async Task<Product> Get(int id)
        //{
        //    var product = await _productRepository.GetById(id);
        //    return product;
        //}

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] IEnumerable<Dictionary<int, string>> productsData)
        {
            var command = new CreateProductCommand(productsData);
            await _mediator.Send(command);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
