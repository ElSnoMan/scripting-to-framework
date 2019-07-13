# Questions

1. What is the following member of a class called? `public string Name { get; set; }`
**Property**
- Method
- Field
- Constructor

2. When objects have things in common, they are called:
- Shared values
**Base properties**
- Main attributes
- Base values

3. What does the `virtual` keyword do?
- The member lives in a virtual space
- The member cannot be overriden by the class that inherits it
- The member is private to the class
**The member can be overriden by the class that inherits it**

4. Interfaces are rules or contracts that must be adhered to by any class that implements them
**True**
- False

5. Which NUnit attribute is used to make explicit test cases for a test method?
**[TestCase]**
- [TestCaseSource]
- [Case]
- [Parameter]

6. Which NUnit attribute is used to pass in a list of values and turn them into test cases?
- [TestCases]
**[TestCaseSource]**
- [TestSource]
- [Parameters]

7. Which NUnit attribute is used to mark a test method for parallel execution?
- [Parallel]
- [Concurrent]
**[Parallelizable]**
- [Parallel.Scope]

8. Which command would run the tests with [Category("foo")]?
- $ dotnet test -f foo
- $ dotnet test --filter foo
- $ dotnet test --filter category=foo
**$ dotnet test --filter testcategory=foo**


9. Why did only one test pass while the other one failed and left the browser open?
**The driver is shared between the tests**
- driver.Quit() didn't work as expected
- [TestCaseSource] interferes with the [TearDown] method
- The [SetUp] method was only executed once
