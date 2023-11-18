using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Producer
    {

        [Key]
        public int ProdID { get; set; }
        public string? ProdName { get; set; }

    }
}
