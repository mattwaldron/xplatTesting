# Goal 
This project demonstrates two advanced applications of integration testing:

The first is to demonstrate running a single test on multiple platforms.  Unit tests are run by a test runner by either compiling them together as an executable, or having the test running act upon a DLL of tests.  The Android example discussed later fits the former case, and Windows the latter.  The relationship means that test code is usually at the highest level of the application, which is usually platform-specific.

The second goal is to demonstrate specifying options into the test run.  The test set-up usually completely configures the test and inject dependencies where necessary.  To exercise different permutations of options with the same tests, it can be beneficial to specify an option to the test runner and iterate, versus parameterizing test fixtures or copying tests with different dependencies injected.

The example takes 'Hello World' to an extreme, with IHello interface, implementations, factory, a HelloType enumeration, etc.  Hopefully this demonstrates the mechanics involved without introducing terms that carry other expectations.

# Sharing Tests Between Platforms
## Structure
This example is made up of 6 projects:
CommonFunctions - .NET Standard
WindowsHello - .NET Framework
AndroidHello - Xamarin Android
CommonTest - .NET Standard
WindowsTest - .NET Framework
NUnit.Tests.AndroidHelloTests - Xamarin Android

The first three project represent a cross-platform application.  Interfaces and common code are stored in the CommonFunctions class.  Platform-specific implementations of the interfaces are located in the .NET Framework and Xamarin projects.

In order to share tests between platforms, a similar design is done with the last 3 projects.  The WindowsTest and AndroidHelloTests projects inject platform dependent classes into the platform-agnostic 'CommonTest' project, where the actual tests are defined.

## Attributes
In this example, we trick the test runners a little bit with inheritance.  The actual tests are defined in the Common project, and act upon only interfaces.  The test functions have the 'Test' attribute on them, but the class they are in do not have the 'TestFixture' attribute.

The 'TestFixture' attribute is placed on classes in the platform-specific projects, and these inherit from the platform-agnostic test classes.  The 'OneTimeSetUp' functions in the derived classes inject the concrete classes into the base classes for tests to run.  The test runner finds the 'TestFixture' classes, and then runs their set-up and 'Test' functions, even with the Test functions being inherited.

# Testing with Command-Line Options
## Windows
For Windows, the NUnit Console Runner takes a --testparam option.  In the example, the Windows integration tests are run with the command:
```
./packages/NUnit.ConsoleRunner.3.10.0/tools ]$ ./nunit3-console.exe ../../../WindowsTests/bin/Debug/WindowsTests.dll --testparam "helloType=casual"
```

The test code picks this up from the TestContext:
```csharp
    public void OneTimeSetup()
    {
        base.OneTimeSetup(WindowsHelloFactory.GetHellos(), 
            CommonTestUtil.LookupHelloType(TestContext.Parameters["helloType"]));
    }
```

CommonTestUtil.LookupHelloType is in the CommonTest project, as the Android version will use this too.  The windows_*.png files show the command-line parameter changing the test behavior (the option selects a different IHello object to call the 'Say' function on, the return value of which is printed).

## Android
Android is quite a bit more difficult, as the tests are built into an app, and there is no command line to specify parameters to.  Instead we can use ADB, and modify the NUnit test program template to store the 'extra' parameters in a global variable.

After compiling and installing the app on a device or emulator with Visual Studio, the following command can be used to start the app and run the tests:
```
adb shell am start -a "android.intent.action.MAIN" -c "android.intent.category.LAUNCHER" -n "NUnit.Tests.AndroidHelloTests/crc64f25ab72de175672d.MainActivity" --es helloType casual
```

The parameters is retrieved in the test code with Intent.GetStringExtra:
```csharp
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public static string helloType;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ...
            helloType = Intent.GetStringExtra("helloType");
            
...

    public void OneTimeSetup()
    {
        base.OneTimeSetup(AndroidHelloFactory.GetHellos(), 
            CommonTestUtil.LookupHelloType(MainActivity.helloType));
    }
```

To stop the app, and re-run with a different option, the following commands are used:
```
adb shell am force-stop NUnit.Tests.AndroidHelloTests

adb shell am start -a "android.intent.action.MAIN" -c "android.intent.category.LAUNCHER" -n "NUnit.Tests.AndroidHelloTests/crc64f25ab72de175672d.MainActivity" --es helloType formal
```

The android_*.png files show what is observed between each step.
