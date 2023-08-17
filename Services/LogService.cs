using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace PruebaRossell.Services
{
    public class LogService
    {
        /// <summary>
        /// Modelo de parametros del AppSetting
        /// </summary>
        private static IConfiguration config;

        /// <summary>
        /// convierte el json a modelo 
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                config = builder.Build();
                return config;
            }
        }

        /// <summary>
        /// permisos para escribir el archivo del log
        /// </summary>
        /// <returns></returns>
        protected static string permisoWrite()
        {
            var cad = Configuration.GetConnectionString("parametro");
            //var cad = ConfigurationManager.AppSettings["parametro"].ToString();
            return cad;

        }
        /// <summary>
        /// obtiene la url donde se guardara el archivo log
        /// </summary>
        /// <returns></returns>
        protected static string pathArchivo()
        {
            var cad = Configuration.GetConnectionString("path");
            //var cad = ConfigurationManager.AppSettings["path"].ToString();
            return cad;
        }

        /// <summary>
        /// escribe la linea de log dentro del archivo 
        /// </summary>
        /// <param name="msj"></param>
        public static void WriteLine(string msj)
        {
            try
            {

                string permiso = permisoWrite();
                string path2 = pathArchivo();
                if (permiso != "S") { return; }

                var vrlPathFolderLog = string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, path2);
                if (!Directory.Exists(vrlPathFolderLog))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(vrlPathFolderLog);
                }

                var vrlFechaActual = DateTime.Now.ToString("yyyyMMdd");
                var vrlNombreArchivo = string.Format("{0}/{1}.txt", vrlPathFolderLog, vrlFechaActual);
                using (StreamWriter w = File.AppendText(vrlNombreArchivo))
                {
                    Log(msj, w);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }
        /// <summary>
        /// crea el nombre del archivo que se guarda por la fecha
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="w"></param>
        public static void Log(string logMessage, TextWriter w)
        {
            var vrlNow = DateTime.Now.ToString();
            w.WriteLine("{0} : {1}", vrlNow, logMessage);
        }
    }
}