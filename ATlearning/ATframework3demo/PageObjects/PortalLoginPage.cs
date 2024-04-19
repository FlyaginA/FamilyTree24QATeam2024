﻿using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    class PortalLoginPage : BaseLoginPage
    {
        public PortalLoginPage(PortalInfo portal):base(portal)
        {
        }

        public HomePage Login(User admin)
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri);
            var loginField = new WebItem("//input[@name = 'USER_LOGIN']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@name = 'USER_PASSWORD']", "Поле для ввода пароля");
            loginField.SendKeys(admin.Login);
            loginField.SendKeys(Keys.Tab);
            pwdField.SendKeys(admin.Password, logInputtedText: false);
            pwdField.SendKeys(Keys.Enter);
            return new HomePage();
        }
    }
}
