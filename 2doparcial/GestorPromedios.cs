using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doparcial
{
    public class GestorPromedios
    {
        public string archivo = "promedios.txt";

        public void GuardarPromedio(Promedio[] promedio)
        {
            FileStream fs = new FileStream(archivo, FileMode.Append);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                foreach(Promedio prom in promedio)
                {
                    writer.WriteLine(prom.GenerarRegistro());
                }
            }
            fs.Close();
        }

        public List<Alumno> GenAlumnos(string[] alumnos)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            foreach (var alumno in alumnos)
            {
                string[] datos = alumno.Split(',');
                listaAlumnos.Add(new Alumno
                {
                    Legajo = int.Parse(datos[0]),
                    Nombre = datos[1],
                    Apellido = datos[2]
                });
            }
            return listaAlumnos;
        }
        public List<Notas> GenNotas(string[] notas)
        {
            List<Notas> listaNotas = new List<Notas>();
            foreach (var nota in notas)
            {
                string[] datos = nota.Split(',');
                listaNotas.Add(new Notas
                {
                    Legajo = int.Parse(datos[0]),
                    NombreMateria = datos[1],
                    Calificacion = int.Parse(datos[2])
                });
            }
            return listaNotas;
        }

        public Promedio[] GenPromedios(List<Alumno> alumnos, List<Notas> notas)
        {
            List<Promedio> promedios = new List<Promedio>();
            foreach (Alumno alumno in alumnos)
            {
                Promedio prom = new Promedio();
                prom.Legajo = alumno.Legajo;
                prom.Nombre = alumno.Nombre;
                prom.Apellido = alumno.Apellido;

                int cantidadDeMaterias = 0;
                int notasSumadas = 0;

                foreach (Notas nota in notas)
                {
                    if (nota.Legajo == alumno.Legajo && nota.Calificacion > 4)
                    {
                        notasSumadas += nota.Calificacion;
                        cantidadDeMaterias++;
                    }
                }

                prom.PromedioGeneral = cantidadDeMaterias == 0 ? 0 : notasSumadas / cantidadDeMaterias;
                promedios.Add(prom);
            }
            GuardarPromedio(promedios.ToArray());
            return promedios.ToArray();
        }
        public double MejorPromedio(Promedio[] promedios)
        {
            double mejorPromedio = 0;
            foreach (Promedio promedio in promedios)
            {
                if (promedio.PromedioGeneral > mejorPromedio)
                {
                    mejorPromedio = promedio.PromedioGeneral;
                }
            }
            return mejorPromedio;
        }

    }
}
