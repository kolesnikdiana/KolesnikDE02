package com.epam.ta.pages;

import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;

public class MainPage extends AbstractPage
{
	private final String BASE_URL = "https://www.instagram.com/";

	@FindBy(xpath = "//a[@href = '/accounts/edit/']//button")
	private WebElement editButton;

	@FindBy(className = "coreSpriteDesktopNavProfile")
	private WebElement profileButton;

	public MainPage(WebDriver driver)
	{
		super(driver);
		PageFactory.initElements(this.driver, this);
	}

	public void getProfilePage()
	{
		profileButton.click();
	}

	public void editProfile()
	{
		editButton.click();
	}

	@Override
	public void openPage()
	{
		driver.navigate().to(BASE_URL);
	}
}
