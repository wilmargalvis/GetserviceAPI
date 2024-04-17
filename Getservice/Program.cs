using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getservice
{
    class Program
    {

       public static void Main()
        {
            Imprimir ImprimirMensaje = new Imprimir();
            Repositorio repositorio = new Repositorio();
            Uri url= new Uri("https://raw.githubusercontent.com/EvanLi/Github-Ranking/master/Data/github-ranking-2022-02-26.csv");
            
            ClienteHttp client = new ClienteHttp(url);
            string result = client.Get(); //Obtiene un string con los datos de la URL del servicio
            List<ListDatos> data = repositorio.GetLista(result); //Recibe los datos del repositorio en una lista ya trasnformada

            ImprimirMensaje.Mensaje("\n               RANKING DEL REPOSITORIO DE GIRHUB              ");
            ImprimirMensaje.Mensaje("\nEscriba el número de items a obtener");

            string nItems = Console.ReadLine();
            string valido = new Validaciones().ValidarEntradaItems(nItems); //Verifica si la entrada del número de items es válida

            if (valido != "") { Console.Clear(); ImprimirMensaje.Mensaje(valido); Main(); }

                else
                {
                    ImprimirMensaje.Mensaje("\nIngrese el nombre del item que desea consultar.");
                    string item = Console.ReadLine();
                    if (item=="") {
                        Console.Clear();
                        ImprimirMensaje.Mensaje("Le faltó ingresar el elemento. Vuelva al menú de inicio");
                        Main();
                    }

                    if (!data.Exists(e => e.item.Equals(item))) { //Verifica si el elemento buscado se encuentra, en la lista devuelta, para no recorrer el resto de código
                        Console.Clear();
                        ImprimirMensaje.Mensaje($"El elemento ' {item} ' no existe en el repositorio. Comprobación inicial \n");
                        Main();
                    }

                    if (item != "")
                        {

                        var listafinal = new List<ListDatos>();
                        ImprimirMensaje.Mensaje("Ingrese el modelo de ordenamiento \n             1 = Ascendente\n             2 = Descendente");
                        string ordenamiento = Console.ReadLine();

                        //Verifica si la entrada del tipo de ordenamiento es válida
                        string validoordenamiento = new Validaciones().validarEntradaOrdenamiento(ordenamiento.ToString());

                        if (validoordenamiento != "") { Console.Clear(); ImprimirMensaje.Mensaje(validoordenamiento); Main(); }

                        else
                            {

                             if (Convert.ToInt16(ordenamiento) == (int)EnumeradorSort.Ascending)
                                {
                                    ordenamiento = "ASC";
                             }
                             else { ordenamiento = "DESC"; }

                             //Realiza la búsqueda con los parámetros de entrada requerida
                             listafinal = repositorio.busqueda(int.Parse(nItems), item, ordenamiento.ToString(), data);
                             Imprimir ImprimirDatos = new Imprimir();
                             ImprimirDatos.ImprimirResultado(listafinal);
                             ImprimirDatos.SaliroContinuar();
                             Environment.Exit(0);

                            }
                        }

                }

        }


      
    }
}
