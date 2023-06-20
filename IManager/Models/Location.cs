using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IManager.Models
{
    public class Location
    {
        [Key]
        public int locationID { get; set; }
        public string LocationName { get; set; }
        public ICollection<LocationInvItem> LocationInvItems { get; set; }
        public Location()
        {
            LocationInvItems = new List<LocationInvItem>();
        }
        public Location(string name)
        {
            LocationInvItems = new List<LocationInvItem>();
            this.LocationName = name;
        }
    }
}
