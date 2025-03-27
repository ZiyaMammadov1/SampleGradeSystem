using CSharpFunctionalExtensions;
using SampleGradeSystem.Data.UnitOfWork.Implementations;
using SampleGradeSystem.Data.UnitOfWork.Interfaces;
using SampleGradeSystem.Models.Special;
using System.Diagnostics;

namespace SampleGradeSystem.Services
{
    public class SalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<decimal>> CalculateSalaryByEmployeeIdAsync(int employeeId, decimal monthlyStoreAmount, decimal monthlyEmployeeAmount)
        {
            Employee employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(employeeId);

            if (employee == null) return Result.Failure<decimal>("Employee not found");

            Position position = await _unitOfWork.Repository<Position>().GetByIdAsync(employee.PositionId);

            Store store = await _unitOfWork.Repository<Store>().GetByIdAsync(employee.StoreId);

            var gradeData = await GetGradeDataAsync(store.GradeId);
            decimal storeGradeAmount = CalculateLocalGradeAmount(gradeData.grade, gradeData.thresholdGradeList, monthlyStoreAmount);

            //Other grades are not considered because the company grade does not meet the requirements
            if (store.GradeId is not null && position.GradeId is not null && storeGradeAmount == 0) return Result.Success<decimal>(position.Salary);

            gradeData = await GetGradeDataAsync(position.GradeId);
            decimal positionGradeAmount = CalculateLocalGradeAmount(gradeData.grade, gradeData.thresholdGradeList, monthlyEmployeeAmount);

            return Result.Success<decimal>(storeGradeAmount + positionGradeAmount + position.Salary);
        }

        private async Task<(Grade grade, List<Grade> thresholdGradeList)> GetGradeDataAsync(int? gradeId)
        {
            Grade grade = gradeId.HasValue ? await _unitOfWork.Repository<Grade>().GetByIdAsync(gradeId.Value) : null;
            List<Grade> thresholdGradeList = new();

            if (grade is not null && grade.GradeTypeId == 3)
            {
                thresholdGradeList = await _unitOfWork.Repository<Grade>().GetAsync(x => x.GradeTypeId == 3 && x.Name == grade.Name);
            }
            return (grade, thresholdGradeList);
        }

        private decimal CalculateLocalGradeAmount(Grade grade, List<Grade> thresholdGradeList, decimal monthlyAmount = 0)
        {
            if (grade == null) return 0;

            if (grade.GradeTypeId == 1 && grade.Min >= monthlyAmount)
            {
                return grade.FixGradeAmount;
            }

            if (grade.GradeTypeId == 2 && grade.Min <= monthlyAmount)
            {
                return (monthlyAmount * grade.Percent.Value) / 100;
            }

            if (grade.GradeTypeId == 3)
            {
                foreach (var thresholdGradeListItem in thresholdGradeList)
                {
                    if (monthlyAmount >= thresholdGradeListItem.Min && monthlyAmount <= thresholdGradeListItem.Max)
                    {
                        return (monthlyAmount * thresholdGradeListItem.Percent.Value) / 100;
                    }
                }
            }

            return 0;
        }
    }
}
