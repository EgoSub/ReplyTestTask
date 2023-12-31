﻿using OpenQA.Selenium;

namespace PageObject.CustomElements.ListElements
{
    public class Report : CustomElement
    {
        public Report(IWebElement element) : base(element)
        {
        }
        public IWebElement Name => element.FindElement(By.ClassName("listViewNameLink"));
    }
}
