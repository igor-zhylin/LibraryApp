namespace Domain
{
    using System;

    public class Book : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Author { get; set; }

        public virtual DateTime Releasedate { get; set; }

        public virtual int Totalcount { get; set; }

    }
}
