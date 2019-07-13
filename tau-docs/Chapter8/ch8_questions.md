# Questions

1. Which method created the log file?
- File.CreateFile()
- Directory.CreateFile()
**File.CreateText()**
- Directory.CreateText()

2. What does the "recursive: true" argument do in the Directory.Delete() method?
- Deletes this directory and any other directories with the same name
**Deletes this directory and all subdirectories and files within it as well**
- Deletes this directory and only its subdirectories
- Deletes this directory and only its files

3. What is the difference between WriteLine() and Write()?
- First writes to console and second writes to files
- First writes a new line and second writes to console
- First writes a files and second writes to console
**First writes a new line and second appends on the current line**

4. How do you do string interpolation in C#?
**`$` before quotes and inject with `{}`**
- inject with `${}` in the quotes
- `f` before quotes and inject with `{}`
- You can't do that in C#

5. Which NUnit class allows us to get information about the current running test?
- CurrentTest
- Context
**TestContext**
- Test

6. Which NUnit attribute executes the method before any tests run?
- [BeforeAll]
**[OneTimeSetUp]**
- [FixtureSetUp]
- [BeforeAny]

7. FW.SetLogger() creates a new instance of Logger. Which method should it start in?
- The Test method
- The TearDown method
**The SetUp method**
- The Constructor method

8. What is a Race Condition?
- When one method is quicker than another method
- When multiple things are trying to get garbage collected at the same time
- When multiple merges cause merge conflicts
**When multiple things are trying to work with the same data at the same time**

9. What is a "lock" in C#?
**A mechanism that forces threads or processes to wait in line and go one by one**
- A mechanism to delay a thread or process until a condition is true
- A mechanism to delete threads or processes that are too slow
- A mechanism to optimize writing to files
