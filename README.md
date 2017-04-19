# example-csharp-rest-client

This csharp project is most suitable for [Visual Studio Community 2017](https://www.visualstudio.com/downloads/).

Ensure that the current source control plug-in is set to Git:
1. Click the `Tools` > `Options`... main menu item to open the Options dialog window.
2. Select the Source Control tree view item to open the Plug-in Selection tab page.
3. Select the `Git` selection in the Current source control plug-in: option.

Clone to local git repositories via Team Explorer:
1. Click the `Team` > `Manage Connection` main menu item to open the Team Explorer connection manager.
2. Select the `Clone` option from the `Local Git Repositories` section. 
3. Paste the repo location https://github.com/smsglobal/example-csharp-rest-client.git into the applicable url field.
4. Click the `Clone` button to begin the project cloning process.
5. Click the `Home` button in the Team Explorer main menu.
6. Select the `Open` option from the `Solutions` section.
7. Open the example-csharp-rest-client.sln file located in the cloned repository.

Add the following reference, Newtonsoft.Json and System.Net.Http.Formatting:
1. Click the `Tools` > `NuGet Package Manager` > `Manage NuGet Packages for Solution` main menu item to open the NuGet Package Manager.
2. Click the `Browse` tab and search for `Newtonsoft.Json` and select the top most search result.
3. Check `SMSGlobal.SMS` under the `Version(s)` sections.
4. Click the `Install` button beside the latest version selection (accept review changes and licences as applicable).
5. Click the `Browse` tab and search for `System.Net.Http.Formatting` and select the top most search result.
6. Check `SMSGlobal.SMS` under the `Version(s)` sections.
7. Click the `Install` button beside the latest version selection (accept review changes and licences as applicable).

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

> Please note that charges will apply to the account when sending message.
