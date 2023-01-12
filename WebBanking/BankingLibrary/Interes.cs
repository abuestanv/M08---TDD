using System;

namespace BankingLibrary
{
    public static class Interes
    {
        public static double CalculoInteres(double monto, double tasa)
        {
            double interes = 0;
            int dias = 365;
            if (monto <= 0)
                interes = 0;
            else
                interes = monto * tasa / dias;
            return interes;
        }
    }
}
