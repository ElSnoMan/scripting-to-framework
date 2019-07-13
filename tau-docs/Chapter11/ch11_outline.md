# TestBase and Outcomes
Centralize test setup and teardown

We're going to focus on creating a TestBase class that shares the test setup and teardowns since both of our test suites start and end the same way.

We'll then see what we can do about handling a passing test versus a failing test. We'll just be logging the result to the log file, but this can be used for many scenarios like sending an email or Slack message on failure.

## TestBase
1. In Royale.Tests, create a new Directory called "Base" and a new file within it called "TestBase.cs"
    - public abstract class TestBase
    - the abstract keyword means this class can only be inherited, not instantiated
2. Cut and Paste the SetUp and TearDown methods from one of the test classes
3. Solve the errors
4. In the test classes, delete the SetUp and TearDown methods
5. Inherit the TestBase class and cleanup the using statements
6. Run the copydeck tests! They should be working the exact same as before, but now that setup and teardown is in one location.

## Test Outcome
Now that this is centralized, let's work on logging the outcome of the test. We can capture the result of each test in the [TearDown] method.

1. In TestBase.cs, before we call Driver.Quit() in [TearDown], we're going to get the outcome of the test and hold it in a variable.
    - Do you remember how we can get information from the current executing test? TestContext!
    - var outcome = TestContext.CurrentContext.Result.Outcome.Status;
2. This outcome status will tell us whether the test passed, failed, or had a different outcome. We can use some simple "if statements" to control our logic.
    - if (outcome == TestStatus.Passed)
    - else if (outcome == TestStatus.Failed)
    - else
3. Now run a single copydeck test. It passes! Let's add Assert.Fail() and run it again so we can see the failing logic. Boom! Just what we expected.

## Screenshot on Failure
The last part in this chapter is to take a screenshot if the test fails. You probably know how to do this already, but we want the screenshot to go into the current test directory along with its log file.

1. In the Driver class, we'll add a TakeScreenshot(string imageName) method
2. In the TestBase class, we'll take a screenshot if the test fails. Add Driver.TakeScreenshot()
3. Run a failing test to see the screenshot. Woot!

# BONUS - Maximizing Window Example
Back in Chapter 2, you had the challenge to maximize the window. For Windows machines, it's pretty straightforward. You could either pass in a --start-maximized argument to the Driver Options or even call Driver.Manage().Window.Maximize().

The issue is that those methods may not work for Mac or Linux. So, I wanted to share one of the solutions that works for any platform and any browser. Check it out!

I started by making a Window class with a CurrentWindows property that this SwitchTo() method could use. It's just an example of the kinds of things you may want to put in this class.

For maximizing the window, the first step is to get the screensize that we're working with. We can dynamically get this value by executing some javascript to get the dimensions of the screen by width and height.

Once we have that size, we can then position the window at the top-left corner and then set it's size to the screensize we received. Voila! You can now maximize your browser dynamically for any browser and platform.

The last thing to do is to use it in our Driver class. Just like our Wait class, we'll make a [ThreadStatic] field and instantiate it in the Init() method. Simply call Window.Maximize() after that and you're done!
