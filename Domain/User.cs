namespace Domain
{
    public class User : Entity
    {
        public virtual string Firstname { get; set; }

        public virtual string Lastname { get; set; }

        public virtual int Limit { get; set; }

        public virtual Book book { get; set; }
    }
}
