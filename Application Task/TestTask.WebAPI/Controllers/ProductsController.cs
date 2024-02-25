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

        /// <summary>
        /// Метод получения продуктов с параметрами
        /// </summary>
        /// <param name="code">Код продукта</param>
        /// <param name="value">Название продукта</param>
        /// <returns>Список продуктов</returns>
        [HttpGet("get-filtered-data")]
        public async Task<IEnumerable<ProductDto>> Get(int? code, string? value)
        {
            var query = new GetProductsQuery(code, value);
            var products = await _mediator.Send(query);

            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsToReturn;
        }

        /// <summary>
        /// Метод добавления продуктов
        /// </summary>
        /// <param name="productsData">Массив продуктов</param>
        /// <returns></returns>
        [HttpPost("insert-array")]
        public async Task Post([FromBody] IEnumerable<Dictionary<int, string>> productsData)
        {
            var command = new CreateProductCommand(productsData);
            await _mediator.Send(command);
        }
    }
}
