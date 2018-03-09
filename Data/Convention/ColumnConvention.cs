
namespace Data.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class ColumnConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(Inflector.Inflector.Pluralize(instance.Name));
        }
    }
}
