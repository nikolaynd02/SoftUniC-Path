using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class DateModifier
    {
        public int GetDiffInDays(string firstDate, string secondDate)
        {
            string[] firstInfo = firstDate.Split();
            string[] secondInfo = secondDate.Split();

            int firstYear = int.Parse(firstInfo[0]);
            int firstMounth = int.Parse(firstInfo[1]);
            int firstDay = int.Parse(firstInfo[2]);

            int secondYear = int.Parse(secondInfo[0]);
            int secondMounth = int.Parse(secondInfo[1]);
            int secondDay = int.Parse(secondInfo[2]);


            DateTime startDate = new DateTime(firstYear, firstMounth, firstDay);
            DateTime endDate = new DateTime(secondYear, secondMounth, secondDay);

            int diff = Math.Abs(int.Parse((endDate - startDate).TotalDays.ToString()));

            return diff;
        }
    }
}
