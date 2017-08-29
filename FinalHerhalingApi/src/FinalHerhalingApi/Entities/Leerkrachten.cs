using System;
using System.Collections.Generic;

namespace FinalHerhalingApi.Entities
{
    public partial class Leerkrachten
    {
        public Leerkrachten()
        {
            Cursussen = new HashSet<Cursussen>();
        }

        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public virtual ICollection<Cursussen> Cursussen { get; set; }
    }
}
