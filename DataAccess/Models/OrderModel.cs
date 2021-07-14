using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string PersonName { get; set; }

        public string PersonAddress { get; set; }

        public int FoodId { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
