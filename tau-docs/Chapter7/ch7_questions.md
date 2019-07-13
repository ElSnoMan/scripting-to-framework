# Questions

1. How do you access the elements of a Page Object?
- You can't since they are hidden behind the Page Map
- Page.Element
**Page.Map.Element**
- You must make a new PageMap() in the test

2. After making a new Page Object, what's the next thing you should do?
**Add it to the Pages wrapper**
- High-five your co-workers
- Push changes to master
- Add it to the Driver class

3. What is the default filter for $ dotnet test?
- Category
- **Test Name**
- Priority
- Class Name

4. By default, what is WebDriverWait's polling interval?
- 10 seconds
- 1000 milliseconds
- 5 seconds
**500 milliseconds**

5. Driver.Wait.Until(drvr => !Map.OtherStoresButton.Displayed) reads as:
- "wait until other stores button is displayed"
**"wait until other stores button is not displayed"

6. "other element would receive or intercepted the click" is an error that usually means:
**Another element is on top of the element you want to click on**
- Your locator is locating a different element
- Your locator is invalid
- Your element is moving on the page
