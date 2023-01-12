using System;
using Xunit;
using BankingLibrary;

namespace TestProject
{
    public class UnitTestInteres
    {
        [Fact]
        public void TestInteres1()
        {
            double monto = 100;
            double tasa = 0.2;
            double resultado = 0;
            resultado = Interes.CalculoInteres(monto, tasa);
            Assert.Equal(0.0548, resultado, 4);

        }
        [Fact]
        public void TestInteres2()
        {
            double monto = 0;
            double tasa = 0.2;
            double resultado = 0;
            resultado = Interes.CalculoInteres(monto, tasa);
            Assert.Equal(0, resultado, 4);

        }

        [Fact]
        public void TestInteres3()
        {
            double monto = -100;
            double tasa = 0.2;
            double resultado = 0;
            resultado = Interes.CalculoInteres(monto, tasa);
            Assert.Equal(0, resultado, 4);

        }
    }
}
