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
