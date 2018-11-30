/**********************************
*Asignación de programa: 03
*Nombre: Carlos Salazar Martínez 
*Fecha de creación: 29/11/18
* 
*Descripción: Clase que contiene la cadena de conexión 
* hacia la base de datos
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
    class ClassConexionBD
    {
        //Se establece un objeto de conexión a la base de datos con el nombre del servidor SQL y el nombre de la base de datos.
        public SqlConnection LinkConexion = new SqlConnection("server=LENOVO-PC\\MSSQLSERVER01;database=Proyecto_DLP;integrated security=True");
    }
}
