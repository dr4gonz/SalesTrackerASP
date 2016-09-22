using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTrackerASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTrackerASP.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public SalesController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var items = _db.Items.ToList();
            ViewBag.items = items;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewSale(string Buyer, string Comments, Dictionary<string, int> Items)
        {
            ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            Sale newSale = new Sale(Buyer, Comments, currentUser);
            _db.Sales.Add(newSale);
            _db.SaveChanges();
            foreach(KeyValuePair<string, int> kvp in Items)
            {
                int ItemId = int.Parse(kvp.Key);
                Item currentItem = _db.Items.FirstOrDefault(item => item.Id == ItemId);
                ItemsSales newItemsSales = new ItemsSales{ Sale = newSale, Item = currentItem, Quantity = kvp.Value };
                _db.ItemsSales.Add(newItemsSales);
            }
            _db.SaveChanges();
            return View("Index");
        }
    }
}
