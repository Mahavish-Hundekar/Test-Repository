using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryApi.Models
{
    public class Grocery
    {
       
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public DateTime Date { get; set; }

        // Foreign Key
        public int UserId { get; set; }

       // public User User { get; set; }
    }
}
