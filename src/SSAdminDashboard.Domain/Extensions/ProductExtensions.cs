namespace SSAdminDashboard.Domain.Extensions;

using SSAdminDashboard.Domain.Products;

public static class ProductExtensions
{
    public static string DescriptionBrief(this Product user, int maxLength = 50)
    {
        if (user is null || string.IsNullOrEmpty(user.Description))
        {
            return string.Empty;
        }

        if(user.Description.Length > maxLength)
        {
            return $"{user.Description[..maxLength]}...";
        }
        
        return user.Description;
    }
}
