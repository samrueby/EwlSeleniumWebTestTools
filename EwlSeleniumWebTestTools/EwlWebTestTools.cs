using Humanizer;
using OpenQA.Selenium;

namespace SamRueby.EwlSeleniumWebTestTools {
	public static class EwlWebTestTools {
		public static void SelectOptionFromRadioButtonSelectList( this IWebDriver iWebDriver, string formItemLabel, string optionLabel ) {
			iWebDriver.FindElement(
				By.XPath(
					( "//*[@class='formItemAndLabelGrouping']//*[contains(@class,'label')][contains(text(),'{0}')]" +
					  "/ancestor::*[@class='formItemAndLabelGrouping']//label//span[contains(text(),'{1}')]//ancestor::label//input[@type='radio']" ).FormatWith(
						  formItemLabel,
						  optionLabel ) ) ).Click();
		}

		public static By GetTextBoxFromFormItem( string formItemLabel ) {
			return
				By.XPath(
					"//*[@class='formItemAndLabelGrouping']//*[contains(@class,'label')][contains(text(),\"{0}\")]/ancestor::*[@class='formItemAndLabelGrouping']//input[@type='text']"
						.FormatWith( formItemLabel ) );
		}

		public static By GetTextBoxFromLabel( string label ) {
			return By.XPath( "//*[contains(@class,'ewfLabeledControl')][contains(text(),'{0}')]//input[@type='text']".FormatWith( label ) );
		}

		/// <summary>
		/// <param name="divId"></param> should be the ID of the first div INSIDE (child) the div with the class of ewfDropDown. Include the hash.
		/// </summary>
		public static void ClickSelect2DropdownChooseOption( this IWebDriver driver, string divId, string optionChoiceText ) {
			driver.FindElement( By.CssSelector( divId + " > a" ) ).Click();
			driver.FindElement( By.XPath( "//ul[@class='select2-results']/li/div[contains(text(), '" + optionChoiceText + "')]" ) ).Click();
		}

		public static string GetFormItemTableValue( this IWebDriver driver, string leftColumnName ) {
			return driver.FindElement( By.XPath( "//td[contains(text(), '" + leftColumnName + "')]/../td[2]" ) ).Text;
		}

		public static string GetTextBoxValue( this IWebDriver driver, By @by ) {
			return driver.FindElement( @by ).GetAttribute( "value" );
		}

		public static bool RadioButtonIsChecked( this IWebDriver driver, By isEnabled ) {
			return driver.FindElement( isEnabled ).GetAttribute( "checked" ) == "true";
		}

		public static By GetTableCellContaining( string text ) {
			return By.XPath( "//td[contains(text(), '" + text + "')]" );
		}

		public static bool ElementExists( this IWebDriver driver, By by ) {
			try {
				driver.FindElement( @by );
				return true;
			}
			catch( NoSuchElementException ) {
				return false;
			}
		}

		public static void ClickSelect2DropdownChooseOption( By select2, string optionChoiceText, IWebDriver driver ) {
			driver.FindElement( select2 ).FindElement( By.ClassName( "select2-choice" ) ).Click();
			driver.FindElement( By.XPath( "//ul[@class='select2-results']/li/div[contains(text(), '" + optionChoiceText + "')]" ) ).Click();
		}
	}
}