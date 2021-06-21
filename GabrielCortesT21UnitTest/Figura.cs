using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Geometria
{
    public class Figura
    {
        public const int CUADRADO = 0;
        public const int CIRCULO = CUADRADO+1;
        public const int TRIANGULO = CIRCULO + 1;
        public const int RECTANGULO = TRIANGULO + 1;
        public const int PENTAGONO = RECTANGULO + 1;
        public const int ROMBO = PENTAGONO + 1;
        public const int ROMBOIDE = ROMBO + 1;
        public const int TRAPECIO = ROMBOIDE + 1;

        public const int PRIMERO = CUADRADO;
        public const int ULTIMO = TRAPECIO;
        public const int DEFAULT = ULTIMO+1;

        private int id;


        //Constructores
        public Figura(int id)=> Id = id;



        public int Id { 
            get => id; 
            set {

                if (value < PRIMERO || value > ULTIMO)
                    throw new ArgumentOutOfRangeException();

                else id = value; 
            }
        }
        public string Nom => GetNameFigura(Id);
        public IEnumerable<string> Args
        {
            get
            {
              
                string nombreMetodo = $"Area{Nom}";
                MethodInfo method= typeof(Figura).GetMethod(nombreMetodo, BindingFlags.Static | BindingFlags.Public);
                return method.GetParameters().Select(p=>p.Name);
            }
        }
        public double Area(IList<int> args) => Area(args.ToArray());
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
                case CUADRADO:
                    result = AreaCuadrado(args[0]);
                    break;
                case CIRCULO:
                    result = AreaCirculo(args[0]);
                    break;
                case TRIANGULO:
                    result = AreaTriangulo(args[0], args[1]);
                    break;
                case RECTANGULO:
                    result = AreaRectangulo(args[0], args[1]);
                    break;
                case PENTAGONO:
                    result = AreaPentagono(args[0], args[1]);
                    break;
                case ROMBO:
                    result = AreaRombo(args[0], args[1]);
                    break;
                case ROMBOIDE:
                    result = AreaRomboide(args[0], args[1]);
                    break;
                case TRAPECIO:
                    result = AreaTrapecio(args[0], args[1], args[2]);
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }



      
        //Selector de figuras


        public override string ToString()
        {
            return Nom;
        }

        #region Metodos Area
        //Métodos propios de clase Geometria
        //metodo area del cuadrado
        public static int AreaCuadrado(int lado)
        {
            return lado * lado;
        }
        //metodo area del circulo
        public static double AreaCirculo(int radio)
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        //metodo area del triangulo
        public static double AreaTriangulo(int longitudBase, int altura)
        {
            return longitudBase * altura / 2.0;
        }

        //metodo area del rectangulo
        public static int AreaRectangulo(int ancho, int alto)
        {
            return ancho * alto;
        }

        //metodo area del rectangulo
        public static double AreaPentagono(int perimetro, int apotema)
        {
            return perimetro * apotema / 2.0;
        }

        //metodo area del rectangulo
        public static double AreaRombo(int diagonalMayor, int diagonalMenor)
        {
            return diagonalMayor * diagonalMenor/ 2.0;
        }

        //metodo area del rectangulo
        public static int AreaRomboide(int longitudBase, int altura)
        {
            return longitudBase * altura;
        }

        //metodo area del rectangulo
        public static double AreaTrapecio(int baseMayor, int baseMenor, int altura)
        {
            return (baseMayor + baseMenor / 2.0) * altura;
        }
        #endregion

        public static string GetNameFigura(int fiCode)
        {
            string figura;

            switch (fiCode)
            {
                case CUADRADO:
                    figura = "Cuadrado";
                    break;
                case CIRCULO:
                    figura = "Circulo";
                    break;
                case TRIANGULO:
                    figura = "Triangulo";
                    break;
                case RECTANGULO:
                    figura = "Rectangulo";
                    break;
                case PENTAGONO:
                    figura = "Pentagono";
                    break;
                case ROMBO:
                    figura = "Rombo";
                    break;
                case ROMBOIDE:
                    figura = "Romboide";
                    break;
                case TRAPECIO:
                    figura = "Trapecio";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fiCode));
            }
            return figura;

        }



    }
}
