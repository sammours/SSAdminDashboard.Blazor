namespace SSAdminDashboard.Domain.Extensions;

public static class ExtensionClasses
{
    public static string Truncate(this string value, int maxLength = 20)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return value.Length <= maxLength ? value : $"{value.Substring(0, maxLength)}...";
    }
}
