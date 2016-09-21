using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTrackerASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SalesTrackerASP.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public InventoryController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Items.ToList());
        }

        [HttpPost]
        public IActionResult NewItem(string newName, int newQuantity, decimal newCost, decimal newMargin)
        {

            Item newItem = new Item(newName, newQuantity, newCost, newMargin);
            _db.Items.Add(newItem);
            _db.SaveChanges();
            return Json(newItem);
        }
        [HttpPost]
        public void DeleteItem(int id)
        {
            var item = _db.Items.FirstOrDefault(i => i.Id == id);
            _db.Items.Remove(item);
            _db.SaveChanges();
        }
        [HttpPost]
        public void EditItem(int id)
        {
            var item = _db.Items.FirstOrDefault(i => i.Id == id);
            item.Name = Request.Form["newName"];
            item.Count = int.Parse(Request.Form["newQuantity"]);
            item.Cost = decimal.Parse(Request.Form["newCost"]);
            item.Margin = decimal.Parse(Request.Form["newMargin"]);
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
