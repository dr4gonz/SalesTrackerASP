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
        public virtual Sale Sale { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
