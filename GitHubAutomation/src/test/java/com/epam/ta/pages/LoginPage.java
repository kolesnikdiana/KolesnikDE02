package com.epam.ta.pages;

import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.LogManager;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

public class LoginPage extends AbstractPage
{
	private final Logger logger = LogManager.getRootLogger();
	private final String BASE_URL = "https://www.instagram.com/";

	@FindBy(className = "_ibk5z")
	private WebElement html;

    @FindBy(className = "_fcn8k")
    private WebElement linkSignIn;

	@FindBy(name = "username")
	private WebElement inputLogin;

	@FindBy(name = "password")
	private WebElement inputPassword;

	@FindBy(className = "_o0442")
	private WebElement buttonSubmit;

	@FindBy(className = "_i572c")
	private WebElement linkLoggedInUser;

	@FindBy(className = "coreSpriteEllipsis")
	private WebElement optionsButton;

	@FindBy(xpath = "//button[contains(.,'Log out')]")
	private WebElement logoutButton;

	public LoginPage(WebDriver driver)
	{
		super(driver);
		PageFactory.initElements(this.driver, this);
	}

	@Override
	public void openPage()
	{
		driver.navigate().to(BASE_URL);
		logger.info("Login page opened");
	}

	public void login(String username, String password)
	{
        linkSignIn.click();
		inputLogin.sendKeys(username);
		inputPassword.sendKeys(password);
		buttonSubmit.click();
		html.click();
		logger.info("Login performed");
	}

	public void logout()
	{
		MainPage mainPage = new MainPage(driver);
		mainPage.getProfilePage();
		optionsButton.click();
		logoutButton.click();
	}

	public String getLoggedInUserName()
	{
		MainPage mainPage = new MainPage(driver);
		mainPage.getProfilePage();
		return linkLoggedInUser.getText();
	}

}
