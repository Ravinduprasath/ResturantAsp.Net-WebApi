using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Need to enter the name")]
        [MinLength(5, ErrorMessage="Name should hava at least 5 character")]
        public string PersonName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Need to enter the address")]
        public string PersonAddress { get; set; }

        [Display(Name = "Food")]
        [Required(ErrorMessage = "Need select food")]
        public int FoodId { get; set; }

        [Required]
        [Range(1,1000, ErrorMessage = "You should at least buy one food")]
        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public List<SelectListItem> foodItem { get; set; } = new List<SelectListItem>();
    }
}
