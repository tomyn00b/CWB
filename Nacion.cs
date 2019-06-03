using System;

namespace Clases
{
    public class Nacion
    {
        private int _Id_nac;
        public int Id_nac
        {
            get
            {
                return _Id_nac;
            }
            set
            {
                _Id_nac = value;
            }
        }

        private string _Nombre;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        private int _Cant_terr;
        public int Cant_terr
        {
            get
            {
                return _Cant_terr;
            }
            set
            {
                _Cant_terr = value;
            }
        }
    }
}
