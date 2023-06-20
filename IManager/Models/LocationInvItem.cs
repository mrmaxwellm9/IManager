using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IManager.Models
{
    public class LocationInvItem
    {
        [Key]
        public int LocationInvItemId { get; set; }

        [ForeignKey("Location")]
        public int locationId { get; set; }
        public Location Location { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("InvItem")]
        public int itemId { get; set; }
        public InvItem InvItem { get; set; }
    }
}
