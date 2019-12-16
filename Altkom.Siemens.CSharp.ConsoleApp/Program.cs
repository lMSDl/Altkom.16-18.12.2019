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
        delegate void Output(string output);
        static Output TextOutput { get; set; }

        static void Main(string[] args)
        {
            TextOutput += WriteToConsole;
            TextOutput += outputString => Debug.WriteLine(outputString);


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
                var firstName = ReadPersonData(nameof(Person.FirstName), person.FirstName, text => string.IsNullOrWhiteSpace(text));
                var lastName = ReadPersonData(nameof(Person.LastName), person.LastName, text => string.IsNullOrWhiteSpace(text));

                var birtDateString = ReadPersonData(nameof(Person.BithDate), person.BithDate.ToShortDateString(), text => 
                {
                    DateTime dateTime;
                    return !DateTime.TryParse(text, out dateTime);
                }
                );
                var birtDate = DateTime.Parse(birtDateString);

                //TODO 3. Dodajemy edycję płci
                //TODO 4. Walidator płci Enum.IsDefined(typeof(Genders), ...)

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

        //delegate bool PersonDataValidator(string input);
        
        static string ReadPersonData(string header, string currentValue, Func<string, bool> validator)
        {
            string input;
            do
            {
                TextOutput(header);
                SendKeys.SendWait(currentValue);
                input = Console.ReadLine();
            } while (validator?.Invoke(input) ?? true);
            return input;
        }

        static void DisplayPeople()
        {
            List<string> personInfo = new List<string>();
            foreach (var item in Context.Read())
            {
                personInfo.Add(string.Format("{0, -3} {1, -15} {2, -15} {3, -10}",
                    item.PersonId, item.FirstName, item.LastName, item.BithDate.ToShortDateString()));
            }
            var @string = string.Join("\n", personInfo);
            //if(TextOutput != null)
            TextOutput?.Invoke(@string);
        }

        static void WriteToConsole(string output)
        {
            Console.Clear();
            Console.WriteLine(output);
            Console.WriteLine();
        }

    }
}