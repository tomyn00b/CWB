using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Provincia
    {
        private int _Id_prov;
        public int Id_prov
        {
            get
            {
                return _Id_prov;
            }
            set
            {
                _Id_prov = value;
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

        private int _Ocupado;
        public int Ocupado
        {
            get
            {
                return _Ocupado;
            }
            set
            {
                _Ocupado = value;
            }
        }

        private int[] _Limites;
        public int[] Limites
        {
            get
            {
                return _Limites;
            }
            set
            {
                _Limites = value;
            }
        }

    }
}
