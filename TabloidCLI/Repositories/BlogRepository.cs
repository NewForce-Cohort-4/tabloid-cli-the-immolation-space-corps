using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;

namespace TabloidCLI.Repositories
{
    public class BlogRepository : DatabaseConnector, IRepository<Blog>
    {
        /* Connect to the database server */
        public BlogRepository(string connectionString) : base(connectionString) { }

        /* Return all blogs in the database */
        public List<Blog> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                               Title,
                                               URL
                                          FROM Blog";

                    List<Blog> blogs = new List<Blog>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Blog blog = new Blog()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Url = reader.GetString(reader.GetOrdinal("URL")),
                        };
                        blogs.Add(blog);
                    }

                    reader.Close();

                    return blogs;
                }
            }
        }
        public Blog Get(int id)
        {
            //using (SqlConnection conn = Connection)
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = @"SELECT a.Id AS AuthorId,
            //                                   a.FirstName,
            //                                   a.LastName,
            //                                   a.Bio,
            //                                   t.Id AS TagId,
            //                                   t.Name
            //                              FROM Author a 
            //                                   LEFT JOIN AuthorTag at on a.Id = at.AuthorId
            //                                   LEFT JOIN Tag t on t.Id = at.TagId
            //                             WHERE a.id = @id";

            //        cmd.Parameters.AddWithValue("@id", id);

            //        Author author = null;

            //        SqlDataReader reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            if (author == null)
            //            {
            //                author = new Author()
            //                {
            //                    Id = reader.GetInt32(reader.GetOrdinal("AuthorId")),
            //                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
            //                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
            //                    Bio = reader.GetString(reader.GetOrdinal("Bio")),
            //                };
            //            }

            //            if (!reader.IsDBNull(reader.GetOrdinal("TagId")))
            //            {
            //                author.Tags.Add(new Tag()
            //                {
            //                    Id = reader.GetInt32(reader.GetOrdinal("TagId")),
            //                    Name = reader.GetString(reader.GetOrdinal("Name")),
            //                });
            //            }
            //        }

            //        reader.Close();

            //        return author;
            //    }
            //}
            throw new NotImplementedException();
        }

        /* Add a new blog to the database */
        public void Insert(Blog blog)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Blog (Title, URL)
                                                     VALUES (@title, @url)";
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@url", blog.Url);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Blog blog)
        {
            //using (SqlConnection conn = Connection)
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = @"UPDATE Author 
            //                               SET FirstName = @firstName,
            //                                   LastName = @lastName,
            //                                   bio = @bio
            //                             WHERE id = @id";

            //        cmd.Parameters.AddWithValue("@firstName", author.FirstName);
            //        cmd.Parameters.AddWithValue("@lastName", author.LastName);
            //        cmd.Parameters.AddWithValue("@bio", author.Bio);
            //        cmd.Parameters.AddWithValue("@id", author.Id);

            //        cmd.ExecuteNonQuery();
            //    }
            //}
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            //using (SqlConnection conn = Connection)
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = @"DELETE FROM Author WHERE id = @id";
            //        cmd.Parameters.AddWithValue("@id", id);

            //        cmd.ExecuteNonQuery();
            //    }
            //}
            throw new NotImplementedException();
        }
    }
}
