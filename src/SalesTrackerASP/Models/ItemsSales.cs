using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTrackerASP.Models
{
    [Table("ItemsSales")]
    public class ItemsSales
    {
        [Key]
        public int Id { get; set; }
        public Sale Sale { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public ItemsSales(Sale sale, Item item, int quantity, int id = 0)
        {
            Sale = sale;
            Item = item;
            Quantity = quantity;
            Id = id;
        }
        public ItemsSales() { }
    }
}
