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
            int userChoice = 0; bool flag = false;
            while (flag != true)
            {
               
            enterUserChoice: Console.WriteLine("1.Add School\n2.Add student\n3.Add marks of the student\n4.Show student progress card\n5.Display\n6.Exit");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserChoice;
                }
                if (userChoice < 1 && userChoice > 4)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserChoice;
                }


                switch (userChoice)
                {
                    case 1:
                       
                        School.AddSchool();
                        break;
                    case 2:
                        
                        Student.AddStudent();
                        break;
                    case 3:

                        Student.UpdateMarks();
                        break;
                    case 4:
                        Student.ViewProgress();
                        break;
                    case 5:
                        Student.Display();
                        break;
                    case 6:
                        flag = true;
                        break;
                   
                }
            }


        }
    }
}

    










