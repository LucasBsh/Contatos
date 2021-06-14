using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class Numeros
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public int numero { get; set; }
    }

    public class NumerosDBContext : DbContext
    {
        public DbSet<Numeros> Numero { get; set; }
    }
}