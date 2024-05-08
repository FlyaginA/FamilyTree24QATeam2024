using atFrameWork2.SeleniumFramework;
using System.Reflection.Metadata;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Описание объекта Header страницы
    /// </summary>
    public class Header
    {
        public WebItem ProfileButton = new WebItem("//div[@class=\"navbar-item\"]", "Кнопка открытия профиля в хедере");
        
        /// <summary>
        /// Открытие редактирования профиля 
        /// </summary>
        /// <returns></returns>
        public ProfileEditPage ProfileEdit()
        {
            ProfileButton.Click();
            return new ProfileEditPage();
        }
    }
}
