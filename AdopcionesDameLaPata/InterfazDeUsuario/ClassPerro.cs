/**********************************
*Asignación de programa: 04
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18
* 
*Descripción: Clase que contiene la conexión a la
* base de datos para usar los Stored Procedures
* de registrar, modificar y visualizar datos de               
* perros.              
* 
*Modificado por: Carlos Salazar Martínez               
*Cambios: Cambios de nombre a variables. Documentación    
*Fecha de modificación: 06/12/18
* 
* 
*Declaraciones        
*   °ClassConexionBD Link
*   °SqlCommand Comando
*   °DataSet Conjunto
*   °SqlCommand Buscar
*   °SqlAdapter Adaptador
* 
* 
*   °public bool RegistroPerro(string Nombre, DateTime FechaIngreso, int Edad, string Raza, string Tamaño, string Esterilizado, string Adoptado) 
*       Propósito: ingresar los datos que recibe como parámetros a la base de datos.
*       Limitaciones: en la Edad no se debe ingresar letras o símbolos.
*                     Nombre no debe exceder los 30 caracteres.
*       Regresa True si se completó con éxito el guardado de datos en la BD. Caso contrario, retorna False. 
* 
*   °public DataSet SelectPerros()
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
    class ClassPerro
    {
        //Objeto que contiene la forma de conexión a la base de datos.
        ClassConexionBD Link = new ClassConexionBD();

        /*La siguiente sección del programa se establece una conexión a la base de datos
        y ejecuta el Stored Procedure para ingresar datos del perro.*/
        public bool RegistroPerro(string Nombre, string Genero, DateTime FechaIngreso, int Edad, string Raza, string Tamaño, string Esterilizado, string Adoptado)
        {
            SqlCommand comando = new SqlCommand("", Link.LinkConexion);
            comando.CommandText = "SP_InsertPerro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Genero", Genero);
            comando.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            comando.Parameters.AddWithValue("@Edad", Edad);
            comando.Parameters.AddWithValue("@Raza", Raza);
            comando.Parameters.AddWithValue("@Tamaño", Tamaño);
            comando.Parameters.AddWithValue("@Esterilizado", Esterilizado);
            comando.Parameters.AddWithValue("@Adoptado", Adoptado);

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

        public bool UpdatePerro(int Id, string Nombre, string Genero, DateTime FechaIngreso, int Edad, string Raza, string Tamaño, string Esterilizado, string Adoptado)
        {
            SqlCommand comando = new SqlCommand("", Link.LinkConexion);
            comando.CommandText = "SP_UpdatePerro";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdPerro", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Genero", Genero);
            comando.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            comando.Parameters.AddWithValue("@Edad", Edad);
            comando.Parameters.AddWithValue("@Raza", Raza);
            comando.Parameters.AddWithValue("@Tamaño", Tamaño);
            comando.Parameters.AddWithValue("@Esterilizado", Esterilizado);
            comando.Parameters.AddWithValue("@Adoptado", Adoptado);

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

        public DataSet SelectPerros()
        {
            DataSet Conjunto = new DataSet();
            SqlCommand Buscar = new SqlCommand("EXEC SP_SelectPerros", Link.LinkConexion);
            // Dim Buscar As New SqlClient.SqlCommand("EXEC SP_SelectAdoptantes", Cadena.Cadena)
            //  Dim u As New SqlClient.SqlDataAdapter();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            Adaptador.SelectCommand = Buscar;

            try
            {
                Link.LinkConexion.Open();
                Adaptador.Fill(Conjunto);
                Link.LinkConexion.Close();
                return Conjunto;
            }



            catch
            {
                Link.LinkConexion.Close();
                return Conjunto;
            }
        }

        public DataSet EsPerroRepetido( string Nombre )
        {
            DataSet Conjunto = new DataSet();
            SqlCommand Buscar = new SqlCommand("EXEC SP_EsPerroRepetido'" + Nombre + "'", Link.LinkConexion);
            // Dim Buscar As New SqlClient.SqlCommand("EXEC SP_SelectAdoptantes", Cadena.Cadena)
            //  Dim u As New SqlClient.SqlDataAdapter();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            Adaptador.SelectCommand = Buscar;

            try
            {
                Link.LinkConexion.Open();
                Adaptador.Fill(Conjunto);
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
