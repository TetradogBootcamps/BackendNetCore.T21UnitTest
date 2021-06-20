using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometria;


namespace GabrielCortesT21Testing
{
    [TestClass]
    public class FiguraTest
    {
        [TestMethod]
        public void TestAreaCuadrado() => TestAreaFiguraGenerico(Figura.CUADRADO, 100.0, 10);
        [TestMethod]
        public void TestAreaCirculo() => TestAreaFiguraGenerico(Figura.CIRCULO, 12.566, 2);
        void TestAreaFiguraGenerico(int figuraId, double result, params int[] args)
        {
            const int DECIMALES = 2;

            Figura figura = new Figura(figuraId);

            Assert.IsTrue(Math.Round(result, DECIMALES) - Math.Round(figura.Area(args), DECIMALES) == 0);
        }
    }

}
