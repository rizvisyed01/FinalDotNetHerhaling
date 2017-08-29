using System;
using System.Collections.Generic;

namespace FinalHerhalingApi.Entities
{
    public partial class Studenten
    {
        public Studenten()
        {
            StudentenCursussen = new HashSet<StudentenCursussen>();
        }

        public int Studnr { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public string Geslacht { get; set; }
        public int? Betaald { get; set; }
        public string Email { get; set; }
        public string Woonplaats { get; set; }
        public int? PeterMeter { get; set; }
        public int? Boete { get; set; }

        public virtual Boete BoeteNavigation { get; set; }
        public virtual ICollection<StudentenCursussen> StudentenCursussen { get; set; }
        public virtual Studenten PeterMeterNavigation { get; set; }
        public virtual ICollection<Studenten> InversePeterMeterNavigation { get; set; }
    }
}
