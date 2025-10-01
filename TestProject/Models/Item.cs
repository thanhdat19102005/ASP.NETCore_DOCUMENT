using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class Item
    {
        public  int ItemId { get; set; }   // EF sẽ nhận đây là PK
        public string  Name { get; set; }
        public double  Price { get; set; }

       public   int  ? SerialNumberId { get; set; }  // FK
        [ForeignKey("SerialNumberId")]

        public     SerialNumber ? SerialNumber  { get; set; } //  Navigation  Property

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category   ? Category;   //  Navigation  Property
        
        


    }
}
