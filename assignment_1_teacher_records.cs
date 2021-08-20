using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ConsoleApp2
{
    class teacher_records

    {
        public int id { get; set; }
        public string name { get; set; }
        public int cls { get; set; }
        public char sec { get; set; }

    }




    class assignment_1_teacher_records
    
    {
       static public void add_teachers(teacher_records new_record, List<teacher_records> teacher_list) 
       {         
            Console.WriteLine("\nEnter the number of records you want to enter..");
            int record_count = int.Parse(Console.ReadLine());

            for (int i = 0; i < record_count; i++)
            {
                Console.WriteLine("\nEnter the teacher's ID :");
                int ID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the teacher's name :");
                string NM = Console.ReadLine();

                Console.WriteLine("Enter Class :");
                int clss = int.Parse(Console.ReadLine()); // reading class from user input

                Console.WriteLine("Enter Section :");
                char secn = Console.ReadLine()[0];  // reading signle char from user


                new_record = new teacher_records();
                new_record.id = ID;
                new_record.name = NM;
                new_record.cls = clss;
                new_record.sec = secn;
                teacher_list.Add(new_record);

            }
        }




        static public void display_teachers(teacher_records new_record, List<teacher_records> teacher_list) 
        {
            
            for (int i = 0; i < teacher_list.Count; i++)

            {
                Console.WriteLine("\n\nID = " + teacher_list[i].id);
                Console.WriteLine("Teacher Name = " + teacher_list[i].name);
                Console.WriteLine("Class = " + teacher_list[i].cls);
                Console.WriteLine("Section = " + teacher_list[i].sec + "\n\n");
            }

            if (teacher_list.Count < 1)
                Console.WriteLine("\n Alert.., No teacher's data found \n");

        }




        static public void dump_data_to_text_file(List<teacher_records> teacher_list) 
        {
            string path_to_file = @"D:\file_handling\teachers_records.txt";
            string rec = "";

            
                for (int i = 0; i < teacher_list.Count; i++)
                {
                    rec += teacher_list[i].id + " " + teacher_list[i].name + " " + teacher_list[i].cls + " " + teacher_list[i].sec + "\n";
                }

                File.WriteAllText(path_to_file, rec);
            
            
        }




        static public void convert_text_data_to_list( teacher_records new_record, List<teacher_records> teacher_list)
        {
            string path_to_file = @"D:\file_handling\teachers_records.txt";

            if (File.Exists(path_to_file))
            { 
            
            
                string[] lines = File.ReadAllLines(path_to_file);
                String[] text_file_data;

                for (int i = 0; i < lines.Length; i++)
                {
                    text_file_data = lines[i].Split(' ');
                    new_record = new teacher_records();
                    new_record.id = int.Parse(text_file_data[0]);
                    new_record.name = text_file_data[1];
                    new_record.cls = int.Parse(text_file_data[2]);
                    new_record.sec = text_file_data[3][0];
                    teacher_list.Add(new_record);

                }
            }

            else
                Console.WriteLine("\nFile not found at location, A new file will be created\n");

        }




        static public void update_teachers_data(List<teacher_records> teacher_list)
        {
            Console.WriteLine("Enter the teacher's id to update data ..");
            int update_id = int.Parse(Console.ReadLine());

            int index = teacher_list.FindIndex(x => x.id == update_id);
            if (index > -1)
            {
                Console.WriteLine("Enter choice \n1. Name \n2. Class\n3. Section");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter new name ..");
                    string nn = Console.ReadLine();
                    teacher_list[index].name = nn;
                }

                if (choice == 2)
                {
                    Console.WriteLine("Enter new class allocated ..");
                    int nc = int.Parse(Console.ReadLine());
                    teacher_list[index].cls = nc;
                }

                if (choice == 3)
                {
                    Console.WriteLine("Enter new section allocated ..");
                    char ns = Console.ReadLine()[0];
                    teacher_list[index].sec = ns;
                }
            }
            
            else
                Console.WriteLine("\nIndex not found in records");
        
        }




        static public void delete_records(List<teacher_records> teacher_list)
        {
            Console.WriteLine("\nEnter the teacher's id to delete record ..");
            int delete_id = int.Parse(Console.ReadLine());
            int index = teacher_list.FindIndex(x => x.id == delete_id);

            if (index > -1)
            {
                Console.WriteLine("\nTeacher's Name :" +teacher_list[index].name + "\nAllocated Class :" + teacher_list[index].cls + "\nAllocated Section :" + teacher_list[index].sec);
                Console.WriteLine("Will be deleted from records ..\n");
                teacher_list.RemoveAt(index);
            }

            else
                Console.WriteLine("ID not found in records \n");



        }


        static void Main(string[] args)
        {
            /* We will create a list of teachers type each index of this list will hold an object of class teacher, 
            each instances will hold the records of teacher (id,name,class,section) 
         */
            // [obj1] [obj2] [obj3]

            List<teacher_records> teacher_list = new List<teacher_records>();

            // instantiating class teacher_record
           teacher_records new_record = null;

         

            convert_text_data_to_list(new_record, teacher_list);



            while (true)
            {
                Console.WriteLine("Enter Choice \n 1. Add a record \n 2. Display record \n 3. Save data to text file and Exit \n 4. Update data\n 5. Delete record\n 6. Exit without saving");
              //  try
                //{
                    int choice = int.Parse(Console.ReadLine());
                    
                    
                    switch (choice)
                    {
                        case 1:
                            add_teachers(new_record, teacher_list);
                            break;

                        case 2:
                            display_teachers(new_record,teacher_list);
                            break;

                        case 3:
                            dump_data_to_text_file(teacher_list);
                            break;

                        case 4:
                        update_teachers_data(teacher_list);
                            break;

                        case 5:
                            delete_records(teacher_list);
                            Console.WriteLine("Under Dev");
                            break;

                    case 6:
                        break;


                        
                    }

                  if (choice == 3 || choice == 6)  // breaking out of the while loop
                        break;
               // }

               // catch 
                //{
                  //  Console.WriteLine("Please enter a numerical value .. ");
               // }
            }



        }

    }
}
