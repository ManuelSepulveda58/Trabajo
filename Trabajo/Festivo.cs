using System;

namespace Trabajo
{
    public class Tipo
    {
        public int Id { get; set; }
        public string NombreTipo { get; set; }
    }

    public class Festivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int DiasPascua { get; set; }
        public int IdTipo { get; set; }
        public Tipo TipoFestivo { get; set; } // Relación con la clase Tipo
    }
}

