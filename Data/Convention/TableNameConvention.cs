namespace Data.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table("library_"
                  + Inflector.Inflector.Pluralize(instance.EntityType.Name));
        }
    }
}
