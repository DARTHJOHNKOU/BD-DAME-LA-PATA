/**********************************
*Asignación de programa: 04
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18
* 
*Descripción: Clase que contiene la conexión a la
* base de datos para usar los Stored Procedures
* de registrar, modificar y visualizar datos de               
* perros.              
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
    class ClassPerro
    {
        //Objeto que contiene la forma de conexión a la base de datos.
        ClassConexionBD Link = new ClassConexionBD();

        /*La siguiente sección del programa se establece una conexión a la base de datos
        y ejecuta el Stored Procedure para ingresar datos del perro.*/
        public bool RegistroPerro(string Empleo)
        {
            SqlCommand comando = new SqlCommand("", Link.LinkConexion);
            comando.CommandText = "SP_InsertPerro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Empleo", Empleo);

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
