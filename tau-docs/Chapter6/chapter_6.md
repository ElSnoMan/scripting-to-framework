# Using Test Data from an API
API Endpoint: https://statsroyale.com/api/cards

Right now we have hard-coded two cards - Ice Spirit and Mirror. However, there are tons of cards that we currently aren't testing.
We could go through each one and hard-code these too, but our devs are grabbing these lists of cards from the database using REST endpoints.
As Automation Engineers, it is a requirement that we know how to work with the data our devs are using too. Especially in the world of microservices where transactions are happening across multiple calls and services.

There are so many pros to this approach, but just think about this one scenario... If they add a new card with the next release, how would we handle that new card? Our current implementation would have us create a NewCard.cs file that inherits from Card and then find out what the values are for us to hard-code them too. However, they will be adding that new card to the database which will get picked up by the endpoints they're already using. If we also leveraged that same endpoint in our tests, then we wouldn't have to make any code changes because we would already have the new card as well!

Let's dive right back into code and see what live endpoint that we can view with PostMan and bring into our framework and tests.

## Use PostMan to look at our /cards endpoint
1. Open PostMan and paste in "https://statsroyale.com/api/cards"
    - PostMan is our client
    - https://statsroyale.com/api/cards is our Request Url
    - We aren't sending anything else as part of the request
2. Click `Send`
    - This executes the request
3. We get back a response. It's an array of Card objects! However, these cards look a bit different than the ones we created.
    - We're missing the `id` and `icon` properties, but everything else is the same.
4. Let's go back to our Card.cs class and add the `Id` and `Icon` properties
5. The awesome thing is that now we have a list of all the cards that are in the game! We don't have to store this ourselves if we don't want to.

Having this is obviously helpful, but we want to leverage it in our Framework so our tests can use it too.

## Calling a REST endpoint from our Framework
1. `PackSharp: Add Package` to install `RestSharp` and `Newtonsoft.Json`into our Framework project
2. In Framework.Services, we'll make a new class called ApiCardService.cs
3. We want it to implement our ICardService as well. We don't have a way to get a single card from the API yet, so let's leave the NotImplementedException() for now.
4. Now that we are adhering the interface, we want to add a GetAllCards() method to get what we just saw in PostMan.
5. `using RestSharp` and `using Newtonsoft.Json`
6. We need to "build" the REST request just like we did in PostMan. Now that we are calling the /cards endpoint and converting the response into Card objects, we can use that to get a single card from the list.
7. Add implementation to GetCardByName() by using GetAllCards(). We'll do it this way just because we don't have an endpoint to get a single card.

## Using our ApiCardService in our tests
With our ApiCardService complete, we can use them with our existing tests to validate ALL of the cards instead of the two we defined.

1. Replace `cardsNames` with `apiCards` that uses our ApiCardService.GetAllCards()
2. Update the [TestCaseSource] of each test to use "apiCards"
3. Update the `string name` parameter to `Card apiCard`
4. If you want to run the tests, just make sure to specify the number of test workers to use because there are a lot more than just 2 cards now
    - `dotnet test --filter name=card_is_on_cards_page -- NUnit.NumberOfTestWorkers=4`
    - You can probably run 2-4 tests at one time. It really depends how powerful your machine is.
5. Well now we know there are 93 different cards! Our single test method turned into 93 tests!
6. Now, I would argue that these tests might be better served as lower-level tests, but look how easy it was for us to leverage a single endpoint to ramp up almost 200 tests using only two test methods. It's pretty awesome stuff.

## Update ICardService
Before we move on, I would like to make a change to our ICardService interface. I think that any Card Service we have should really have the capability to return a list of all the cards we have available. Let's make that change.

1. In ICardService, add the GetAllCards() method.
2. Add the implementation to our InMemoryCardService class with a helpful exception.
