using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTrackerASP.Models
{
    [Table ("Sales")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public string Buyer { get; set; }
        public string Comments { get; set; }
        public virtual ApplicationUser SalesRep { get; set; }
        public virtual IEnumerable<ItemsSales> ItemsSales { get; set; }
    }
}
