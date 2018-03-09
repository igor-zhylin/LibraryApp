
namespace Data.Conventions
{
    using FluentNHibernate.Conventions.Instances;
    using FluentNHibernate.Conventions;

    public class OneToManyConvention : IHasManyConvention
    {
        public virtual void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.None();
            instance.Inverse();
            instance.Key.Column("id" + instance.Member.DeclaringType.Name);
            instance.LazyLoad();
        }
    }
}
