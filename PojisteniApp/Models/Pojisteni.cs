using System.ComponentModel.DataAnnotations;

namespace PojisteniApp.Models
{
    public class Pojisteni
    {
        public int Id { get; set; }
        [Display(Name="Předmět pojištění")]
        public string Type { get; set; }
        [Display(Name = "Částka")]
        public string Price { get; set; }
     
        public List<Pojistenec>? Pojistenec { get; set; }
}
    }
