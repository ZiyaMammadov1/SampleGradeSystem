using SampleGradeSystem.Data.UnitOfWork.Interfaces;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
        }

    }
}
