# Chapter 3 - Page Object Model
Refactoring - the Beginnings of a Framework

We're currently working with 3 sections:

- Shared Header Navigation Bar
- Cards Page
- Card Details Page

If you think of each page as an object with properties, then you can think of two primary things about the page:

1. Things on the page
2. Things you can do on the page

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
2. `PackSharp: Bootstrap Selenium` targeting Framework
3. `PackSharp: Remove Package` to remove both Selenium packages from Royale.Tests
4. `PackSharp: Add Reference` from Framework => Royale and Royale => Royale.Tests
5. Bring in Selenium `using statements`
6. `=> driver.FindElement` raises an error because `driver` doesn't exist in this class anywhere. It doesn't know what driver is! We need to define what it is in this class. In our test, we defined driver as an `IWebDriver`, so that's all we need to do here as well.
7. We'll declare it just like we did in the test class, but this time we'll also include a Constructor method. This method is run any time we make a `new` instance of this map. That will make more sense real soon.
8. In our Page class, we need to create an action to go to cards page
9. Define the map, add a constructor, and pass in an IWebDriver

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
Let's make a `GetCardCategory()` method which returns a tuple of <string, string>
6. Update the test so it's cleaner

Great work! Our test is looking much better and we don't have complicated logic exposed in the test so it's easier to follow.
Does that mean we're done? Of course not! There is much more work to be done...
