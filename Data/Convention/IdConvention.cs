namespace Data.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class IdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("id");
            instance.GeneratedBy.Increment();
        }
    }
}
