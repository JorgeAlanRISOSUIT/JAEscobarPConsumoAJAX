using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PersonaAseguradora
    {
        public static (bool, string, Exception, ML.PersonaAseguradora) GetAll()
        {
            try
            {
                ML.PersonaAseguradora model = new ML.PersonaAseguradora();
                model.Aseguradoras = new List<ML.PersonaAseguradora>();
                using (DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
                {
                    if (context.GetPersonaAseguradoras().Count > 0)
                    {
                        foreach (var data in context.GetPersonaAseguradoras())
                        {
                            ML.PersonaAseguradora aseguradora = new ML.PersonaAseguradora()
                            {
                                IdPersona = data.IdPersona,
                                Nombre = data.Nombre,
                                ApellidoPaterno = data.ApellidoPaterno,
                                ApellidoMaterno = data.ApellidoMaterno,
                                EstadoCivil = data.EstadoCivil,
                                Genero = data.Genero,
                                FechaNacimiento = data.FechaNacimiento,
                                Entidad = new ML.Entidad()
                                {
                                    IdEntidad = data.EntidadNacimientoNavigation.IdEstado,
                                    Nombre = data.EntidadNacimientoNavigation.Nombre
                                },
                                CURP = data.Curp,
                                RFC = data.Rfc,
                                Telefono = data.Telefono,
                                Correo = data.Correo
                            };
                            model.Aseguradoras.Add(aseguradora);
                        }
                        return (true, "", null, model);
                    }
                    else
                    {
                        return (false, "No existen variables", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex, null);
            }
        }

        public static (bool, string, Exception, ML.PersonaAseguradora) GetById(int idPersona)
        {
            try
            {
                ML.PersonaAseguradora model = new ML.PersonaAseguradora();
                using (DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
                {
                    if (context.GetPersonaAseguradora(idPersona) != null)
                    {
                        var init = context.GetPersonaAseguradora(idPersona);
                        model.IdPersona = init.IdPersona;
                        model.Nombre = init.Nombre;
                        model.ApellidoPaterno = init.ApellidoPaterno;
                        model.ApellidoMaterno = init.ApellidoMaterno;
                        model.EstadoCivil = init.EstadoCivil;
                        model.Genero = init.Genero;
                        model.FechaNacimiento = init.FechaNacimiento;
                        model.Entidad = new ML.Entidad();
                        model.Entidad.Nombre = init.EntidadNacimientoNavigation.Nombre;
                        model.CURP = init.Curp;
                        model.RFC = init.Rfc;
                        model.Telefono = init.Telefono;
                        model.Correo = init.Correo;
                        return (true, "", null, model);
                    }
                    else
                    {
                        return (false, "", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex, null);
            }
        }

        public static (bool, string, Exception) Add(ML.PersonaAseguradora aseguradora)
        {
            try
            {
                using (JAEscobarConsumoAJAXContext context = new JAEscobarConsumoAJAXContext())
                {
                    if (context.AddPersonaAseguradora(aseguradora) > 0)
                    {
                        return (true, "Inserción existosa", null);
                    }
                    else
                    {
                        return (false, "Fallo en la inserción", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }

        public static (bool, string, Exception) Update(ML.PersonaAseguradora aseguradora)
        {
            try
            {
                using (JAEscobarConsumoAJAXContext context = new JAEscobarConsumoAJAXContext())
                {
                    if (aseguradora.IdPersona > 0)
                    {
                        if (context.UpdatePersonaAseguradora(aseguradora) > 0)
                        {
                            return (true, "", null);
                        }
                        else
                        {
                            return (false, "Esta persona no existe", null);
                        }
                    }
                    else
                    {
                        return (false, "Actualización fallida: falta ID", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }

        public static (bool, string, Exception) Delete(int idPersona)
        {
            try
            {
                using (JAEscobarConsumoAJAXContext context = new JAEscobarConsumoAJAXContext())
                {
                    if (context.DeletePersonaAseguradora(idPersona) > 0)
                    {
                        return (true, "Persona Eliminada", null);
                    }
                    else
                    {
                        return (false, "Esta Persona no existe", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
    }
}
