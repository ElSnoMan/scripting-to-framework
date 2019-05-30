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

2. Maintenance. Same elements are used in both tests. If I change how I find them or the locators change, I would have to make that change in EVERY test that uses that element. Imagine having 100 tests that used that element... No thanks.

3. No reusability or extensibility. The code that gets the Ice Spirit card would only work for finding Ice Spirit, but there are many more cards on the page and I'm sure I'd be testing those too. It would be better to have a single function that could get me the card I want.

4. Readability. I did my best to make the tests as readable as possible, but it is still complex and requires the reader to really walk through bit by bit rather than reading like a natural flow.

This is what the concept of the Framework is looking to solve. There are many more issues with what we've currently implemented, but it's time to start refactoring and optimizing our code to solve the scripting problems.
