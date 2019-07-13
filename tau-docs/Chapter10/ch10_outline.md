# Configuration
Use a JSON file to manage our tests and framework

Inevitably, we will need to find a way to configure our tests and framework. There are many ways to do this, but I like to work with json or yaml files.

We'll start by making a simple DriverFactory class, then we'll make a JSON file to store our settings.

## Create DriverFactory
In Framework.Selenium, we'll make a DriverFactory.cs class. This is a static class, but all this factory needs to do is to build the driver we ask for and nothing more. We call this creational design pattern the Factory Pattern.

1. Create DriverFactory.cs
2. Create Build() method
    - public static IWebDriver Build(string browser)
3. A quick switch block makes easy work for handling a ChromeDriver or FirefoxDriver
4. Then let's use the DriverFactory in our Driver class
    - _driver = DriverFactory.Build(browser)
5. We now have errors because we changed the signature of our Driver.Init() method. Let's resolve those.

## Without a centralized config
Gross. We had to change a few things in different places. That goes against what we're trying to do with our Framework. What you want is the ability to make a change to a single location and have it affect many locations, remember?

Having a config file, that is essentially your "settings" file, will not only centralize these options, but make it very easy for you and others to make a simple change and affect the test suites.

## Configuration
We will create a JSON file at the workspace root called `framework-config.json` and give it some simple values.

### The .json file
1. Create json file
2. Start with driver object that has `browser` set to "chrome"
    - This will control which browser the tests run against
3. Then a test object that has `url` set to "staging.statsroyale.com"
    - This will control the environment. I'm sure you'll have a staging or QA environment at the very least.

Now that our basic json file is done, we need to turn this file into something our code can read and use.

### FwConfig class
1. Create a new class called FwConfig.cs in Framework project. We want to have this file match what's in our json file.
2. public class FwConfig

But we need to have a driver and test object as well.
3. public class DriverSettings
    - public string Browser { get; set; }
4. public class TestSettings
    - public string Url { get; set; }
5. Then include those in the FwConfig class
    - public DriverSettings Driver { get; set; }
    - public TestSettings Test { get; set; }

### Set the Config in our FW class
We'll set this configuration in our FW class. Since this config applies to the entire framework and test run, this would be considered a singleton. In other words, we really only need to set this once at the beginning of the test run.

1. In FW, create a private static field to hold our configuration
    - private static FwConfig _configuration;
2. Then, create the public member
    - public static FwConfig Config => _configuration ?? throw new NullReferenceException("Configuration is null. SetConfig() first.)
3. Last thing to do in this class is to create a SetConfig() method

## Use our framework-config in code
Finally we can use it in code!

1. In each of our Test Classes, add FW.SetConfig() to our OneTimeSetUp method
2. Then remove the hard-coded "chrome" from Driver.Init()
    - This will require some quick changes to our Driver class
3. Then replace the hard-coded "statsroyale.com" url from Driver.Goto() to FW.Config.Test.Url

## Run copydeck Tests
1. dotnet test --filter testcategory=copydeck
2. They fail! Let's look at the logs
3. Looks like we are going to staging.statsroyale.com and that site doesn't exist. Let's change it back to the original URL and run the tests again. Boom! Works like a charm.

We're only holding two values in our JSON right now, but I've seen these config files get pretty big because of all the different settings that need to be stored or tracked.

Can you think of other things we could store in our JSON? I sure can, but we're ready for the next chapter!
