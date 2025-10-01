using NetTopologySuite.Operation.Valid;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class SerialNumber
    {
            public int serialNumberId { get; set; }   // EF sẽ nhận đây là PK   
            public string Name { get; set; }    
          
            public  int ? ItemId { get; set; }  // FK
            [ForeignKey ("ItemId")]
            public Item ? Item { get; set; }

    }
}
