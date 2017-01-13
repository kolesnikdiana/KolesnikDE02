package com.epam.ta;

import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import com.epam.ta.steps.Steps;

public class GitHubAutomationTest
{
	private Steps steps;
	private final String USERNAME = "testEpam";
	private final String PASSWORD = "testcase";
	private final String NEW_NAME = "Epam Epamich";
	private final String USER = "diana.kolesnik";

	@BeforeMethod(description = "Init browser")
	public void setUp()
	{
		steps = new Steps();
		steps.initBrowser();
	}

	@Test(description = "Find the user in Instagram")
	public void oneCanFindUser()
	{
		steps.loginInstagram(USERNAME, PASSWORD);
		steps.findUser(USER);
		Assert.assertTrue(steps.isUserFinded(USER));
	}

	@Test(description = "Login to Instagram")
	public void oneCanLoginInstagram()
	{
		steps.loginInstagram(USERNAME, PASSWORD);
		Assert.assertTrue(steps.isLoggedIn(USERNAME.toLowerCase()));
		steps.logoutInstagram();
	}

	@Test
	public void oneCanChangeName()
	{
		steps.loginInstagram(USERNAME, PASSWORD);
		steps.changeProfileName(NEW_NAME);
		String expectedName = steps.changeProfileName(NEW_NAME);
		Assert.assertTrue(steps.isNameChanged(expectedName));
		steps.logoutInstagram();
	}

	@AfterMethod(description = "Stop Browser")
	public void stopBrowser()
	{
		steps.closeDriver();
	}

}
