# Chapter 0 -Intro
Hi, my name is Carlos Kidman and welcome to my course:
"From Scripting to Framework with Selenium and C#"

In this course, we'll be talking about what a Test Automation Framework is and looks like,
but we'll also be designing and implementing one from scratch. The goal of this course is
to get you understand and build enterprise-level solutions to test automation and what you can do
to make your tests easy to read, write, and maintain.

Topics that we'll be covering include:

[] Basic programming with C#
[] Refactoring
[] JSON and Configurations
[] Page Object Model and other Patterns
[] Leveraging test data
[] Working with HTTP endpoints
[] Simple logging and reporting
[] NUnit Testing Framework
[] Test Structure

There will be a lot of coding, so I hope you're as excited as I am to get started! Let's go!

# Chapter 1 - Machine Setup
There are only two requirements:

1. You need .NET Core 2.1 or greater installed
2. VS Code

.NET Core is the C# version that works for Windows, Mac and Linux. I will be working on a Mac, so make sure you do your platform's equivalent.

VS Code is what I'll be using exclusively in this course. There are VS Code-specific things I'll be doing,
so I highly recommend you use it as you follow along. Of course, you can use Visual Studio Community or any other text editor if you'd like as well.

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

# Chapter 2 - Script Some Tests
We'll be using statsroyale.com as our Application Under Test and we'll start with 2 tests:

1. Assert the Ice Spirit card is on Cards page
2. Assert the Ice Spirit card's stats are correct on its Card Details page

First thing I'll do is change the name of the Test Class and Test Method:

1. Test Class to CardTests (make sure to change the file name too)
2. TestMethod1 to Ice_Spirit_is_on_cards_page

Next, we'll add Selenium to our Tests project so we can start using Selenium! PackSharp makes this a breeze.

1. Open Command Palette (SHIFT + COMMAND + P)
2. Enter "PackSharp: Bootstrap Selenium" and select Royale.Tests
3. Selenium is now installed and you also have a new _drivers directory with chromedriver installed!
4. Open Royale.Tests.csproj file to view details about this project. You'll see Selenium has been added!

## Rundown of NUnit basics
To turn a class into a Test Class, we decorate it with the `[TestFixture]` attribute
To turn a method into a Test Method, we decorate it with the `[Test]` attributes
The [SetUp] attribute means this method will be run before each test.
The [TearDown] attribute means this method will be run after each test.

## The tests
The first test is pretty straightforward.

The second test jumps in complexity pretty quickly - especially when we consider that each of these cards are different from each other. There are tons of properties that each card has, but for this test we'll just focus on a few for now:

- Name
- Type
- Arena
- Rarity

Now that the test are complete, let's run them with `dotnet test`. Whoops! We get an error saying that the chromedriver could not be found. That is easily solved by copying the chromedriver in the _drivers directory and pasting it in the `bin/Debug/netcoreapp` directory.

Run the tests again and voila! Your tests are running.

## The Scripting Problem
We were able to write these two tests relatively quickly, but hopefully you can spot some of the problems with this type of automated tests. To name a few:

1. Repetition. I have both tests going to the same starting URL and then going to the Cards Page.

2. Maintainance. Same elements are used in both tests. If I change how I find them or the locators change, I would have to make that change in EVERY test that uses that element. Imagine having 100 tests that used that element... No thanks.

2. No reusability or extensibility. The code that gets the Ice Spirit card would only work for finding Ice Spirit, but there are many more cards on the page and I'm sure I'd be testing those too. It would be better to have a single function that could get me the card I want.

3. Readability. I did my best to make the tests as readable as possible, but it is still complex and requires the reader to really walk through bit by bit rather than reading like a natural flow.

This is what the concept of the Framework is looking to solve. There are many more issues with what we've currently implemented, but it's time to start refactoring and optimizing our code to solve the scripting problems.

# Chapter 3 - Page Object Model
Refactoring - the Beginnings of a Framework

