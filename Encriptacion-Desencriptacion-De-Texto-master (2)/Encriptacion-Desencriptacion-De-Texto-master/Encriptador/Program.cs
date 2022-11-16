using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encriptar
{
    class Program
    {

        static void Main(string[] args)
        {
            //variable para guardar la opcion queel usuario ingrese
            int opcion = 0;
            //siclo para no dejar de mostrar el menu hasta que el usuario ingrese la opcion 3
            while (opcion != 3)
            {
                Console.WriteLine("\nBienvenido al programa de encriptacion");
                Console.WriteLine("1. Encriptar texto");
                Console.WriteLine("2. Desencriptar texto");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Ingrese una opcion");
                //Try catch por si el usuario ingresa un valor que no sea un numero le mande un mensaje de error
                try
                {
                    //validacion de la opcion ingresada por el usuario para entrar en un case
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            //llamado al metodo encriptar
                            Encriptar();
                            break;
                        case 2:
                            //llamado al metodo desencriptar
                            Desencriptar();
                            break;
                        case 3:
                            //mensaje de salida
                            Console.WriteLine("Gracias por usar el programa");
                            break;
                        default:
                            //mensaje de error si el usuario ingresa una opcion que no esta en el menu
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                }
                catch (Exception)
                {
                    //mensaje de error si el usuario ingresa un valor que no sea un numero
                    Console.WriteLine("Opcion no valida");
                }
            }
            //Console.ReadKey para evitar que se cierre la consola
            Console.ReadKey();

           //Metodo de encriptar estatico y asincrono
           async static void Encriptar()
            {
                //arreglo con las letras del alfabeto
                char[] alfabeto = new char[26];
                char letra;
                int posicion = 0;
                //llenar el arreglo con las letras del alfabeto
                for (int i = 0; i < alfabeto.Length; i++)
                {
                    letra = Convert.ToChar(i + 65);
                    alfabeto[i] = letra;
                }
                //pedir el texto a encriptar
                Console.WriteLine("Ingrese el texto a encriptar");
                string texto = Console.ReadLine();
                //convertir el texto a mayusculas
                texto = texto.ToUpper();
                //recorrer el texto letra por letra
                for (int i = 0; i < texto.Length; i++)
                {
                    //buscar la posicion de cada letra en el arreglo
                    for (int j = 0; j < alfabeto.Length; j++)
                    {
                        if (texto[i] == alfabeto[j])
                        {
                            posicion = j + 1;
                            break;
                        }
                    }
                    //matriz auxiliar con la que se va multuplicar la matriz generada por el usuario
                    int[] a = new int[] { 1, 3, 5, 7, 9 };
                    //multiplicar la matriz generada por el usuario por la matriz auxiliar
                    int resultado = posicion * a[i % 5];
                    //guardar el resultado en un arreglo
                    int[] b = new int[5];
                    b[i % 5] = resultado;
                    //mostrar el resultado
                    Console.Write(b[i % 5] + " ");

                }
            }
            //Metodo de encriptar estatico y asincrono
            async static void Desencriptar()
            {
                //Preguntar al usuario cuantos numeros va a ingresar
                Console.WriteLine("Ingrese la cantidad de numeros a desencriptar");
                //Variable para guardar la cantidad de numeros a ingresar
                int cantidad = 0;
                //Try catch por si el usuario ingresa un valor que no sea un numero le mande un mensaje de error
                try
                {
                    cantidad = Convert.ToInt32(Console.ReadLine());
                    //guardar los numeros que ingresa el usuario en un arreglo
                    int[] numeros = new int[cantidad];
                    for (int i = 0; i < numeros.Length; i++)
                    {
                        Console.WriteLine("Ingrese el numero " + (i + 1));
                        numeros[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    //desencriptar los numeros con la misma matriz auxiliar y mostrar el resultado en texto
                    int[] a = new int[] { 1, 3, 5, 7, 9 };
                    int posicion = 0;
                    for (int i = 0; i < numeros.Length; i++)
                    {
                        posicion = numeros[i] / a[i % 5];
                        Console.Write(Convert.ToChar(posicion + 64));
                    }
                }
                //mensaje de error si el usuario ingresa un valor que no sea un numero
                catch (Exception)
                {
                    Console.WriteLine("Cantidad no valida");
                }
            }
        }
        }
}
