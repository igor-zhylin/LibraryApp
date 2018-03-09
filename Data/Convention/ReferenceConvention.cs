namespace Data.Conventions
{
    using FluentNHibernate.Conventions.Instances;
    using FluentNHibernate.Mapping;
    using FluentNHibernate.Conventions;

    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Cascade.None();
            instance.LazyLoad(Laziness.Proxy);
            instance.Column("id" + instance.Property.Name);
        }
    }
}