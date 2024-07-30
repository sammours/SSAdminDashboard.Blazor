namespace SSAdminDashboard.UIComponents.Theming;

public static class MainTheme
{
    public static MudTheme GenerateLightTheme() => new ()
       {
           PaletteLight = new PaletteLight()
           {
               Black = "#191919",
               Primary = "#fdb157",
               White = "#ffffff",
               Info = "#ffffff",
               GrayLight = "#bdbdbd",
           },
       };
}
