using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace CpNegocio.Gmail
{
    //TODO: Clase que representa la configuración de Gmail para enviar correos electrónicos
    public class Configuracion
    {
        //Propiedades para almacenar la configuración de Gmail
        public string GmailSenderEmail { get; set; }
        public string GmailApplicationPassword { get; set; }

        //TODO: Método para guardar la configuración en un archivo JSON
        public static Configuracion Cargar()
        {
            //Cargar la configuración desde un archivo JSON llamado "credentials.json"
            string filePath = "credentials.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Configuracion>(json); //Deserializar el JSON a un objeto Configuracion
            }
            //Si el archivo no existe, lanzar una excepción indicando que el archivo de credenciales no fue encontrado.
            throw new FileNotFoundException("El archivo de credenciales 'credentials.json' no fue encontrado.");
        }
    }
}
