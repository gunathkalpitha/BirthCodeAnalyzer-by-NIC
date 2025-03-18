using NIC_project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NIC_project
{
    public class Nic
    {
        string? nic;
        int[]? nic_array;
        int totalDate;
        string? month;
        int date;
        int[]? year;
        int combinedYear;
        int monthIndex;
        int lifePathNumber;

        public void get_nic()
        {
            Console.WriteLine("=====YOUR BIRTHDAY=====");
            Console.WriteLine();
            Console.Write("Enter your NIC no(without V): ");
            nic = Console.ReadLine();
        }

        public void print()
        {
            int[] nic_array = nic.Select(digit => int.Parse(digit.ToString())).ToArray();
            if (9 != nic_array.Length && nic_array.Length != 12)
            {
                Console.WriteLine("Invalid NIC number!");
                return;
            }

            else if (nic_array.Length == 12)
            {
                int[] Year = new int[] { nic_array[0], nic_array[1], nic_array[2], nic_array[3] };
                int combinedYear = int.Parse(string.Join("", Year));

                int[] Gender = new int[] { nic_array[4], nic_array[5], nic_array[6] };
                int combinedGender = int.Parse(string.Join("", Gender));

                if (combinedGender > 500)
                {
                    Console.WriteLine("Gender:Female");
                    totalDate = combinedGender - 500;
                }
                else
                {
                    Console.WriteLine("Gender:Male");
                    totalDate = combinedGender;
                }

                CalculateBirthDetails(combinedYear, totalDate);
                //Console.WriteLine($"Life Path Number: {CalculateLifePathNumber(combinedYear, monthIndex + 1, date)}");
                int lifePathNumber = CalculateLifePathNumber(combinedYear, monthIndex + 1, date);
                DisplayLifePathMeaning(lifePathNumber);


            }
            else if (nic_array.Length == 9)
            {
                int[] Year = new int[] { 1, 9, nic_array[0], nic_array[1] };
                int combinedYear = int.Parse(string.Join("", Year));

                int[] Gender = new int[] { nic_array[2], nic_array[3], nic_array[4] };
                int combinedGender = int.Parse(string.Join("", Gender));

                if (combinedGender > 500)
                {
                    Console.WriteLine("Gender:Female");
                    totalDate = combinedGender - 500;
                }
                else
                {
                    Console.WriteLine("Gender:Male");
                    totalDate = combinedGender;
                }

                CalculateBirthDetails(combinedYear, totalDate);
                //Console.WriteLine($"Life Path Number: {CalculateLifePathNumber(combinedYear, monthIndex + 1, date)}");
                int lifePathNumber = CalculateLifePathNumber(combinedYear, monthIndex + 1, date);
              
                DisplayLifePathMeaning(lifePathNumber);



            }
        }
        private void CalculateBirthDetails(int year, int totalDate)
        {
            if (totalDate > 60)
            {
                totalDate = totalDate - 1;
            }
            else if(totalDate<60)
            {
                totalDate = totalDate;
            }
            int[] daysInMonths = { 31, (year % 4 == 0 ) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
         
            int m = 0;
            while (totalDate > daysInMonths[m]) 
            {
                totalDate = totalDate-daysInMonths[m];
                m++;
            }
            
           
            
                date = totalDate;
                month = monthNames[m];
                monthIndex = m;

            Console.WriteLine($"Birth Year: {year}");
                Console.WriteLine($"Month: {month}");
                Console.WriteLine($"Date: {date}");
       
        }


        private int CalculateLifePathNumber(int year, int monthIndex, int day)
        {
       
            int yearSum = SumDigits(year); 
            int monthSum = SumDigits(monthIndex );  
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

        public  void DisplayLifePathMeaning(int lifePathNumber)
        {
            switch (lifePathNumber)
            {
                case 1:
                    Console.WriteLine("Life Path Meaning: Leader - Independent, ambitious, and determined.");
                    break;
                case 2:
                    Console.WriteLine("Life Path Meaning: Peacemaker - Diplomatic, cooperative, and sensitive.");
                    break;
                case 3:
                    Console.WriteLine("Life Path Meaning: Communicator - Creative, expressive, and optimistic.");
                    break;
                case 4:
                    Console.WriteLine("Life Path Meaning: Builder - Hardworking, disciplined, and practical.");
                    break;
                case 5:
                    Console.WriteLine("Life Path Meaning: Adventurer - Energetic, curious, and freedom-loving.");
                    break;
                case 6:
                    Console.WriteLine("Life Path Meaning: Nurturer - Caring, responsible, and family-oriented.");
                    break;
                case 7:
                    Console.WriteLine("Life Path Meaning: Seeker - Analytical, spiritual, and intellectual.");
                    break;
                case 8:
                    Console.WriteLine("Life Path Meaning: Powerhouse - Ambitious, confident, and business-minded.");
                    break;
                case 9:
                    Console.WriteLine("Life Path Meaning: Humanitarian - Compassionate, wise, and idealistic.");
                    break;
                case 11:
                    Console.WriteLine("Life Path Meaning: Visionary - Intuitive, inspiring, and a spiritual teacher.");
                    break;
                case 22:
                    Console.WriteLine("Life Path Meaning: Master Builder - Practical genius with big achievements.");
                    break;
                case 33:
                    Console.WriteLine("Life Path Meaning: Master Teacher - Deep wisdom and helps others on a large scale.");
                    break;
                default:
                    Console.WriteLine("Life Path Meaning: Unknown.");
                    break;
            }
        }


    }
}





