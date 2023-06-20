using System.ComponentModel.DataAnnotations;

namespace IManager.Models
{
    public class Category
    {
        [Key]
        public int _categoryID { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
    }
}
