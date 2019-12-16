using Altkom.Siemens.CSharp.CollectionBasedService;
using Altkom.Siemens.CSharp.ConsoleApp.Models;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altkom.Siemens.CSharp.ConsoleApp
{
    class Program
    {
        static Context Context { get; } = new Context();

        static void Main(string[] args)
        {
            do
            {
                DisplayPeople();
            } while (ExecuteCommand(Console.ReadLine()));

        }

        static bool ExecuteCommand(string input)
        {
            var splittedInput = input.Split(' ');
            int id = 0;
            if (splittedInput.Length > 1)
                int.TryParse(splittedInput[1], out id);

            if (Enum.TryParse(splittedInput[0], true, out Commands command))
            {
                switch (command)
                {
                    case Commands.Delete:
                        DeletePerson(id);
                        break;
                    case Commands.Add:
                        AddPerson();
                        break;
                    case Commands.Edit:
                        EditPerson(id);
                        break;
                    case Commands.Exit:
                        return false;
                }
            }

            return true;
        }

        private static void DeletePerson(int id)
        {
            Context.Delete(id);
        }

        private static void AddPerson()
        {
            var person = new Person();
            if (EditPerson(person))
                Context.Create(person);

        }

        private static void EditPerson(int id)
        {
            var person = Context.Read(id);
            if(EditPerson(person))
            Context.Update(person);
        }

        private static bool EditPerson(Person person)
        {
            if (person == null)
                return false;
            try
            {
                Console.WriteLine(nameof(Person.FirstName));
                SendKeys.SendWait(person.FirstName);
                var firstName = Console.ReadLine();

                Console.WriteLine(nameof(Person.LastName));
                SendKeys.SendWait(person.LastName);
                var lastName = Console.ReadLine();

                Console.WriteLine(nameof(Person.BithDate));
                SendKeys.SendWait(person.BithDate.ToShortDateString());
                var birtDate = DateTime.Parse(Console.ReadLine());


                person.FirstName = firstName;
                person.LastName = lastName;
                person.BithDate = birtDate;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            return true;
        }

        static void DisplayPeople()
        {
            foreach (var item in Context.Read())
            {
                var personInfo = string.Format("{0, -3} {1, -15} {2, -15} {3, -10}",
                    item.PersonId, item.FirstName, item.LastName, item.BithDate.ToShortDateString());
                Console.WriteLine(personInfo);
            }
        }
    }
}