using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Amigo
    {
        // falta criar a classe usuárioamigo ... nao vi no video...
        // ver aula 35... 08:09 minutos.... fala sobre o sistema no GetHub

        public virtual int  UsuarioId { get; set; }
        public virtual Usuario  Usuario { get; set; }
        public int UsuarioAmigoId { get; set; }
        public virtual Usuario UsuarioAmigo { get; set; }
    }
}
