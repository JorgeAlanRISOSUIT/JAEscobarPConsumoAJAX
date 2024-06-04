using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public partial class JAEscobarConsumoAJAXContext
    {
        public virtual DbSet<ML.StoredProcedure.SPAsegurado> SPResult { get; set; }

        public virtual DbSet<ML.StoredProcedure.SPEvento> SPEvento { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ML.StoredProcedure.SPAsegurado>().HasNoKey();
            modelBuilder.Entity<ML.StoredProcedure.SPEvento>().HasNoKey();
        }

        public List<ML.StoredProcedure.SPAsegurado> GetPersonaAseguradoras()
        {
            return SPResult.FromSqlRaw("MostrarPersonaAseguradora").ToList();
        }

        public ML.StoredProcedure.SPAsegurado GetPersonaAseguradora(int idPersona)
        {
            return SPResult.FromSqlInterpolated($"MostrarPersonaAseguradoraById {idPersona}").AsEnumerable().SingleOrDefault();
        }

        public int AddPersonaAseguradora(ML.PersonaAseguradora aseguradora)
        {
            return Database.ExecuteSqlInterpolated($"AgregarPersonaAseguradora {aseguradora.Nombre}, {aseguradora.ApellidoPaterno}, {aseguradora.ApellidoMaterno}, {aseguradora.EstadoCivil}, {aseguradora.Genero}, {aseguradora.FechaNacimiento}, {aseguradora.Entidad.IdEntidad}, {aseguradora.CURP}, {aseguradora.RFC}, {aseguradora.Telefono}, {aseguradora.Correo}");
        }

        public int UpdatePersonaAseguradora(ML.PersonaAseguradora aseguradora)
        {
            return Database.ExecuteSqlInterpolated($"ActualizarPersonaAseguradora {aseguradora.IdPersona}, {aseguradora.Nombre}, {aseguradora.ApellidoPaterno}, {aseguradora.ApellidoMaterno}, {aseguradora.EstadoCivil}, {aseguradora.Genero}, {aseguradora.FechaNacimiento}, {aseguradora.Entidad.IdEntidad}, {aseguradora.CURP}, {aseguradora.RFC}, {aseguradora.Telefono}, {aseguradora.Correo}");
        }

        public int DeletePersonaAseguradora(int idPersona)
        {
            return Database.ExecuteSqlInterpolated($"EliminarPersonaAseguradora {idPersona}");
        }

        public List<ML.StoredProcedure.SPEvento> GetPersonaEventos()
        {
            return SPEvento.FromSqlInterpolated($"MostrarPersonaEvento;").ToList();
        }

        public DL.PersonaEvento GetPersonaEvento(int idPersona)
        {
            return PersonaEventos.FromSqlInterpolated($"MostrarPersonaEventoById {idPersona}").AsEnumerable().SingleOrDefault();
        }
        
        public int AddPersonaEvento(ML.PersonaEvento evento)
        {
            return Database.ExecuteSqlInterpolated($"AgregarPersonaEventos {evento.Nombre}, {evento.Telefono}, {evento.Email}, {evento.Empresa}");
        }

        public int UpdatePersonaEvento(ML.PersonaEvento evento)
        {
            return Database.ExecuteSqlInterpolated($"ActualizarPersonaEvento {evento.IdPersona}, {evento.Nombre}, {evento.Telefono}, {evento.Email}, {evento.Empresa}");
        }

        public int DeletePersonaEvento(int idPersona)
        {
            return Database.ExecuteSqlInterpolated($"EliminarPersonaEvento {idPersona}");
        }
    }
}
