using System.Security.Policy;

namespace PojisteniApp.Models
{
    public class PojisteniDetails
    {
        public int Id { get; set; }
         public string Type { get; set; }
        public string  Price { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }

        public List<Pojisteni>? Pojisteni { get; set; }
        public Pojistenec? Pojistenec { get; set; }
        public Pojisteni? Route { get; set; }
        public Conn? conn { get; set; }
       
    }
}
