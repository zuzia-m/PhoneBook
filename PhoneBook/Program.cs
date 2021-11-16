using System;
using System.Linq;
using System.Collections.Generic;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {

            SetColor(ConsoleColor.Magenta, "Hello to the PhoneBook App!");
            bool CloseApp = false;
            var phonebook = new PhoneBook();
            while (!CloseApp)
            {
                Console.WriteLine();
                SetColor(ConsoleColor.Cyan, 
                    "1 - Add contact\n" +
                    "2 - Display contact by number\n" +
                    "3 - Display all contacts\n" +
                    "4 - Search contacts\n" +
                    "5 - Remove contact\n" +
                    "X - Close app\n");

                SetColor(ConsoleColor.Yellow, "What you want to do? \nPress key 1, 2, 3, 4, 5 or X: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        SetColor(ConsoleColor.Yellow, "Insert Number: ");
                        var numberInput = Console.ReadLine();
                       
                        bool IsDigitsOnly(string number)
                        {
                            foreach (char c in number)
                            {
                                if (c < '0' || c > '9')
                                    return false;
                            }
                            return true;
                        }
                       
                        string number = null;
                        

                        if (numberInput.Length >= 9 && IsDigitsOnly(numberInput))
                            number = numberInput;
                        else
                        {
                            SetColor(ConsoleColor.Red, "The number has to contains only digits and the minimum length is 9.");

                            break;
                        }

                        SetColor(ConsoleColor.Yellow, "Insert Name: ");
                        var nameInput = Console.ReadLine();
                        string name = null;
                        if (nameInput.Length >= 3)
                            name = nameInput;
                        else
                        {
                            SetColor(ConsoleColor.Red, "Minimum length of name is 3 chars. Please try again.");
                            break;
                        }

                        var newContact = new Contact(name, number);

                        phonebook.AddContact(newContact);
                        break;

                    case "2":
                        SetColor(ConsoleColor.Yellow, "Insert Number: ");
                        var numberToSearch = Console.ReadLine();
                        phonebook.DisplayContact(numberToSearch);
                        break;
                    case "3":
                        phonebook.DisplayAllContacts();
                        
                        break;
                    case "4":
                        SetColor(ConsoleColor.Yellow, "Insert Name: ");
                        var nameToSearch = Console.ReadLine();
                        phonebook.DisplayMatchingContacts(nameToSearch);
                        break;
                    case "5":
                        SetColor(ConsoleColor.Yellow, "Insert Number to delete: ");
                        var numberToDelete = Console.ReadLine();
                        phonebook.DeleteByNumber(numberToDelete);
                        break;
                    case "X":
                        CloseApp = true;

                        break;
                    default:
                        SetColor(ConsoleColor.Red, "Invalid operation.\n");
                        continue;
                }

                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine("\n\n1 - Main Menu\nX or any other - Close the App");
                //Console.ResetColor();
                //var userInput2 = Console.ReadLine();
                //if (userInput2 == "1")
                //    CloseApp = false;
                //else
                //    CloseApp = true;
                //Console.Clear();
            }

        }

        private static void SetColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
