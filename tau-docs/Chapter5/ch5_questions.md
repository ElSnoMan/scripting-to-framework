# Questions

1. Which attribute allows a static member to have a unique value per thread?
**[ThreadStatic]**
- [Threaded]
- [StaticThead]
- [MultiThread]

2. What does the `??` operator do?
- Gets left expression if true, else right expression
**Gets left expression if not null, else right expression**
- Gets left expression if greater than the right expression
- Gets left expression if no exception is thrown

3. What does Driver.Current represent?
- The static Driver
- The singleton instance of _driver
**The current, unique instance of _driver attached to a thread or process**
- The current, unique instance of Driver

4. What Type is _driver?
- Driver
- WebDriver
- Selenium.WebDriver
- IWebDriver

5. We customized what our Driver.Goto() method could do. Which functionality did it not have?
- Prefix http if it was not already included in the URL
- Print the URL when in debugging the tests
**Append .com if it was not already included in the URL
- Navigate to the URL
