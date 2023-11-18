using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class FavoriteFilm
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        [ForeignKey(nameof(FilmId))]

        public virtual Film Film { get; set; }


        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }
    }
}
