using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DTO
{
	public class ResultDTO
	{
		public bool Success { get; set; } = false;
		public object Error { get; set; } = null;
		public string Message { get; set; } = string.Empty;
		public object Object { get; set; } = null;
		public List<object> Objects { get; set; } = new List<object>();
	}
}
