using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Data.Repositories.Implementations;
public class StoreRepository : Repository<Store>
{
    public StoreRepository(DbContext context) : base(context) { }
}