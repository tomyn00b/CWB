using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace CivilWarBot
{
    public class SeteoNacProv
    {
        private Clases.Provincia[] _Provincias;
        public Clases.Provincia[] Provincias
        {
            get { return _Provincias; }

            set { _Provincias = value; }
        }

        private Clases.Nacion[] _Naciones;
        public Clases.Nacion[] Naciones
        {
            get { return _Naciones; }

            set { _Naciones = value; }
        }

        private int _TRestantes;
        public int TRestantes
        {
            get { return _TRestantes; }

            set { _TRestantes = value; }
        }

        private int _Tier;
        public int Tier
        {
            get { return _Tier; }

            set { _Tier = value; }
        }

        private int[] _Cola;
        public int[] Cola
        {
            get { return _Cola; }

            set { _Cola = value; }
        }

        private Queue<int> _LPosibles;
        public Queue<int> LPosibles
        {
            get { return _LPosibles; }

            set { _LPosibles = value; }
        }

        public SeteoNacProv()
        {
            TRestantes = 24;
            Tier = 5;
            Cola = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Cola[i] = 24;
            }
            LPosibles = new Queue<int>();
            Provincias = new Provincia[24];
            Naciones = new Nacion[24];
            for (int i = 0; i < 24; i++)
            {
                Provincias[i] = new Provincia();
                Naciones[i] = new Nacion();
            }
            Provincias[0].Nombre = "Ciudad autónoma de Buenos Aires";
            Provincias[1].Nombre = "Buenos Aires";
            Provincias[2].Nombre = "Cordoba";
            Provincias[3].Nombre = "Santa Fe";
            Provincias[4].Nombre = "La Pampa";
            Provincias[5].Nombre = "Entre Rios";
            Provincias[6].Nombre = "Tierra del Fuego, Antártida e Islas del Atlántico Sur";
            Provincias[7].Nombre = "Corrientes";
            Provincias[8].Nombre = "Misiones";
            Provincias[9].Nombre = "Chaco";
            Provincias[10].Nombre = "Formosa";
            Provincias[11].Nombre = "Santiago del estero";
            Provincias[12].Nombre = "San Luis";
            Provincias[13].Nombre = "Mendoza";
            Provincias[14].Nombre = "San Juan";
            Provincias[15].Nombre = "La Rioja";
            Provincias[16].Nombre = "Catamarca";
            Provincias[17].Nombre = "Tucumán";
            Provincias[18].Nombre = "Salta";
            Provincias[19].Nombre = "Jujuy";
            Provincias[20].Nombre = "Rio Negro";
            Provincias[21].Nombre = "Neuquén";
            Provincias[22].Nombre = "Chubut";
            Provincias[23].Nombre = "Santa Cruz";
            for (int i = 0;i<24; i++)
            {
                Provincias[i].Id_prov = i;
                Provincias[i].Ocupado = i;
                Naciones[i].Id_nac = Provincias[i].Id_prov;
                Naciones[i].Nombre = Provincias[i].Nombre;
                Naciones[i].Cant_terr = 1;
            }
            Provincias[0].Limites = new int[] {1};
            Provincias[1].Limites = new int[] {0,2,3,4,5,20};
            Provincias[2].Limites = new int[] {1,3,4,11,12,15,16};
            Provincias[3].Limites = new int[] {1,2,5,7,9,11};
            Provincias[4].Limites = new int[] {1,2,12,13,20};
            Provincias[5].Limites = new int[] {1,3,7};
            Provincias[6].Limites = new int[] {23};
            Provincias[7].Limites = new int[] {3,5,8,9};
            Provincias[8].Limites = new int[] {7};
            Provincias[9].Limites = new int[] {3,7,10,11,18};
            Provincias[10].Limites = new int[] {9,18};
            Provincias[11].Limites = new int[] {2,3,9,16,17,18};
            Provincias[12].Limites = new int[] {2,4,13,14,15};
            Provincias[13].Limites = new int[] {4,12,14,21};
            Provincias[14].Limites = new int[] {12,13,15};
            Provincias[15].Limites = new int[] {2,12,14,16};
            Provincias[16].Limites = new int[] {2,11,15,17,18};
            Provincias[17].Limites = new int[] {11,16,18};
            Provincias[18].Limites = new int[] {9,10,11,16,17,19};
            Provincias[19].Limites = new int[] {18};
            Provincias[20].Limites = new int[] {1,4,21,22};
            Provincias[21].Limites = new int[] {13,20};
            Provincias[22].Limites = new int[] {20,23};
            Provincias[23].Limites = new int[] {6,22};
        }

        public void Jugar()
        {
            Console.WriteLine("QUE EMPIEZE LA MASACRE!!!");
            bool flagero = false;
            while (flagero == false)
            { 
                Console.WriteLine();
                Console.WriteLine("Pulsa enter para la siguiente iteracion.");
                Console.ReadKey();
                Jugada();
                if(TRestantes == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine(Naciones[Provincias[0].Ocupado].Nombre+" ha conquistado toda la Argentina!!!");
                    flagero = true;
                }
            }
        }

        public void Jugada()
        {
            Console.Clear();
            int dado = 0;
            bool f = true;
            Random r = new Random();
            while (f == true)
            { 
                dado = r.Next(24);
                f = false;
                if(Tier != 0)
                {
                    for (int i = 0; i < Tier; i++)
                    {
                        if (Provincias[dado].Ocupado == Cola[i])
                        {
                            f = true;
                            break;
                        }
                    }
                }
            }


            int idAtacante = Provincias[dado].Ocupado;

            if(Tier != 0)
            {
                for(int i = Tier -1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Cola[i] = Provincias[dado].Ocupado;
                    }
                    else
                    {
                        Cola[i] = Cola[i - 1];
                    }
                }
                
            }

            for (int i = 0;i < 24;i++)
            {
                if (Provincias[i].Ocupado == idAtacante)
                {
                    foreach(int x in Provincias[i].Limites)
                    {
                        if(Provincias[x].Ocupado != idAtacante)
                        {
                            if(!LPosibles.Contains(x))
                                LPosibles.Enqueue(x);
                        }
                    }
                }
            }

            f = false;
            int lp = LPosibles.Count();
            int attackDado = r.Next(lp);
            int ataque = 0;
            while (f == false)
            {
                if(attackDado == 0)
                {
                    ataque = LPosibles.Peek();
                    LPosibles.Clear();
                    f = true;
                }
                else
                {
                    attackDado--;
                    LPosibles.Dequeue();
                }
            }

            int idAtacado = Provincias[ataque].Ocupado;

            Naciones[idAtacante].Cant_terr++;
            Naciones[idAtacado].Cant_terr--;
            Provincias[ataque].Ocupado = idAtacante;

            Console.WriteLine();
            Console.WriteLine(Naciones[idAtacante].Nombre + " ha conquistado la provincia de "+Provincias[ataque].Nombre+",");
            Console.WriteLine("anteriormente bajo control de " + Naciones[idAtacado].Nombre + ".");
            if (Naciones[idAtacado].Cant_terr == 0)
            {
                Console.WriteLine();
                Console.WriteLine(Naciones[idAtacado].Nombre+" ha sido eliminado!!!");
                TRestantes--;
                if(TRestantes > 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Quedan " + TRestantes + " naciones restantes!");
                }
                if (TRestantes == 4 || TRestantes == 8 || TRestantes == 12 || TRestantes == 16 || TRestantes == 20)
                { 
                    Cola[Tier - 1] = 25;
                    Tier--;
                }
            }
        }
    }
}
