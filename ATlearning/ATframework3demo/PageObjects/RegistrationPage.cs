




using atFrameWork2.SeleniumFramework;
using System.Xml.Linq;

namespace atFrameWork2.PageObjects
{
    public class RegistrationPage
    {
        public static string NameOfObject = "RegistrationPage";
        /// <summary>
        /// Вводит заданное значение в поле "имя"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterName(string name)
        {
            new WebItem("//input[@name = \"USER_NAME\"]", "Поле для ввода имени").SendKeys(name);
            return this;
        }
        /// <summary>
        /// Вводит заданное значение в поле "Фамилия"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterSurname(string surname)
        {
            new WebItem("//input[@name = \"USER_LAST_NAME\"]", "Поле для ввода фамилии").SendKeys(surname);
            return this;
        }
        /// <summary>
        /// Вводит заданное значение в поле "Логин"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterLogin(string login)
        {
            new WebItem("//input[@name = \"USER_LOGIN\"]", "Поле для ввода логина").SendKeys(login);
            return this;
        }
        /// <summary>
        /// Вводит заданное значение в поле "Пароль"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistrationPage EnterPassword(string password)
        {
            new WebItem("//input[@name = \"USER_PASSWORD\"]", "Поле для ввода пароля").SendKeys(password);
            return this;
        }

        /// <summary>
        /// Нажатие на кнопку "зарегистрироваться"
        /// Если удачно, открывается главная страница
        /// Если неудачно то выкидывает в лог исключение
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MainPage RegistrationButton()
        {
            new WebItem("//input[@name = \"Register\"]", "кнопка 'Зарегистрироваться'").Click();
            return new MainPage();
        }
    }
}