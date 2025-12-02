using EtlaToolPicker.EtlaToolbelt;
using System.Reflection;

namespace EtlaToolPicker.EtlaToolbelt.Forms;

public static class ObjectPropertyExternsions
{
    private static readonly BindingFlags _Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    /// <summary>Gets the value of a named property of an object, using Reflection
    /// Note:
    ///     If the object does not contain an accessible property of that name, a null is returned
    ///</summary>
    /// <param name="obj"></param>
    /// <param name="propertyName"></param>
    /// <returns>The value contained in the named property of the object or null if the property does not exist</returns>
    public static object? GetPropertyValue(this object obj, string propertyName)
    {
        PropertyInfo? propertyInfo = obj.GetType().GetProperty(propertyName, _Flags);
        if (propertyInfo != null)
        {
            return propertyInfo.GetValue(obj);
        }
        Log.Warn($"Failed to get value for property {propertyName}");
        return null;
    }

    /// <summary>Sets the value of a named property of an object
    /// If no such named property exists, or if it cannot be written then nothing happens apart from a logged warning
    /// Any exceptions are caught and logged as Errors
    /// Note:
    ///     There is no check that the value provided is compatible with the type of the property of the object 
    ///     or that the object contains the named property
    /// </summary>
    /// <param name="obj">The object whoose property will be set</param>
    /// <param name="propertyName">The name of the property which will be set</param>
    /// <param name="value">The value which will be set</param>
    public static void SetPropertyValue(this object obj, string propertyName, object? value)
    {
        try
        {
            PropertyInfo? propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(obj, value);
                Log.Debug($"Property {propertyName} set to {value}");
            }
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to set value for property {propertyName}", ex);
        }
    }
}
