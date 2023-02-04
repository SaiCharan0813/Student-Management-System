using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Student_management;
using Studentmanagement;
namespace Schoolmanagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            School school = new School();


            string schoolName;
            int isSchoolnamevalid = 1;
        enterSchoolname: Console.WriteLine("Enter school name:");
            schoolName = Console.ReadLine();
            string regexForname = @"^[a-zA-Z ]+$";
            Regex r = new Regex(regexForname);

            if (!r.IsMatch(schoolName) || schoolName == "")
            {
                Console.WriteLine("Enter string as name");
                goto enterSchoolname;
                isSchoolnamevalid = 0;
            }
            else
            {
                school.schoolName = schoolName;
            }
        
             
        schoolId: Console.WriteLine("Enter School Id:");
            try
            {
                school.schoolId = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter number as School Id");
                goto schoolId;
            }


            Console.WriteLine("-----Welcome to " + school.schoolName.ToUpperInvariant() + " School with an id " + school.schoolId + "--------");

            int userChoice = 0, flag = 0;
            while (flag != 1)
            {
            enterUserchoice: Console.WriteLine("1.Add student\n2.Add marks of the student\n3.Show student progress card\n4.Exit\n5.Display");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserchoice;
                }
                if (userChoice < 1 && userChoice > 4)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserchoice;
                }
                switch (userChoice)
                {
                    case 1:
                        Student s = new Student();
                        Student.AddStudent();
                        break;
                    case 2:

                        Student.UpdateMarks();
                        break;
                    case 3:
                        Student.ViewProgress();
                        break;
                    case 4:
                        flag = 1;
                        break;
                    case 5:
                        Student.Display();
                        break;
                }
            }


        }
    }
}

    










