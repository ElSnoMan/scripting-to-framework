# Chapter 2 - Script Some Tests
In this chapter, we'll be using statsroyale.com as our Application Under Test. Let's go to it real quick so we can familiarize ourselves.

The main pages we'll be working on for now are the Cards Page and the Card Details Page.

We will be writing 2 tests:

1. Assert the Ice Spirit card is on Cards page
2. Assert the Ice Spirit card's stats are correct on its Card Details page

With that, let's dive into code and write these tests.

## Setting up Selenium
The first thing I'll do is change the name of the Test Class and Test Method:

1. Test Class to CardTests (make sure to change the file name too)
2. Test1 to "Ice_Spirit_is_on_cards_page"

Next, we'll add Selenium to our Tests project so we can start using Selenium! PackSharp makes this a breeze.

1. Open Command Palette
2. Enter "PackSharp: Bootstrap Selenium" and select Royale.Tests
3. Selenium is now installed and you also have a new _drivers directory with chromedriver installed!
4. Open Royale.Tests.csproj file to view details about this project.

You'll see Selenium has been added and we can use it now.

1. Declare a field for driver. `IWebDriver driver;`
2. In our [SetUp], we'll instantiate a new instance of ChromeDriver
3. Point the ChromeDriver to the _drivers folder path

## Rundown of NUnit basics
* To turn a method into a Test Method, we decorate it with the `[Test]` attribute
* The [SetUp] attribute means this method will be run before each test.
* The [TearDown] attribute means this method will be run after each test.

## The tests
The first test is pretty straightforward. Let's write out the steps:

1. go to statsroyale.com
2. click Cards Header Nav link
3. Assert Ice Spirit is displayed

The second test jumps in complexity pretty quickly - especially when we consider that each of these cards are different from each other. There are tons of properties that each card has, but for this test we'll just focus on a few for now:

- Name
- Type
- Arena
- Rarity

We'll start by copy/pasting the first test, but we'll change the name to Ice_Spirit_headers_are_correct_on_Card_Details_Page.
Then find the 4 headers and assert their values.

## The Scripting Problem
We were able to write these two tests relatively quickly, but hopefully you can spot some of the problems with this type of automated test. To name a few:

1. Repetition. I have both tests going to the same starting URL and then going to the Cards Page. I literally copy and pasted the first test!

2. Maintenance. Same elements are used in both tests. If I change how I find them or the locators change, I would have to make that change in EVERY test that uses that element. Imagine having 100 tests that used that element. You'd have to pray to the gods of Find and Replace... No thanks.

3. No Readability. I did my best to make the tests as readable as possible, but it is still complex and requires the reader to really walk through bit by bit rather than reading like a natural flow.

4. No reusability or extensibility. The code that gets the Ice Spirit card would only work for finding Ice Spirit, but there are many more cards on the page and I'm sure I'd be testing those too. It would be better to have a single function that could get me the card I want.

This is what the concept of the Framework is looking to solve. There are many more issues with what we've currently implemented, but it's time to start refactoring and optimizing our code to solve the scripting problems.

Bring on the Page Object Model!
