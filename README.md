# Calculator, running in the browser with MauiWeb

[Calculator](https://github.com/dotnet/maui-samples/tree/main/10.0/Apps/Calculator) is the .NET MAUI sample
from Microsoft (MIT). This repository is the same app, moved to **.NET 11 / .NET MAUI 11.0.0**, with one extra
project that serves it as a website through [MauiWeb](https://mauiweb.appmare.com). The XAML, the styles and
the visual states are untouched: the browser gets real HTML rendered on the server, and every key press runs
the app's own C#.

| Desktop width | After pressing 7 | Phone width |
| --- | --- | --- |
| ![Calculator](docs/calculator-start.png) | ![Seven](docs/calculator-7.png) | ![Phone](docs/calculator-phone.png) |

**Try it live:** https://live.mauiweb.appmare.com/calculator (also in the [MauiWeb live gallery](https://mauiweb.appmare.com/gallery.html)'s Samples section).

## Run it

Requirements: the .NET 11 SDK and the .NET MAUI 11 workload (`dotnet workload install maui`).

```bash
dotnet run --project src/Calculator.Web
```

Open <http://localhost:5325>. MauiWeb is free on localhost, `.local`, `.test` and private hosts; a public
domain needs a licence (see the [pricing](https://mauiweb.appmare.com)).

The phone and desktop heads are still there: `src/Calculator` targets `net11.0-android`, `net11.0-ios`,
`net11.0-maccatalyst` (and Windows on Windows) as before.

## What changed from the original

1. **`Directory.Build.props`** — `MauiVersion` 10.0.60 → 11.0.0, `DotNetVersion` 10.0.7 → 11.0.0.
2. **`src/Calculator/Calculator.csproj`** — targets moved from `net10.0-*` to `net11.0-*` and a plain
   `net11.0` target added (built as a library, so the web host can reference it).
3. **`src/Calculator/MauiProgram.cs`** — `CreateMauiApp` takes an optional `Action<MauiAppBuilder>` so a host
   can add its own setup. The phone heads call it with no argument, as before.
4. **`src/Calculator.Web/`** (new) — an empty ASP.NET Core project with the `AppMare.MauiWeb` package and one
   line in `Program.cs`:

   ```csharp
   app.MapMauiWeb(() => MauiProgram.CreateMauiApp(b => b.UseMauiWeb()));
   ```

   plus an item group that copies the app's `Resources/` (fonts, images) next to the web host.

Nothing in the pages or styles was edited.

## Licence

The sample is MIT, © Microsoft (see [LICENSE](LICENSE)); the original readme is kept as
[README.upstream.md](README.upstream.md). The web host project added here is MIT too. MauiWeb itself is a
commercial package by [AppMare](https://appmare.com), free for local development.
