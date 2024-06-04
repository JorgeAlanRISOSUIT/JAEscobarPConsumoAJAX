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
                    var listSP = context.GetPersonaAseguradoras();
                    if (listSP.Count > 0)
                    {
                        foreach (var item in listSP)
                        {
                            ML.PersonaAseguradora objPersona = new ML.PersonaAseguradora()
                            {
                                IdPersona = item.IdPersona,
                                Nombre = item.Nombre,
                                ApellidoPaterno = item.ApellidoPaterno,
                                ApellidoMaterno = item.ApellidoMaterno,
                                Correo = item.Correo,
                                CURP = item.CURP,
                                RFC = item.RFC,
                                Entidad = new ML.Entidad
                                {
                                    Nombre = item.Estado
                                },
                                EstadoCivil = item.EstadoCivil,
                                FechaNacimiento = item.FechaNacimiento,
                                Genero = item.Genero,
                                Telefono = item.Telefono,
                            };
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
                    var item = context.GetPersonaAseguradora(idPersona);
                    if (item != null)
                    {
                        ML.PersonaAseguradora objPersona = new ML.PersonaAseguradora()
                        {
                            IdPersona = item.IdPersona,
                            Nombre = item.Nombre,
                            ApellidoPaterno = item.ApellidoPaterno,
                            ApellidoMaterno = item.ApellidoMaterno,
                            Correo = item.Correo,
                            CURP = item.CURP,
                            RFC = item.RFC,
                            Entidad = new ML.Entidad
                            {
                                Nombre = item.Estado
                            },
                            EstadoCivil = item.EstadoCivil,
                            FechaNacimiento = item.FechaNacimiento,
                            Genero = item.Genero,
                            Telefono = item.Telefono,
                        };
                        return (true, "", null, objPersona);
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
