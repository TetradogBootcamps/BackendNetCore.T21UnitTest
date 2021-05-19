using System;
using System.Collections.Generic;
using System.Text;

namespace Geometria
{
    public class Figura
    {
        public const int CUADRADO = 0;
        public const int CIRCULO = CUADRADO+1;


        public const int PRIMERO = CUADRADO;
        public const int ULTIMO = 8;
        public const int DEFAULT = ULTIMO+1;

        private int id;


        //Constructores
        public Figura(int id=DEFAULT)
        {
            this.Id = id;
        }


        public int Id { 
            get => id; 
            set { 

                if (value < PRIMERO || value>ULTIMO)
                    id = DEFAULT;
                
                else id = value; 
            }
        }
        public string Nom => ToString();

        /// <summary>
        /// Método que usa el Id para saber que geometria se usa.
        /// </summary>
        /// <param name="args">Se tiene que manterner el numero de argumentos y su orden del metodo especifico para cada figura</param>
        /// <returns>area figura</returns>
        public double Area(params int[] args)
        {
            double result;

            switch (Id)
            {
                case 1:
                    result = AreaCuadrado(args[0]);
                    break;
                case 2:
                    result = AreaCirculo(args[0]);
                    break;
                case 3:
                    result = AreaTriangulo(args[0], args[1]);
                    break;
                case 4:
                    result = AreaRectangulo(args[0], args[1]);
                    break;
                case 5:
                    result = AreaPentagono(args[0], args[1]);
                    break;
                case 6:
                    result = AreaRombo(args[0], args[1]);
                    break;
                case 7:
                    result = AreaRomboide(args[0], args[1]);
                    break;
                case 8:
                    result = AreaTrapecio(args[0], args[1], args[2]);
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }

        //Métodos propios de clase Geometria
        //metodo area del cuadrado
        public int AreaCuadrado(int lado)
        {
            return lado * lado;
        }

        //metodo area del circulo
        public double AreaCirculo(int r)
        {
            return Math.PI * Math.Pow(r, 2);
        }

        //metodo area del triangulo
        public double AreaTriangulo(int longitudBase, int altura)
        {
            return (longitudBase * altura) / 2.0;
        }

        //metodo area del rectangulo
        public int AreaRectangulo(int b, int h)
        {
            return b * h;
        }

        //metodo area del rectangulo
        public double AreaPentagono(int p, int a)
        {
            return (p * a) / 2.0;
        }

        //metodo area del rectangulo
        public double AreaRombo(int diagonalMayor, int diagonalMenor)
        {
            return (diagonalMayor * diagonalMenor) / 2.0;
        }

        //metodo area del rectangulo
        public int AreaRomboide(int b, int h)
        {
            return b * h;
        }

        //metodo area del rectangulo
        public double AreaTrapecio(int baseMayor, int baseMenor, int h)
        {
            return ((baseMayor + baseMenor) / 2.0) * h;
        }

        //Selector de figuras


        public override string ToString()
        {
            return GetNameFigura(Id);
        }
        public static String GetNameFigura(int fiCode)
        {
            String figura;

            switch (fiCode)
            {
                case 1:
                    figura = "Cuadrado";
                    break;
                case 2:
                    figura = "Circulo";
                    break;
                case 3:
                    figura = "Triangulo";
                    break;
                case 4:
                    figura = "Rectangulo";
                    break;
                case 5:
                    figura = "Pentagono";
                    break;
                case 6:
                    figura = "Rombo";
                    break;
                case 7:
                    figura = "Romboide";
                    break;
                case 8:
                    figura = "Trapecio";
                    break;
                default:
                    figura = "Default";
                    break;
            }
            return figura;

        }



    }
}
