using SchoolAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Data
{
    public class FinalRepository : IFinalRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public FinalRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public IEnumerable<Final> AllFinals => _schoolDbContext.Finals;

        public Final AddFinal(Final final)
        {
            _schoolDbContext.Finals.Add(final);
            _schoolDbContext.SaveChanges();

            return final;
        }

        public Final GetFinalById(int id)
        {
            return _schoolDbContext.Finals.Include(f => f.Course).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Final> GetFinalByStudentId(int studentId)
        {
            return _schoolDbContext.Finals.Include(f => f.Course).Where(c => c.StudentId == studentId);
        }

        public Final UpdateFinal(Final final)
        {
            Final updatedFinal = _schoolDbContext.Finals.FirstOrDefault(f => f.Id == final.Id && f.StudentId == final.StudentId);
            if(updatedFinal != null)
            {
                updatedFinal.Mark = final.Mark;
                updatedFinal.Name = final.Name;
                _schoolDbContext.SaveChanges();
            }

            return updatedFinal;
        }
    }
}
