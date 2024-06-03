using Microsoft.EntityFrameworkCore.Storage;

namespace BL
{
    public class PersonaEvento
    {

        public static (bool, string, Exception, ML.PersonaEvento) GetAll()
        {
            try
            {
                ML.PersonaEvento model = new ML.PersonaEvento();
                model.Eventos = new List<ML.PersonaEvento> { new ML.PersonaEvento() };
                using (DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
                {
                    if (context.GetPersonaEventos().Count > 0)
                    {
                        foreach (var data in context.GetPersonaEventos())
                        {
                            ML.PersonaEvento objEvento = new ML.PersonaEvento()
                            {
                                IdPersona = data.IdPersona,
                                Nombre = data.Nombre,
                                Email = data.Email,
                                Telefono = data.Telefono,
                                Empresa = data.Empresa,
                            };
                            model.Eventos.Add(objEvento);
                        }
                        return (true, "", null, model);
                    }
                    else
                    {
                        return (false, "No existen registros", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex, null);
            }
        }

        public static (bool, string, Exception, ML.PersonaEvento) GetById(int idPersona)
        {
            try
            {
                using (DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
                {
                    if (context.GetPersonaEvento(idPersona) != null)
                    {
                        var init = context.GetPersonaEvento(idPersona);
                        ML.PersonaEvento model = new ML.PersonaEvento
                        {
                            IdPersona = init.IdPersona,
                            Nombre = init.Nombre,
                            Email = init.Email,
                            Empresa = init.Empresa,
                            Telefono = init.Telefono
                        };
                        return (true, "", null, model);
                    }
                    else
                    {
                        return (false, "No existe la persona", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex, null);
            }
        }

        public static (bool, string, Exception) Add(ML.PersonaEvento evento)
        {
            try
            {
                using (DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
                {
                    if (context.AddPersonaEvento(evento) > 0)
                    {
                        return (true, "Se agregado esta persona al evento", null);
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

        public static (bool, string, Exception) Update(ML.PersonaEvento evento)
        {
            try
            {
                using (DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
                {
                    if(evento.IdPersona > 0)
                    {
                        if(context.UpdatePersonaEvento(evento) > 0)
                        {
                            return (true, "Se actualizo correctamente", null);
                        }
                        else
                        {
                            return (false, "Se elimino la contraseña", null);
                        }
                    }
                    else
                    {
                        return (false, "No se encontro los datos de la persona", null);
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
