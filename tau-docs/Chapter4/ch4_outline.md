# Chapter 4 - Models and Services
In this chapter, we'll implement basic models and services that will help our tests with things like test data. We'll then use those objects with NUnit to start doing some cool stuff.

In our second test, we have 4 assertions. That is a valid strategy, but we are working with many different cards that have many different properties. Let's make a 3rd test that validates a different card called "Mirror".

## Mirror Card Test
1. Copy + paste the 2nd test and change test name to "Mirror..."
2. Change values in test to match Mirror's
3. Try the test out
4. Our test runs as expected! But... we did copy + paste quite a bit of code...

I think we can do better because there are a lot of cards and we don't want to copy and paste THAT many lines of code. We would have to do that for every card on that page and there's a ton of them. Right now, those 4 Assert lines are the biggest offenders. We know the Mirror card isn't going to change any time soon and, if it did, we would want the test to fail. It's also a "card object" and we know that objects can have properties! What if we applied the same thing to our card just like we did with pages? Let's do it.

## MirrorCard.cs
1. Create a Models directory in Framework
2. Move Class1.cs into Models directory and rename it to MirrorCard.cs
    - Make sure to change the namespace to Framework.Models since that's where this file now lives.
3. We already know the name, cost, rarity, type, and arena, so set those values

We're slowly getting there, but we can't use MirrorCard for the Ice Spirit test. Before we go and make an IceSpiritCard.cs file, let's take a look at what we currently have. Each card, at a minimum, has quite a few things in common:

1. Name
2. Cost
3. Rarity
4. Type
5. Arena

When objects have things in common, just like the pages, we call them "base attributes" or "base properties". If you remember, we created a PageBase class that the other Page Objects inherited from. We'll be doing the same thing here.

## Card Base class
1. Create a Card.cs file in Models directory
2. Add the base properties, but mark them with the `virtual` keyword. This keyword means that classes that inherit this class can override them to give them new functionality and/or values.
3. Have MirrorCard inherit Card
4. You get some warnings real quick that say you are not overriding the members of the base class. Let's add those `override` keywords to each property.
5. Now let's make the Ice Spirit card and have it inherit the Card base class as well. Just make sure to give it Ice Spirit's values.

## GetBaseCard()
We can put it all together to reap the fruits of our labor by creating a method that returns the Base Card using elements on the page.

1. In CardDetailsPage, we'll add a GetBaseCard() method to get the base card metrics off of the page and return it as a Card object.
2. We won't worry about the extra, card-specific metrics for now.
3. We create a base Card object and give it values.
4. Then we return the Card object.
5. Lastly, we'll change our tests to use our new method.

Let's go to our CardTests.
1. Create a variable called card that is the card on the page using cardDetails.GetBaseCard()
2. Create a mirror variable that is our "actual" mirror card values.
3. Now change the assertions
4. Right side is the card.Name and the left is the expected mirror.Name
5. Naming is very important! We have changed between "type" and "category" a couple times now. From now on we'll standardize and call it "type".

There we go! A much cleaner test.

## Interfaces and Bases - First Card Service
But, you guessed it, we're still not done! The last refactor we'll implement is to create a Service class that will serve us any type of card we ask for!

1. Make a `Services` folder under the Framework project.
2. In this folder, we'll create an interface called ICardService
3. We'll define a GetCardByName() method that every CardService will have

Interfaces are rules or contracts that must be followed by any class that implements them. This is powerful because it guarantees that multiple classes will have the same method names or signatures.

1. Now create a InMemoryCardService.cs class and implement the ICardService interface
2. You get an error because we are not adhering to the contract
3. We'll implement the missing interface which is pretty straightforward
4. Then add the implementation. We'll use a switch statement on the cardName.
5. If we pass in "Ice Spirit", return a new IceSpiritCard()
6. If we pass in "Mirror", return a new MirrorCard()
7. We'll also add a default case in case someone passes something incorrect or something like "Golem".
8. We'll throw an ArgumentException that shows them that the card is not available and the card they tried to use.

## NUnit - [TestCase]
Let's use the InMemoryCardService in our test. We'll start by renaming our `card` variable to `cardOnPage` so it's more explicit that this is the card we are getting off the page.

From there, instead of instantiating the MirrorCard directly, we'll use our CardService.

At this point, test 2 and 3 are now almost identical because of our refactorings. This enables us to re-use our Test Methods by using the [TestCase] attribute from the NUnit test framework.

1. Add TestCases to our method
    - [TestCase("Ice Spirit")]
    - [TestCase("Mirror")]
2. Update test to use `stirng cardName` parameter
3. Replace the hard-coded "Mirror" strings with `cardName`

If we walk through the test method, the first test is going to have cardName equal "Ice Spirit" and this will become an "Ice Spirit test". The second time will have cardName equal "Mirror" and the test is now a "Mirror test".

That means that this is a more generic test. Change `mirror` variable to just say `card` and also change the test method name.

Our test method will now work for any card as long as we provide a test case. However, this is not scalable because we'd have to make a test case and model for every card. Instead, we'll use a TestCaseSource.

## NUnit - [TestCaseSource]
1. We'll make a static string[] called cardNames and put it "Ice Spirit" and "Mirror"
    - static string[] cardNames = { "Ice Spirit", "Mirror" };
2. Then we can use the [TestCaseSource("cardNames")] attribute and pass in the name of the array

## NUnit - [Parallelizable]
By now you've noticed that we are running the tests one at a time. We can greatly improve our Test Run Time by running our tests in parallel.

1. Add [Test, Parallelizable(ParallelScope.Children)] to make them run in parallel
2. Add [Category("cards")]
2. Run the tests using `dotnet test --filter testcategory=cards`

But we currently can't run in parellel! We see multiple browsers spin up, but only one closes and things freak out! This is because we are sharing the same driver across our tests. We'll be fixing this in the next chapter by refactoring the WebDriver.
