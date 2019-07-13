# Challenges

## Challenge 1
Before we move on, I would like to make a change to our ICardService interface. I think that any Card Service we have should really have the capability to return a list of all the cards we have available.

The challenge is to add the GetAllCards() method to our ICardService interface and then run `dotnet build` successfully without any errors.

> HINT: Changing the interface means that any class that implements it will have to change to adhere to the contract, but it's ok if there currently isn't a way to get all the cards.

## Challenge 2
If you ran the tests, you will see that many of them fail! Uh oh! Fortunately the error message is helpful here, but what's the issue?

Ice Spirit had the type of "Troop" and Mirror had the type of "Spell". However, from the API, Ice Spirit's type is "tid_card_type_character" and Mirror's type is "tid_card_type_spell".

The challenge is to use fix the errors without touching the test methods.

> HINTS:
- "tid_card_type_spell" already has the word "spell" in it. How could you use that?
- "character" and "troop" are synonymous in the context of our tests. In other words, if we see "Troop" on the page, that means that it is a "character" and the assertion should pass.
