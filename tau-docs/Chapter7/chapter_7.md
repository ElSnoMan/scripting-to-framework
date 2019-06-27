# Copy Deck Test Suite
Flow Through Multiple Pages and WebDriverWait

The last suite of tests will be around the site's Deckbuilder functionality.
On the Deck Builder page, users have the option to Copy the Deck.
This takes them to the Copy Deck Page where they can either Copy the Deck or go to the App Stores to download the app.
We want to write tests against this page.

There are a few scenarios:
1. User has the app installed and clicks Yes to copy the deck
2. User doesn't have the app installed and opens App Store
3. User doesn't have the app installed and opens Google Play
4. The Deck the user wants to copy from the Deck Builder Page is the same deck that is displayed on Copy Deck Page

The first 3 scenarios are straightforward, but the last scenario has a very high number of combinations since Decks consist of 8 cards and we have 93 total cards...

In this Chapter we'll only write the first 3 tests.

## Create the first Copy Deck test
We'll start with the easiest test which is that the user can copy the deck.
We'll write the test first and then refactor it into the Page Object Model.

1. In Royale.Tests, create the CopyDeckTests.cs class.
2. Our [SetUp] and [TearDown] methods will be the exact same, so let's copy that from our CardTests.cs class.
3. Make a new test and call it `User_can_copy_the_deck()`

### Script out the test
Let's code the steps!
1. Go to statsroyale.com
    - This is already done in our [SetUp]
2. Go to Deck Builder Page
3. Click "add cards manually"
4. Click "Copy Deck" icon
5. Click "Yes"
6. Assert that "If clicking \"Yes\" has no response, please try to open this page in a browser." message is equal to what is seen on the page.

### Refactor the DeckBuilderPage actions
Great! Now let's refactor it out into Page Objects
1. Step 2 is in the HeaderNav
    - Add DeckBuilderLink to HeaderNav.Map
    - We won't create the GotoDeckBuilder() method just so you can see a different way of using this Map.
2. Steps 2 and 3 are from the Deck Builder Page
    - When you land on the Deck Builder Page, there are two options
        [] Load Collection
        [] Add Cards Manually
    - Either way, the Suggested Decks list is displayed. We can mimic this behavior in our Page Object.
3. Create the DeckBuilderPage.cs class (Pages.DeckBuilderPage)
    - Find "Load Collection" elements and create the LoadCollection() method
    - Find Add Cards Manually link and Copy Deck Icon link elements
    - Create AddCardsManually() method
4. Inherit PageBase so you can Goto()
5. Create CopySuggestedDeck() method
6. Add DeckBuilderPage to Pages wrapper
7. Update the test to use Pages.DeckBuilder

### Refactor the CopyDeckPage actions
1. Create the Pages.CopyDeckPage class
2. Create Copy() or Yes() method
3. Add CopyDeckPage to Pages wrapper
4. Update the test to use Pages.CopyDeck

Much cleaner! Let's run the test to see what we get... ruh roh! Failed because it couldn't find an element.
If you haven't already guessed, it's because our test is going too fast!
We need to add waits to our test so we give the website enough time to load the elements we need.

## WebDriverWait Out of the Box
1. In our test, let's initialize a new WebDriverWait
2. We'll add the wait after AddCardsManually() because that seems to be where it fails
    - `wait.Until(drvr => Pages.DeckBuilder.Map.CopyDeckIcon.Displayed);`
3. Run the tests again. Looks like it waited for the Suggested Decks to load this time, but it failed again! We need to add a wait somewhere else.
4. Add a wait after Copy() or Yes() method
    - `wait.Until(drvr => Pages.CopyDeck.Map.CopiedMessage.Displayed);`
5. Run the tests again. Another fail! But the error message is much more helpful. It looks like we forgot the word "web" in our assertion. After fixing it, the test passes!
6. However, our test doesn't look as clean anymore and the waiting mechanisms were a bit cryptic... Let's fix that.

## Refactor WebDriverWait into a Wait class
1. In Framework.Selenium, create a Wait.cs class
2. We'll customize how we initialize WebDriverWait within Wait's constructor.
3. We'll also make an Until(Func<IWebDriver, bool> condition) method to match the exact functionality of WebDriverWait.
4. Add [ThreadStatic] public static Wait Wait; to our Driver.cs class and include it in Driver's constructor and add a default waitSeconds = 10 parameter.
5. Update the tests to use Driver.Wait.Until(), but that doesn't buy us much. We got rid of the `var wait` instantiation and a using statement, but that's about it. We'll make this even better in another chapter.

## Refactor our "waits" into their Actions
All that's left to do is to refactor the "waits" in the test into their respective actions.
1. Add first wait into AddCardsManually() method
2. Add second wait into Yes() method

Now the test is much more clear while still having the functionality we need. Great work!

## Write the 2nd and 3rd Tests
1. Make two new test methods
    - User_opens_app_store()
    - User_opens_play_store()
2. Copy + Paste the first two steps from first test
3. Add No() method to Pages.CopyDeckPage
4. Add OpenAppStore() and OpenGooglePlay() methods.
5. Add these methods to your test
6. Assert the title is equal to Driver.Title. We don't have a "Title" property on Driver, so we need to add it.
    - `public static string Title => Current.Title;`
7. Run the tests and we get a failure saying that a different element was gonna get clicked. The issue is, when we get to the CopyDeck page, a Cookie Consent popup is displayed and covers the app store buttons. Fortunately, the error message is pretty helpful, but it would have been nice to see some logs and a screenshot to quickly diagnose and solve the problem.
8. Add an AcceptCookies() method and add that to our No() method
    - public void AcceptCookies()
    - Map.AcceptCookiesButton.Click();
    - Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
9. Re-run the tests. They pass!
