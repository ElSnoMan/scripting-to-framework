# Challenges

In our AfterEach() method in TestBase.cs, we have three separate `FW.Log` lines. It might be best to condense that a bit.

The challenge is to only have ONE `FW.Log.Info()` line that will log whichever outcome to the log file.

> HINT:
* `outcome` may not be able to be concatenated with `"Outcome: " + outcome` because it's technically not a string.
