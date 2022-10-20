using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Appdomain1
{
    class Program
    {
        static void Main(string[] args)
        {
            //obtenemos la lista de procesos del pc
            var procesos= from proc in Process.GetProcesses()
            orderby proc.Id select proc;

            //recorremos los procesos encontrados
            foreach (var proceso in procesos)
            {
                //imprimimos el ID y el nombre
                Console.WriteLine("Process ID: {0}, Nombre: {1}", proceso.Id, proceso.ProcessName);

                Console.WriteLine("------------------");

            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("--inicio y finalizacion de procesos--");
            //iniciar y finalizar procesos


            try
            {
                //Iniciamos el proceso y le pasamos un parametro
                Console.WriteLine("puede intentar ingresar como nombre:explorer y como parametro: Documentos \n");
                Console.WriteLine("ingrese el nombre del proceso a iniciar: ");
                string nombrep = Console.ReadLine();
                Console.WriteLine("\ningrese el parametro: ");
                string parametro = Console.ReadLine();
                Process otroproceso =  Process.Start(nombrep,parametro);
                //Process otroproceso = Process.Start("explorer");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\noprime una tecla para continuar a la finalizacion de procesos");
            Console.ReadLine();

            try
            {
                //finalizamos el proceso
                Console.WriteLine("\ningrese el nombre del proceso que desea finalizar: ");
                string nombrep = Console.ReadLine();
                foreach (var otroproceso in Process.GetProcessesByName(nombrep))
                {
                    otroproceso.Kill();
                }
                //otroproceso.Kill(); 
                
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
     
    }
}