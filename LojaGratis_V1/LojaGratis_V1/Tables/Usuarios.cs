using System;
using System.Collections.Generic;
using System.Text;

namespace LojaGratis_V1.Tables
{
    class Usuarios
    {
        public string Id { get; set; }
        public int codigo { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public Boolean bloqueado { get; set; }
        public Boolean admin { get; set; }

    }
}