We're currently working with 3 objects:

- Shared Header Navigation Bar
- Cards Page
- Card Details Page

If you think of each page as an object with properties, then you can think of two primary things about the page:

1. Things on the page
2. Things you can do with the things on the page

This is the very concept of the Page Object Model! In C#, I like to have two classes per page.

The first class is called the `Page Map` or just `Map`, and it answers the question: What is on the page? These are your elements!

The second class, which is the main class, is simply the `Page Object` or just `Page`, and it answers the question: What can the user do on the page? These would be your functions and methods that use the elements in the Map to perform those user actions.

I call this approach the "Page Map Pattern" and it works really well with the Page Object Model. Separating the "what's on the page" and "what can you do on the page" into their own classes simplifies the overall structure and usability of the Page Objects.

## Refactor our tests into Page Objects
We'll start cleaning the first test by refactoring things out of the Royale.Tests project. Your Page Objects will live in the Royale project and your tests will use those pages.

1. Open the Royale project
2. Create a new folder called `Pages`
3. Move `Class1.cs` into `Pages` and rename it to `HeaderNav.cs`
4. Change the namespace to `Royale.Pages` to match where the file currently lives.
5. Create the HeaderNavMap class
- The naming convention of pages and maps is very simple. Give your page a name. Your page class will be [name]Page and your map class will be [name]PageMap.

> Disclaimer: We're about to start diving into C# and programming concepts, so please feel free to follow along as best as you can or pause to Google something you don't quite understand. Diving into C# is out of the scope of this course, but you are also welcome to ping me at any time with questions and I will do my best to answer. Ok, with that out of the way, let's get to it!

### Page Object Model - Refactoring Demo
#### HeaderNav POM
1. Let's add our first element to the HeaderNavMap - the Cards tab
    - `public IWebElement` raises an error because Selenium isn't in the Royale project
2. `PackSharp: Bootstrap Selenium` targeting Royale
3. `PackSharp: Remove Package` to remove both Selenium packages from Royale.Tests
4. Bring in Selenium `using statements`
5. `=> driver.FindElement` raises an error because `driver` doesn't exist in this class anywhere. It doesn't know what driver is! We need to define what it is in this class. In our test, we defined driver as an `IWebDriver`, so that's all we need to do here as well.
6. We'll declare it just like we did in the test class, but this time we'll also include a Constructor method. This method is run any time we make a `new` instance of this map. That will make more sense real soon.
7. In our Page class, we need to create an action to go to cards page
8. Define the map, add a constructor, and pass in an IWebDriver

#### CardsPage POM
1. Create CardsPage.cs
2. Create Page class and Map class
3. Define driver, add a constructor, and pass in an IWebDriver
4. Add IceSpiritCard to Map
5. Add GetCardByName(string cardName) to Page
6. Add Goto() to Page
7. This will require a PageBase.cs class that has the HeaderNav in it to be inherited by all pages.
8. Add `var cardsPage = new CardsPage(driver)` to test. This raises an error because we need to add a reference
9. `PackSharp: Add Reference`
10. Finish using cardsPage
11. Finish refactoring so test is cleaner

#### CardDetailsPage POM
1. Create CardDetailsPage.cs
2. Create Page class and Map class
3. Define driver, add a constructor, and pass in an IWebDriver
4. Hopefully you are seeing the pattern here, because each page is going to be following the same steps to get it started.
5. The logic for getting information on this page is a bit more complicated, so we'll create methods to handle that for us.
Let's make a `GetCardType()` method which returns a tuple of <string, string> and a `GetCardRarity()` method that returns a string.
6. Update the test so it's cleaner

Great work! Our test is looking much better and we don't have complicated logic exposed in the test so it's easy to follow.
Does that mean we're done? Of course not! There is much more work to be done...

# Chapter 4 - Model Objects
In our second test, we had 4 assertions. That is a valid strategy, but we are working with many different cards that have many different properties. Let's make a 3rd test that validates a different card - "Mirror"

