# Challenges

We wanted to stop using `Driver.Current` as much as possible, but we currently have `Driver.Current.Quit();` in our TearDown method.

The challenge is to create your own implementation of `Quit()` inside our new Driver class. Then use it in the TearDown method.
