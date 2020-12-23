using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INSS.UnitTest
{
    [TestClass]
    public class Calculador
    {
        [TestMethod]
        public void DadoNaoEncontrado()
        {
            var calculador = new CalculadorInss();
            Assert.ThrowsException<ArgumentException>(() => calculador.CalcularDesconto(new DateTime(2020, 12, 31), 1000));
        }

        [TestMethod]
        public void Aliquota_8_2011()
        {
            var calculador = new CalculadorInss();
            var resultado = calculador.CalcularDesconto(new DateTime(2011, 12, 31), 1000);
            Assert.AreEqual(resultado, 80);
        }
    }
}
