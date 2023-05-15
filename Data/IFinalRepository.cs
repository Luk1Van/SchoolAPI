using SchoolAPI.Data.Entities;

namespace SchoolAPI.Data
{
    public interface IFinalRepository
    {
        public IEnumerable<Final> AllFinals {get;}
        public Final GetFinalById(int id);
        public IEnumerable<Final> GetFinalByStudentId(int studentId);
        public Final AddFinal(Final final);
        public Final UpdateFinal(Final final);
    }
}
