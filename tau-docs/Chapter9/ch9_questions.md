# Questions

1. If I wanted Element to implement IWebElement, which would I use?
- Element extends IWebElement
- Element implements IWebElement
**Element : IWebElement**
- Element :: IWebElement

2. How do you require a `name` value whenever you make a new instance of Element?
**In the constructor, add `string name` to its parameters**
- Create a `private readonly string Name;` field
- Create a `public string Name { get; set; }` property
- In the constructor, have `_name = name`

3. If I wanted Elements to inherit ReadOnlyCollection<IWebElement>, which would I use?
- Elements extends ReadOnlyCollection<IWebElement>
- Elements implements ReadOnlyCollection<IWebElement>
**Elements : ReadOnlyCollection<IWebElement>**
- Elements :: ReadOnlyCollection<IWebElement>

4. How is our Elements class using `Count` when it isn't defined anywhere in the file?
- Magic obviously
**Count is a property in the base class**
- Elements comes with Count pre-defined
- Every object in C# has a Count property
