using System.ComponentModel.DataAnnotations;

namespace IManager.Models
{
    public class Order
    {
        [Key]
        public int _orderID { get; set; }
        public string _orderDate { get; set; }
        public decimal _amountCharged { get; set; }
        public ICollection<InvItem> _items { get; set; }

        public int _customerID { get; set; }
        public Customer Customer { get; set; }
    }
}