1. Copy + paste the 2nd test and change test name to "Mirror..."
2. Change values in test to match Mirror's
3. Try the test out
4. Amazing! With just a few string changes, our test was running as expected! But... we did copy + paste quite a bit of code...

I think we can do better because there are a lot of cards and we don't want to copy and paste THAT many lines of code.
Right now, those 4 Assert lines are the biggest offenders. We know the Mirror card isn't going to change any time soon.
It's also a "card object" and we know that objects can have properties! What if we applied the same thing?? Let's do it.

1. Create a Models directory in Framework
2. Move Class1.cs into Models directory and rename it to MirrorCard.cs
3. We already know the name, category, arena, and rarity, so set those values already
4. Use the MirrorCard in the test
5. PackSharp added Framework to Royale project
6. Change assertions to use things like `mirror.Name`

Slowly getting there, but we can't use MirrorCard for the Ice Spirit test. Before we go and make an IceSpiritCard.cs file, let's take a look at what we currently have. Each card, at a minimum, has quite a few things in common:

1. Name
2. Cost
3. Description
4. Rarity
5. Category
6. Arena

When objects have things in common, we call them "base attributes" or "base properties". If you remember, we created a PageBase class that the other Page Objects inherited from. We'll be doing the same thing here.

This may be a good time to pause the video if you would like to do some more research on Abstract classes, Base classes, Interfaces, Generics, and Polymorphism. Or you could keep following along and researching those later. Whatever works for you!

1. Create a Card.cs file in Models directory
2. Add the properties, but mark them with the `virtual` keyword. This keyword means that classes that inherit this class can override them to give them new functionality.
3. Have MirrorCard inherit Card
4. You get some warnings real quick that say you are not overriding the members of the base class. Let's add those override keyword.
5. Now let's make the Ice Spirit card inherit the Card base class as well.

We can put it all together to reap the fruits of our labor by creating a method that returns the Base Card using elements on the page.

1. In CardDetailsPage, we'll add a GetBaseCard() method to get the base card metrics off of the page and return it as a Card object.
2. We won't worry about the extra, card-specific metrics for now.
3. We create a base Card object and give it values.
4. Then we return the Card object.
5. We'll add a docstring to this method to give a helpful hint to callers outside of this class.
6. Lastly, we'll change our tests to use our new method.

But we're still not done! The last refactor we'll implement is to create a Service class that will serve us any type of card we ask for! We're in the home stretch!

1. Make a `Services` folder under the Framework project.
2. In this folder, we'll create an interface called ICardService
3. We'll have one generic method that can get us any type of card we want by passing in the type

Interfaces are rules or contracts that must be followed by any class that implements them. This is powerful because it guarantees that multiple classes will have the same method names or signatures. This will make more sense later on.

1. Now create a CardService.cs class and implement ICardService
2. You get an error because we are not adhering to the contract
3. We'll implement the missing method which is pretty straightforward
4. Then change our tests to use the new CardService.

Test 2 and 3 are now almost identical because of our refactorings. This enables us to re-use our Test Methods by using the [TestCase] attribute from the NUnit test framework.

1. Add TestCases to our method
2. Update test to use cardName parameter
3. We can use these same attributes on our first test too!
4. Run the tests
5. Now the tests are using the same TestCases. We can simplify this further by making an array of cardNames
6. We'll make a static string[] called cardNames and put it "Ice Spirit" and "Mirror"
7. Then we can use the [TestCaseSource("cardNames)] attribute and pass in the name of the array

By now you've noticed that we are running the tests one at a time. We can greatly improve our Test Run Time by running our tests in parallel.

1. Add [Test, Parallelizable(ParallelScope.Children)] to make them run in parallel
2. Run the tests
3. We currently can't run in parellel... We get an error because all the tests are sharing the same driver. That's what we need to fix next.
