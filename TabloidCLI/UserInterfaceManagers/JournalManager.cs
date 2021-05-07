
using System;
using System.Collections.Generic;
using System.Text;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    class JournalManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private JournalRepository _journalRepository;
        private string _connectionString;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _journalRepository = new JournalRepository(connectionString);
            _connectionString = connectionString;
        }


        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1) List Entries");
            Console.WriteLine("2) Add Entry");
            Console.WriteLine("3) Edit Entry");
            Console.WriteLine("4) Remove Entry");
            Console.WriteLine("0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
                    Edit();
                    return this;
                case "4":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }

        }
        private void List()
        {
            List<Journal> entries = _journalRepository.GetAll();
            foreach (Journal entry in entries)
            {
                Console.WriteLine($"Journal Entry #{entry.Id}");
                Console.WriteLine($"Date Created: {entry.CreateDateTime}");
                Console.WriteLine($"Title: {entry.Title}");
                Console.WriteLine($"Content: {entry.Content}");
                Console.WriteLine();
            }
        }
        /// <summary>
        ///     Ticket List Journal Entries #5
        ///         Created Choose method which combines user prompt
        ///         and a for loop to store an iterated interger, 
        ///         and passes the returned value - 1 to select the correct
        ///         entry from the entries List.
        ///         
        ///         Method implements try/catch to notify user of an invalid selection,
        ///         and returns a null value if this happens.
        /// </summary>
        public Journal Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please select a journal entry:";
            }

            Console.WriteLine(prompt);

            List<Journal> entries = _journalRepository.GetAll();

            for (int i = 0; i < entries.Count; i++)
            {
                Journal entry = entries[i];
                Console.WriteLine($" {i + 1}) {entry.Title}");
            }

            Console.Write(">> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return entries[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
            

        }

        private void Add()
        {
            Console.WriteLine("New Journal Entry:");
            Journal jEntry = new Journal();

            Console.Write("Title: ");
            jEntry.Title = Console.ReadLine();

            Console.Write("Content: ");
            jEntry.Content = Console.ReadLine();

            _journalRepository.Insert(jEntry);
        }

        /// <summary>
        ///     Ticket Edit Journal Entry #6
        ///         Edit method invokes Choose method for user to select a post,
        ///         once selected the user is prompted to update title and content,
        ///         and notified that a blank value will return the same name.
        ///         
        ///         Edit method **does not** allow user to modify date created.
        /// </summary>
        private void Edit()
        {
            Journal entryToEdit = Choose("Select a journal entry to edit: ");
            if (entryToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("**Leave field blank to keep previous title**");
            Console.Write("New Entry Title: ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                entryToEdit.Title = title;
            }
            Console.WriteLine("**Leave field blank to keep previous entry content**");
            Console.Write("New Entry Content: ");
            string content = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(content))
            {
                entryToEdit.Content = content;
            }

            _journalRepository.Update(entryToEdit);
        }

        /// <summary>
        ///     Ticket List Journal Entries #5
        ///         Updated remove method with conditional that removes a single entry
        ///         from the DB if Choose does not return null
        /// </summary>
        private void Remove()
        {
           Journal entryToDelete = Choose("Which entry would you like to remove?");
            if (entryToDelete != null)
            {
                _journalRepository.Delete(entryToDelete.Id);
            }
        }
    }
}
