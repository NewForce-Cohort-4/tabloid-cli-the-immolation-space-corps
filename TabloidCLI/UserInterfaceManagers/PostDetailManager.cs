using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class PostDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private TagRepository _tagRepository;
        private int _postId;

        public PostDetailManager(IUserInterfaceManager parentUI, string connectionString, int postId)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _postId = postId;
        }

        public IUserInterfaceManager Execute()
        {
            Post post = _postRepository.Get(_postId);
            Console.WriteLine($"{post.Title} Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Remove Tag");
            Console.WriteLine(" 4) Note Management");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;
                case "2":
                    AddTag();
                    return this;
                case "3":
                    RemoveTag();
                    return this;
                case "4":
                    throw new NotImplementedException();
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

								/// <summary>
								///     Ticket View Post's Tags #34
								///         Added for loop to iterate through all tags
								///         associated with each post.
								/// </summary>

								private void View()
        {
            Post post = _postRepository.Get(_postId);
            Console.WriteLine($"Name: {post.Title}");
            Console.WriteLine($"URL: {post.Url}");
            Console.WriteLine($"Publication Date: {post.PublishDateTime}");
												Console.WriteLine("Tags:");
												foreach (Tag tag in post.Tags)
												{
																Console.WriteLine("" + tag);
												}
												Console.WriteLine();
        }

        private void ViewPostPosts()
        {
            throw new NotImplementedException();
        }


								/// <summary>
								///     Ticket Add Tag to Post #33
								///         Updated AddTag method to display all tags
								///         and invoke the InsertTag method to add Post
								///         and Tag Ids to the join table.
								/// </summary>

								private void AddTag()
        {
												Post post = _postRepository.Get(_postId);

												Console.WriteLine($"Which tag would you like to add to {post.Title}?");
												List<Tag> tags = _tagRepository.GetAll();

												for (int t = 0; t < tags.Count; t++)
												{
																Tag tag = tags[t];

																Console.WriteLine($" {t + 1}) {tag.Name}");
												}

												Console.Write("> ");

												string input = Console.ReadLine();
												try
												{
																int choice = int.Parse(input);
																Tag tagSelected = tags[choice - 1];
																_postRepository.InsertTag(post, tagSelected);
												}
												catch (Exception ex)
												{
																Console.WriteLine("Invalid selection. Unable to add tag.");
												}
								}

        private void RemoveTag()
        {
            throw new NotImplementedException();
        }
    }
}