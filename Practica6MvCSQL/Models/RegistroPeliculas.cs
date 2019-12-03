using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using Practica6MvCSQL;

namespace Practica6MvCSQL.Models
{
    public class RegistroPeliculas
    {
        private SqlConnection con;
        /*Conectarse a BD*/
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(constr);
        }
        //Guardar un registro en la base de Datos
        public int GrabarPelicula(Peliculas peli)
        {

            Conectar();
            SqlCommand comando = new SqlCommand("Insert Into TBL_PELICULA (Codigo, Titulo, Director, AutorPrincipal, No_Actores,Duracion, Estreno)" +
               "Values (@Codigo, @Titulo, @Director, @AutorPrincipal, @No_Actores,@Duracion, @Estreno)", con);

            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters.Add("@titulo", SqlDbType.VarChar);
            comando.Parameters.Add("@Director", SqlDbType.VarChar);
            comando.Parameters.Add("@AutorPrincipal", SqlDbType.VarChar);
            comando.Parameters.Add("@No_Actores", SqlDbType.Int);
            comando.Parameters.Add("@Duracion", SqlDbType.Float);
            comando.Parameters.Add("@Estreno", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = peli.Codigo;
            comando.Parameters["@Titulo"].Value = peli.Titulo;
            comando.Parameters["@Director"].Value = peli.Director;
            comando.Parameters["@AutorPrincipal"].Value = peli.AutorPrincipal;
            comando.Parameters["@No_Actores"].Value = peli.NumAutores;
            comando.Parameters["@Duracion"].Value = peli.Duracion;
            comando.Parameters["@Estreno"].Value = peli.Estreno;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }
        /* Mostrar todos los registros de la base de datos*/
        public List<Peliculas> RecupearTodos()
        {
            Conectar();
            List<Peliculas> pelicula = new List<Peliculas>();

            SqlCommand com = new SqlCommand("Select Codigo, Titulo, Director, AutorPrincipal, No_Actores,Duracion, Estreno From TBL_PELICULA", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Peliculas peli = new Peliculas
                {
                    Titulo = registros["Titulo"].ToString(),
                    Director = registros["Director"].ToString(),
                    AutorPrincipal = registros["AutorPrincipal"].ToString(),
                    NumAutores = int.Parse(registros["No_Actores"].ToString()),
                    Duracion = double.Parse(registros["Duracion"].ToString()),
                    Estreno = int.Parse(registros["Estreno"].ToString())

                };

                pelicula.Add(peli);

            }
            con.Close();
            return pelicula;


        }
        //Mostrar un Registro Especifico de la base de datos

        public Peliculas Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Select Codigo, Titulo, Director, AutorPrincipal, No_Actores, Estreno " + "From TBL_PELICULA where Codigo=@Codigo ", con);
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["Codigo"].Value = codigo;
            con.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Peliculas pelicula = new Peliculas();

            if (registro.Read())
            {
                pelicula.Codigo = int.Parse(registro["Codigo"].ToString());
                pelicula.Titulo = registro["Titulo"].ToString();
                pelicula.Director = registro["Director"].ToString();
                pelicula.AutorPrincipal = registro["AutorPrincipal"].ToString();
                pelicula.NumAutores = int.Parse(registro["No_Actores"].ToString());
                pelicula.Duracion = float.Parse(registro["Duracion"].ToString());
                pelicula.Estreno = int.Parse(registro["Estreno"].ToString());


            }
            con.Close();
            return pelicula;
        }

        //Modificar un Registro de la Base de Datos

        public int Modificar(Peliculas peli)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Update TBL_PELICULA set Codigo=@Codigo, Titulo=@Titulo, Director=@Director, AutorPrincipal=@AutorPrincipal, No_Actores=@No_Actores, " + "Duracion=@Duracion, Estreno=@Estreno where Codigo=@Codigo ", con);
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters["@Codigo"].Value = peli.Codigo;
            comando.Parameters.Add("@Titulo", SqlDbType.VarChar);
            comando.Parameters["@Titulo"].Value = peli.Titulo;
            comando.Parameters.Add("@Director", SqlDbType.VarChar);
            comando.Parameters["@Director"].Value = peli.Director;
            comando.Parameters.Add("@AutorPrincipal", SqlDbType.VarChar);
            comando.Parameters["@AutorPrincipal"].Value = peli.AutorPrincipal;
            comando.Parameters.Add("@No_Actores", SqlDbType.VarChar);
            comando.Parameters["@No_Actores"].Value = peli.NumAutores;
            comando.Parameters.Add("@Duracion", SqlDbType.VarChar);
            comando.Parameters["@Duracion"].Value = peli.Duracion;
            comando.Parameters.Add("@Estreno", SqlDbType.VarChar);
            comando.Parameters["@Estreno"].Value = peli.Estreno;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        //Borrar un Registro Especifico de La Base de Datos

        public int Borrar(int Codigo)
        {

            Conectar();
            SqlCommand comando = new SqlCommand("Delete TBL_PELICULA where Codigo=@Codigo", con);
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = Codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

    }
}