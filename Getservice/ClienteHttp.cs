using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Getservice
{
    class ClienteHttp
    {

        HttpClient Cliente = new HttpClient();
        Uri _uri;
        public string base_url { get; set; }

        /// <summary>
        /// Constructor para que recibe la URL del servicio
        /// </summary>
        /// <param name="url"></param>
        public ClienteHttp(Uri url)
        {
            _uri = url;
        }

        /// <summary>
        /// Devuelve en un string la información del servicio
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            string resultado = Cliente.GetStringAsync(_uri).Result;
            return resultado;
        }

        public void post() {
        
        }

        public void put()
        {

        }

        public void delete()
        {

        }
    }
}
