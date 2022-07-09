using AutoMapper;
using BusinessObject.Dtos;
using BusinessObject.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository repository;
        private readonly IMapper mapper;

        public OrdersController(IMapper mapper)
        {
            this.mapper = mapper;
            repository = new OrderRepository();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            try
            {
                return Ok(mapper.Map<List<OrderDto>>(await repository.GetOrdersAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            try
            {
                var result = await repository.FindOrderByIdAsync(id);
                return result != null ? Ok(mapper.Map<OrderDto>(result)) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync([FromBody] OrderDto order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await repository.SaveOrderAsync(mapper.Map<Order>(order));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var e = await repository.FindOrderByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await repository.DeleteOrderAsync(e);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderAsync(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (order.OrderId != id)
            {
                return BadRequest();
            }
            var e = await repository.FindOrderByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await repository.UpdateOrderAsync(mapper.Map<Order>(order));
            return NoContent();
        }
    }
}