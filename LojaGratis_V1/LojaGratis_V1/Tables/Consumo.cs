using System;
using System.Collections.Generic;
using System.Text;

namespace LojaGratis_V1.Tables
{
    class Consumo
    {
        public string Id { get; set; }
        public int usuario { get; set; }
        public string produto { get; set; }
        public DateTime data { get; set; }
        public string hora { get; set; }
        public double preco { get; set; }
        public Boolean pago { get; set; }
        public int ordem { get; }

    }
}
