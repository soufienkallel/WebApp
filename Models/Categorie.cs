using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Categorie
    {
        
            [Key]
            public int CatID { get; set; }
            public string? CatName { get; set; }

    }
}
