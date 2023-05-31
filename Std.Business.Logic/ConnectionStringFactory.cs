using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.BusinessLogic
{
	public class ConnectionStringFactory : IConnectionStringFactory
	{
		public IConfiguration Configuration { get; }
		public ConnectionStringFactory(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public string GetConnectionString()
		{
			var connectionstring = Configuration.GetConnectionString("StudentDB");
			return connectionstring;
		}
	}
}

