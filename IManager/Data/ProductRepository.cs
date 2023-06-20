using IManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IManager.Data
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<InvItem> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public InvItem GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.itemID == id);
        }

        public void AddProduct(InvItem product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(InvItem product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(InvItem product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
