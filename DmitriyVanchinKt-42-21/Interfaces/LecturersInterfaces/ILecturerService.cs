using DmitriyVanchinKt_42_21.Database;
using DmitriyVanchinKt_42_21.Filters.LecturerFilters;
using DmitriyVanchinKt_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DmitriyVanchinKt_42_21.Interfaces.LecturersInterfaces
{
    public interface ILecturerService
    {
        public Task<Lecturer[]> GetLecturersByCathedraAsync(LecturerCathedraFilter filter, CancellationToken cancellationToken);
    }
    public class LecturerService : ILecturerService
    {
        private readonly LecturerDbContext _dbContext;
        public LecturerService(LecturerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Lecturer[]> GetLecturersByCathedraAsync(LecturerCathedraFilter filter, CancellationToken cancellationToken = default)
        {
            var lecturers = _dbContext.Set<Lecturer>().Where(w=>w.Cathedra.CathedraName == filter.CathedraName).ToArrayAsync(cancellationToken);
            return lecturers;
        }
    }
}
