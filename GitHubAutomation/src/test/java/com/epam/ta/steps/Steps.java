package com.epam.ta.steps;

import java.util.concurrent.TimeUnit;

import com.epam.ta.driver.DriverSingleton;
import com.epam.ta.pages.*;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;

import com.epam.ta.pages.EditProfilePage;
import org.openqa.selenium.support.FindBy;

public class Steps
{
	private WebDriver driver;

	private final Logger logger = LogManager.getRootLogger();

	public void initBrowser()
	{
		driver = DriverSingleton.getDriver();
	}

	public void closeDriver()
	{
		driver.quit();
	}

	public void loginInstagram(String username, String password)
	{
		LoginPage loginPage = new LoginPage(driver);
		loginPage.openPage();
		loginPage.login(username, password);
	}

	public void logoutInstagram()
	{
		MainPage mainPage = new MainPage(driver);
		mainPage.getProfilePage();
		LoginPage loginPage = new LoginPage(driver);
		loginPage.logout();
	}

	public boolean isLoggedIn(String username)
	{
		LoginPage loginPage = new LoginPage(driver);
		return (loginPage.getLoggedInUserName().trim().toLowerCase().equals(username));
	}

	public String changeProfileName(String newName)
	{
		MainPage mainPage = new MainPage(driver);
		mainPage.getProfilePage();
		mainPage.editProfile();
		EditProfilePage editProfilePage = new EditProfilePage(driver);
		String expectedName = editProfilePage.editName(newName);
		return expectedName;
	}

	public boolean isNameChanged(String expectedName)
	{
		EditProfilePage editProfilePage = new EditProfilePage(driver);
		return expectedName.equals(editProfilePage.getCurrentProfileName());
	}

	public void findUser(String name){
		FindProfilePage findPage = new FindProfilePage(driver);
		findPage.find(name);
	}

	public boolean isUserFinded(String expectedName)
	{
		FindProfilePage findPage = new FindProfilePage(driver);
		return expectedName.equals(findPage.getCurrentOpenedUserPage());
	}

}
