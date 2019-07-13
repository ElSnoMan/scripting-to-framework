# Wait Conditions
The final chapter

You made it to the last chapter in this course! Well done! In this chapter, we're going to explore ExpectedConditions and how to make our own custom Wait Conditions as well.

We have waits in our Copy Deck and Deck Builder pages, but we used lambdas to make the wait conditions on the fly. In C#, lambdas are used so often that it's just part of our toolkit as .NET developers.

However, for others that are starting out, lambdas can be a little cryptic and difficult to grasp. We can solve this by making our own library of WaitConditions or by using the WaitHelpers package that has the familiar ExpectedConditions class.

I'll start by showing how to use the WaitHelpers package from DotNetSeleniumExtras. It's easy to setup, but this project is NOT being maintained, so just be aware and use it at your own risk.

## WaitHelpers.ExpectedCondtions

1. PackSharp: Add Package
    - Select "Framework"
    - Search "Selenium Extras"
    - Select DotNetSeleniumExtras.WaitHelpers
2. $ dotnet restore
3. $ dotnet build
4. Use `ExpectedConditions.ElementIsVisible(Map.OtherStoresButton.FoundBy);` in CopyDeckPage.No() method

## Custom Wait Conditions
Hopefully the WaitHelpers package will work for you, but because it's not being maintained, I would rather have my own custom WaitConditions since I end up writing custom conditions anyway.

1. In the Selenium directory, create a WaitConditions sealed class
2. Let's create an ElementDisplayed condition since that's the most common one we've been using in our pages
    - public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
3. We need to create the condition, but it's pretty simple since we are just waiting for the element to be displayed. Remember, the Wait.Until() method will poll up to the number of seconds we defined when we instantiated our Wait class. Right now we have that set to a default of 10 seconds, so the condition will be checked over and over again until it returns true, throws an unhandled exception, or runs out of time.
4. Then return the condition
5. Now let's go to our CopyDeckPage class and replace our lambdas with our new WaitConditions.
6. Run the tests and they still work!

The last lambda is looking for the element to no longer be displayed. Let's add an ElementNotDisplayed() condition.
1. Create the ElementNotDisplayed condition
2. We'll use a try/catch here because it's very possible that an exception is thrown here, but we WANT to catch it because that means the element is NOT displayed.
3. Back in the CopyDeckPage, we'll replace that last lambda with our new WaitCondition.
4. Let's go to our DeckBuilderPage and replace that lambda as well.

## Elements Wait Condition
What makes this so cool is that you can create any conditions that you want! We'll make one more just to show some of the things you can do.
1. Create an ElementsNotEmpty condition
    - public static Func<IWebDriver, Elements> ElementsNotEmpty(Elements elements)
2. This will actually use the FoundBy property that we defined in our Elements class. Since we are saving the locator we're using in the FoundBy variable, we can use that in places just like this!
3. Also, instead of returning a boolean, we are returning the Elements that we waited for. That way we have access to those elements immediately.

## That's it
And that's it! As you can see, there is TONS to do and this is really just the tip of the iceberg. We haven't done anything with secret or key management, databases, reporting, and many other things, but I hope this course has been helpful. What I love is that we didn't write many test methods, but the tests we did write are pretty darn powerful. Get creative and innovative with this. That's what makes programming so much fun!

Also, please please reach out to me with any questions or feedback. I would love to help you on your journey to becoming a Test Automation Superstar!

Until next time, peace!
