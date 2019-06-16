# Element and Elements
Extending IWebElement

In this chapter, we're going to focus on the IWebElement interface. Just like how we wrapped IWebDriver into our own Driver class, we want to do something very similar with IWebElement. Like Driver, logging was a good reason for this, but we can then create any functionality and tie it to the Element object we use throughout our Page Objects and tests.

In the last chapter, we added some logging to our DeckBuilderPage class, but all we were saying was "Click this element" right before we actually clicked that element. It would be much cleaner to just have .Click() log the step for us automatically! We do not get that functionality out of the box, but we can add it once we extend IWebElement. Let's get started.

## Extending IWebElement
1. In Framework.Selenium, create a new file called Element.cs
2. Implement the IWebElement interface and bring in OpenQA.Selenium
3. You'll see that all of the properties and methods get added automatically, but they have no functionality yet!
4. Make a constructor that takes an IWebElement and holds it for us.
    - public IWebElement Current => _element ?? throw new NullReferenceException("Current IWebElement _element is null.");
5. Now we'll add the base functionality to each member in the class using Current.
6. Then we will make a new, custom field called Name to get the name of the element variable
    - public readonly string Name;
7. And require a name argument in our constructor to give it the value
8. In our Click() method, log the click with the name of the element
    - FW.Log.Step($"Click {Name}");

## Our Driver should return Element objects now
We'll keep returning to the Element class, but now we need to go to the Driver class. Right now we are returning IWebElement with our Driver.FindElement() and Driver.FindElements() methods. If we want to make use of our new Element functions, then we need to return Element instead.
1. Change return type of FindElement() from IWebElement to Element.
    - return new Element(Current.FindElement(by), elementName);
    - Notice how we get zero errors even though we changed the return type? That's because Element is an IWebElement, remember??
2. Now we have to update our Page Objects to use the new Element class
    - shortcut to Find and Replace
    - shortcut to edit multiple lines at the same time

## Let's see the new logs!
1. Let's remove those hard-coded pieces in the DeckBuilderPage class
2. and then after changing IWebElement to Element, we can run the tests again to see what we get!
    - $ dotnet test --filter testcategory=copydeck
3. Looks like we have a log file that actually shows what our test is doing. That's what I'm talking about!

## Extending IList<IWebElement>
We'll quickly wrap this chapter up by also extending a collection of IWebElements. We aren't using this in our Page Objects yet, but it's a great time to do it.

1. Create an Elements.cs class in Framework.Selenium
2. For simplicity's sake, we'll just inherit ReadOnlyCollection<IWebElement>
3. Solve the errors
4. Then we'll add a really simple property called IsEmpty just so we can see that we can also add whatever functionality we need
    - public bool IsEmpty => Count == 0;
5. Lastly, change the return type of Driver.FindElements() to Elements.
    - return new Elements(Current.FindElements(by));

## That's it!
Hopefully you can already see the potential for the crazy amount of things we can do now just by wrapping or extending objects. Being able to name our Element objects is just one thing, but I'm sure you can think of 2 or 3 more things right off the top of your head for things you can do.
