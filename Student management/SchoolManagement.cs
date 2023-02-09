using Studentmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_management
{
    public class SchoolManagement
    {
        public static List<School> Schools = new List<School>();
        public static School GetSchoolById(int schoolId)
        {
            return Schools.Find(x => x.SchoolId == schoolId);
        }
        public static void DisplayAllSchools()
        {
            foreach (var school in SchoolManagement.Schools)
            {
                Console.WriteLine("The School id is: " + school.SchoolId+" The School name is: "+school.SchoolName);
            }
        }
        public static List<School> GetAllSchools()
        {
            return Schools;
        }

    }
}
