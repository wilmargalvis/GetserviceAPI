using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getservice
{
  public  class Validaciones
    {

        /// <summary>
        /// Valida la entrada del número de items a requerir del tipo de elemento del repositorio, cumpla las condiciones dadas
        /// </summary>
        /// <param name="entradaUsuario"></param>
        /// <returns></returns>
        public string ValidarEntradaItems(string entradaUsuario)
        {
            bool esNumero = int.TryParse(entradaUsuario, out int valor);
            string mensaje = "";

            if (entradaUsuario == "")
            {
                mensaje = "No ingresó la información solicitada";
            }else
                if (!esNumero)
                {
                    mensaje = "No es un número o entrada válida";
                }else
                 if (Convert.ToInt32(entradaUsuario) > 10)
                    {
                        mensaje = "\nNo es posible devolver más de 10 registros. Vuelva al menú de inicio";
                    }else
                        if (entradaUsuario == "0")
                        {
                            mensaje = "Ingrese un número mayor a cero (0)";
                        }

            return mensaje;
        }


        /// <summary>
        /// Valida que la entrada del nombre del item a requerir del repositorio, cumpla las condiciones dadas
        /// </summary>
        /// <param name="ordenamiento"></param>
        /// <returns></returns>
        public string validarEntradaOrdenamiento(string ordenamiento)
        {
            bool esNumero = int.TryParse(ordenamiento, out int valor);
            string mensaje = "";

            if (ordenamiento == "")
            {
                mensaje = "Aún no ha ingresado una opción de ordenamiento válida";
            }else
                if (!esNumero)
                {
                    mensaje = "No es un número o entrada válida para el tipo de ordenamiento";
                }
                else
                    if (int.Parse(ordenamiento) > 2 || int.Parse(ordenamiento) == 0)
                    {
                         mensaje = "\nIngrese una opcíon válida de ordenamiento (solo 1 o 2)";
                    }

            return mensaje;
        }


    }
}
