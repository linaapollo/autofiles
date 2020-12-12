package com.example.tests;

import com.thoughtworks.selenium.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.regex.Pattern;

public class HelloWorld_IDE_JUnit4 extends SeleneseTestCase {
	@Before
	public void setUp() throws Exception {
		selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://www.google.com.au/");
		selenium.start();
	}

	@Test
	public void testHelloWorld_IDE_JUnit4() throws Exception {
		selenium.open("/");
		String paramSecondSearch = "hellowworld1";
		selenium.type("id=gbqfq", "helloworld");
		selenium.click("id=gbqfb");
		for (int second = 0;; second++) {
			if (second >= 60) fail("timeout");
			try { if (selenium.isTextPresent("glob:About 93,?00,000 results")) break; } catch (Exception e) {}
			Thread.sleep(1000);
		}

		selenium.type("id=gbqfq", paramSecondSearch);
		selenium.click("id=gbqfb");
		for (int second = 0;; second++) {
			if (second >= 60) fail("timeout");
			try { if (selenium.isTextPresent("regexp:About 47,100 results.*(0.* seconds)")) break; } catch (Exception e) {}
			Thread.sleep(1000);
		}

		assertTrue(selenium.isTextPresent("regexp:About 47,100 results.*(0.* seconds)"));
		selenium.click("id=gbqfb");
	}

	@After
	public void tearDown() throws Exception {
		selenium.stop();
	}
}
