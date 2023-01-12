using System;
using Xunit;
using BankingLibrary;

namespace TestProject
{
    public class UnitTestOperaciones
    {
        [Fact]
        public void TestAperturaCuentas()
        {
            //Arrange
            bool cuentaValida = false;

            //Act
            //LLamar al metodo de apertura de cuenta
            Operaciones.AperturaCuenta();
            cuentaValida = Operaciones.Abierta;

            Assert.True(cuentaValida);
        }

        [Fact]
        public void TestDeposito()
        {
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(100);
            Assert.Equal(100, Operaciones.Saldo);
        }

        [Fact]
        public void TestRetiro()
        {
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(100);
            Operaciones.Retiro(20);
            Assert.Equal(80, Operaciones.Saldo);
        }

        [Fact]
        public void TestSaldo()
        {
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(100);
            Operaciones.Retiro(100);
            Assert.Equal(0, Operaciones.Saldo);
        }

        [Fact]
        public void TestCantidadMovimientosRealizados()
        {
            var movimientos = 6;

            Operaciones.AperturaCuenta();
            Operaciones.Deposito(100);
            Operaciones.Deposito(100);
            Operaciones.Deposito(100);
            Operaciones.Retiro(100);
            Operaciones.Retiro(100);
            Operaciones.Retiro(100);

            Assert.Equal(movimientos, Operaciones.Movimientos);
        }

        [Fact]
        public void TestSobregiroNoPermitido()
        {
            var sobregiro = false;
            try
            {
                Operaciones.AperturaCuenta();
                Operaciones.Deposito(20);
                Operaciones.Retiro(100);
                sobregiro = Operaciones.Saldo < 0;

                Assert.False(sobregiro);

            } catch (Exception )  {
                Assert.True(true);
            }
        }

        [Fact]
        public void TestRetiroExcepcionSobregiro()
        {
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(20);
            Assert.Throws<ArgumentException>(() => Operaciones.Retiro(100));
        }

        [Fact]
        public void TestRetiroCantidadCeroNoPermitido()
        {
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(100);
            Assert.Throws<ArgumentException>(() => Operaciones.Retiro(0));
        }

        [Fact]
        public void TestDepositoCantidadCeroNoPermitido()
        {
            Operaciones.AperturaCuenta();
            Assert.Throws<ArgumentException>(() => Operaciones.Deposito(0));
        }

        [Fact]
        public void TestCalculoIntereses()
        {
            double deposito = 100;
            double interes = Interes.CalculoInteres(deposito, 0.2);
            double resultado = deposito + interes;

            Operaciones.AperturaCuenta();
            Operaciones.Deposito(deposito);
            Operaciones.PagoDeIntereses();

            Assert.Equal(resultado, Operaciones.Saldo, 4);
        }


        [Fact]
        public void TestPermitirSobregisros()
        {
            var ResultadoEsperado = -950;

            Operaciones.AperturaCuenta();
            Operaciones.Deposito(50);

            Operaciones.CuentaPermiteSobregiros();
            Operaciones.Retiro(1000);

            Assert.Equal(ResultadoEsperado, Operaciones.Saldo, 4);

        }


        [Fact]
        public void TestValidarCuentaInactivaDeposito()
        {
            Operaciones.AperturaCuenta();
            Operaciones.InactivarCuenta();

            Assert.Throws<ArgumentException>(() => Operaciones.Deposito(100));

        }

        [Fact]
        public void TestValidarCuentaInactivaRetiro()
        {
            Operaciones.AperturaCuenta();
            Operaciones.Deposito(100);
            Operaciones.InactivarCuenta();

            Assert.Throws<ArgumentException>(() => Operaciones.Retiro(50));

        }


    }
}
