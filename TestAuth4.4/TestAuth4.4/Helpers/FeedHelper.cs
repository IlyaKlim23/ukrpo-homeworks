using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestAuth4._4.Models;
using TestAuth4._4.Tools;

namespace TestAuth4._4.Helpers;

public class FeedHelper(AppManager manager) : HelperBase(manager)
{
    #region scripts

    private const string LabelElementJs =
        """
            return document
                .querySelector('#custom-feed-create-modal-content > rpl-modal-card > custom-feed-details-form')
                .shadowRoot.querySelector('faceplate-form > div > faceplate-text-input')
                .shadowRoot.querySelector('label');
        """;

    private const string LabelInputElementJs =
        """
            const modal = document.querySelector('#custom-feed-create-modal-content > rpl-modal-card > custom-feed-details-form');
            if (!modal) return null;
            
            const shadow1 = modal.shadowRoot;
            if (!shadow1) return null;
            
            const faceplateForm = shadow1.querySelector('faceplate-form > div > faceplate-text-input');
            if (!faceplateForm) return null;
            
            const shadow2 = faceplateForm.shadowRoot;
            if (!shadow2) return null;
            
            return shadow2.querySelector('label > div > span > span.input-container.activated > input[type=text]');
        """;

    private const string TextElementJs =
        """
            const rootElement = document.querySelector('#custom-feed-create-modal-content > rpl-modal-card > custom-feed-details-form');
            if (!rootElement) {
                console.log('Root element not found');
                return null;
            }
            
            // Первый уровень Shadow DOM
            const shadow1 = rootElement.shadowRoot;
            if (!shadow1) {
                console.log('First shadow root not found');
                return null;
            }
            
            // Находим textarea-input
            const textareaInput = shadow1.querySelector('faceplate-form > div > faceplate-textarea-input');
            if (!textareaInput) {
                console.log('Textarea input element not found');
                return null;
            }
            
            // Второй уровень Shadow DOM
            const shadow2 = textareaInput.shadowRoot;
            if (!shadow2) {
                console.log('Second shadow root not found');
                return null;
            }
            
            // Ищем конечный элемент
            const targetDiv = shadow2.querySelector('label > div');
            if (!targetDiv) {
                console.log('Target div not found');
            }
            return targetDiv;
        """;

    private const string TextInputJs =
        """
            function getElement() {
            // 1. Находим корневой элемент
            const rootElement = document.querySelector('#custom-feed-create-modal-content > rpl-modal-card > custom-feed-details-form');
            if (!rootElement) {
                console.error('Root element not found');
                return null;
            }
        
            // 2. Первый Shadow DOM
            const firstShadow = rootElement.shadowRoot;
            if (!firstShadow) {
                console.error('First shadow root not found');
                return null;
            }
        
            // 3. Находим textarea-input
            const textareaInput = firstShadow.querySelector('faceplate-form > div > faceplate-textarea-input');
            if (!textareaInput) {
                console.error('Textarea input element not found');
                return null;
            }
        
            // 4. Второй Shadow DOM
            const secondShadow = textareaInput.shadowRoot;
            if (!secondShadow) {
                console.error('Second shadow root not found');
                return null;
            }
        
            // 5. Находим конечный элемент
            const innerTextArea = secondShadow.querySelector('#innerTextArea');
            if (!innerTextArea) {
                console.error('Inner textarea not found');
            }
            return innerTextArea;
        }
        return getElement();
        """;

    private const string SubmitJs =
        """
        return document.querySelector("#custom-feed-create-modal-content > rpl-modal-card > custom-feed-details-form").shadowRoot.querySelector("faceplate-form > div > div > button.button-small.px-\\[var\\(--rem10\\)\\].button-primary.items-center.justify-center.button.inline-flex")
        """;
    
    private const string ToolsButtonJs =
        """
        return document.querySelector("#subgrid-container > div.masthead.w-full > custom-feed-header").shadowRoot.querySelector("div > div > div.flex.items-center.gap-xs > faceplate-dropdown-menu > button")
        """;
    private const string DeleteButtonJs =
        """
        return document.querySelector("#subgrid-container > div.masthead.w-full > custom-feed-header").shadowRoot.querySelector("div > div > div.flex.items-center.gap-xs > faceplate-dropdown-menu > faceplate-menu > faceplate-tracker:nth-child(4) > rpl-dialog-trigger > li > div")
        """;
    private const string DeleteApplyButtonJs =
        """
        return document.querySelector("#custom-feed-delete-confirmation-modal > rpl-modal-card > div:nth-child(4) > button > span > span")
        """;

    private const string HeaderJs =
        """
        return document.querySelector("#right-sidebar-contents > aside.flex.flex-col.py-md.box-border.mb-0.bg-neutral-background-weak.rounded-\\[8px\\].\\!h-auto > custom-feed-description").shadowRoot.querySelector("#title")
        """;

    
    #endregion

    public void CreateFeed(FeedData feedData)
    {
        FluentWait.WaitUntilAndDo(_manager.Driver, By.Id("multireddits_section"), x => x.Click());
        FluentWait.WaitUntilAndDo(_manager.Driver, By.CssSelector(".w-100:nth-child(3)"), x => x.Click());

        InsertIntoInputs(LabelElementJs, LabelInputElementJs, feedData.Name);
        InsertIntoInputs(TextElementJs, TextInputJs, feedData.Description);
        
        FluentWait.WaitUntilAndDo(_manager.Driver, SubmitJs, x => x.Click());
    }

    public void DeleteFeed()
    {
        FluentWait.WaitUntilAndDo(_manager.Driver, ToolsButtonJs, x => x.Click());
        FluentWait.WaitUntilAndDo(_manager.Driver, DeleteButtonJs, x => x.Click());
        FluentWait.WaitUntilAndDo(_manager.Driver, DeleteApplyButtonJs, x => x.Click());
    }

    public FeedData GetFeedData()
    {
        var titleElement = (IWebElement?)((IJavaScriptExecutor)_manager.Driver).ExecuteScript(HeaderJs);
        var descElement = _manager.Driver.FindElement(By.CssSelector("#-post-rtjson-content > p"));
        
        return new FeedData(titleElement?.Text ?? string.Empty, descElement.Text);
    }

    private void InsertIntoInputs(string labelScript, string inputScript, string value)
    {
        FluentWait.WaitUntilAndDo(_manager.Driver, labelScript, x => x.Click());
        FluentWait.WaitUntilAndDo(_manager.Driver, inputScript, x =>
        {
            x.Clear();
            value.ToList().ForEach(y => x.SendKeys(y.ToString()));
        });
    }
}