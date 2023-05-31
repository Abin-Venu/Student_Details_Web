using Std.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Std.BusinessLogic.Repository
{
    public class StudentRepository: BaseRepository<StudentRecord>, IStudentRepository
    {
        public StudentRepository(IConnectionStringFactory connectionStringFactory) : base(connectionStringFactory)
    {
    Schema = "[dbo]";
    GetAllProc = "[Student_GetAll]";

            InsertProc = "[Student_BulkInsert]";
            UpdateProc = "[Student_BulkUpdate]";
            DeleteProc = "[Student_BulkDelete]";

            DymamicProc = "[Student_DynamicSQL]";

            PageSortFilterProc = "[Student_GetByPageSortFilter]";
        }
          
        public Task<StudentRecord> GetByIdAsync(int companyId, int studentId, bool bubbleException = false)
        {
            var filterByList = new List<FilterBySetting>()
              {
                  new FilterBySetting()
                  {
                      FilterByClause = "StudentId = " + studentId.ToString(),
                      FilterByOrd = 1
                  }
              };
            return GetByUniqueKey(companyId, filterByList, orderByList: new List<OrderBySetting>(), bubbleException: bubbleException);
        }

        
		 public Task<IEnumerable<StudentRecord>> GetAllByCompanyIdAsync(int companyId, bool bubbleException = false)
         {
             var filterByList = new List<FilterBySetting>()
                  {
                      new FilterBySetting()
                      {
                          FilterByClause = "CompanyId = " + companyId.ToString(),
                          FilterByOrd = 1
                      }
                  };
             return GetByForeignKey(companyId, filterByList, orderByList: new List<OrderBySetting>(), bubbleException: bubbleException);
         }
	  
    }

    public interface IStudentRepository
    {
        Task<IEnumerable<StudentRecord>> GetAllAsync(int companyId, bool bubbleException = false);
        Task<StudentRecord> CreateAsync(int companyId, StudentRecord entity, bool bubbleException = false);
        Task<int> DeleteAsync(int companyId, StudentRecord entity, bool bubbleException = false);
        Task<int> UpdateAsync(int companyId, StudentRecord entity, bool bubbleException = false);
        Task<IEnumerable<StudentRecord>> BulkInsertAsync(int companyId, List<StudentRecord> entityList, bool bubbleException = false);
        Task<int> BulkUpdateAsync(int companyId, List<StudentRecord> entityList, bool bubbleException = false);
        Task<int> BulkDeleteAsync(int companyId, List<StudentRecord> entityList, bool bubbleException = false);
        Task<PageOrderFilterReturn> GetPageSortFilterAsync(int companyId, PageSortFilterModel model, bool bubbleException = false);
        
        Task<IEnumerable<StudentRecord>> GetAllByCompanyIdAsync(int companyId, bool bubbleException = false);
		
		Task<StudentRecord> GetByIdAsync(int companyId, int studentId, bool bubbleException = false);

        
    }
}
