using System;
using System.Collections.Generic;
using System.Text;

namespace LojaGratis_V1.Tables
{
    class Produtos
    {

        public string Id { get; set; }
        public int codigo { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public Boolean inativo { get; set; }
    }
}
