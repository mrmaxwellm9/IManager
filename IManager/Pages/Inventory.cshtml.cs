using IManager.Models;
using IManager.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using IManager.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IManager.Pages
{
    public class InventoryModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<InventoryModel> _logger;
        public List<InvItem> Items { get; set; }
        public List<Location> Locations { get; set; }
        public Location NewLocation { get; set; }
        public string NewLocationString { get; set; }
        public InvItem EditProduct { get; set; }
        public int[] SelectedLocation { get; set; }
        public int EditProductId { get; set; }

        public InventoryModel(ILogger<InventoryModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            NewLocation = new Location();
            Items = new List<InvItem>();
            Locations = new List<Location>();
            EditProduct = new InvItem();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Items = await _context.Products.Include(p => p.LocationInvItems).ThenInclude(li => li.Location).ToListAsync();
            var query = @"
        SELECT * 
        FROM Locations 
        WHERE LocationName IS NOT NULL AND locationID IS NOT NULL";

            Locations = await _context.Locations
                .FromSqlRaw(query)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAddProductAsync(InvItem product, int[] selectedLocationIds, Dictionary<int, int> quantities)
        {
                foreach (var locationId in selectedLocationIds)
                {

                    var location = await _context.Locations.FindAsync(locationId);

                    if (location != null)
                    {
                        var quantity = quantities[locationId];

                        var locationInvItem = new LocationInvItem
                        {
                            Location = location,
                            InvItem = product,
                            Quantity = quantity
                        };

                        product.LocationInvItems.Add(locationInvItem);
                    }
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetSaveProductAsync(int id)
        {
            // Retrieve the product from the database
            var product = await _context.Products.Include(p => p.LocationInvItems).FirstOrDefaultAsync(p => p.itemID == id);

            if (product == null)
            {
                return NotFound();
            }

            // Set the EditProduct property
            EditProduct = product;

            // Other code...

            return Page();
        }
        public async Task<IActionResult> OnPostSaveProductAsync(int id, string[] selectedLocationIds, int quantity)
        {
            var product = await _context.Products.Include(p => p.LocationInvItems).FirstOrDefaultAsync(p => p.itemID == id);

            if (product == null)
            {
                return NotFound();
            }
            product.LocationInvItems.Clear();

            if (selectedLocationIds != null)
            {
                foreach (var locationId in selectedLocationIds)
                {
                    if (int.TryParse(locationId, out int parsedLocationId))
                    {
                        var location = await _context.Locations.FindAsync(parsedLocationId);

                        if (location != null)
                        {
                            var locationInvItem = new LocationInvItem
                            {
                                Location = location,
                                InvItem = product,
                                Quantity = quantity
                            };
                            product.LocationInvItems.Add(locationInvItem);
                        }
                    }
                }
            }

            if (await TryUpdateModelAsync(product, "", p => p.name, p => p.description, p => p.price))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostCreateLocationAsync()
        {
            if (ModelState.IsValid)
            {
                string newLocationString = Request.Form["NewLocationString"];
                if (!string.IsNullOrEmpty(newLocationString))
                {
                    int newLocationId = await _context.Locations
                    .OrderByDescending(l => l.locationID)
                    .Select(l => l.locationID)
                    .FirstOrDefaultAsync() + 1;
                    
                    var newLocation = new Location(newLocationString);
                    newLocation.locationID = newLocationId;

                    await _context.Locations.AddAsync(newLocation);
                    await _context.SaveChangesAsync();
                }
                Locations = await _context.Locations.ToListAsync();
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveProductAsync(int id)
        {
            InvItem? product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                var ToRemove = _context.LocationInvItems.Where(item => item.itemId == id);
                _context.LocationInvItems.RemoveRange(ToRemove);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
