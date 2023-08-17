using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PruebaRossell.DBManager;
using PruebaRossell.Services;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PruebaRossell.DbManager
{
    public class ClassCarga
    {
        /// <summary>
        /// obtiene todas las peliculas
        /// </summary>
        /// <returns></returns>
        public Task<DataTable> Peliculas()
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 1));
                var dt = db.GetDataTableByNameSP("VT_SP_PELICULA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// inserta la nueva pelicula
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="duracion"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public Task<DataTable> InsertPelicula(string titulo, TimeSpan duracion, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 2));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Titulo", SqlDbType.NVarChar, titulo));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Duracion", SqlDbType.Time, duracion));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_PELICULA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// modifica una pelicual segun su id
        /// </summary>
        /// <param name="peliculaId"></param>
        /// <param name="titulo"></param>
        /// <param name="duracion"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public Task<DataTable> UpdatePelicula(string peliculaId, string titulo, TimeSpan duracion, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 3));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Titulo", SqlDbType.NVarChar, titulo));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Duracion", SqlDbType.Time, duracion));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_PELICULA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// elimina la pelicula
        /// </summary>
        /// <param name="peliculaId"></param>
        /// <returns></returns>
        public Task<DataTable> DeletePelicula(string peliculaId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 4));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));

                var dt = db.GetDataTableByNameSP("VT_SP_PELICULA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// obtiene la pelicula segun su ID
        /// </summary>
        /// <param name="peliculaId"></param>
        /// <returns></returns>
        public Task<DataTable> GetPeliculaById(string peliculaId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 5));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));

                var dt = db.GetDataTableByNameSP("VT_SP_PELICULA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /***********************************************************
         * SALA
         * **********************************************************/

        public Task<DataTable> Salas()
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 1));
                var dt = db.GetDataTableByNameSP("VT_SP_SALA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> InsertSala(int numero, int capacidad, int peliculaId, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 2));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Numero", SqlDbType.Int, numero));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Capacidad", SqlDbType.Int, capacidad));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_SALA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> UpdateSala(int salaId, int numero, int capacidad, int peliculaId, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 3));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Numero", SqlDbType.Int, numero));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Capacidad", SqlDbType.Int, capacidad));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_SALA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> DeleteSala(int salaId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 4));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));

                var dt = db.GetDataTableByNameSP("VT_SP_SALA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> GetSalaById(int salaId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 5));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));

                var dt = db.GetDataTableByNameSP("VT_SP_SALA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /***********************************************************
        * FUNCION
        ***********************************************************/



        public Task<DataTable> Funciones()
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 1));
                var dt = db.GetDataTableByNameSP("VT_SP_FUNCION", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> InsertFuncion(TimeSpan hora, int salaId, int peliculaId, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 2));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Hora", SqlDbType.Time, hora));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_FUNCION", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> UpdateFuncion(int funcionId, TimeSpan hora, int salaId, int peliculaId, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 3));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@FuncionId", SqlDbType.Int, funcionId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Hora", SqlDbType.Time, hora));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@PeliculaId", SqlDbType.Int, peliculaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_FUNCION", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> DeleteFuncion(int funcionId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 4));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@FuncionId", SqlDbType.Int, funcionId));

                var dt = db.GetDataTableByNameSP("VT_SP_FUNCION", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> GetFuncionById(int funcionId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 5));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@FuncionId", SqlDbType.Int, funcionId));

                var dt = db.GetDataTableByNameSP("VT_SP_FUNCION", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /***********************************************************
        * Entrada
        ***********************************************************/

        public Task<DataTable> Entradas()
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 1));
                var dt = db.GetDataTableByNameSP("VT_SP_ENTRADA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> InsertEntrada(int funcionId, decimal precio, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 2));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@FuncionId", SqlDbType.Int, funcionId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Precio", SqlDbType.Decimal, precio));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_ENTRADA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> UpdateEntrada(int entradaId, int funcionId, decimal precio, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 3));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@EntradaId", SqlDbType.Int, entradaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@FuncionId", SqlDbType.Int, funcionId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Precio", SqlDbType.Decimal, precio));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_ENTRADA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> DeleteEntrada(int entradaId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 4));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@EntradaId", SqlDbType.Int, entradaId));

                var dt = db.GetDataTableByNameSP("VT_SP_ENTRADA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> GetEntradaById(int entradaId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 5));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@EntradaId", SqlDbType.Int, entradaId));

                var dt = db.GetDataTableByNameSP("VT_SP_ENTRADA", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /***********************************************************
        * Asiento
        ***********************************************************/

        public Task<DataTable> Asientos()
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 1));
                var dt = db.GetDataTableByNameSP("VT_SP_ASIENTO", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> InsertAsiento(int numero, int salaId, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 2));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Numero", SqlDbType.Int, numero));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_ASIENTO", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> UpdateAsiento(int asientoId, int numero, int salaId, DateTime ts)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 3));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@AsientoId", SqlDbType.Int, asientoId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@Numero", SqlDbType.Int, numero));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@SalaId", SqlDbType.Int, salaId));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@ts", SqlDbType.DateTime, ts));

                var dt = db.GetDataTableByNameSP("VT_SP_ASIENTO", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> DeleteAsiento(int asientoId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 4));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@AsientoId", SqlDbType.Int, asientoId));

                var dt = db.GetDataTableByNameSP("VT_SP_ASIENTO", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<DataTable> GetAsientoById(int asientoId)
        {
            try
            {
                var db = new ClassConnectionSqlServer();
                string msg = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@i_operacion", SqlDbType.Int, 5));
                parametros.Add(ClassConnectionSqlServer.CreateCustomParameter("@AsientoId", SqlDbType.Int, asientoId));

                var dt = db.GetDataTableByNameSP("VT_SP_ASIENTO", parametros, ref msg);

                return Task.FromResult(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }





    }
}
