# Machine Setup
There are only two requirements:

1. You need .NET Core 2.2 or greater installed
2. VS Code

.NET Core is the C# version that works for Windows, Mac and Linux. I will be working on a Mac, so make sure you do your platform's equivalent.

VS Code is what I'll be using exclusively in this course. There are VS Code-specific things I'll be doing,
so I highly recommend you use it as you follow along. Of course, you can use Visual Studio Community or any other text editor if you'd like as well.

## Some Notes on My Setup

[] Terminal
[] Font
[] Editor
[] I'm on a Mac
[] Themes
[] Extensions

## Dive into Demo
### [.NET Core Installation]
I'll let you handle the installation of VS Code, but let's install .NET Core real quick.

- go to downloads page
- download installer
- open terminal and validate installation by using `$ dotnet --version`

### [Solution and Project Structure]
Fantastic! Now we'll create a new C# solution where we'll be coding. I like to keep my projects in a directory called `dev` or `projects`, but let's call the main folder `tau-statsroyale`.

- `$ cd projects`
- `$ mkdir tau-statsroyale`
- `$ cd tau-statsroyale`
- `$ ls`

With C#, you will be using the `dotnet` command quite a bit. There is amazing documentation about all the things you can do with it, but for now, we'll just create three projects within this solution - `Framework`, `Royale`, and `Royale.Tests`

- `$ dotnet new sln`
- `$ dotnet new classlib --name Framework`
- `$ dotnet new classlib --name Royale`
- `$ dotnet new nunit --name Royale.Tests`
- `$ ls`

Then add them to the solution file. The solution file will handle all of the organization and dependencies of the project to make it easier for C# to build and perform other tasks. Basically, the solution file keeps things bundled together for you automatically!

- `$ dotnet sln add Framework`
- `$ dotnet sln add Royale`
- `$ dotnet sln add Royale.Tests`

### [VS Code Setup]
With our solution and projects created and ready to be used, let's open VS Code.

- `$ code .`
- or open VS Code manually and open the `tau-statsroyale` folder

In the `Royale.Tests` project, open the `UnitTest1.cs` file and install the recommended extensions and files the notifications show you:

- C# extension
- .vscode assets

Open the integrated terminal and run the tests!

- `$ dotnet test`

### [Some notes on my setup]
You may have already noticed that my terminal and VS Code looks different than yours. That's because I customized it to my liking! Before continuing, I'd like to talk briefly about my setup.

### [Extensions Installation]

1. Open the Extensions tab
2. Search for Material Theme Icons and install
3. You can search for any themes you want and switch easily between them
4. Now let's search for PackSharp and install it

You made it! You are now ready to start coding.
