using DataAcceessLibrary.BussinessLogic;
using FoodOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturentApi.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodController : Controller
    {
        [HttpGet]
        public List<FoodModel> Get()
        {
            var data = FoodClass.LoadFood();

            List<FoodModel> food = new List<FoodModel>();

            foreach (var row in data)
            {
                food.Add(new FoodModel
                {
                    Id = row.Id,
                    FoodName = row.FoodName,
                    FoodPrice = row.FoodPrice
                });
            }

            return food;
        }
    }
}
