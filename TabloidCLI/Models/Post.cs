using System;
using System.Collections.Generic;

namespace TabloidCLI.Models
{

				/// <summary>
				///     Ticket Post's Tags #34
				///         Updated the Post class with a newly instansiated List
				///         to hold all Tags returned by the Get method.
				/// </summary>
				public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Author Author { get; set; }
        public Blog Blog { get; set; }
								public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
