﻿/**********************************
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
        public bool RegistroPerro(string Nombre, DateTime FechaIngreso, int Edad, string Raza, string Tamaño, string Esterilizado, string Adoptado)
        {
            SqlCommand comando = new SqlCommand("", Link.LinkConexion);
            comando.CommandText = "SP_InsertPerro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
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
            SqlDataAdapter u = new SqlDataAdapter();

            u.SelectCommand = Buscar;

            try
            {
                Link.LinkConexion.Open();
                u.Fill(Conjunto);
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
