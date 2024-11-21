using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Validations
{
    public class UserRegistrationValidation
    {

        public string ValidateUserName()
        {

            string enteredUserName = string.Empty;
            bool userNameCondition = false;

            do
            {
                Console.WriteLine("Enter User Name");
                enteredUserName = Console.ReadLine();

                if (enteredUserName.Length < 1 || enteredUserName.Length > 100)
                {
                    Console.WriteLine("Incorrect User Name, Enter Again");
                    userNameCondition = true;
                }
                else
                {
                    userNameCondition = false;
                }


            } while (userNameCondition);

            return enteredUserName;

        }

        public string ValidateUserIdentificationNumber()
        {
            var userIdentificationNumber = string.Empty;
            bool identificationNumberCondition = false;

            do
            {

                Console.WriteLine("Enter User Identification Number");
                userIdentificationNumber = Console.ReadLine();

                bool ContainsOnlyNumbers(string userIdentificationNumber)
                {
                    foreach (char character in userIdentificationNumber)
                    {
                        if (character < '0' || character > '9')
                            return false;
                    }

                    return true;
                }

                if (ContainsOnlyNumbers(userIdentificationNumber) == true && userIdentificationNumber.Length == 11)
                {
                    identificationNumberCondition = false;
                }
                else
                {
                    Console.WriteLine("Incorrect Identification Number");
                    identificationNumberCondition = true;
                }


            } while (identificationNumberCondition);

            return userIdentificationNumber;

        }

        public string ValidateUserEmail()
        {
            var userEmail = string.Empty;
            bool emailCondition = false;

            do
            {
                Console.WriteLine("Enter User Email");
                userEmail = Console.ReadLine();

                bool IsValidEmail(string email)
                {
                    var trimmedEmail = email.Trim();

                    if (trimmedEmail.EndsWith("."))
                    {
                        return false;
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                        return addr.Address == trimmedEmail;
                    }
                    catch
                    {
                        return false;
                    }
                }

                if (IsValidEmail(userEmail))
                {
                    emailCondition = false;
                }
                else
                {
                    emailCondition = true;
                }


            } while (emailCondition);

            return userEmail;
        }

    }
}
