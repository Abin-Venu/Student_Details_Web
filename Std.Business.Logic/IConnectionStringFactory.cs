using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.BusinessLogic
{
	public interface IConnectionStringFactory
	{
		string GetConnectionString();
	}
}
