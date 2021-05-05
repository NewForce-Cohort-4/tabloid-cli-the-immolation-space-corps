using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class BlogManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private BlogRepository _blogRepository;
        private string _connectionString;

        public BlogManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _blogRepository = new BlogRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Blog Menu");
            Console.WriteLine(" 1) List Blogs");
            Console.WriteLine(" 2) Blog Details");
            Console.WriteLine(" 3) Add Blog");
            Console.WriteLine(" 4) Edit Blog");
            Console.WriteLine(" 5) Remove Blog");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Blog blog = Choose();
                    /* Remove null when Details are fully implemented */
                    return null;
                    /*if (blog == null)
                    {
                        return this;
                    }
                    else
                    {
                        return new BlogDetailManager(this, _connectionString, blog.Id);
                    }*/
                case "3":
                    Add();
                    return this;
                case "4":
                    Edit();
                    return this;
                case "5":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        /* List all blogs in the database to the Console */
        private void List()
        {
            List<Blog> blogs = _blogRepository.GetAll();
            foreach (Blog blog in blogs)
            {
                Console.WriteLine(blog);
            }
        }

        /* Turn User input into database entry */

        private Blog Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a Blog:";
            }

            Console.WriteLine(prompt);

            List<Blog> blogs = _blogRepository.GetAll();

            for (int i = 0; i < blogs.Count; i++)
            {
                Blog blog = blogs[i];
                Console.WriteLine($" {i + 1}) {blog.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return blogs[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        /* Add User input as a new Blog to the database */
        private void Add()
        {
            Console.WriteLine("New Blog");
            Blog blog = new Blog();

            Console.Write("Title: ");
            blog.Title = Console.ReadLine();

            Console.Write("Url: ");
            blog.Url = Console.ReadLine();

            _blogRepository.Insert(blog);
        }
        private void Edit()
        {
            //Author authorToEdit = Choose("Which author would you like to edit?");
            //if (authorToEdit == null)
            //{
            //    return;
            //}

            //Console.WriteLine();
            //Console.Write("New first name (blank to leave unchanged: ");
            //string firstName = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(firstName))
            //{
            //    authorToEdit.FirstName = firstName;
            //}
            //Console.Write("New last name (blank to leave unchanged: ");
            //string lastName = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(lastName))
            //{
            //    authorToEdit.LastName = lastName;
            //}
            //Console.Write("New bio (blank to leave unchanged: ");
            //string bio = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(bio))
            //{
            //    authorToEdit.Bio = bio;
            //}

            //_authorRepository.Update(authorToEdit);
            throw new NotImplementedException();
        }

        /* Remove a given blog in the database to the Console */
        private void Remove()
        {
            Blog blogToDelete = Choose("Which blog would you like to remove?");
            if (blogToDelete != null)
            {
                _blogRepository.Delete(blogToDelete.Id);
            }
        }
    }
}
