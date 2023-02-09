using Student_management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace Studentmanagement
{
    public class Student
    {
        public int StudentRollNumber { get; set; }
        public int IdOfSchool { get; set; }
        public string Name { get; set; }
        public float TotalMarks { get; set; }
        public double Percentage { get; set; }
        public List<Marks> SubjectMarks = new List<Marks>();
        Marks telugu = new Marks();
        Marks hindi = new Marks();
        Marks english = new Marks();
        Marks maths = new Marks();
        Marks science = new Marks();
        Marks social = new Marks();
        public static void AddStudent()
        {
            List<School> schools = SchoolManagement.GetAllSchools();
            List<Student> students = School.GetAllStudents();
           foreach(Student student in students)
            {
            Console.WriteLine("student name is: "+student.Name);
            }
                Student newStudent = new Student();
            if (SchoolManagement.schools.Count > 0)
            {
            enterSchoolIdNumber:
                Console.WriteLine("Enter School id which you want to join:");
                int schoolIdNumber;
                try
                {
                    schoolIdNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid School id number");
                    goto enterSchoolIdNumber;
                }
                bool isSchoolExist = false;
                for (int i = 0; i < SchoolManagement.schools.Count; i++)
                {

                    if (SchoolManagement.schools[i].SchoolId == schoolIdNumber)
                    {
                        isSchoolExist = true;
                        break;
                    }
                }
                if (isSchoolExist == true)
                {
                    School schoolObject = SchoolManagement.GetSchoolById(schoolIdNumber);
                enterRollNumber:
                    Console.WriteLine("Enter Student Roll Number:");
                    int studentRollNumber;
                    try
                    {
                        studentRollNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid roll number");
                        goto enterRollNumber;
                    }

                    foreach (Student student in schoolObject.Students)
                    {
                        if (student.StudentRollNumber == studentRollNumber)
                        {
                            Console.WriteLine("Roll number already exist");
                            goto enterRollNumber;
                        }

                    }
                    string name;
                    bool isNameValid = true;
                enterStudentName: Console.WriteLine("Enter Student Name: ");
                    name = Console.ReadLine();
                    string nameRegex = @"^[a-zA-Z ]+$";
                    Regex r = new Regex(nameRegex);

                    if (!r.IsMatch(name) || name == "")
                    {
                        Console.WriteLine("Enter string as name");
                        goto enterStudentName;
                        isNameValid = false;
                    }
                    else
                    {
                        newStudent.Name = name;
                        newStudent.StudentRollNumber = studentRollNumber;
                        newStudent.IdOfSchool = schoolIdNumber;
                    }
                    schoolObject.Students.Add(newStudent);
                }
            }
            else
            {
                Console.WriteLine("No school are there to join");
            }
        }
        public static void UpdateMarks()
        {
            List<School> schools = SchoolManagement.GetAllSchools();
            School school = new School();
            if (SchoolManagement.schools.Count > 0)
            {
            enterSchoolIdNumber:


                Console.WriteLine("Enter School id of the student :");
                int schoolIdNumber;

                try
                {
                    schoolIdNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid School id number");
                    goto enterSchoolIdNumber;
                }

                bool isSchoolExist = false;
                 
                int size = SchoolManagement.schools.Count;
                for (int i = 0; i < size; i++)
                {

                    if (SchoolManagement.schools[i].SchoolId == schoolIdNumber)
                    {
                        isSchoolExist = true;
                        break;
                    }

                }
                if (isSchoolExist == true)
                {
                    School schoolObject = SchoolManagement.GetSchoolById(schoolIdNumber);
                    Student student = new Student();
                    int studentRollId;
                enterRollId: Console.WriteLine("Enter Roll Number");

                    try
                    {
                        studentRollId = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid roll number");
                        goto enterRollId;
                    }
                    Student newStudent = new Student();
                    bool isStudentExist = false;
                    size = school.Students.Count;
               
                    foreach (Student schoolStudent in schoolObject.Students)
                    {
                        if (schoolStudent.StudentRollNumber == studentRollId)
                        {
                            isStudentExist = true;
                            break;
                        }
                       
                    }
                    if (isStudentExist == true)
                    {
                        newStudent = schoolObject.Students.Find(x => x.StudentRollNumber == studentRollId);
                        string teluguMarks;
                        bool isStudentMarksValid = false;
                        string re = @"^[0-9]*$";
                        Regex r = new Regex(re);
                        while (isStudentMarksValid != true)
                        {
                            Console.WriteLine("Enter Telugu marks:");

                            teluguMarks = Console.ReadLine();
                            isStudentMarksValid = true;
                            if (!r.IsMatch(teluguMarks) || teluguMarks == "")
                            {

                                Console.WriteLine("Enter valid Marks");
                                isStudentMarksValid = true;
                            }
                            else
                            {

                                newStudent.telugu.SubjectName = StudentSubjects.Subjects.Telugu;
                                newStudent.telugu.Score = Convert.ToInt32(teluguMarks);
                                newStudent.SubjectMarks.Add(newStudent.telugu);

                            }

                            if (newStudent.telugu.Score < 0 || newStudent.telugu.Score > 100)
                            {
                                isStudentMarksValid = false;
                                Console.WriteLine("Enter valid Marks");

                            }

                        }
                        string hindiMarks;
                        isStudentMarksValid = false;
                        re = @"^[0-9]*$";
                        r = new Regex(re);
                        while (isStudentMarksValid != true)
                        {
                            Console.WriteLine("Enter Hindi marks:");

                            hindiMarks = Console.ReadLine();
                            isStudentMarksValid = true;
                            if (!r.IsMatch(hindiMarks) || hindiMarks == "")
                            {

                                Console.WriteLine("Enter valid Marks");
                                isStudentMarksValid = false;
                            }
                            else
                            {

                                newStudent.hindi.SubjectName = StudentSubjects.Subjects.Hindi;
                                newStudent.hindi.Score = Convert.ToInt32(hindiMarks);
                                newStudent.SubjectMarks.Add(newStudent.hindi);
                            }
                            if (newStudent.hindi.Score < 0 || newStudent.hindi.Score > 100)
                            {
                                isStudentMarksValid = false;
                                Console.WriteLine("Enter valid Marks");

                            }

                        }
                        string englishMarks;
                        isStudentMarksValid = false;
                        re = @"^[0-9]*$";
                        r = new Regex(re);
                        while (isStudentMarksValid != true)
                        {
                            Console.WriteLine("Enter English marks:");

                            englishMarks = Console.ReadLine();
                            isStudentMarksValid = true;
                            if (!r.IsMatch(englishMarks) || englishMarks == "")
                            {

                                Console.WriteLine("Enter valid Marks");
                                isStudentMarksValid = false;
                            }
                            else
                            {

                                newStudent.english.SubjectName = StudentSubjects.Subjects.English;
                                newStudent.english.Score = Convert.ToInt32(englishMarks);
                                newStudent.SubjectMarks.Add(newStudent.english);
                            }
                            if (newStudent.english.Score < 0 || newStudent.english.Score > 100)
                            {
                                isStudentMarksValid = false;
                                Console.WriteLine("Enter valid Marks");

                            }

                        }
                        string mathsMarks;
                        isStudentMarksValid = false;
                        re = @"^[0-9]*$";
                        r = new Regex(re);
                        while (isStudentMarksValid != true)
                        {
                            Console.WriteLine("Enter Maths marks:");

                            mathsMarks = Console.ReadLine();
                            isStudentMarksValid = true;
                            if (!r.IsMatch(mathsMarks) || mathsMarks == "")
                            {

                                Console.WriteLine("Enter valid Marks");
                                isStudentMarksValid = false;
                            }
                            else
                            {

                                newStudent.maths.SubjectName = StudentSubjects.Subjects.Maths;
                                newStudent.maths.Score = Convert.ToInt32(mathsMarks);
                                newStudent.SubjectMarks.Add(newStudent.maths);
                            }
                            if (newStudent.maths.Score < 0 || newStudent.maths.Score > 100)
                            {
                                isStudentMarksValid = false;
                                Console.WriteLine("Enter valid Marks");

                            }

                        }
                        string scienceMarks;
                        isStudentMarksValid = false;
                        re = @"^[0-9]*$";
                        r = new Regex(re);
                        while (isStudentMarksValid != true)
                        {
                            Console.WriteLine("Enter Science marks:");

                            scienceMarks = Console.ReadLine();
                            isStudentMarksValid = true;
                            if (!r.IsMatch(scienceMarks) || scienceMarks == "")
                            {

                                Console.WriteLine("Enter valid Marks");
                                isStudentMarksValid = false;
                            }
                            else
                            {

                                newStudent.science.SubjectName = StudentSubjects.Subjects.Science;
                                newStudent.science.Score = Convert.ToInt32(scienceMarks);
                                newStudent.SubjectMarks.Add(newStudent.science);
                            }
                            if (newStudent.science.Score < 0 || newStudent.science.Score > 100)
                            {
                                isStudentMarksValid = false;
                                Console.WriteLine("Enter valid Marks");

                            }

                        }
                        string socialMarks;
                        isStudentMarksValid = false;
                        re = @"^[0-9]*$";
                        r = new Regex(re);
                        while (isStudentMarksValid != true)
                        {
                            Console.WriteLine("Enter Social marks:");

                            socialMarks = Console.ReadLine();
                            isStudentMarksValid = true;
                            if (!r.IsMatch(socialMarks) || socialMarks == "")
                            {

                                Console.WriteLine("Enter valid Marks");
                                isStudentMarksValid = false;
                            }
                            else
                            {

                                newStudent.social.SubjectName = StudentSubjects.Subjects.Social;
                                newStudent.social.Score = Convert.ToInt32(socialMarks);
                                newStudent.SubjectMarks.Add(newStudent.social);
                            }
                            if (newStudent.social.Score < 0 || newStudent.social.Score > 100)
                            {
                                isStudentMarksValid = false;
                                Console.WriteLine("Enter valid Marks");

                            }
                        }

                        newStudent.TotalMarks = newStudent.telugu.Score + newStudent.hindi.Score + newStudent.english.Score + newStudent.maths.Score + newStudent.science.Score + newStudent.social.Score;
                        newStudent.Percentage = Math.Round((double)newStudent.TotalMarks / 6, 2);

                        
                        var studentToUpdate = schoolObject.Students.Find(x => x.StudentRollNumber == studentRollId);
                        studentToUpdate = newStudent;
                    }
                    else
                    {
                        Console.WriteLine("No student with that roll number");
                    }
                }
                else
                {
                    Console.WriteLine("No school present with that ID");
                }



            }
        }
        public static void ViewProgress()
        {
            List<School> schools = SchoolManagement.GetAllSchools();
            foreach (School school in schools)
            {
                Console.WriteLine("School is: " + school.SchoolId);
            }
        enterSchoolIdNumber:


            Console.WriteLine("Enter School id of the student :");
            int schoolIdNumber;

            try
            {
                schoolIdNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter valid School id number");
                goto enterSchoolIdNumber;
            }

            bool isSchoolExist = false;
            int size = SchoolManagement.schools.Count;
            for (int i = 0; i < size; i++)
            {

                if (SchoolManagement.schools[i].SchoolId == schoolIdNumber)
                {
                    isSchoolExist = true;
                    break;
                }

            }
            if (isSchoolExist == true)
            {
                School schoolObject = SchoolManagement.GetSchoolById(schoolIdNumber);
                Student student = new Student();
                int studentRollId;
            enterRollId: Console.WriteLine("Enter Roll Number");

                try
                {
                    studentRollId = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid roll number");
                    goto enterRollId;
                }

                bool isStudentExist = false;
                
                foreach (Student schoolStudent in schoolObject.Students)
                {
                    Console.WriteLine(schoolStudent.StudentRollNumber);
                    if (schoolStudent.StudentRollNumber == studentRollId)
                    {
                        isStudentExist = true;
                        break;
                    }
                  
                }
                if (isStudentExist == true)
                {
                    Student studentObject = schoolObject.Students.Find(x => x.StudentRollNumber == studentRollId);
                    Console.WriteLine("Student Telugu marks:" + studentObject.telugu.Score);

                    Console.WriteLine("Student Hindi marks:" + studentObject.hindi.Score);

                    Console.WriteLine("Student English marks:" + studentObject.english.Score);

                    Console.WriteLine("Student Maths marks:" + studentObject.maths.Score);

                    Console.WriteLine("Student Science marks:" + studentObject.science.Score);

                    Console.WriteLine("Student Social marks:" + studentObject.social.Score);

                    Console.WriteLine("Student Total marks:" + studentObject.TotalMarks);

                    Console.WriteLine("Student Percentage marks:" + studentObject.Percentage);

                }
            }
        }

        public static void Display()
        {
            List<School> schools = SchoolManagement.GetAllSchools();
            
 
            bool isSchoolExist = false;
            if(schools.Count > 0)
            {
                isSchoolExist=true;
            }
            if (isSchoolExist == true)
            {
                foreach (School school in schools)
                {
                    if (school.Students.Count > 0)
                    {
                        Console.WriteLine("School id is: " + school.SchoolId + " School name is: " + school.SchoolName);
                        for (int j = 0; j < school.Students.Count; j++)
                        {
                            Console.WriteLine("Student name is: " + school.Students[j].Name + " Student Roll number is: " + school.Students[j].StudentRollNumber);
                        }
                    }
                }
            }

        }
    }
}





