
namespace Common.Extensions
{
    public static class ObjectExtension
    {
        public static object GetPropertyValue(this object entity, string propertyName)
        {
            var entityProperty = entity.GetType().GetProperties()
                .FirstOrDefault(c => c.Name.Equals(propertyName));

            if (entityProperty != null)
            {
                return entityProperty.GetValue(entity, null);
            }

            return null;

        }

        public static object GetPrimaryKeyValue(this object entity)
        {
            string className = entity.GetType().Name;

            className = className.TrimEnd('D', 'T', 'O');

            className = className + "Id";

            return entity.GetPropertyValue(className);
        }

        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
