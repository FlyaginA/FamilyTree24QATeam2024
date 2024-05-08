using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Объект левого меню страницы
    /// </summary>
    public class LeftMenu
    {
        /// <summary>
        /// Функция выхода из профиля
        /// </summary>
        /// <returns></returns>
        public LoginPage LogOut()
        {
            new WebItem("//a [@id =\"logout\"]", "Кнопка выхода из аккаунта").Click();
            return new LoginPage();
        }


    }
}