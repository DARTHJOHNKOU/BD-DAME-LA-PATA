/**********************************
*Asignación de programa: 12
*Nombre: Victoria Martinez Villagómez
*Fecha de creación: 03/12/18
* 
*Descripción: Clase que contiene la conexión a la
* base de datos para usar los Stored Procedures
* de registrar, modificar y visualizar datos de               
* Adopciones.       
* 
* 
*Modificado por: Carlos Salazar Martínez               
*Cambios: Documentación    
*Fecha de modificación: 06/12/18
*               
*Declaraciones        
*   °SqlConnection LinkConnection
*   °SqlCommand Comando
*   
*   °public bool RegistroAdopcion(int IdPerro, int IdAdoptante, DateTime FechaAdopcion, string Lugar)
*       Propósito: ingresar los datos que recibe como parámetros a la base de datos.
*       Limitaciones: en la Edad no se debe ingresar letras o símbolos.
*                     Nombre no debe exceder los 30 caracteres.
*       Regresa True si se completó con éxito el guardado de datos en la BD. Caso contrario, retorna False.    
*   
*   
*   °public bool RegistroAdopcion(int IdPerro, int IdAdoptante, DateTime FechaAdopcion, string Lugar)
*       Propósito: Obtener un conjunto de datos recuperados de la base de datos.
*       Limitaciones:
*       Regresa un conjunto de datos si la recuperación se logró. Caso contrario, regresa un conjunto vacío.

*   
*Código fuente de ClassConexionBD en: /InterfazDeUsuario/ClassConexionBD.cs
*   °SqlConnection LinkConexion
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
    class ClassAdopcion
    {

        //Objeto que contiene la forma de conexión a la base de datos.
        ClassConexionBD Link = new ClassConexionBD();

        /*La siguiente sección del programa se establece una conexión a la base de datos
        y ejecuta el Stored Procedure para ingresar datos de las Adopciones.*/
        public bool RegistroAdopcion(int IdPerro, int IdAdoptante, DateTime FechaAdopcion, string Lugar)
        {
            SqlCommand comando = new SqlCommand("", Link.LinkConexion);
            comando.CommandText = "SP_InsertAdopcion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdPerro", IdPerro);
            comando.Parameters.AddWithValue("@IdAdoptante", IdAdoptante);
            comando.Parameters.AddWithValue("@FechaVisita", FechaAdopcion);
            comando.Parameters.AddWithValue("@Lugar", Lugar);

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

    }
}
