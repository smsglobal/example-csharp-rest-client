# example-csharp-rest-client

This csharp project is most suitable for [Visual Studio Community 2017](https://www.visualstudio.com/downloads/).

Ensure that the current source control plug-in is set to Git:
1. Click the `Tools` > `Options`... menu item to open the Options dialog window.
2. Select the Source Control tree view item to open the Plug-in Selection tab page.
3. Select the `Git` selection in the Current source control plug-in: option.

Open this csharp project from source control:
1. Click the `File` > `Open` > `Open From Source Control` to open the Team Explorer connection manager.
2. Select the `Clone` option from the `Local Git Repositories` section. 
3. Paste the repo location https://github.com/smsglobal/example-csharp-rest-client.git into the applicable url field.
4. Click the `clone` button to begin the project cloning process.

Update the App.config file with api key information:
1. Open the `App.config` file in the `example-csharp-rest-client` folder.
2. Place the appropriate value for the `rest_key`.
3. Place the appropriate value for the `rest_secret`.

Update the Program.cs file with appropriate send sms message test data:
1. Open the `Program.cs` file in the `example-csharp-rest-client` folder.
2. Place the appropriate value for the `origin` number.
3. Place the appropriate value for the `destination` number.

Try the client:
1. Press Ctrl + F5 to run the console window application and see the output displayed.
