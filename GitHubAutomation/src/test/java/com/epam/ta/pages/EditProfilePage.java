package com.epam.ta.pages;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

import com.epam.ta.utils.Utils;

public class EditProfilePage extends AbstractPage
{
	private final String BASE_URL = "https://www.instagram.com/";
	private final Logger logger = LogManager.getRootLogger();

	@FindBy(id = "pepName")
	private WebElement inputNewName;

	@FindBy(xpath = "//button[contains(text(), 'Submit')]")
	private WebElement butttonSave;

	@FindBy(xpath = "//header//div[@class='_bugdy']//h2")
	private WebElement linkCurrentName;

	public EditProfilePage(WebDriver driver)
	{
		super(driver);
		PageFactory.initElements(this.driver, this);
	}

	public String editName(String newName)
	{
		String newFullName = newName + Utils.getRandomString(6);
		inputNewName.clear();
		inputNewName.sendKeys(newFullName);
		butttonSave.click();
		return newFullName;
	}

	public String getCurrentProfileName()
	{
		MainPage mainPage = new MainPage(driver);
		mainPage.getProfilePage();
		return linkCurrentName.getText();
	}

	@Override
	public void openPage()
	{
		driver.navigate().to(BASE_URL);
	}
}
