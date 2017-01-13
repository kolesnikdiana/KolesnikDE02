package com.epam.ta.pages;

import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;

public class FindProfilePage extends AbstractPage
{
    private final String BASE_URL = "https://www.instagram.com/";

    @FindBy(xpath = "//div[@class = '_9pxkq _icv3j']//input")
    private WebElement inputSearch;

    @FindBy(xpath = "//a[@class = '_k2vj6'][@href='/diana.kolesnik/']")
    private WebElement userLink;

    @FindBy(xpath = "//main//header//h1")
    private WebElement openedUserPage;

    public FindProfilePage(WebDriver driver)
    {
        super(driver);
        PageFactory.initElements(this.driver, this);
    }

    public void find(String name)
    {
        inputSearch.click();
        inputSearch.sendKeys(name);
        userLink.click();
    }

    public String getCurrentOpenedUserPage()
    {
        return openedUserPage.getText();
    }

    @Override
    public void openPage()
    {
        driver.navigate().to(BASE_URL);
    }
}
