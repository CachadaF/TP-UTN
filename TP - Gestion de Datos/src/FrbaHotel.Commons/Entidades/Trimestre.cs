using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Commons.Entidades
{
    public class Trimestre
    {
        public static DateTime calcularFechaTrimestre(int anio, int trimestre)
        {
            DateTime retorno;
            switch (trimestre)
            {
                case 1:
                    {
                        retorno = new DateTime(anio, 1, 1);
                        break;
                    }
                case 2:
                    {
                        retorno = new DateTime(anio, 4, 1);
                        break;
                    }
                case 3:
                    {
                        retorno = new DateTime(anio, 7, 1);
                        break;
                    }
                default:
                    {
                        retorno = new DateTime(anio, 10, 1);
                        break;
                    }
            }
            return retorno;
        }
    }
}