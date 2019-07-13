# Customizing WebDriver
Selenium was meant to be extended

In this chapter, we'll be wrapping Selenium's WebDriver with our own Driver class and then start to use it in our pages and tests.

In the previous chapter, we saw that our tests can't run in parallel because they are sharing the same instance of WebDriver.

We could fix this by instantiating a new WebDriver within each test rather than declaring it at the top of our class. However, we've already seen some nasty side-effects to this approach. Remember when we were making our Page Objects and we had to pass around a driver and _driver all over the place? Yeah, not so fun.

We could create a static or global WebDriver so we could avoid all that "pass drive here" or "_driver there" and make working with it so much easier, but a single instance of WebDriver gets us right back to not being able to run tests in parallel.

What if I told you that there is a way for us to get multiple instances of a driver while also being able to use it like a static object?? That is exactly what we're about to do right now.

## ThreadStatic Driver
1. In Framework, create a `Selenium` directory and a file called `Driver.cs`
2. Declare: `static IWebDriver _driver;` and decorate it with [ThreadStatic] attribute
3. Create a Current property: `public static IWebDriver Current => _driver ?? throw new NullReferenceException();`
4. Create an Init() method: `public static Init()`
5. In the tests, remove the `IWebDriver driver` from the top of the class and replace what's inside the [SetUp] method with `Driver.Init()`
6. Fix errors by using `Driver.Current`
7. Save and run the tests.

So now you get the 2 browsers running correctly and in parallel! Also, the tests passed! Wow... that was a piece of cake! So what just happened? Well, [ThreadStatic] indicates that the value of the static field is unique for each thread. If I have 4 tests running on their own threads, then each thread will have its own instance of a driver! Very cool stuff.

## ThreadStatic Pages
We can actually apply this to the Page Objects as well by putting them into a wrapper class.

1. In Royale.Pages, create a `Pages.cs` file
2. Create a public static field for each page and decorate each with [ThreadStatic]
3. Create a static Init() method and instantiate each Page
4. Use the new Pages wrapper in the tests
5. Run the tests and they work like a charm

## Creating our own Driver implementation
We can continue to use our static Driver within the Page Objects themselves, but we'll need to give our Driver some familiar functionality instead of using Driver.Current everywhere.

1. First thing's first - we need to navigate to urls. Add the Goto() method.
2. We can add any functionality that we want! Let's add a Debug.WriteLine so we can log things when in debbuging our tests and check that the url we pass in has http. If not, we'll add it for them. You can customize the way you navigate to URLs! You can do anything!
3. Let's add this to our test setup, `Driver.Goto("statsroyale.com")`, and debug the first test to see our new functionality

## Using Driver.FindElement[s] in our Pages
1. The last thing we'll do is to add the FindElement and FindElements methods to our Driver class
2. And them use them in our Pages and Page Maps.
3. We can replace _driver with Driver
4. We also don't need the constructor or the _driver field in our Page Maps either since that's handled by the ThreadStatic Driver.
5. And then the Page Object itself doesn't need to worry about passing in a IWebDriver.
6. We'll do this for the PageBase first, the HeaderNav, then the Cards Pages, and lastly, the Pages wrapper

We removed quite a bit of code! That's a great thing and our page classes are much cleaner. Something cool to point out as well is that we didn't have to change anything in our tests this time! That means our Framework is doing its job well! Let's run the tests just to make sure our changes didn't break anything.

Our Framework is really starting to come together! :D
