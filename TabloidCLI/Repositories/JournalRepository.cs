﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    /// <summary>
    ///     Journal Repository containing CRUD methods for database interaction
    /// </summary>

    public class JournalRepository : DatabaseConnector, IRepository<Journal>
    {
        public JournalRepository(string connectionString) : base(connectionString) { }
        public List<Journal> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                            Title,
                                            Content,
                                            CreateDateTime
                                    FROM Journal";

                    List<Journal> journalEntries = new List<Journal>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Journal entry = new Journal()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };
                        journalEntries.Add(entry);
                    }

                    reader.Close();
                    return journalEntries;
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Journal Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ticket Add Journal Entry #3
        /// </summary>
        public void Insert(Journal entry)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Journal (Title, Content, CreateDateTime)
                                        VALUES (@title, @Content, @CreateDateTime)";
                    cmd.Parameters.AddWithValue("@title", entry.Title);
                    cmd.Parameters.AddWithValue("@Content", entry.Content);
                    cmd.Parameters.AddWithValue("@CreateDateTime", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Journal entry)
        {
            throw new NotImplementedException();
        }
    }
}