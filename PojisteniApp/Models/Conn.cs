using System.ComponentModel.DataAnnotations;

namespace PojisteniApp.Models
{
    public class Conn
    {
        public int Id { get; set; }
        public int PojistenecId { get; set; }
        [Display(Name = "Pojištění")]
        public int? PojisteniId { get; set; }
        public ICollection<Pojisteni> Pojisteni { get; set; }
        public ICollection<Pojistenec> Pojistenec { get; set; }

    }
}
