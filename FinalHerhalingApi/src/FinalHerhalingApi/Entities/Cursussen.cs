using System;
using System.Collections.Generic;

namespace FinalHerhalingApi.Entities
{
    public partial class Cursussen
    {
        public Cursussen()
        {
            StudentenCursussen = new HashSet<StudentenCursussen>();
        }

        public int Cursusnr { get; set; }
        public string Cursusnaam { get; set; }
        public int? Inschrijvingsgeld { get; set; }
        public int? Leerkracht { get; set; }

        public virtual ICollection<StudentenCursussen> StudentenCursussen { get; set; }
        public virtual Leerkrachten LeerkrachtNavigation { get; set; }
    }
}
