using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Ensino
    {
        public int Id { get; set; }
        public virtual int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public DateTime? AnoFormacao { get; set; }


    }
}
