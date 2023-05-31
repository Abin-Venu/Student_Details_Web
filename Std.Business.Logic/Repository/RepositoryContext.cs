using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.BusinessLogic.Repository
{
	public class RepositoryContext : IRepositoryContext
	{
        public IStudentRepository StudentRepository { get; set; }
        public RepositoryContext(IConnectionStringFactory connectionStringFactory)
        {
            StudentRepository = new StudentRepository(connectionStringFactory);

        }
    }
}
