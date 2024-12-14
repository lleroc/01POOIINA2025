using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using _01_Mi_Primera_Vez.Datos;
using System.Globalization;

namespace _01_Mi_Primera_Vez.Logica
{
   
   public class cls_personal
    {
        private readonly conexion cn = new conexion();
        //insertar
        public string Insertar(dto_personal Personal) {

            using (var conexion = cn.obtenerConexion())
            {
                string cadena1 = "insert into personal (cedula, nombre, cargo, sueldo, idPais)values('" +
                    Personal.cedula + "','" +
                    Personal.nombre + "','" +
                    Personal.cargo + "'," +
                    Personal.sueldo + "," +
                    Personal.idPais + ")";
                using (var comando = new SqlCommand(cadena1, conexion))
                {
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }                 
                }
            }         
        }

        //todos   select * from   getall
        public List<dto_personal> todos() {
            var listapersonal = new List<dto_personal>();
            using (var conexion = cn.obtenerConexion())//1 llamo a la conexion con la base
            {
                string cadena = "SELECT IdPersonal, cedula, nombre, cargo, sueldo, Paises.IdPais, Paises.Detalle " +
                    "FROM Personal inner join Paises on Paises.IdPais = Personal.idPais"; //2 creo la sentencia sql
                using (var comando = new SqlCommand(cadena, conexion)) //3 ejecuto el comando 
                {
                    conexion.Open(); //4 abrir la conexion
                    using (var lector = comando.ExecuteReader())//5 cargar el lector la informacion
                    {                      
                        while (lector.Read())  //6 recorrer el lector para obtener la iformacion
                        {
                            var personal = new dto_personal //7  creo un objeto dto_personal para asiganr lo que trae de la base de datos
                            {
                                IdPersonal = (int)lector["IdPersonal"],
                                cedula = lector["cedula"].ToString(),
                                nombre = lector["nombre"].ToString(),
                                cargo = lector["cargo"].ToString(),
                                sueldo = (decimal)lector["sueldo"],
                                Detalle = lector["Detalle"].ToString()
                            };
                            listapersonal.Add(personal); //8 agregar a la lista el objeto
                        }
                    }
                }
            }

            return listapersonal;
        }
        //uno  select * where

        public dto_personal uno(int id) {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = "select * from personal where IdPersonal=" + id;
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        lector.Read();
                        var personal = new dto_personal 
                        {
                            IdPersonal = (int)lector["IdPersonal"],
                            cedula = lector["cedula"].ToString(),
                            nombre = lector["nombre"].ToString(),
                            cargo = lector["cargo"].ToString(),
                            sueldo = (decimal)lector["sueldo"],
                            idPais = (int)lector["idPais"],
                        };
                        return personal;
                    }
                }
            }     
        }

        //actualziar

        public string actualizar(dto_personal personal) {
            using (var conexion = cn.obtenerConexion())
            {
                string cadeba = "update Personal set " +
                    $"cargo='{personal.cargo}', cedula='{personal.cedula}'," +
                    $"idPais={personal.idPais},nombre='{personal.nombre}'," +
                    $"sueldo={personal.sueldo} where IdPersonal={personal.IdPersonal}";
                using (var comando = new SqlCommand(cadeba, conexion))
                {
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

        public bool duplicadoCedula(string cedula) {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = $"select count(*) as repetidos from personal where cedula='{cedula}'";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        lector.Read();
                        if ((int)lector["repetidos"] > 0)
                        {
                            return true; // verdadero - que hay numeros de cedula repetidos
                        }
                        else { return false; }
                    }
                }
            }
        }

        //eliminar
    }
}
