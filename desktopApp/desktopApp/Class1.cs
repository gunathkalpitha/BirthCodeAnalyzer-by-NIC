using System;
using System.Linq;

namespace NIC_project
{
    public class Nic
    {
        private string? nic; 
        private int totalDate;
        private string? month; 
        private int date;
        private int combinedYear;
        private int monthIndex;
        private int lifePathNumber;

        public void GetNic(string nicNumber)
        {
            nic = nicNumber;
        }

        public string Analyze()
        {
            if (string.IsNullOrEmpty(nic))
            {
                return "NIC number is not set.";
            }

            int[] nicArray = nic.Select(digit => int.Parse(digit.ToString())).ToArray();

            if (nicArray.Length != 9 && nicArray.Length != 12)
            {
                return "Invalid NIC number!";
            }

            string result = "";

            if (nicArray.Length == 12)
            {
                int[] yearDigits = new int[] { nicArray[0], nicArray[1], nicArray[2], nicArray[3] };
                combinedYear = int.Parse(string.Join("", yearDigits));

                int[] genderDigits = new int[] { nicArray[4], nicArray[5], nicArray[6] };
                int combinedGender = int.Parse(string.Join("", genderDigits));

                if (combinedGender > 500)
                {
                    result += "Gender: Female\n";
                    totalDate = combinedGender - 500;
                }
                else
                {
                    result += "Gender: Male\n";
                    totalDate = combinedGender;
                }

                CalculateBirthDetails(combinedYear, totalDate);
                result += $"Birth Year: {combinedYear}\n";
                result += $"Month: {month}\n";
                result += $"Date: {date}\n";

                lifePathNumber = CalculateLifePathNumber(combinedYear, monthIndex + 1, date);
                result += DisplayLifePathMeaning(lifePathNumber);
            }
            else if (nicArray.Length == 9)
            {
                int[] yearDigits = new int[] { 1, 9, nicArray[0], nicArray[1] };
                combinedYear = int.Parse(string.Join("", yearDigits));

                int[] genderDigits = new int[] { nicArray[2], nicArray[3], nicArray[4] };
                int combinedGender = int.Parse(string.Join("", genderDigits));

                if (combinedGender > 500)
                {
                    result += "Gender: Female\n";
                    totalDate = combinedGender - 500;
                }
                else
                {
                    result += "Gender: Male\n";
                    totalDate = combinedGender;
                }

                CalculateBirthDetails(combinedYear, totalDate);
                result += $"Birth Year: {combinedYear}\n";
                result += $"Month: {month}\n";
                result += $"Date: {date}\n";

                lifePathNumber = CalculateLifePathNumber(combinedYear, monthIndex + 1, date);
                result += DisplayLifePathMeaning(lifePathNumber);
            }

            return result;
        }

        private void CalculateBirthDetails(int year, int totalDate)
        {
            if ((year % 4 != 0)&&(totalDate>60))
            {
                totalDate -= 1;
            }

            int[] daysInMonths = { 31, (year % 4 == 0) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            int m = 0;
            while (totalDate > daysInMonths[m])
            {
                totalDate -= daysInMonths[m];
                m++;
            }

            date = totalDate;
            month = monthNames[m];
            monthIndex = m;
        }

        private int CalculateLifePathNumber(int year, int month, int day)
        {
            int yearSum = SumDigits(year);
            int monthSum = SumDigits(month);
            int daySum = SumDigits(day);

            int sum = yearSum + monthSum + daySum;

            while (sum >= 10 && sum != 11 && sum != 22 && sum != 33)
            {
                sum = SumDigits(sum);
            }

            return sum;
        }

        private int SumDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        private string DisplayLifePathMeaning(int lifePathNumber)
        {
            switch (lifePathNumber)
            {
                case 1:
                    return "Life Path Meaning: Leader - Independent, ambitious, and determined.\n";
                case 2:
                    return "Life Path Meaning: Peacemaker - Diplomatic, cooperative, and sensitive.\n";
                case 3:
                    return "Life Path Meaning: Communicator - Creative, expressive, and optimistic.\n";
                case 4:
                    return "Life Path Meaning: Builder - Hardworking, disciplined, and practical.\n";
                case 5:
                    return "Life Path Meaning: Adventurer - Energetic, curious, and freedom-loving.\n";
                case 6:
                    return "Life Path Meaning: Nurturer - Caring, responsible, and family-oriented.\n";
                case 7:
                    return "Life Path Meaning: Seeker - Analytical, spiritual, and intellectual.\n";
                case 8:
                    return "Life Path Meaning: Powerhouse - Ambitious, confident, and business-minded.\n";
                case 9:
                    return "Life Path Meaning: Humanitarian - Compassionate, wise, and idealistic.\n";
                case 11:
                    return "Life Path Meaning: Visionary - Intuitive, inspiring, and a spiritual teacher.\n";
                case 22:
                    return "Life Path Meaning: Master Builder - Practical genius with big achievements.\n";
                case 33:
                    return "Life Path Meaning: Master Teacher - Deep wisdom and helps others on a large scale.\n";
                default:
                    return "Life Path Meaning: Unknown.\n";
            }
        }
    }
}
