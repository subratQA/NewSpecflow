using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specflow.Settings;

namespace WebDriver_Specflow.ActionUtilities
{
    public class ControlUtilities
    {
        public static IWebElement GetLinkFromActionPalette(IWebElement ActionsPalette, String ActionLink, String LogMessageOnException)
        {
            bool ActionLinkFound = false;

            try
            {
                if (ExpandActionsPalette(ActionsPalette, "Unable to expand Actions Palettte"))
                {
                    IWebElement Action = ActionsPalette.FindElement(By.XPath("//*[contains(text(), '" + ActionLink + "')]//ancestor::a[1]"));
                    if (Action != null)
                    {
                        ActionLinkFound = true;
                        return Action;
                    }
                }
                if (!ActionLinkFound)
                {
                    //Control_ActionUtilities.LogException("Action Palette is not displayed.", String.Empty, LogMessageOnException);
                }
            }
            catch (Exception e)
            {
                //Control_ActionUtilities.LogException("Failed to get Action link.", e.ToString(), LogMessageOnException);
            }
            return null;
        }
        public static bool ExpandActionsPalette(IWebElement ActionsPalette, String LogMessageOnException)
        {
            bool ActionsExpanded = false;

            try
            {
                if (ActionsPalette != null && ActionsPalette.ToString() != null)
                {
                    if (ActionsPalette.GetProperty("class") != "visible")
                    {
                        IWebElement ExpandCollapseIcon = ActionsPalette.FindElement(By.XPath(".//preceding::tr[1]//img[contains(@id, 'Actions_imgToggle')]"));
                        if (ExpandCollapseIcon != null)
                        {
                            ExpandCollapseIcon.Click();
                            ActionsExpanded = true;
                        }
                    }
                    //return ActionsExpanded;
                    if (!ActionsExpanded)
                    {
                        //Control_ActionUtilities.LogException("Expand Icon for Actions palette is not displayed.", String.Empty, LogMessageOnException);
                    }
                }
                else
                {
                    //Control_ActionUtilities.LogException("Actions Palette is not displayed to expand.", String.Empty, LogMessageOnException);
                }
            }
            catch (Exception e)
            {
                //Control_ActionUtilities.LogException("Unable to expand Actions Palette.", e.ToString(), LogMessageOnException);
            }
            return ActionsExpanded;
        }
    }
}
