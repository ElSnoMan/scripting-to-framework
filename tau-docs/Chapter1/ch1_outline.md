# Machine Setup
Chapter 1 is all about the machine setup, but it's pretty straightforward. There are only two requirements:

1. You need .NET Core 2.2 or greater installed
2. VS Code

.NET Core is the C# version that works for Windows, Mac and Linux.

VS Code is what I'll be using exclusively in this course. There are VS Code-specific things I'll be doing, so I highly recommend you use it as you follow along. Of course, you can use Visual Studio Community or any other text editor if you'd like to as well.

## Some Notes on My Setup
I do want to go over some things with my setup:

[] Terminal
[] Font
[] Editor
[] I'm on a Mac
[] Themes
[] Extensions
    - C# extension by Microsoft
    - PackSharp extension by Carlos Kidman

## .NET Core Installation
I'll let you handle the installation of VS Code, but let's install .NET Core real quick.

- go to downloads page
    - https://dotnet.microsoft.com/download/dotnet-core/2.2
- download SDK installer for your platform
- open terminal and validate installation by using `$ dotnet --version`

## Solution and Project Structure
Now we'll create a new C# solution where we'll be coding. I like to keep my projects in a directory called `dev` or `projects`, but let's create a `tau` folder with a folder inside of that called `scripting-to-framework`.

- `$ mkdir tau`
- `$ cd tau`
- `$ mkdir scripting-to-framework`
- `$ cd scripting-to-framework`
- `$ code .`
    - or open VS Code manually and open the `scripting-to-framework` folder

With C#, you will be using the `dotnet` command quite a bit. There is amazing documentation about all the things you can do with it, but for now, we'll just create three projects within this solution - `Framework`, `Royale`, and `Royale.Tests`. Let's install the PackSharp extension because this makes working with Projects, Packages, and References much easier.

1. Open the Extension Marketplace
2. Search for "PackSharp" and install it
3. Once installed, you use it by opening the Command Palette
    - Open via Menu: View -> Command Palette
    - Open via shortcut:
        - Windows: SHIFT + CTRL + P
        - Mac: SHIFT + COMMAND + P

Use the `PackSharp: Create New Project` command for each of these three projects and the Solution File:

1. Select `Class Library` and call it "Framework"
2. Select `Class Library` and call it "Royale"
3. Select `NUnit 3 Test Project` and call it "Royale.Tests"
4. Select `Solution File` and call it "StatsRoyale"

Then add them to the solution file. The Solution File will manage the projects and the projects will handle the packages and dependencies. (This makes it easier for C# to build and perform other tasks, too.) Basically, the solution file keeps things bundled together for you automatically! It makes working with packages really easy and convenient.

In the integrated terminal, we need to add the projects to the Solution File:

- `$ dotnet sln add Framework`
- `$ dotnet sln add Royale`
- `$ dotnet sln add Royale.Tests`

### Setup complete!

In the `Royale.Tests` project, open the `UnitTest1.cs` file and install the recommended extensions and files the notifications show you:

- C# extension
- .vscode assets

> NOTE: the .vscode folder is SUPER important! Make sure you have it. You may need to run the `Developer: Reload Window` command in the Command Palette to get those notifications to appear.

Open the integrated terminal and run the tests!

- `$ dotnet test`

You made it! You are now ready to start coding.
