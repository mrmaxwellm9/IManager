using System.ComponentModel.DataAnnotations;

namespace IManager.Models
{
    public class User
    {
        [Key]
        public int _userID { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _email { get; set; }
        public string _role { get; set; }
    }
}
