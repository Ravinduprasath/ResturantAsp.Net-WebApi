using DataAcceessLibrary.BussinessLogic;
using FoodOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturentApi.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {   
        [HttpPost]
        public IActionResult Post(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var food = FoodClass.LoadFood();

                model.Total = model.Quantity * food.Where(x => x.Id == model.FoodId).First().FoodPrice;

                int id = OrderClass.InsertOrder(model.PersonName, model.PersonAddress, model.FoodId,
                     model.Quantity, model.Total);

                return Ok(new { Id = id });
            }

            return BadRequest(); 
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = OrderClass.LoadOrder();

                var val = data.Where(x => x.Id == id).FirstOrDefault();

                OrderModel order = new OrderModel
                {
                    Id = val.Id,
                    PersonName = val.PersonName,
                    PersonAddress = val.PersonAddress,
                    FoodId = val.FoodId,
                    Quantity = val.Quantity,
                    Total = val.Total
                };
                return Ok(order);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(OrderModel model) 
        {
            try
            {
                var food = FoodClass.LoadFood();

                model.Total = model.Quantity * food.Where(x => x.Id == model.FoodId).First().FoodPrice;

                OrderClass.UpdateOrder(model.Id,
                                       model.PersonName,
                                       model.PersonAddress,
                                       model.FoodId,
                                       model.Quantity,
                                       model.Total);

                return Ok();
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                OrderClass.DeleteOrder(id);
                return Ok(id);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }
    }
}
