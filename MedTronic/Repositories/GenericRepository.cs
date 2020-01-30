using MedTronic.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTronic.Repositories
{
    public class GenericRepository
    {
        private IConfiguration configuration;
        private GenericDbContext genericDBContext;
        private SnowflakeContext sfDBContext;

        public GenericRepository(IConfiguration Configuration, GenericDbContext dbContext, SnowflakeContext sfx)
        {
            configuration = Configuration;
            genericDBContext = dbContext;
            sfDBContext = sfx;
        }

        public List<TeacherStudentLinkModel> getTeacherStudents3()
        {
            var lsData = from s in genericDBContext.Students
                         join ts in genericDBContext.TeacherStudents
                         on s.RollNumber equals ts.StudentId
                         join t in genericDBContext.Teachers
                         on ts.TeacherId equals t.EmpId
                         select new { s.IdNum, s.RollNumber, t.EmpId, t.FirstName, t.LastName };

            return genericDBContext.TeacherStudents.ToList();
        }

        public List<StockPriceModel> getStocks()
        {
            return sfDBContext.Stocks.ToList();
        }

        public List<TeacherStudentLinkModel> getTeacherStudentsData()
        {
            //Inner join
            var lsData = from s in genericDBContext.Students
                         join ts in genericDBContext.TeacherStudents
                         on s.RollNumber equals ts.StudentId
                         join t in genericDBContext.Teachers
                         on ts.TeacherId equals t.EmpId
                         select new { s.IdNum, s.RollNumber, t.EmpId, t.FirstName, t.LastName };

            //Outer join
            var lsData1 = from s in genericDBContext.Students
                         join ts in genericDBContext.TeacherStudents
                         on s.RollNumber equals ts.StudentId into gj
                         from subset in gj.DefaultIfEmpty()
                         select new { s.IdNum, s.RollNumber, TeacherId = subset == null ? 0 : subset.TeacherId };



            return genericDBContext.TeacherStudents.ToList();
        }

        public List<TeacherStudentLinkModel> getTeacherStudents()
        {
            //var lsData = from ts in genericDBContext.TeacherStudents
            //             select ts.Studentid;

            //var lsData1 = from ts in genericDBContext.TeacherStudents
            //             where ts.Teacherid == 1
            //             select ts.Studentid;

            //var i = lsData.Where(m => m.Equals(1));

            //var lsData2 = from ts in genericDBContext.TeacherStudents
            //              where ts.Teacherid < 4
            //              select ts;

            //var lsData3 = from ts in genericDBContext.TeacherStudents
            //              where ts.Teacherid < 4
            //              orderby ts.Studentid
            //              select ts;

            //Console.Write(lsData3);

            getTeacherStudentsData();


            return genericDBContext.TeacherStudents.ToList();
        }

        public List<TeacherModel> PutTeacher(TeacherModel tmi)
        {
            TeacherModel tm = genericDBContext.Teachers.FirstOrDefault(m => m.EmpId == tmi.EmpId);
            if (tm == null)
                genericDBContext.Teachers.Add(tmi);
            else
                genericDBContext.Teachers.Update(tmi);
            genericDBContext.SaveChanges();
            return genericDBContext.Teachers.ToList();
        }

    }
}
