using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
namespace Final_Estructura_datos
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            Stack PilaPatentes = null;
            while (opcion != 9)
            {
               
                Console.WriteLine("|---------Menu----------------------|");
                Console.WriteLine(" [1] Crear Pila. \n [2] Borrar Pila. \n [3] Agregar Patente. \n [4] Borrar Patente." +
                " \n [5] Listar Patentes \n [6] Listar Ultima Patente. \n [7] Listar Primera Patente. \n [8] Cantidad de Patentes. " +
                "\n [9] Salir. \n [10] Buscador. \n [11] Borrar ultima Patente cargada.");
                Console.WriteLine("|-----------------------------------|");

                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {

                        case 1:
                            Console.Clear();
                            if (PilaPatentes == null || PilaPatentes.Count < 0) 
                            { 
                                PilaPatentes = new Stack();
                                menssageAlert("  **** Pila creada ****", "Green");
                            } else
                            {
                                menssageAlert("  **** Ya existe una Pila ****", "Yellow");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            if (PilaPatentes == null)
                            {
                                menssageAlert("  **** Pila no existe ****", "Yellow");                           
                            }
                            else if (PilaPatentes.Count > 0)
                            {
                                bool corte = true;
                                while (corte)
                                {
                                    menssageAlert("Seguro que desea Eliminar la Pila?, contiene patentes cargadas.  Si/No", "Yellow");

                                    string op = Console.ReadLine();

                                    if (op.ToUpper() == "SI")
                                    {
                                        PilaPatentes.Clear();
                                        menssageAlert("  ****  Pila borrada ****", "Green");
                                        corte = false;
                                    }
                                    else if (op.ToUpper() == "NO")
                                    {
                                        PilaPatentes.Clear();
                                        corte = false; 
                                        
                                    }

                                }
                            }
                            else
                            {
                                PilaPatentes.Clear();
                                menssageAlert("  ****  Pila borrada ****", "Green");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            menssageAlert("Por Favor, Ingrese la patente: ", "Yellow");
                            bool isOk = true;
                            while (isOk)
                            {
                                string patente = Console.ReadLine();
                                if (Regex.IsMatch(patente, "^[a-z-A-Z]{3}[0-9]{3}$"))
                                {
                                    Console.Clear();
                                    PilaPatentes.Push(patente);
                                    menssageAlert("La patente " + patente + " fue agregada con éxito.", "Green");
                                    isOk = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    menssageAlert("la patente " + patente + " esta mal cargada, \n" +
                                        "debe tener 3 caracteres alfabeticos seguidos de 3 caracteres numericos", "Yellow");
                                };
                            }
                            break;
                        case 4:
                            Console.Clear();
                            if (PilaPatentes.Count > 0)
                            {
                                menssageAlert("Patente a Eliminar: ", "Yellow");
                                string input = Console.ReadLine();
                                List<string> auxiliar = new List<string>();

                                foreach (string patent in PilaPatentes)
                                {
                                    if (patent != input)
                                    {
                                        auxiliar.Add(patent);
                                    }
                                }
                                if (auxiliar.Count == PilaPatentes.Count)
                                {
                                    menssageAlert("La Patente " + input + " no se encuentra cargada", "Red");
                                }
                                else
                                {
                                    menssageAlert("La Patente " + input + " fue Borrada con exito", "Green");
                                }

                                PilaPatentes = new Stack(auxiliar);

                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                            break;
                        case 5:
                            Console.Clear();
                            if (PilaPatentes.Count > 0)
                            {
                                int num = 0;
                                menssageAlert("patentes cargadas", "Green");
                                foreach (string patente in PilaPatentes)
                                {
                                    num++;
                                    menssageAlert("" + num + "-" + patente + "", "Green");
                                }
                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                            break;
                        case 6:
                            Console.Clear();
                            if (PilaPatentes.Count > 0)
                            {   
                                
                                Object[] lista = PilaPatentes.ToArray();
                                //lista[lista.Length - 1] ==  lista[^1]
                                menssageAlert("La última Patente es "+ lista[^1] + "", "Blue");


                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                            break;
                        case 7:
                            Console.Clear();
                            if (PilaPatentes.Count > 0)
                            {
                                menssageAlert("La primer Patente es "+ PilaPatentes.Peek() + "", "Blue" );
                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                            break;
                        case 8:
                            Console.Clear();
                            if (PilaPatentes.Count > 0)
                            {

                                menssageAlert("Numero de Patentes: "+ PilaPatentes.Count + "","Blue");
                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                                break;
                        case 9:
                            Console.Clear();
                            bool corte_exit = true;
                            while (corte_exit)
                            {
                                menssageAlert("Seguro que desea SALIR del programa? Si/No", "Yellow");

                                string op = Console.ReadLine();

                                if (op.ToUpper() == "SI")
                                {
                                    Console.Clear();
                                    menssageAlert("Hasta Luego!", "Green");
                                    Environment.Exit(0);                                    
                                }
                                else if (op.ToUpper() == "NO")
                                {
                                    corte_exit = false;
                                    opcion = 0;
                                    Console.Clear();                                   
                                }
                            }                           
                            break;
                        case 10:
                            Console.Clear();
                            if (PilaPatentes.Count > 0)
                            {
                                menssageAlert("Buscador: ", "Yellow");
                                bool noInformation = false;
                                string input = Console.ReadLine();

                                foreach (string patent in PilaPatentes)
                                {
                                    if (patent.IndexOf(input) != -1)
                                    {
                                        noInformation = true;
                                        menssageAlert("" + patent + "", "Blue");
                                    }
                                }
                                if (!noInformation)
                                {
                                    menssageAlert(" No se encontro ninguna pantente con "+ input +" ", "Red");

                                }
                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                            break;
                        case 11:
                            Console.Clear();

                            if (PilaPatentes.Count > 0)
                            {
                                bool corte_delete = true;
                                while (corte_delete)
                                {
                                    menssageAlert("Seguro que desea ELIMINAR la ultima patente? Si/No", "Yellow");

                                    string op = Console.ReadLine();

                                    if (op.ToUpper() == "SI")
                                    {
                                        PilaPatentes.Pop();

                                        menssageAlert("patente ELIMINADA con exito", "Green");

                                        corte_delete = false;
                                    }
                                    else if (op.ToUpper() == "NO")
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                menssageAlert("La Pila no contiene informacion", "Red");
                            }
                            break;
                    }
                
                }catch (FormatException)
                    {
                        Console.Clear();
                        menssageAlert("Ingrese una opcion valida", "Red");                  
                    }

            void menssageAlert(string message, string color)
                {

                    switch (color)
                    {
                        case "Blue":
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(message);
                            Console.WriteLine("");
                            Console.ResetColor();
                            break;
                        case "Red":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(message);
                            Console.WriteLine("");
                            Console.ResetColor();
                            break;
                        case "Yellow":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(message);
                            Console.WriteLine("");
                            Console.ResetColor();
                            break;
                        case "Green":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(message);
                            Console.WriteLine("");
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

}
