using System;
using System.Data;

namespace Task_tracker_console_project
{
    internal class Program
    {
        const int sz = 10000;
        static int cnt = 0;
        static string[] task_content = new string[sz];
        static bool[] task_done = new bool[sz];
        static void Main(string[] args)
        {
            // 0/ welcome user
            // 1/ add task
            // 2/ mark task complete(edit)
            // 3/ show all tasks
            // 4/ remove task
            // 5/ reset
            // 6/ exit

            start();

            int choice = 3;
            while (true)
            {

                options();

                Console.Write("Enter your choice : ");
                string s = Console.ReadLine();

                if (!int.TryParse(s, out choice))
                { 
                    Console.WriteLine("Worng input , please try agian \n");
                    continue;
                }
                
                if (choice == 1)
                {
                    if (cnt >= sz)
                    {
                        Console.WriteLine("enough tasks here \n");
                        continue;
                    }
                    cnt++;
                    add_task();
                    Console.Clear();
                    
                }
                else if (choice == 2)
                {
                    if (cnt < 1)
                    {
                        Console.WriteLine("No tasks here \n");
                        continue;
                    }
                    edit_task();
                    Console.Clear();
                }
                else if (choice == 3)
                {
                    
                    if (cnt < 1)
                    {
                        Console.WriteLine("No tasks here \n");
                        continue;
                    }
                    Console.Clear();
                    show_all_tasks();
                }
                else if (choice == 4 )
                {
                    if (cnt < 1)
                    {
                        Console.WriteLine("No tasks here \n");
                        continue;
                    }
                    del();
                    cnt--;

                    Console.Clear();
                }
                else if (choice == 5)
                {
                    if (cnt < 1)
                    {
                        Console.WriteLine("No tasks here \n");
                        continue;
                    }
                    reset();
                }
                else if(choice == 6)
                {
                    break;
                }
                else
                {

                    Console.WriteLine("Worng input , please try agian \n");
                }

            }
        }

        static void start()
        {
            Console.WriteLine("Welcome to Your task tracker :)\n");
        }
        static void options()
        {
            Console.WriteLine(" 1) Add a task");
            Console.WriteLine(" 2) Edit a task status");
            Console.WriteLine(" 3) Show all tasks");
            Console.WriteLine(" 4) Delete a task");
            Console.WriteLine(" 5) Reset");
            Console.WriteLine(" 6) Exit \n");
        }
        static void add_task()
        {
            while (true)
            {
                Console.Write("Enter the task's name : ");
                string name = Console.ReadLine();
                bool iss = false;
                for (int i = 1; i < cnt; i++)
                {
                    if (task_content[i] == name) iss = true;
                }
                if (iss)
                {
                    Console.WriteLine("This task is already here \n");
                }
                else
                {
                    task_content[cnt] = name;
                    task_done[cnt] = false;
                    break;
                }
            }
        }
        static void edit_task()
        {

            int num;
            while (true)
            {
                show_all_tasks();
                Console.Write("Enter your choice : ");
                string a = Console.ReadLine();
                if (!(int.TryParse(a, out num)) || (num < 1) || (num > cnt))
                {
                    Console.WriteLine("Worng input , please try again\n");
                }
                else break;
            }
            int c;
            while (true)
            {
                Console.WriteLine(" 1) Done \n" + " 2) not yet\n");
                Console.Write("Enter your choice :");
                string b = Console.ReadLine();
                if (!(int.TryParse(b, out c)) || (c != 1 && c != 2))
                {
                    Console.WriteLine("Worng input , please try again\n");
                }
                else break;
            }
            task_done[num] = (c == 1) ? true : false;
        }
        static void show_all_tasks()
        {
            for(int i = 1; i <= cnt; i++)
            {
                Console.WriteLine((i) + ") " + task_content[i] + " : " + (task_done[i] ? "Done" : "Go on"));
            }
            Console.WriteLine();
        }
        static void reset()
        {
            for(int i = 1; i <= cnt; i++)
            {
                task_done[i] = false;
            }
        }
        static void del()
        {

            int choice;
            while (true)
            {
                show_all_tasks();
                Console.Write("Enter your choice : ");
                string a = Console.ReadLine();
                if (!(int.TryParse(a, out choice)) || (choice < 1) || (choice > cnt))
                {
                    Console.WriteLine("Worng input , please try again\n");
                }
                else break;
            }
            for (int i = choice; i < cnt; i++)
            {
                task_content[i] = task_content[i + 1];
                task_done[i] = task_done[i + 1];
            }
        }
    }
}
