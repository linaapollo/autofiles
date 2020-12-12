using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
[TestFixture]
public class HelloWorld_IDE_CSharp
{
private ISelenium selenium;
private StringBuilder verificationErrors;

[SetUp]
public void SetupTest()
{
selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://www.google.com.au/");
selenium.Start();
verificationErrors = new StringBuilder();
}

[TearDown]
public void TeardownTest()
{
try
{
selenium.Stop();
}
catch (Exception)
{
// Ignore errors if unable to close the browser
}
Assert.AreEqual("", verificationErrors.ToString());
}

[Test]
public void TheHelloWorld_IDE_CSharpTest()
{
			selenium.Open("/");
			String paramSecondSearch = "hellowworld1";
			selenium.Type("id=gbqfq", "helloworld");
			selenium.Click("id=gbqfb");
			for (int second = 0;; second++) {
				if (second >= 60) Assert.Fail("timeout");
				try
				{
					if (selenium.IsTextPresent("glob:About 93,?00,000 results")) break;
				}
				catch (Exception)
				{}
				Thread.Sleep(1000);
			}
			selenium.Type("id=gbqfq", paramSecondSearch);
			selenium.Click("id=gbqfb");
			for (int second = 0;; second++) {
				if (second >= 60) Assert.Fail("timeout");
				try
				{
					if (selenium.IsTextPresent("regexp:About 47,100 results.*(0.* seconds)")) break;
				}
				catch (Exception)
				{}
				Thread.Sleep(1000);
			}
			Assert.IsTrue(selenium.IsTextPresent("regexp:About 47,100 results.*(0.* seconds)"));
			selenium.Click("id=gbqfb");
}
}
}
