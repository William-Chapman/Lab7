using System;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Program
    {
        static void Main()
        {
            do
            {
                string userInput;
                string result;
                Console.WriteLine("What would you like to validate?");
                Console.WriteLine("(Name, Email, Phone Number, Date, Html)");
                userInput = Console.ReadLine();
                result = Ask(userInput);
                if(result != "")
                {
                    Console.WriteLine(result);
                }
            }
            while (Continue() == 1);
        }

        static string Ask(string userInput)
        {
            string userName;
            string email;
            string phoneNum;
            string date;
            string html;
            string response = "";

            if (userInput.ToLower() == "name")
            {
                Console.WriteLine("Be sure to capitalize the first letter.");
                Console.Write("Enter your first name: ");
                userName = Console.ReadLine();
                response = ValidateName(userName);
            }
            else if (userInput.ToLower() == "email")
            {
                Console.WriteLine("eg. JohnDoe@email.com");
                Console.Write("Enter your Email: ");
                email = Console.ReadLine();
                response = ValidateEmail(email);
            }
            else if (userInput.ToLower() == "phone number")
            {
                Console.WriteLine("eg. 555-555-5555");
                Console.Write("Enter your Phone Number: ");
                phoneNum = Console.ReadLine();
                response = ValidatePhoneNumber(phoneNum);
            }
            else if (userInput.ToLower() == "date")
            {
                Console.WriteLine("dd/mm/yyyy");
                Console.Write("Enter today's date: ");
                date = Console.ReadLine();
                response = ValidateDate(date);
            }
            else if (userInput.ToLower() == "html")
            {
                Console.Write("Enter some HTML open and close elements: ");
                html = Console.ReadLine();
                response = ValidateHtml(html);
            }
            return response;
        }

        static string ValidateName(string name)
        {
            string pattern = @"^[A-Z]{1}[a-z]{1,29}$";
            var match = Regex.Match(name, pattern);
            if(match.Success)
            {
                return name;
            }
            else
            {
                Console.WriteLine("Please ensure the first letter of your name is capitalized.");
                return "";
            }
        }

        static string ValidateEmail(string email)
        {
            string pattern = @"^[A-Za-z0-9]{5,30}@[A-Za-z0-9]{5,10}\.[A-Za-z0-9]{2,3}$";
            var match = Regex.Match(email, pattern);
            if(match.Success)
            {
                return email;
            }
            else
            {
                Console.WriteLine("Please ensure you enter your email in the valid format.");
                return "";
            }
        }

        static string ValidatePhoneNumber(string phoneNum)
        {
            string pattern = @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$";
            var match = Regex.Match(phoneNum, pattern);
            if(match.Success)
            {
                return phoneNum;
            }
            else
            {
                Console.WriteLine("Please ensure you enter your phone number in the valid format");
                return "";
            }
        }
        
        static string ValidateDate(string date)
        {
            string pattern = @"^[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}$";
            var match = Regex.Match(date, pattern);
            if(match.Success)
            {
                return date;
            }
            else
            {
                Console.WriteLine("Please ensure you enter the date in the valid format");
                return "";
            }
        }

        static string ValidateHtml(string html)
        {
            string pattern = @"^<[a-z0-9]{1,2}> <\/[a-z0-9]{1,2}>$";
            var match = Regex.Match(html, pattern);
            if(match.Success)
            {
                return html;
            }
            else
            {
                Console.WriteLine("Please ensure the html elements are in the right format");
                return "";
            }
        }

        static int Continue()
        {
            string response;
            int situ = 3;
            while (situ == 3)
            {
                Console.WriteLine("Continue? (y/n): ");
                response = Console.ReadLine().ToLower();

                if (response == "y" || response == "yes")
                {
                    //if yes, restart at main
                    situ = 1;
                }
                else if (response == "n" || response == "no")
                {
                    //if no, exit
                    situ = 0;
                }
                else if (response != "n" || response != "no" || response != "y" || response != "yes")
                {
                    situ = 3;
                }

                if (situ == 3)
                {
                    Console.WriteLine("Please enter valid response.");
                }
            }
            return situ;
        }

    }
}
