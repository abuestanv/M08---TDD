using System;
using System.Collections.Generic;
using System.Text;

namespace BankingLibrary
{
    public static class Operaciones
    {
        public static string Cuenta { get; set; }
        public static double Saldo { get; set; }
        public static bool Abierta { get; set; }
        public static int Movimientos { get; set; }
        private static bool PermitirSobregiros { get; set; }


        public static void AperturaCuenta()
        {
            Cuenta = "1001";
            Abierta = true;
            Saldo = 0;
            Movimientos = 0;
            PermitirSobregiros = false;
        }

        public static void Deposito(double valor)
        {
            if(!Abierta) { throw new ArgumentException("La cuenta no se encuentra activa"); }

            if(valor <= 0) { throw new ArgumentException("El valor del deposito debe ser mayor a cero"); }
        
            Saldo += valor;
            Movimientos += 1;
        }
        public static void Retiro(double valor)
        {
            if (!Abierta) { throw new ArgumentException("La cuenta no se encuentra activa"); }

            if (valor <= 0) { throw new ArgumentException("El valor del retiro debe ser mayor a cero"); }
        
            if((Saldo - valor) < 0 && !PermitirSobregiros) { throw new ArgumentException("El valor del retiro sobregira la cuenta"); }

            Saldo -= valor;
            Movimientos += 1;
        }


        public static void PagoDeIntereses()
        {
            var intereses = Interes.CalculoInteres(Saldo, 0.2);
            Deposito(intereses);

        }

        public static void CuentaPermiteSobregiros()
        {
            PermitirSobregiros = true;
        }

        public static void CuentaNoPermiteSobregiros()
        {
            PermitirSobregiros = false;
        }


        public static void InactivarCuenta() 
        {
            Abierta = false;
        }

        public static void ActivarCuenta()
        {
            Abierta = true;
        }


    }
}
