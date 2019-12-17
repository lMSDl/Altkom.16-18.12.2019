using Altkom.Siemens.CSharp.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.ConsoleApp.Extensions
{
    public static class StringExtensions
    {
        public static int? ToInt(this string @string)
        {
            if (int.TryParse(@string, out int result))
            {
                return result;
            }
            else
                return null;
        }

        public static Commands? ToCommand(this string @string)
        {
            try
            {
                return (Commands)Enum.Parse(typeof(Commands), @string, true); //w razie niepowodzenia rzutowania - wyjątek
                //return Enum.Parse(typeof(Commands), @string, true) as Commands; //w razie niepowodzenia rzutowania - null
            }
            catch//(Exception e)
            {
                return null;
            }
        }

        public static DateTime? ToDateTime(this string @string)
        {
            if (DateTime.TryParse(@string, out DateTime result))
            {
                return result;
            }
            else
                return null;
        }
    }
}
