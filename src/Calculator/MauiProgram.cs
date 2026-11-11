namespace Calculator;

public static class MauiProgram
{
	/// <param name="platform">Extra setup from the host that creates the app (the MauiWeb web host passes UseMauiWeb).</param>
	public static MauiApp CreateMauiApp(Action<MauiAppBuilder>? platform = null)
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		platform?.Invoke(builder);


		return builder.Build();
	}
}
