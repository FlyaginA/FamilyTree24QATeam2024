
using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    public class MainPage
    {
        /// <summary>
        /// Главная страница ресурса, меню деревьев
        /// </summary>
        public MainPage()
        {
        }


        /// <summary>
        /// Проверка того что мы находимся на главной странице.
        /// Осуществляется через поиск уникальной кнопки Create New tree!
        /// </summary>
        /// <returns></returns>
        public bool IsMainPage()
        {
            if (new WebItem("//button [@class = \"button is-success is-rounded button-add-tree\"]",
                "Кнопка создания нового дерева").WaitElementDisplayed())
            {
                return true;
            }
            else
            { return false; }
        }


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