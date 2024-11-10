using System.Data.SqlTypes;

namespace Testes;

public abstract class NullableInstanceProps
{
    public NullableInstanceProps()
    {
        if (!AreAllPropertiesNullable(this))
            throw new ArgumentException("Propriedades não anulável");
    }

    public bool AreAllPropertiesNullable(object o)
    {
        var properties = o.GetType().GetProperties();
        return properties.All(p => Nullable.GetUnderlyingType(p.PropertyType) != null || !p.PropertyType.IsValueType);
    }
}