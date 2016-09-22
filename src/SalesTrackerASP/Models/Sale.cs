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
        public virtual ICollection<ItemsSales> ItemsSales { get; set; }

        public Sale(string buyer, string comments, ApplicationUser salesRep)
        {
            Buyer = buyer;
            Comments = comments;
            SalesRep = salesRep;
        }
    }
}
