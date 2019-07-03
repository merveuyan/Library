using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryServices
{
    public class DataHelpers
    {
        public static List<string> HumanizeBizHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);

                var timeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(timeEntry);
            }

            return hours;
        }

        
        public static string HumanizeDay(int number)
        {
            return Enum.GetName(typeof(DayOfWeek), number);
        }

        public static string HumanizeTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }

        public static List<string> HumanizeNames(IEnumerable<Patron> patrons)
        {
            var names = new List<string>();
            foreach (var patron in patrons)
            {
                var fullname = patron.FirstName + " " + patron.LastName;
                names.Add(fullname);
            }
            return names;
        }
        public static List<string> HumanizeAssets(IEnumerable<LibraryAsset> assets)
        {
            var assetNames = new List<string>();
            foreach (var asset in assets)
            {
                // Library.Data.Models.'yı remove ediyorum.
                var assetname = $"{asset.Title}({asset.GetType().ToString().Substring(19)})";
                assetNames.Add(assetname);
            }
            return assetNames;
        }

    }
}
