namespace DTO
{
    using System;

    public class BookDTO : EntityDTO
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int TotalCount { get; set; }
    }
}
