using System.Reflection;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace JaisAppCore;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class AppAttribute : Attribute
{
    public string AppName { get; }
    public Bitmap AppIcon { get; }

    public AppAttribute(string name, string iconPath)
    {
        AppName = name;

        string? assemblyName = Assembly.GetEntryAssembly()?.GetName()?.Name;
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        Stream? asset = assets?.Open(new Uri($"avares://{assemblyName}{iconPath}"));

        AppIcon = new Bitmap(asset);
    }
}