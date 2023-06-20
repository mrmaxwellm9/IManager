using System.ComponentModel.DataAnnotations;

namespace IManager.Models
{
    public class InvItem
    {
        [Key]
        public int itemID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public List<LocationInvItem> LocationInvItems { get; set; }
        public InvItem()
        {
            LocationInvItems = new List<LocationInvItem>();
        }
    }
}
