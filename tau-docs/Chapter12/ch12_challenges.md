# Challenges

## Challenge 1
In the WaitConditions.ElementsNotEmpty() method, there is an optimization that can be done.

Right now, we are passing in a list of elements, but we are NOT checking if that list is empty or not! Whoops!

The challenge is to add that logic.
* If the list we pass in is not empty, then return the elements right back.
* If the list we pass in is empty, then try finding the elements again like we had before

## Challenge 2
In this challenge, write your own custom WaitCondition that waits until the URL of the page contains the string you pass in.

## Challenge 3
In this challenge, write your own custom WaitCondition that waits until the element is enabled.

## Challenge 4
In this challenge, write your own custom WaitCondition that waits until the number of elements in the list is equal to the number you pass in
