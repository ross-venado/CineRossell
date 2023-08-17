using PruebaRossell.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PruebaRossell.DBManager
{
    public class ClassConnectionSqlServer
    {
        public static SqlConnection conn;
        public readonly static string Proyecto_Admin = Configuration.GetConnectionString("databaseSql");
        public readonly static string VT_SP_LOGUEO = Configuration.GetConnectionString("nameSpLogueo");
        public readonly static string VT_SP_VALIDACION = Configuration.GetConnectionString("nameSpUpCodGenerado");
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
        /// Obtiene la cadena de conexión del AppSettings
        /// </summary>
        /// <returns></returns>
        protected string cadena()
        {
            var cad = Configuration.GetConnectionString("stringConnectioSQLServer");
           //ar cad = ConfigurationManager.AppSettings["stringConnectioSQLServer"].ToString();
            return cad;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado en la base de datos
        /// </summary>
        /// <param name="pmNameSP">Nombre del procedimiento almacenado</param>
        /// <param name="pmParametros">Lista de los parámetros del procedimiento almacenado</param>
        /// <param name="pmMensaje">Mensaje de error en caso de que ocurra una excepción</param>
        /// <returns>DataTable con los resultados de la ejecución del procedimiento almacenado</returns>
        public DataTable GetDataTableByNameSP(string pmNameSP, List<SqlParameter> pmParametros, ref string pmMensaje)
        {
            try
            {
                DataTable tblRes = new DataTable();

                using (SqlConnection conn = new SqlConnection())
                {
                    string connString = cadena();
                    conn.ConnectionString = connString;
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(pmNameSP, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Clear();

                    foreach (SqlParameter pm in pmParametros)
                    {
                        cmd.Parameters.Add(pm);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tblRes);

                    conn.Close();

                    return tblRes;
                }
            }
            catch (Exception ex)
            {
                LogService.WriteLine("SP:" + pmNameSP + " - " + ex.ToString());
                pmMensaje = ex.Message.ToString();
                return null;
            }
        }

        /// <summary>
        /// Crea un parámetro del procedimiento almacenado con su valor respectivo
        /// </summary>
        /// <param name="name">Nombre del parámetro</param>
        /// <param name="tipo">Tipo de datos</param>
        /// <param name="value">Valor del parámetro</param>
        /// <param name="dir">Dirección del parámetro</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter CreateCustomParameter(string name, SqlDbType tipo, object value /*, ParameterDirection dir*/)
        {
            var sqlParameter = new SqlParameter
            {
                ParameterName = name,
                //Direction = dir,
                SqlDbType = tipo
            };
            sqlParameter.Value = value;
            return sqlParameter;
        }
    }
}