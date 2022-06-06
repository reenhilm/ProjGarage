using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjGarage.Vehicles;

[assembly:InternalsVisibleTo("MainMethods.Tests")]
namespace ProjGarage
{

    internal static class Util
    {    
        public static LicensePlate AskForLicensePlate(string question, string questionName, Action<string> print, Func<string?> getLine)
        {
            LicensePlate plate;
            do
            {
                plate = new(Util.AskForString(question, questionName, print, getLine: getLine));
                if (!plate.IsValid())
                    plate.InvalidReasons().ForEach(reason => print?.Invoke(reason));
            }
            while (!plate.IsValid());
            return plate;
        }
        public static bool AskUserWantsYes(string question, Action<string> print, Func<string?> getLine)
        {
            string line;
            while (true)
            {
                print?.Invoke($"{question} {Language.ShortYES}/{ Language.ShortNO}");
                line = getLine?.Invoke() ?? String.Empty;

                if (!string.IsNullOrWhiteSpace(line))                  
                {
                    line = line.Trim().ToUpper();
                    if (line == Language.ShortYES || line == Language.YES)
                        return true;
                    else if (line == Language.ShortNO || line == Language.NO)
                        return false;
                }
                print?.Invoke(string.Concat(Language.MustEnterYesOrNoEnglish));
            }            
        }
        public static string AskForString(string question, string questionName, Action<string> print, Func<string?> getLine)
        {
            bool success = false;
            string line;
            do
            {
                print?.Invoke(question);
                line = getLine?.Invoke() ?? String.Empty;

                if (string.IsNullOrWhiteSpace(line))
                    print?.Invoke(string.Concat(Language.MustEnterValidEnglish + questionName));
                else
                    success = true;
            }
            while (!success);
            return line;
        }
        public static int AskForInt(string question, string questionName, Action<string> print, Func<string> getLine)
        {
            while (true)
            {
                print?.Invoke(question);
                string line = getLine?.Invoke() ?? String.Empty;

                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (int.TryParse(line, out int iNumber))
                        return iNumber;
                }
                print?.Invoke(string.Concat(Language.MustEnterValidEnglish + questionName));
            }
        }
        public static VehicleColor AskForColor(string question, string questionName, Action<string> print, Func<string> getLine)
        {
            while (true)
            {
                print?.Invoke(Language.ValidColorsEnglish);
                Enum.GetNames<VehicleColor>().ToList().ForEach(x => print?.Invoke(x));
                print?.Invoke(question);
                string line = getLine?.Invoke() ?? String.Empty;

                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (Enum.TryParse<VehicleColor>(line, true, out VehicleColor color))
                        return color;
                }
                print?.Invoke(string.Concat(Language.MustEnterValidEnglish + questionName));
            }
        }

        private static List<Type> AllTypes = new()
        {
            typeof(Airplane),
            typeof(Boat),
            typeof(Bus),
            typeof(Car),
            typeof(Motorcycle),
            typeof(Vehicle)
        };
        public static string AskForTypeName(string question, string questionName, Action<string> print, Func<string> getLine)
        {
            while (true)
            {
                List<Type> allTypes = AllTypes;
                print?.Invoke(Language.ValidTypesEnglish);
                allTypes.ForEach(x => print?.Invoke(x.Name));
                print?.Invoke(question);
                string line = getLine?.Invoke() ?? String.Empty;

                if (!string.IsNullOrWhiteSpace(line))
                {
                    Type? type = allTypes.FirstOrDefault(x => x.Name.ToUpper() == line.ToUpper().Trim());
                    if(type != null)
                        return type.Name;
                }
                print?.Invoke(string.Concat(Language.MustEnterValidEnglish + questionName));
            }
        }
    }
}
