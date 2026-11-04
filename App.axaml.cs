using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WestCoastCollege.Utils;
using WestCoastCollege.ViewModels;
using WestCoastCollege.Views;

namespace WestCoastCollege;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection(); // a list of dependencies that the app will have, built on the interface ISrviceCollection
        collection.AddServices();

        var services = collection.BuildServiceProvider(); // this looks in colection which is all in the framweork that is a service, then build compile all that and put the result in services. IE paket all services and put them inservices to we can access them easily.
        var vm = services.GetRequiredService<MainWindowViewModel>(); // when the app starts we ask the service to give us what we want in this case the mainwidnowviewmodel take everytihgn in our servicecollectinoextension and pack into the services
        // initilize the new class where we use collectionservice        
        // tell the app that we are going to use the ViewModels as MainWindow class
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm // connect to whatever viemodel that vm is, after it have gotten the required service
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}