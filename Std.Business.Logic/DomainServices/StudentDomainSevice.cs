using Std.BusinessLogic.Models;
using Std.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.BusinessLogic.DomainServices
{
    public class StudentDomainService : BaseDomainService, IStudentDomainService
    {
        public StudentDomainService(IDomainServiceContext domainService, IRepositoryContext repository) : base(domainService, repository)
        {

        }
        public async Task<List<StudentRecord>> GetAllStudentAsync()
        {
            var records = await Repository.StudentRepository.GetAllAsync(Database.NonScalling);
            return records.ToList();
        }
        public async Task<StudentRecord> GetStudentByIdAsync(int StudentId)
        {
            var record = await Repository.StudentRepository.GetByIdAsync(Database.NonScalling, StudentId);
            return record;
        }

        public async Task<StudentRecord> CreateStudentAsync(StudentRecord model)
        {
            var record = await Repository.StudentRepository.CreateAsync(Database.NonScalling, model);
            return record;
        }

        public async Task<bool> UpdateStudentAsync(StudentRecord model)
        {
            var row = await Repository.StudentRepository.UpdateAsync(Database.NonScalling, model);
            return row > 0 ? true : false;
        }

        public async Task<bool> DeleteStudentAsync(StudentRecord model)
        {
            var row = await Repository.StudentRepository.DeleteAsync(Database.NonScalling, model);
            return row > 0 ? true : false;
        }

        public async Task<List<StudentRecord>> BulkCreateStudentAsync(List<StudentRecord> model)
        {
            var record = await Repository.StudentRepository.BulkInsertAsync(Database.NonScalling, model);
            return record.ToList();
        }

        public async Task<bool> BulkUpdateStudentAsync(List<StudentRecord> model)
        {
            var rows = await Repository.StudentRepository.BulkUpdateAsync(Database.NonScalling, model);
            return rows > 0 ? true : false;
        }


        public async Task<bool> BulkDeleteStudentAsync(List<StudentRecord> model)
        {
            var rows = await Repository.StudentRepository.BulkDeleteAsync(Database.NonScalling, model);
            return rows > 0 ? true : false;
        }
    }
    public interface IStudentDomainService
    {
        Task<List<StudentRecord>> GetAllStudentAsync();
        Task<StudentRecord> GetStudentByIdAsync(int StudentId);

        Task<StudentRecord> CreateStudentAsync(StudentRecord model);
        Task<bool> UpdateStudentAsync(StudentRecord model);
        Task<bool> DeleteStudentAsync(StudentRecord model);
        Task<List<StudentRecord>> BulkCreateStudentAsync(List<StudentRecord> model);
        Task<bool> BulkUpdateStudentAsync(List<StudentRecord> model);
        Task<bool> BulkDeleteStudentAsync(List<StudentRecord> model);

    }
}
