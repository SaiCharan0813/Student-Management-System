using Studentmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Student_management
{
    public class School
    {
        
        public int SchoolId { get; set; }
        public string SchoolName;
        public  List<Student> Students = new List<Student>();

        public static List<Student> GetAllStudents()
        {
            List<School> schools = SchoolManagement.GetAllSchools();
            List<Student> students = new List<Student>();   
            foreach (School studentSchool in schools)
            {
                if (studentSchool.Students.Count > 0)
                {

                    for (int j = 0; j < studentSchool.Students.Count; j++)
                    {
                        students.Add(studentSchool.Students[j]);
                    }
                }
            }
            return students;
        }
        public static void AddSchool()
        {
            School school = new School();
            string schoolName;
        enterSchoolName: Console.WriteLine("Enter school name:");
            schoolName = Console.ReadLine();
            string regexForName = @"^[a-zA-Z ]+$";
            Regex r = new Regex(regexForName);

            if (!r.IsMatch(schoolName) || schoolName == "")
            {
                Console.WriteLine("Enter string as name");
                goto enterSchoolName;
            }
            else
            {
                school.SchoolName = schoolName;
            }


        schoolId: Console.WriteLine("Enter School Id:");
            int schoolIdNumber;
            try
            {
                schoolIdNumber = Convert.ToInt32(Console.ReadLine());
                
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter number as School Id");
                goto schoolId;
            }
            foreach (var s in SchoolManagement.schools)
            {
                if (s.SchoolId == schoolIdNumber)
                {
                    Console.WriteLine("Roll number already exist");
                    goto schoolId;
                }
               
                
            }
            school.SchoolId = schoolIdNumber;
            SchoolManagement.schools.Add(school);
            
            Console.WriteLine("-----Welcome to " + school.SchoolName.ToUpperInvariant() + " School with an id " + school.SchoolId + "--------");
           
            
        }
        
     
        
    }
}
