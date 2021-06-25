using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contatos.Models
{
    public class Numeros
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public int Operadora { get; set; }
    }

    public class NumerosDBContext : DbContext
    {
        public DbSet<Numeros> Numero { get; set; }
    }
}