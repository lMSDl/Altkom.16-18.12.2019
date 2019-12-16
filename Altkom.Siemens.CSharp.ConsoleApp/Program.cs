using Altkom.Siemens.CSharp.CollectionBasedService;
using Altkom.Siemens.CSharp.ConsoleApp.Models;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
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
                    case Commands.Edit:
                        EditPerson(Context.Read(id));
                        break;
                    case Commands.Exit:
                        return false;
                }
            }

            return true;
        }

        private static void EditPerson(Person person)
        {
            if (person == null)
                return;

            Console.WriteLine(nameof(Person.FirstName));
            SendKeys.SendWait(person.FirstName);
            person.FirstName = Console.ReadLine();

            Context.Update(person);
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