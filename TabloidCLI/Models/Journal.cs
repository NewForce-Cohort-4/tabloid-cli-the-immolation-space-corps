using System;
using System.Collections.Generic;

namespace TabloidCLI.Models
{
    /// <summary>
    ///     Custom type to create Journal Entry objects.
    /// </summary>

    public class Journal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

    }
}
