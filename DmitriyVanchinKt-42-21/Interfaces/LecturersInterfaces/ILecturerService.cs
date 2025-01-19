using DmitriyVanchinKt_42_21.Database;
using DmitriyVanchinKt_42_21.Filters.LecturerFilters;
using DmitriyVanchinKt_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DmitriyVanchinKt_42_21.Interfaces.LecturersInterfaces
{
    public interface ILecturerService
    {
        public Task<Lecturer[]> GetLecturersByCathedraAsync(LecturerCathedraFilter filter, CancellationToken cancellationToken);
        public Task<Load[]> GetLecturersByNameAsync(LecturerNameFilter filter, CancellationToken cancellationToken);
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
        //public Task<Load[]> GetLecturersByNameAsync(LecturerNameFilter filter, CancellationToken cancellationToken = default)
        //{

        //    var lecturers = _dbContext.Set<Load>().Where(w =>
        //    (!string.IsNullOrEmpty(filter.Familia) && w.Lecturer.MiddleName == filter.Familia &&
        //     (string.IsNullOrEmpty(filter.Name) || w.Lecturer.FirstName == filter.Name)) || // Уточнение имени
        //    (string.IsNullOrEmpty(filter.Familia) && !string.IsNullOrEmpty(filter.Name) && w.Lecturer.FirstName == filter.Name) || // Только имя
        //    (!string.IsNullOrEmpty(filter.Otchectvo) && w.Lecturer.LastName == filter.Otchectvo) // Отчество
        //)
        //.ToArrayAsync(cancellationToken);
        //    return lecturers;

        //}
        public Task<Load[]> GetLecturersByNameAsync(LecturerNameFilter filter, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<Load>().AsQueryable();

            // Проверяем совпадение по всем полям
            if (!string.IsNullOrEmpty(filter.Familia))
            {
                query = query.Where(w => w.Lecturer.MiddleName == filter.Familia);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(w => w.Lecturer.FirstName == filter.Name);
            }

            if (!string.IsNullOrEmpty(filter.Otchectvo))
            {
                query = query.Where(w => w.Lecturer.LastName == filter.Otchectvo);
            }

            return query.ToArrayAsync(cancellationToken);
        }
    }
}
