using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class FoodModel
    {
        public int Id { get; set; }

        [Display(Name ="Food Name")]
        public string FoodName { get; set; }

        [Display(Name ="Price")]
        public decimal FoodPrice { get; set; }
    }
}
