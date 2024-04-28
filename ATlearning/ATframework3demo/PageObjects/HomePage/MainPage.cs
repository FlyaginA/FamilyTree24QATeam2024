
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

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
                "Кнопка создания нового дерева").WaitElementDisplayed(2))
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

        /// <summary>
        /// Введение текста в поле "enter a tree name"
        /// </summary>
        /// <param name="title"></param>
        /// <exception cref="NotImplementedException"></exception>
        public MainPage TreeTitleInput(string title)
        {
            var field = new WebItem("//input [@id =\"treeTitleInput\"]", "Поле \"enter a tree name\"");
            field.Click();
            field.ClearValue();
            field.SendKeys(title);
            return this;

        }

        /// <summary>
        /// Клик на кнопку добавления дерева
        /// </summary>
        /// <returns></returns>
        public MainPage ClickButtonAddNewTree()
        {
            var button = new WebItem("//button[@id =\"addTreeButton\"]", "Кнопка добавления деревьев");
            button.Click();         
            return this;
        }
        /// <summary>
        /// Проверка сщуествования дерева на экране
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public bool TreeIsExist(TreeItem tree)
        {
            if (new WebItem(tree.Xpath,$"карточка дерева{tree.Title}").WaitElementDisplayed(2))
            {
                return true;
            }    
            else { return false; }
        }

        public TreeItem ChooseTree(TreeItem testTree)
        {
            return testTree;
        }
    }
}