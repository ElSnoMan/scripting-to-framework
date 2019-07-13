# Logging
Creating directories and logging to files

Logging is a very important strategy to programming because it helps us locate issues when we inevitably have to debug a problem.

There are MANY ways to handle your Logging Strategy like using an existing Logging Library like Log4Net or a service like Loggly. For this course, we'll simply log to a .txt file. It may not sound as awesome as "Logger as a Service", but your CI/CD pipelines can easily work with artifacts your test runs generate and these log files are a piece of cake.

Another benefit is seeing how to read and write to files using C# which has many applications outside of just logging. Let's dive in.

## Create the TestResults Directory
The first thing we'll want to do is to store our log files into a TestResults directory.
1. Create a FW.cs class, which stands for Framework, in our Framework project
2. Cut + Paste our WORKSPACE_ROOT variable from the Driver.Init() method into FW.cs since it's a string that is used throughout all of our code.
    - `public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");`
3. Next, we'll make a CreateTestDirectory() method. This method will be used at the beginning of our Test Runs.
    - We check if the directory already exists. If it does, delete it and any files within it
    - Then we create the TestResults directory

## Create the Logger class
1. Make a new directory in the Framework project called "Logging"
2. In Logging, create a Logger.cs class
    - check screenshots (002 and 003)
3. In FW, create a SetLogger() method
    - This will use the CurrentTestDirectory which requires using NUnit.Framework
    - PackSharp: Add Package -> Framework -> NUnit
    - PackSharp: Remove Package -> Royale.Tests -> NUnit (not the Test Adapter)
    - See screenshot 001-1

## Log Info and Steps in our Pages
Let's add our new Framework methods to the tests!
1. In CopyDeckTests, we need a [OneTimeSetUp] method where we can create our test directory - FW.CreateTestResultsDirectory()
2. In [SetUp], we'll call FW.SetLogger()
3. Then let's add some simple logging to a couple of our classes
    - Driver.Init()
    - Driver.Goto()
    - Driver.Quit()
    - DeckBuilder.Goto()
    - DeckBuilder.AddCardsManually()
    - DeckBuilder.CopySuggestedDeck()
4. Now let's run the tests
    - dotnet test --filter testcategory=copydeck
5. Yay! We now a Test Results directory for our test run and each test has its own folder and log.

## Solving Race Conditions
But before we call it a day, did you try running our parallel tests?
    - dotnet test --filter card_is_on_cards_page -- NUnit.NumberOfTestWorkers=3
Our tests are executing in parallel as expected, but there is only one test folder in our Test Results. What happened? Well, our test is technically a single test method with a single name, so if we are creating our test folder based on the name of the test, then each test case has the same name! That means each new test case is overriding the test folder and test log of the previous test case. This is an example of a "Race Condition"

A race condition happens when two or more threads, processes, requests, or whatever, try to work with the same data at the same time.
In our case, we have 3 tests running at the same time and trying to write to a single log file. They are in a race to write to it! Another good example is having multiple processes trying to set data in a database. One test may be setting the data as another test is trying to read it.

Let's solve this by forcing the workers to "wait in a line" when creating the directories and log files, but by also giving each test case its own test folder and log by using a unique ID.

1. We're going to create a "lock". A Lock is a mechanism that forces the workers to wait in line until the current worker exits the lock. Very much like a prize room where one person can enter at a time, grab their prize, and once they leave, the next person can enter the room to pick their prize.
    - private static object _setLoggerLock = new object(); // we create the room
    - lock (_setLoggerLock) // we use the room
2. We'll then check to see if the test folder already exists. If it does, that means this is a test method with multiple test cases. We will still use the test name, but we'll also include the unique ID of the test case and append that to the name.
    - CurrentTestDirectory = Directory.CreateDirectory(testPath + TestContext.CurrentContext.Test.ID);
3. Save this and run those tests again.

And check it out... each test case now has a its own test folder and log as expected.
