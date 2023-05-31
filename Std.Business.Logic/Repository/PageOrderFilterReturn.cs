using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.BusinessLogic.Repository
{
	public class PageOrderFilterReturn
	{
		public long TotalCount { get; set; }
		public long FilteredCount { get; set; }
		public dynamic Content { get; set; }
	}
}
