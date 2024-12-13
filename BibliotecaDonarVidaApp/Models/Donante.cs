using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDonarVidaApp.Models
{
    public class Donante
    {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string DNI { get; set; }
            public DateOnly FechaNacimiento { get; set; }
            public string GrupoSanguineo { get; set; }
            public string FactorRH { get; set; }
            public string Contacto { get; set; } = string.Empty;

    }
    
}
