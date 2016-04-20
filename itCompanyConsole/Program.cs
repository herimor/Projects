using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using itCompany;

namespace itCompanyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<itCompany.Class1> allEmployee = new List<itCompany.Class1>();
                List<string[]> allNote = new List<string[]>();
                string[] currentNote = new string[8];
                itCompany.func Function = new func();
                Console.WriteLine("Choose action: 0 - addNote || 1 - OpenNote");
                string act = Console.ReadLine();
                if (act == "0")
                {
                    Console.WriteLine("Enter surname:");
                    string sunrname = Console.ReadLine();
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter patronymic:");
                    string patronymic = Console.ReadLine();
                    Function.SetRoles();
                    int roleIndex = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter phoneNumber:");
                    string phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter address:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter chief:");
                    string chief = Console.ReadLine();
                    Function.setDepartment();
                    int departmentIndex = Convert.ToInt32(Console.ReadLine());
                    Class1 employee = new Class1(sunrname, name, patronymic, roleIndex, phoneNumber, address, chief, departmentIndex);
                    allEmployee.Add(employee);
                    employee.Show();
                    employee.Write();
                    Console.ReadLine();
                }
                else if (act == "1")
                {
                    Console.WriteLine("Show by surname - 0 || showAll - 1");
                    act = Console.ReadLine();
                    if (act == "0")
                    {
                        try
                        {
                            Console.WriteLine("Enter surname:");
                            Function.ShowBySurname(Console.ReadLine(), ref allEmployee, ref allNote, ref currentNote);
                            Function.ChangeRole(allEmployee[0], act);
                            Function.ChangeContacts(allEmployee[0], act);
                            Function.ChangeDepartment(allEmployee[0]);
                            Function.reWriteChanges(allEmployee[0], currentNote, allNote);
                            allEmployee[0].Write();
                            Console.ReadLine();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Enter correct values");
                        }
                    }
                    else if (act == "1")
                    {
                        Function.Show(ref allEmployee);
                        Console.WriteLine("Show hierachy: 0 - no || 1 - yes");
                        act = Console.ReadLine();
                        if (act == "1")
                            Function.hierarchy(allEmployee);
                        Console.ReadLine();
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter correct values");
            }
        }
    }
}
