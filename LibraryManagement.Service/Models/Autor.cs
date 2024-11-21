using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    internal class Autor
    {

        public int AutorId { get; set; }
        public string AutorName { get; set; }
        public int AutorBirthYear { get; set; }
        public string AutorBiography { get; set; }
        public bool AutorHasAtLeastOneBook { get; set; }

    }
}
