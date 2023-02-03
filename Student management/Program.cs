using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Studentmanagement;
namespace Schoolmanagement
{
    class School
    {
        public static void Main(string[] args)
        {
            Student student = new Student();
            Dictionary<int, Student> students = new Dictionary<int, Student>();
            Student sc = new Student();
        enterSchoolname: Console.WriteLine("Enter school name:");
            string schoolname = Console.ReadLine()!;
            if (schoolname == "")
            {
                Console.WriteLine("Enter valid school name");
                goto enterSchoolname;
            }
            Console.WriteLine("-----Welcome to " + schoolname + "--------");
           
            int choice = 0, flag = 0;
            while (flag != 1)
            {
                enterChoice: Console.WriteLine("1.Add student\n2.Add marks of the student\n3.Show student progress card\n4.Exit");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterChoice;
                }
                if (choice <1 && choice>4) {
                    Console.WriteLine("Enter valid choice");
                    goto enterChoice;
                }
                switch (choice)
                {
                    case 1:
                        Student s = new Student();
                        addStudent(ref students, ref s);
                        break;
                    case 2:

                        updateMarks(ref students, ref sc);
                        break;
                    case 3:
                        viewProgress(ref students, ref sc);
                        break;
                    case 4:
                        flag = 1;
                        break;
                }
            }
            void addStudent(ref Dictionary<int,Student> students,ref Student sc)
            {
                read: Console.WriteLine("Enter Student Roll Number:");
                int studentRollnumber;

                try
                {
                    studentRollnumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid roll number");
                    goto read;
                }
                if (students.ContainsKey(studentRollnumber))
                {
                    Console.WriteLine("Roll number already exist");
                    goto read;
                }
              
                string tempname;
                int falg = 0;
                
                int flag = 1;
            enterStudentname: Console.WriteLine("Enter Student Name: ");
                tempname = Console.ReadLine();
                string re1 = @"^[a-zA-Z ]+$";
                Regex r = new Regex(re1);

                if (!r.IsMatch(tempname) || tempname == "")
                {
                    Console.WriteLine("Enter string as name");
                    goto enterStudentname;
                    flag = 0;
                }
                else
                {
                    sc.name = tempname;
                }
           
                students.Add(studentRollnumber, sc);
                
            }
            void updateMarks(ref Dictionary<int,Student> students,ref Student sc)
            {
                int sno;

                read: Console.WriteLine("Enter Roll Number");

                try
                {
                    sno = Convert.ToInt32(Console.ReadLine());
                
                }catch(FormatException ex) {
                    Console.WriteLine("Enter valid roll number");
                    goto read;
                }
                
                if (students.ContainsKey(sno))
                {
                    sc = students[sno];

                  
                    string temp1;
                    int flag = 0;
                    string re = @"^[0-9]*$";
                    Regex r = new Regex(re);
                    while (flag != 1)
                    {
                        Console.WriteLine("Enter Telugu marks:");

                        temp1 =Console.ReadLine();
                            flag = 1;
                        if (!r.IsMatch(temp1) || temp1=="")
                        {

                            Console.WriteLine("Enter valid Marks");
                            flag = 0;
                        }
                        else
                        {
                            sc.telugu = Convert.ToInt32(temp1);
                        }
                        if (sc.telugu < 0 || sc.telugu > 100)
                        {
                            flag = 0;
                            Console.WriteLine("Enter valid Marks");

                        }

                    }
                    string temp2;
                    flag = 0;
                    re = @"^[0-9]*$";
                    r = new Regex(re);
                    while (flag != 1)
                    {
                        Console.WriteLine("Enter Hindi marks:");

                        temp2 = Console.ReadLine();
                        flag = 1;
                        if (!r.IsMatch(temp2) || temp2 == "")
                        {

                            Console.WriteLine("Enter valid Marks");
                            flag = 0;
                        }
                        else
                        {
                            sc.hindi = Convert.ToInt32(temp2);
                        }
                        if (sc.hindi < 0 || sc.hindi > 100)
                        {
                            flag = 0;
                            Console.WriteLine("Enter valid Marks");

                        }

                    }
                    string temp3;
                    flag = 0;
                    re = @"^[0-9]*$";
                    r = new Regex(re);
                    while (flag != 1)
                    {
                        Console.WriteLine("Enter English marks:");

                        temp3 = Console.ReadLine();
                        flag = 1;
                        if (!r.IsMatch(temp3) || temp3 == "")
                        {

                            Console.WriteLine("Enter valid Marks");
                            flag = 0;
                        }
                        else
                        {
                            sc.english = Convert.ToInt32(temp3);
                        }
                        if (sc.english < 0 || sc.english > 100)
                        {
                            flag = 0;
                            Console.WriteLine("Enter valid Marks");

                        }

                    }
                    string temp4;
                    flag = 0;
                    re = @"^[0-9]*$";
                    r = new Regex(re);
                    while (flag != 1)
                    {
                        Console.WriteLine("Enter Maths marks:");

                        temp4 = Console.ReadLine();
                        flag = 1;
                        if (!r.IsMatch(temp4) || temp4 == "")
                        {

                            Console.WriteLine("Enter valid Marks");
                            flag = 0;
                        }
                        else
                        {
                            sc.maths = Convert.ToInt32(temp4);
                        }
                        if (sc.maths < 0 || sc.maths > 100)
                        {
                            flag = 0;
                            Console.WriteLine("Enter valid Marks");

                        }

                    }
                    string temp5;
                    flag = 0;
                    re = @"^[0-9]*$";
                    r = new Regex(re);
                    while (flag != 1)
                    {
                        Console.WriteLine("Enter Science marks:");

                        temp5 = Console.ReadLine();
                        flag = 1;
                        if (!r.IsMatch(temp5) || temp5 == "")
                        {

                            Console.WriteLine("Enter valid Marks");
                            flag = 0;
                        }
                        else
                        {
                            sc.science = Convert.ToInt32(temp5);
                        }
                        if (sc.science < 0 || sc.science > 100)
                        {
                            flag = 0;
                            Console.WriteLine("Enter valid Marks");

                        }

                    }
                    string temp6;
                    flag = 0;
                    re = @"^[0-9]*$";
                    r = new Regex(re);
                    while (flag != 1)
                    {
                        Console.WriteLine("Enter Social marks:");

                        temp6 = Console.ReadLine();
                        flag = 1;
                        if (!r.IsMatch(temp6) || temp6 == "")
                        {

                            Console.WriteLine("Enter valid Marks");
                            flag = 0;
                        }
                        else
                        {
                            sc.social = Convert.ToInt32(temp6);
                        }
                        if (sc.social < 0 || sc.social > 100)
                        {
                            flag = 0;
                            Console.WriteLine("Enter valid Marks");

                        }

                    }

                    sc.totalMarks =sc.telugu+sc.hindi+sc.english+sc.maths+sc.science+sc.social;
                    sc.percentage = Math.Round((double)sc.totalMarks / 6,2);
                    students[sno] = sc;
                }
                else
                {
                    Console.WriteLine("No student with that roll number");
                }
            }
            void viewProgress(ref Dictionary<int, Student> students, ref Student sc)
            {

                
                int sno;
                enterRollnumber: Console.WriteLine("Enter Roll Number");

                try
                    {
                        sno = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid RollNumber");
                        goto enterRollnumber;
                    }
                if(!students.ContainsKey(sno))
                {
                    Console.WriteLine("RollNumber does not exist");
                   
                }
                if (students.ContainsKey(sno))
                {
                    sc = students[sno];
                    Console.WriteLine("Enter Telugu marks:"+ sc.telugu);
             
                    Console.WriteLine("Enter Hindi marks:" + sc.hindi);
                   
                    Console.WriteLine("Enter English marks:"+sc.english);
                   
                    Console.WriteLine("Enter Maths marks:"+sc.maths);
                    
                    Console.WriteLine("Enter Science marks:"+sc.science);
                    
                    Console.WriteLine("Enter Social marks:"+sc.social);

                    Console.WriteLine("Enter Total marks:" + sc.totalMarks);

                    Console.WriteLine("Enter Percentage marks:" + sc.percentage);

                }

            }

        }

    }
}

