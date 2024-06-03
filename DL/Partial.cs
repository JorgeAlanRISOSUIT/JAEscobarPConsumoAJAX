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
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {
        }

        public List<DL.PersonaAseguradora> GetPersonaAseguradoras()
        {
            return PersonaAseguradoras.FromSqlRaw("MostrarPersonaAseguradora").ToList();
        }

        public PersonaAseguradora GetPersonaAseguradora(int idPersona)
        {
            return PersonaAseguradoras.FromSqlInterpolated($"MostrarPersonaAseguradoraById {idPersona}").SingleOrDefault();
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

        public List<DL.PersonaEvento> GetPersonaEventos()
        {
            return PersonaEventos.FromSqlRaw("MostrarPersonaEvento").ToList();
        }

        public DL.PersonaEvento GetPersonaEvento(int idPersona)
        {
            return PersonaEventos.FromSqlRaw($"MostrarPersonaAseguradoraById {idPersona}").SingleOrDefault();
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
