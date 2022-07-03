using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrocadilhosWebApp.Models
{
    public class Trocadilho
    {
        public int Id { get; set; }
        public String TrocadilhoQuestion { get; set; }
        public String TrocadilhoAnswer { get; set; }

        public Trocadilho()
        {

        }
    }
}
