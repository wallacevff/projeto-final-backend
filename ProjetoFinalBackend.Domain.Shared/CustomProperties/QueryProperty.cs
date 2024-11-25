using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinalBackend.Domain.Shared.CustomProperties;

[AttributeUsage(AttributeTargets.Property)]
public class QueryProperty(string propertyName) : Attribute
{
    public string PropertyName { get; set; } = propertyName;
}


public class CustomFromQuery : FromQueryAttribute
{

}
