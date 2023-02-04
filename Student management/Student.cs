using Student_management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Studentmanagement
{
    public class Student
    {
        public int StudentRollnumber;
        public string Name;
        public float TotalMarks;
        public double Percentage;
        public List<Marks>SubjectMarks=new List<Marks>();

        Marks telugu = new Marks();
        Marks hindi = new Marks();
        Marks english = new Marks();
        Marks maths = new Marks();
        Marks science = new Marks();
        Marks social = new Marks();


        public static void AddStudent()
        {
            Student sc = new Student();
        enterRollnumber: Console.WriteLine("Enter Student Roll Number:");
            int studentRollnumber;

            try
            {
                studentRollnumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter valid roll number");
                goto enterRollnumber;
            }

            foreach (var student in School.students)
            {
                if (student.StudentRollnumber == studentRollnumber)
                {
                    Console.WriteLine("Roll number already exist");
                    goto enterRollnumber;
                }

            }

            string enterName;
            int isName = 1;
        enterStudentname: Console.WriteLine("Enter Student Name: ");
            enterName = Console.ReadLine();
            string nameRegex = @"^[a-zA-Z ]+$";
            Regex r = new Regex(nameRegex);

            if (!r.IsMatch(enterName) || enterName == "")
            {
                Console.WriteLine("Enter string as name");
                goto enterStudentname;
                isName = 0;
            }
            else
            {
                sc.Name = enterName;
                sc.StudentRollnumber = studentRollnumber;
            }

            School.students.Add(sc);
           

        }
        public static void UpdateMarks()
        {
            Student student= new Student();
            int studentRollid;
        enterRollid: Console.WriteLine("Enter Roll Number");

            try
            {
                studentRollid = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter valid roll number");
                goto enterRollid;
            }
            Student sc = new Student();
            int isStudentexist = 0;
            int i;
            int size = School.students.Count;
            for (i = 0; i < size; i++)
            {

                if (School.students[i].StudentRollnumber == studentRollid)
                {
                    isStudentexist = 1;
                    break;
                }
            }
            if (isStudentexist == 1)
            {
                sc = School.students[i];
                string teluguMarks;
                int isStudentmarks = 0;
                string re = @"^[0-9]*$";
                Regex r = new Regex(re);
                while (isStudentmarks != 1)
                {
                    Console.WriteLine("Enter Telugu marks:");

                    teluguMarks = Console.ReadLine();
                    isStudentmarks = 1;
                    if (!r.IsMatch(teluguMarks) || teluguMarks == "")
                    {

                        Console.WriteLine("Enter valid Marks");
                        isStudentmarks = 0;
                    }
                    else
                    {

                        sc.telugu.SubjectName = StudentSubjects.Subjects.telugu;
                        sc.telugu.Score = Convert.ToInt32(teluguMarks);
                        sc.SubjectMarks.Add(sc.telugu);
                       
                    }

                    if (sc.telugu.Score < 0 || sc.telugu.Score > 100)
                    {
                        isStudentmarks = 0;
                        Console.WriteLine("Enter valid Marks");

                    }

                }
                string hindiMarks;
                isStudentmarks = 0;
                re = @"^[0-9]*$";
                r = new Regex(re);
                while (isStudentmarks != 1)
                {
                    Console.WriteLine("Enter Hindi marks:");

                    hindiMarks = Console.ReadLine();
                    isStudentmarks = 1;
                    if (!r.IsMatch(hindiMarks) || hindiMarks == "")
                    {

                        Console.WriteLine("Enter valid Marks");
                        isStudentmarks = 0;
                    }
                    else
                    {

                        sc.hindi.SubjectName = StudentSubjects.Subjects.hindi;
                        sc.hindi.Score = Convert.ToInt32(hindiMarks);
                        sc.SubjectMarks.Add(sc.hindi);
                    }
                    if (sc.hindi.Score < 0 || sc.hindi.Score > 100)
                    {
                        isStudentmarks = 0;
                        Console.WriteLine("Enter valid Marks");

                    }

                }
                string englishMarks;
                isStudentmarks = 0;
                re = @"^[0-9]*$";
                r = new Regex(re);
                while (isStudentmarks != 1)
                {
                    Console.WriteLine("Enter English marks:");

                    englishMarks = Console.ReadLine();
                    isStudentmarks = 1;
                    if (!r.IsMatch(englishMarks) || englishMarks == "")
                    {

                        Console.WriteLine("Enter valid Marks");
                        isStudentmarks = 0;
                    }
                    else
                    {

                        sc.english.SubjectName = StudentSubjects.Subjects.english;
                        sc.english.Score = Convert.ToInt32(englishMarks);
                        sc.SubjectMarks.Add(sc.english);
                    }
                    if (sc.english.Score < 0 || sc.english.Score > 100)
                    {
                        isStudentmarks = 0;
                        Console.WriteLine("Enter valid Marks");

                    }

                }
                string mathsMarks;
                isStudentmarks = 0;
                re = @"^[0-9]*$";
                r = new Regex(re);
                while (isStudentmarks != 1)
                {
                    Console.WriteLine("Enter Maths marks:");

                    mathsMarks = Console.ReadLine();
                    isStudentmarks = 1;
                    if (!r.IsMatch(mathsMarks) || mathsMarks == "")
                    {

                        Console.WriteLine("Enter valid Marks");
                        isStudentmarks = 0;
                    }
                    else
                    {

                        sc.maths.SubjectName = StudentSubjects.Subjects.maths;
                        sc.maths.Score = Convert.ToInt32(mathsMarks);
                        sc.SubjectMarks.Add(sc.maths);
                    }
                    if (sc.maths.Score < 0 || sc.maths.Score > 100)
                    {
                        isStudentmarks = 0;
                        Console.WriteLine("Enter valid Marks");

                    }

                }
                string scienceMarks;
                isStudentmarks = 0;
                re = @"^[0-9]*$";
                r = new Regex(re);
                while (isStudentmarks != 1)
                {
                    Console.WriteLine("Enter Science marks:");

                    scienceMarks = Console.ReadLine();
                    isStudentmarks = 1;
                    if (!r.IsMatch(scienceMarks) || scienceMarks == "")
                    {

                        Console.WriteLine("Enter valid Marks");
                        isStudentmarks = 0;
                    }
                    else
                    {

                        sc.science.SubjectName = StudentSubjects.Subjects.science;
                        sc.science.Score = Convert.ToInt32(scienceMarks);
                        sc.SubjectMarks.Add(sc.science);
                    }
                    if (sc.science.Score < 0 || sc.science.Score > 100)
                    {
                        isStudentmarks = 0;
                        Console.WriteLine("Enter valid Marks");

                    }

                }
                string socialMarks;
                isStudentmarks = 0;
                re = @"^[0-9]*$";
                r = new Regex(re);
                while (isStudentmarks != 1)
                {
                    Console.WriteLine("Enter Social marks:");

                    socialMarks = Console.ReadLine();
                    isStudentmarks = 1;
                    if (!r.IsMatch(socialMarks) || socialMarks == "")
                    {

                        Console.WriteLine("Enter valid Marks");
                        isStudentmarks = 0;
                    }
                    else
                    {

                        sc.social.SubjectName = StudentSubjects.Subjects.social;
                        sc.social.Score = Convert.ToInt32(socialMarks);
                        sc.SubjectMarks.Add(sc.social);
                    }
                    if (sc.social.Score < 0 || sc.social.Score > 100)
                    {
                        isStudentmarks = 0;
                        Console.WriteLine("Enter valid Marks");

                    }
                }

                sc.TotalMarks = sc.telugu.Score + sc.hindi.Score + sc.english.Score + sc.maths.Score + sc.science.Score + sc.social.Score;
                sc.Percentage = Math.Round((double)sc.TotalMarks / 6, 2);
                
                School.students[i] = sc;
            }
            else
            {
                Console.WriteLine("No student with that roll number");
            }
        }

        public static void ViewProgress()
        {


            int studentRoll;
        enterRollnumber: Console.WriteLine("Enter Roll Number");

            try
            {
                studentRoll = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter valid RollNumber");
                goto enterRollnumber;
            }
            int isRoll = 0;
            foreach (var student in School.students)
            {
                if (student.StudentRollnumber == studentRoll)
                {

                    isRoll = 1;
                    break;

                }

            }
            if (isRoll == 0)
            {
                Console.WriteLine("roll number dosen't exist");
            }
            int isId = 0;
            int j;
            for (j = 0; j < School.students.Count; j++)
            {
                if (School.students[j].StudentRollnumber == studentRoll)
                {
                    isId = 1;
                    break;
                }
            }
            if (isId == 1)
            {
                Student sc = School.students[j];
                Console.WriteLine("Student Telugu marks:" + sc.telugu.Score);

                Console.WriteLine("Student Hindi marks:" + sc.hindi.Score);

                Console.WriteLine("Student English marks:" + sc.english.Score);

                Console.WriteLine("Student Maths marks:" + sc.maths.Score);

                Console.WriteLine("Student Science marks:" + sc.science.Score);

                Console.WriteLine("Student Social marks:" + sc.social.Score);

                Console.WriteLine("Student Total marks:" + sc.TotalMarks);

                Console.WriteLine("Student Percentage marks:" + sc.Percentage);

            }

        }
        public static void Display()
        {
            Console.WriteLine("Total Students");
            foreach (var student in School.students)
            {
                Console.WriteLine("Student with Rollnumber: " + student.StudentRollnumber + " \nName:" + student.Name);
            }
        }
    }

}


