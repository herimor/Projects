using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace itCompany
{

    public class func
    {

        public void ChangeRole(Class1 employee, string act = "")
        {
            Console.WriteLine("Change employer role: 0 - no || 1 - yes");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Demote - 0 || Promote - 1");
                act = Console.ReadLine();
                if (act == "0")
                {
                    Console.WriteLine("Current role: {0}", employee.getRole());
                    Console.WriteLine("Changed role: {0}", employee.roleDown());
                }
                else if (act == "1")
                {
                    Console.WriteLine("Current role: {0}", employee.getRole());
                    Console.WriteLine("Changed role: {0}", employee.roleUp());
                }
            }
            Console.WriteLine();
        }

        public void ChangeDepartment(Class1 employee, string act = "")
        {
            Console.WriteLine("Change department: 0 - no || 1 - yes");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("To change department in list to right enter: 1 or to left enter: -1");
                act = Console.ReadLine();
                Console.WriteLine("Current department: {0}", employee.getDepartment());
                Console.WriteLine("Changed department: {0}", employee.departmentChanged(Convert.ToInt32(act)));
            }
            Console.WriteLine();
        }

        public void ChangeContacts(Class1 employee, string act = "", string act1 = "")
        {
            Console.WriteLine("Change contacts: 0 - no || 1 - yes");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Enter new phone number:");
                act = Console.ReadLine();
                Console.WriteLine("Enter new address:");
                act1 = Console.ReadLine();
                Console.WriteLine("Current contacts: {0} {1}", employee.getContacts()[0], employee.getContacts()[1]);
                Console.WriteLine("Changed contacts: {0} {1}", employee.changeContacts(act, act1)[0], employee.changeContacts(act, act1)[1]);
            }
            Console.WriteLine();
        }

        public void reWriteChanges(Class1 employee, string[] currentNote, List<string[]> allNote)
        {
            string splitted = string.Empty;
            foreach(string[] arrays in allNote)
            {
                if(arrays[0] == currentNote[0])
                {
                    allNote.Remove(arrays);
                    break;
                }
            }
            using (StreamWriter sw = File.CreateText("Company.txt"))   //AppendText
            {
                foreach (string[] note in allNote)
                {
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", note[0], note[1], note[2], note[3], note[4], note[5], note[6], note[7]);
                }
            }
        }
        public void ShowBySurname(string surname, ref List<Class1> allEmployee, ref List<string[]> allNote, ref string[] currentNote)
        {
            allNote = new List<string[]>();
            allEmployee.Clear();
            using (FileStream fs = new FileStream("Company.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                        allNote.Add(sr.ReadLine().Split(new Char[] { '\t' }));
                }
            }
            allNote.RemoveAt(allNote.Count - 1);
            foreach (string[] array in allNote)
            {
                if (array[0] == surname)
                {
                    Class1 employee = new Class1(array[0], array[1], array[2], Convert.ToInt32(array[3]), array[4], array[5], array[6], Convert.ToInt32(array[7]));
                    currentNote = array;
                    employee.Show();
                    allEmployee.Add(employee);
                    Console.WriteLine();
                    break;
                }
            }
            Console.WriteLine();
        }
        public void Show(ref List<Class1> allEmployee)
        {
            List<string[]> allNote = new List<string[]>();
            allEmployee.Clear();
            using (FileStream fs = new FileStream("Company.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                        allNote.Add(sr.ReadLine().Split(new Char[] { '\t' }));
                }
            }
            allNote.RemoveAt(allNote.Count - 1);
            foreach (string[] array in allNote)
            {
                Class1 employee = new Class1(array[0], array[1], array[2], Convert.ToInt32(array[3]), array[4], array[5], array[6], Convert.ToInt32(array[7]));
                employee.Show();
                allEmployee.Add(employee);
            }
            Console.WriteLine();
        }
        public void SetRoles()
        {
            Console.WriteLine("Choose role: 0 - developer || 1 - qa || 2 - project manager || 3 - business analyst || 4 - product owner");
        }

        public void setDepartment()
        {
            Console.WriteLine("Choose department: 0 - analytic || 1 - develop || 2 - sales");
        }

        public void hierarchy(List<Class1> classArray)
        {
            string chief = "";
            foreach (Class1 classExp in classArray)
            {
                if (classExp.chief == "none")
                {
                    chief = classExp.fio[0];
                    fio_Role(classExp);
                    continue;
                }
            }
            RecChief(classArray, chief);
        }

        private void fio_Role(Class1 classExp, string tab = "")
        {
            Console.Write("{0}", tab);
            foreach (string items in classExp.fio)
                Console.Write("{0} ", items);
            Console.Write("{0}\n", classExp.getRole());
        }

        private void RecChief(List<Class1> classArray, string currentChief, string hierarchyTab = "\t")
        {
            foreach (Class1 classExp in classArray)
            {
                if (classExp.chief == currentChief)
                {
                    fio_Role(classExp, hierarchyTab);
                    hierarchyTab += "\t";
                    RecChief(classArray, classExp.fio[0], hierarchyTab);
                    hierarchyTab = hierarchyTab.Substring(0, hierarchyTab.Length - 1);
                }
            }
        }
    }

    public class Class1
    {
        public string[] fio;
        Dictionary<int, string> role = new Dictionary<int, string>();
        Dictionary<int, string> department = new Dictionary<int, string>();
        string[] roleArray = { "developer", "qa", "project manager", "business analyst", "product owner" };
        string[] departmentArray = { "analytic department", "develop department", "sales department" };
        int roleIndex, departmentIndex;
        string[] contacts = new string[2];
        public string chief;

        public Class1(string surname, string name, string patronymic, int roleIndex, string phoneNumber, string adress, string chief, int departmentIndex)
        {
            FIO(surname, name, patronymic);
            this.roleIndex = roleIndex;
            changeContacts(phoneNumber, adress);
            this.chief = chief;
            this.departmentIndex = departmentIndex;
            Roles();
            Departments();
        }

        public void Write()
        {
            using (StreamWriter sw = File.AppendText("Company.txt"))
            {
                sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\n", fio[0], fio[1], fio[2], roleIndex, contacts[0], contacts[1], chief, departmentIndex);
            }
        }

        public void Show()
        {
            foreach (string item in fio)
                Console.Write("{0} ", item);
            Console.WriteLine("Role: {0} || Chief: {1} || Department: {2}", role[roleIndex], chief, department[departmentIndex]);
            Console.WriteLine("Contacts:");
            foreach (string item in contacts)
                Console.Write("{0}\t", item);
        }

        private string[] FIO(string surname, string name, string patronymic)
        {
            fio = new string[] { surname, name, patronymic };
            return fio;
        }

        private void Roles()
        {
            role.Clear();
            for (int i = 0; i < roleArray.Length; i++)
                role.Add(i, roleArray[i]);
        }

        private void Departments()
        {
            department.Clear();
            for (int i = 0; i < departmentArray.Length; i++)
                department.Add(i, departmentArray[i]);
        }

        public string departmentChanged(int rightLeft)
        {
            if (rightLeft == 1)
            {
                if (departmentIndex < 2)
                    departmentIndex++;
                else
                    Console.WriteLine("it`s impossible to change department in right side, try left");
            }
            else if(rightLeft == -1)
            {
                if (departmentIndex > 1)
                    departmentIndex--;
                else
                    Console.WriteLine("it`s impossible to change department in left side, try right");
            }
                return getDepartment();
        }
        public string roleUp()
        {
            if (roleIndex < 4)
                roleIndex++;
            else
                Console.WriteLine("it`s impossible to promote");
            return getRole();
        }

        public string roleDown()
        {
            if (roleIndex > 0)
                roleIndex--;
            else
                Console.WriteLine("it`s impossible to demote");
            return getRole();
        }

        public string[] changeContacts(string phoneNumber, string adress)
        {
            contacts[0] = phoneNumber;
            contacts[1] = adress;
            return contacts;
        }

        public string[] getContacts()
        {
            return contacts;
        }

        public string getRole()
        {
            return role[roleIndex];
        }

        public string getDepartment()
        {
            return department[departmentIndex];
        }

    }
}
