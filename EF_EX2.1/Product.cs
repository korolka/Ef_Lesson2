using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX2._1
{
    public class Product
    {
        public int  ProductAlterId { get; set; }
        //[Column("ProductId")]
        public int Id { get; set; }
       // [Required]
        public string Name { get; set; }
        public double Cost { get; set; }
       // [Required]
        public string Description { get; set; }
        public int Quantity { get; set; }
    }

    public class User
    {
        //[Column("UserId")]
        public Guid Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public string? LastName { get; set; }
        //[Required]
        public string Login { get; set; }
        public string Password { get; set; }
        //[Required]
        public string Email { get; set; }
    }

    public class Order
    {
       // [Column("OrderId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime Create { get; set; }
       // [Column(TypeName = "Date")]
        public DateTime Update { get; set; }
        //[Required]
        public string Description { get; set; }
    }
}
