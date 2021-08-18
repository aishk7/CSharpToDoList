using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Program
    {
        static int sortPrio(ToDoList A, ToDoList B)
        {
            if (A.prio > B.prio)
                return 1;
            else
                return -1;
        }

        static int sortDead(ToDoList A, ToDoList B)
        {
            if (A.dead > B.dead)
                return 1;
            else
                return -1;
        }

        static int sortId(ToDoList A, ToDoList B)
        {
            if (A.id > B.id)
                return 1;
            else
                return -1;
        }
        static void Main(string[] args)
        {
            int flg = 0;
            int id, prio;
            string nm, msg, status;
            DateTime dead;

            List<ToDoList> list = new List<ToDoList>();
            list.Add(new ToDoList(101, "Reading", "Complete till 4th chapter", "Pending", 3, new DateTime(2021,09,21)));
            list.Add(new ToDoList(102, "Emails", "Reply to Emails", "Pending", 1, new DateTime(2021,08,17)));
            list.Add(new ToDoList(103, "Project", "Push the Code", "Pending", 2, new DateTime(2021,08,21)));


            while (flg == 0)
            {
                Console.WriteLine("\n\n-----------Welcome To To-Do List!-----------\n\nChoose The Option :- \n\n" +
                    "\t1.Create New Task \n\t2.View Task by ID \n\t3.View All Tasks \n\t4.Edit a Task \n\t5.Delete a Task" +
                    "\n\t6.Sort by Deadline \n\t7.Sort by Priority \n\t8.Sort by ID \n\t9.Exit Application\n--------------------------------------------");
                int opt = Convert.ToInt32(Console.ReadLine());
                int flag = 0;
                int choice;
                switch (opt)
                {
                    case 1:
                        idlabel:
                        try
                        {
                            Console.Write("Enter Task ID : ");
                            id = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error encountered : " + ex.Message);
                            goto idlabel;
                        }

                        Console.Write("Enter Task Name : ");
                        nm = Console.ReadLine();
                        
                        Console.Write("Enter Message : ");
                        msg = Console.ReadLine();
                        
                        priority:
                        try
                        {
                            Console.Write("Enter Priority : ");
                            prio = Convert.ToInt32(Console.ReadLine());
                            if (prio < 1 || prio > 3)
                                throw new Exception("Priority entered is incorrect.");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error encountered : "+ex.Message);
                            goto priority;
                        }
                        
                        deadline:
                        try
                        {
                            Console.WriteLine("Deadline-");
                            Console.Write("\tEnter a month: ");
                            int month = int.Parse(Console.ReadLine());
                            Console.Write("\tEnter a day: ");
                            int day = int.Parse(Console.ReadLine());
                            Console.Write("\tEnter a year: ");
                            int year = int.Parse(Console.ReadLine());
                            dead = new DateTime(year, month, day);

                            if (DateTime.Now > dead)
                                throw new Exception("Please Enter appropriate Deadline");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error encountered : " + ex.Message);
                            goto deadline;
                        }


                        status = "Pending";

                        list.Add(new ToDoList(id, nm, msg, status, prio, dead));
                        Console.WriteLine("Task has been added to the List!");
                        break;

                    case 2:
                    idlabel1:
                        try
                        {
                            Console.Write("Enter Task ID : ");
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error encountered : " + ex.Message);
                            goto idlabel1;
                        }
                        foreach (var item in list)
                        {
                            if(choice == item.id)
                            {
                                Console.WriteLine($"\n\n\tID : {item.id}\n\tName : {item.name}\n\tMessage : {item.msg}" +
                                    $"\n\tPriority : {item.prio}\n\tStatus : {item.status}\n\tDeadline : {item.dead}");
                                flag = 1;
                                break;
                            }
                            
                        }
                        if (flag != 1)
                            Console.WriteLine("ID Not Found!");
                        break;

                    case 3:
                        display:
                        bool isEmpty = !list.Any();
                        if (isEmpty)
                            Console.WriteLine("No Tasks in List!");
                        else
                        {
                            Console.WriteLine("Choose The Formatting Option : \n\t1.Asterik\n\t2.Dashed\n\t3.Hashed");
                            int o  = Convert.ToInt32(Console.ReadLine());
                            if(o==1)
                            {
                                foreach (var item in list)
                                {
                                    Console.WriteLine($"\n\n--------------------------------------------\n\t*ID : {item.id}\n\t*Name : {item.name}\n\t*Message : {item.msg}" +
                                            $"\n\t*Priority : {item.prio}\n\t*Status : {item.status}\n\t*Deadline : {item.dead} \n--------------------------------------------");
                                }
                            }
                            else if(o==2)
                            {
                                foreach (var item in list)
                                {
                                    Console.WriteLine($"\n\n--------------------------------------------\n\t-ID : {item.id}\n\t-Name : {item.name}\n\t-Message : {item.msg}" +
                                            $"\n\t-Priority : {item.prio}\n\t-Status : {item.status}\n\t-Deadline : {item.dead} \n--------------------------------------------");
                                }
                            }
                            else if(o==3)
                            {
                                foreach (var item in list)
                                {
                                    Console.WriteLine($"\n\n--------------------------------------------\n\t#ID : {item.id}\n\t#Name : {item.name}\n\t#Message : {item.msg}" +
                                            $"\n\t#Priority : {item.prio}\n\t#Status : {item.status}\n\t#Deadline : {item.dead} \n--------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Choice Entered!");
                            }
                            
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.Write("Enter ID of Task to be Edited : ");
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error encountered : " + ex.Message);
                            goto idlabel1;
                        }
                        Console.WriteLine("\n\nCoose Option :-\n1.Edit Message\n2.Edit Status\n3.Edit Priority");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        flag = 0;
                        foreach (var item in list)
                        {
                            if (choice == item.id)
                            {
                                if (ch == 1)
                                {
                                    Console.WriteLine("Enter New Message : ");
                                    string nmsg = Console.ReadLine();
                                    item.msg = nmsg;
                                    flag = 1;
                                    break;
                                }
                                else if (ch == 2)
                                {
                                    Console.WriteLine("Enter New Status : ");
                                    string nstatus = Console.ReadLine();
                                    item.status = nstatus;
                                    flag = 1;
                                    break;
                                }
                                else if (ch == 3)
                                {
                                    Console.WriteLine("Enter New Priority : (Complete/Incomplete/Pending)");
                                    int nprio = Convert.ToInt32(Console.ReadLine());
                                    item.prio = nprio;
                                    flag = 1;
                                    break;
                                }
                                else
                                    Console.WriteLine("Wrong Choice Entered!");
                            }
                        }
                        if (flag != 1)
                            Console.WriteLine("ID Not Found!");
                        else 
                            Console.WriteLine("Task has been Updated!");
                        break;

                    case 5:
                        try
                        {
                            Console.Write("Enter ID of Task to be Deleted : ");
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error encountered : " + ex.Message);
                            goto idlabel1;
                        }
                        flag = 0;
                        foreach (var item in list)
                        {
                            if (choice == item.id)
                            {
                                list.Remove(item);
                                flag = 1;
                                break;
                            }
                        }
                        if (flag != 1)
                            Console.WriteLine("ID Not Found!");
                        else
                            Console.WriteLine("Task has been Deleted!");
                        break;

                    case 6:
                        list.Sort(sortDead);
                        goto display;
                        //break;

                    case 7:
                        list.Sort(sortPrio);
                        goto display;
                        //break;

                    case 8:
                        list.Sort(sortId);
                        goto display;
                        //break;

                    case 9:
                        Console.WriteLine("Thanks For Using To-Do List!");
                        flg = 1;
                        break;

                    default:
                        Console.WriteLine("Please Enter Correct Option");
                        break;


                }


            }
        }
    }
}
