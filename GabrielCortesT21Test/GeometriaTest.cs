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
        [TestMethod]
        public void TestAreaTriangulo() => TestAreaFiguraGenerico(Figura.TRIANGULO, 10,10,2);

        [TestMethod]
        public void TestAreaRectangulo() => TestAreaFiguraGenerico(Figura.RECTANGULO, 20, 10, 2);

        [TestMethod]
        public void TestAreaPentagono() => TestAreaFiguraGenerico(Figura.PENTAGONO, 10.0, 10, 2);
        [TestMethod]
        public void TestAreaRombo() => TestAreaFiguraGenerico(Figura.ROMBO, 10.0, 10, 2);
        [TestMethod]
        public void TestAreaRomboide() => TestAreaFiguraGenerico(Figura.ROMBOIDE, 20, 10, 2);
        [TestMethod]
        public void TestAreaTrapecio() => TestAreaFiguraGenerico(Figura.TRAPECIO, 22.5, 10,5,3);

        void TestAreaFiguraGenerico(int figuraId, double resultEsperado, params int[] args)
        {
            const int DECIMALES = 2;

            Figura figura = new Figura(figuraId);
            double resultCalculado = figura.Area(args);

            Assert.IsTrue(Math.Round(resultEsperado, DECIMALES) - Math.Round(resultCalculado, DECIMALES) == 0);
        }
    }

}
