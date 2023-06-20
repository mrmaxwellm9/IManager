using IManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IManager.Data
{
    public class LocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.FirstOrDefault(p => p.locationID == id);
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            _context.Locations.Remove(location);
            _context.SaveChanges();
        }
    }
}
