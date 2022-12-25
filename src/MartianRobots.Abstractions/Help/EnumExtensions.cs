using System.ComponentModel;
using System.Reflection;

namespace MartianRobots.Abstractions.Help;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T enumerationValue) where T : struct
    {

        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("Value must be of enum type!");
        }

        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());

        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }

        return enumerationValue.ToString();
    }
}
