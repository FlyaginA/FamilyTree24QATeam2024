using atFrameWork2.BaseFramework.LogTools;
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
    public class LoginPage : BaseLoginPage
    {

        public LoginPage(PortalInfo portal = null):base(portal)
        {
        }
        /// <summary>
        /// Вход на ресурс
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public ServiceHomePage Login(User admin)
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri);
            var loginField = new WebItem("//input[@name = 'USER_LOGIN']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@name = 'USER_PASSWORD']", "Поле для ввода пароля");
            loginField.ClearValue();
            loginField.SendKeys(admin.Login);
            loginField.SendKeys(Keys.Tab);
            pwdField.ClearValue();
            pwdField.SendKeys(admin.Password, logInputtedText: false);
            pwdField.SendKeys(Keys.Enter);
            return new ServiceHomePage();
        }
        /// <summary>
        /// Открытие формы регистрации
        /// </summary>
        /// <returns></returns>
        public RegistrationPage OpenRegistrationForm()
        {
            new WebItem("//a[text()=\"Зарегистрироваться\"]", "Открытие формы регистрации").Click();
            return new RegistrationPage();
        }
        /// <summary>
        /// Вход на ресурс для тестирования полей авторизации
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceHomePage TestLogIn(List<string> user)
        {
            var loginField = new WebItem("//input[@name = 'USER_LOGIN']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@name = 'USER_PASSWORD']", "Поле для ввода пароля");
            loginField.ClearValue();
            loginField.SendKeys(user[3]);
            loginField.SendKeys(Keys.Tab);
            pwdField.ClearValue();
            pwdField.SendKeys(user[4]);
            pwdField.SendKeys(Keys.Enter);
            return new ServiceHomePage();
        }
    }
}
