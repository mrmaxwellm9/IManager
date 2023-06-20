using System.ComponentModel.DataAnnotations;

namespace IManager.Models
{
    public class Customer
    {
        [Key]
        public int _customerID { get; set; }

        public string _name { get; set; }

        public ICollection<Order> _orders { get; set; }
    }
}
