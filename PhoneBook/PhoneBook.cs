using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneBook
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }
        private void SetForegroundColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        private void DisplayContactDetails(Contact contact)
        {
            SetForegroundColor(ConsoleColor.Green, $"Contact: {contact.Name}, {contact.Number}");
        }

        public void DisplayContact(string number)
        {
            var contact = Contacts.FirstOrDefault(x => x.Number == number);

            if (contact == null)
            {
                SetForegroundColor(ConsoleColor.Red, "Contact not found");
            }
            else
                DisplayContactDetails(contact);
        }

      

        private void DisplayContactsDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayAllContacts()
        {
            bool phonebookIsNotEmpty = Contacts.Any();
            if (!phonebookIsNotEmpty)
                SetForegroundColor(ConsoleColor.Red, "There's no contacts in the phonebook.");
            else
            {
                var contsctsOrderedByName = Contacts
                .OrderBy(x => x.Name).ToList();
                DisplayContactsDetails(contsctsOrderedByName);
            }

        }

        public void DisplayMatchingContacts(string searchPharse)
        {
            var matchingContacts = Contacts
                .Where(x => x.Name.ToLower().Contains(searchPharse.ToLower()))
                .OrderBy(x => x.Name).ToList();
            if (matchingContacts.Any())
                DisplayContactsDetails(matchingContacts);
            else
                SetForegroundColor(ConsoleColor.Red, "There's no matching contacts.");
        }
        public void DeleteByNumber(string number)
        {
            var contactToRemove = Contacts.FirstOrDefault(x => x.Number == number);
            if(contactToRemove != null)
            {
                Contacts.Remove(contactToRemove);
                SetForegroundColor(ConsoleColor.Green, $"Contact {contactToRemove.Name}, {contactToRemove.Number} has been succesfully removed.");
            }
            else
            {
                SetForegroundColor(ConsoleColor.Red, $"Contact with number {number} doesnt exist in the PhoneBook.");
            }
        }
    }
}
