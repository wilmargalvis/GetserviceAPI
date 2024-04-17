using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getservice
{
    class Imprimir
    {
        /// <summary>
        /// Recibe la lista de elementos requeridos con el ordenamiento deseado y los imprime
        /// </summary>
        /// <param name="lista"></param>
        public void ImprimirResultado(List<ListDatos> lista)
        {
            foreach (ListDatos item in lista)
            {

                Console.WriteLine($"El número {item.rank} del ranking de {item.item} es el repositorio" +
                    $" {item.repo_name} con {item.stars} estrellas");
            }
        }

        /// <summary>
        /// Se le pregunta al usuario si desea volver a iniciar el programa o desea salir
        /// </summary>
        public void SaliroContinuar()
        {
            Console.WriteLine("\nPresione una tecla para salir, o escriba la letra S para reiniciar el programa");
            string respuesta = Console.ReadLine();
            if (respuesta == "S" || respuesta == "s")
            {
                Console.Clear();
                Program.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Imprime los mensajes del en la consola
        /// </summary>
        /// <param name="mensaje"></param>
        public void Mensaje(string mensaje) {
            Console.WriteLine(mensaje + "\n");
        }
    }
}
