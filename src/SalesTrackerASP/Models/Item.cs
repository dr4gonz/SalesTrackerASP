using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTrackerASP.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Margin { get; set; }
        public decimal SalePrice
        {
            get
            {
                return Cost + Margin;
            }
        }
    }
}
