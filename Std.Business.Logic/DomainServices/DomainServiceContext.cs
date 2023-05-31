using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.BusinessLogic.DomainServices
{
    public class DomainServiceContext : IDomainServiceContext
    {
        #region Private ReadOnly

        private readonly Lazy<IStudentDomainService> _studentDomainService;

        #endregion
        public IStudentDomainService StudentDomainService => _studentDomainService.Value;

        public DomainServiceContext(

                                    Func<IStudentDomainService> studentServiceFactory

            )

        {
            _studentDomainService = new Lazy<IStudentDomainService>(studentServiceFactory);
        }
    }
    public interface IDomainServiceContext
    {
        IStudentDomainService StudentDomainService { get; }
    }
}



