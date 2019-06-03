using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilWarBot
{
    class Program
    {
        static void Main(string[] args)
        {
            SeteoNacProv snp = new SeteoNacProv();
            snp.Jugar();
                Console.ReadKey();
        }
    }
}
