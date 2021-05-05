using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private string _connectionString;

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Post Menu");
            Console.WriteLine(" 1) List Posts");
            Console.WriteLine(" 2) Post Details");
            Console.WriteLine(" 3) Add Post");
            Console.WriteLine(" 4) Edit Post");
            Console.WriteLine(" 5) Remove Post");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    throw new NotImplementedException();
                case "2":
                    throw new NotImplementedException();
                case "3":
                    Add();
                    return this;
                case "4":
                    throw new NotImplementedException();
                case "5":
                    throw new NotImplementedException();
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            throw new NotImplementedException();
        }

        private Post Choose(string prompt = null)
        {
            throw new NotImplementedException();
        }

        private void Add()
        {
            AuthorRepository authRepo = new AuthorRepository(_connectionString);

            Console.WriteLine("New Post");
            Post post = new Post();

            Console.Write("Title: ");
            post.Title = Console.ReadLine();

            Console.Write("URL: ");
            post.Url = Console.ReadLine();

            Console.Write("Publish Date: ");
            post.PublishDateTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Choose an author (blank to add new: ");
            List<Author> authors = authRepo.GetAll();
            Author selectedAuth = new Author();

            for (int i = 0; i < authors.Count; i++)
            {
                Author author = authors[i];
                Console.WriteLine($" {i + 1}) {author.FullName}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                selectedAuth = authors[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
            }

            post.Author = selectedAuth;

            BlogRepository blogRepo = new BlogRepository(_connectionString);
            Console.Write("Choose a blog: ");
            //Waiting for blog section
            List<Blog> blogs = blogRepo.GetAll();
            Blog selectedBlog = new Blog();

            for (int i = 0; i < blogs.Count; i++)
            {
                Blog blog = blogs[i];
                Console.WriteLine($" {i + 1}) {blog.Title}");
            }
            Console.Write("> ");

            string blogInput = Console.ReadLine();
            try
            { 
                int choice = int.Parse(blogInput);
                selectedBlog = blogs[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
            }

            post.Blog = selectedBlog;
            _postRepository.Insert(post);
        }

        private void Edit()
        {
            throw new NotImplementedException();
        }

        private void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
