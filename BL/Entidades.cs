using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Entidades
	{
		public static (bool, string, Exception, ML.Entidad) GetAll()
		{
			try
			{
				ML.Entidad model = new ML.Entidad { Entidades = new List<ML.Entidad>() };
				using(DL.JAEscobarConsumoAJAXContext context = new DL.JAEscobarConsumoAJAXContext())
				{
					var info = context.GetEstados();
					if(info.Count > 0)
					{
						foreach(DL.Estado estado in info) 
						{
							ML.Entidad entidad = new ML.Entidad
							{
								IdEntidad = estado.IdEstado,
								Nombre = estado.Nombre
							};
							model.Entidades.Add(entidad);
						}
						return (true, "", null, model);
					}
					else
					{
						return (false, "No existen Entidades Federativas", null, null);
					}
				}
			}
			catch (Exception ex)
			{
				return (false, ex.Message, ex, null);
			}
		}
	}
}
