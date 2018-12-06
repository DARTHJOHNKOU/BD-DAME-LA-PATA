/**********************************
*Asignación de programa: 11
*Nombre: Victoria Martinez Villagómez
*Fecha de creación: 03/12/18
* 
*Descripción: Clase que contiene la conexión a la
* base de datos para usar los Stored Procedures
* de registrar, modificar y visualizar datos de               
* Visitas.              
* 
* 
*Modificado por: Carlos Salazar Martínez               
*Cambios: Cambios de nombre a variables. Documentación    
*Fecha de modificación: 06/12/18
* 
* 
* Declaraciones:
*   °ClassConexionBD Link
*   °DataSet Conjunto
*   °SqlCommand Buscar
*   °SqlAdapter Adaptador
*   
*   ° public bool RegistroVisita(int IdAdoptante, string Lugar, DateTime FechaVisita, DateTime FechaProximaVisita, string NombreVisitante, string Observaciones)
*       Propósito: ingresar los datos que recibe como parámetros a la base de datos.
*       Limitaciones: en la Edad no se debe ingresar letras o símbolos.
*                     Lugar no debe exceder los 30 caracteres.
*                     NombreVisitante no debe exceder los 50 caracteres.
*                     Observaciones no debe exceder los 500 caracteres.
*       Regresa True si se completó con éxito el guardado de datos en la BD. Caso contrario, retorna False. 
*   
*   ° DataSet SelectVisitas()
*       Propósito: Obtener un conjunto de datos recuperados de la base de datos.
*       Limitaciones:
*       Regresa un conjunto de datos si la recuperación se logró. Caso contrario, regresa un conjunto vacío.
*   
*Código fuente de ClassConexionBD en: /InterfazDeUsuario/ClassConexionBD.cs
*   °SqlConnection LinkConexion
*   
*   
**********************************/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazDeUsuario
{
    class ClassVisita
    {
        //Objeto que contiene la forma de conexión a la base de datos.
        ClassConexionBD Link = new ClassConexionBD();

        /*La siguiente sección del programa se establece una conexión a la base de datos
        y ejecuta el Stored Procedure para ingresar datos de las visitas.*/
        public bool RegistroVisita(int IdAdoptante, string Lugar, DateTime FechaVisita, DateTime FechaProximaVisita, string NombreVisitante, string Observaciones)
        {
            SqlCommand comando = new SqlCommand("", Link.LinkConexion);
            comando.CommandText = "SP_InsertVisita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdAdoptante", IdAdoptante);
            comando.Parameters.AddWithValue("@Lugar", Lugar);
            comando.Parameters.AddWithValue("@FechaVisita", FechaVisita);
            comando.Parameters.AddWithValue("@FechaProximaVisita", FechaProximaVisita);
            comando.Parameters.AddWithValue("@NombreVisitante", NombreVisitante);
            comando.Parameters.AddWithValue("@Observaciones", Observaciones);

            //¿La conexión a la base de datos fue posible?
            try
            {
                Link.LinkConexion.Open();
                comando.ExecuteNonQuery();
                Link.LinkConexion.Close();
                return true;
            }
            catch
            {
                Link.LinkConexion.Close();
                return false;
            }
        }

            public DataSet SelectVisitas()
            {
                DataSet Conjunto = new DataSet();
                SqlCommand Buscar = new SqlCommand("EXEC SP_SelectVisitas", Link.LinkConexion);
                // Dim Buscar As New SqlClient.SqlCommand("EXEC SP_SelectAdoptantes", Cadena.Cadena)
                //  Dim u As New SqlClient.SqlDataAdapter();
                SqlDataAdapter Adaptador = new SqlDataAdapter();

                Adaptador.SelectCommand = Buscar;

                try
                {
                    Link.LinkConexion.Open();
                    Adaptador.Fill(Conjunto, "Visitas");
                    Link.LinkConexion.Close();
                    return Conjunto;
                }



                catch
                {
                    Link.LinkConexion.Close();
                    return Conjunto;
                }
            }

        
    }
}
