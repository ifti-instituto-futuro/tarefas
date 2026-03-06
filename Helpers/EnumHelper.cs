
using System.ComponentModel;
using System.Reflection;

namespace tarefas.Helpers;

public static class EnumHelper
{
    // Referência: https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value
    public static string GetEnumDescription(this Enum value)
    {
        FieldInfo campoEnum = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] atributosEnum = campoEnum.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (atributosEnum != null && atributosEnum.Any())
            return atributosEnum.First().Description;

        return value.ToString();
    }
}