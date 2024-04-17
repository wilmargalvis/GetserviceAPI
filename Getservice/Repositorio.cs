using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getservice
{

    public class Repositorio
    {

        /// <summary>
        /// Transforma la información del servicio a una lista de tipo clase ListDatos
        /// Pasa a un vector las filas encontradas en el servicio
        /// Divide cada fila del vector por coma(,) y lo lleva a un objeto. Asigna cada objeto a la lista
        /// Devuelve la lista
        /// </summary>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public List<ListDatos> GetLista(string resultado)
        {
            List<ListDatos> listaDatos = new List<ListDatos>();
            string[] fila = resultado.Split('\n');
            int i = 0;
            foreach (string reg in fila)
            {

                if (i > 0)
                {

                    try
                    {
                        string[] filarecorrida = reg.Split(',');
                        ListDatos _objlista = new ListDatos();

                        if (filarecorrida[0] != "")
                        {

                            _objlista.rank = Convert.ToInt32(filarecorrida[0]);
                            _objlista.item = filarecorrida[1];
                            _objlista.repo_name = filarecorrida[2];
                            _objlista.stars = filarecorrida[3];

                            listaDatos.Add(_objlista);
                        }

                    }
                    catch (Exception e)
                    {

                        throw;
                    }

                }


                i++;
            }

            return listaDatos;
        }



        /// <summary>
        /// Busca en la lista de acuerdo a los siguientes parámetros de entrada. Cantidad de Items, Nombre del Items, y tipo de ordenamiento(ascenente y descendente)
        /// Utiliza Linq para odenar la información de la lista
        /// </summary>
        /// <param name="numItem"></param>
        /// <param name="iteName"></param>
        /// <param name="sort"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public  List<ListDatos> busqueda(int numItem, string iteName, string sort, List<ListDatos> lista)
        {
            List<ListDatos> listafiltrada = new List<ListDatos>();
            var data = new List<ListDatos>();

            foreach (ListDatos objeto in lista)
            {

                if (iteName != "")
                {


                    if (listafiltrada.Count() < numItem)
                    {
                        if (objeto.item.Contains(iteName))
                        {
                            listafiltrada.Add(objeto);
                        }
                    }

                }


            }

            if (listafiltrada.Count() == 0)
            {
                new Imprimir().Mensaje("\nNo se encontró el nombre del elemento buscado");
                new Imprimir().SaliroContinuar();
            }


            switch (sort)
            {
                case "ASC":

                  
                    data = (from datos in listafiltrada orderby datos.rank ascending select datos).ToList();
                    break;

                case "DESC":
                    data = (from datos in listafiltrada orderby datos.rank descending select datos).ToList();
                    break;

                default:
                    data = (from datos in listafiltrada orderby datos.rank descending select datos).ToList();
                    break;
            }


            return data;

        }


    }
}
