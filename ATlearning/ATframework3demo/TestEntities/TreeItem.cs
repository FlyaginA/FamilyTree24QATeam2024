using ATframework3demo.PageObjects.TreePage;
using System.Xml.XPath;

namespace ATframework3demo.TestEntities
{
    /// <summary>
    /// Объект дерева на главной странице
    /// </summary>
    public class TreeItem
    {
        public TreeItem(string title, string Xpath = null)
        {
            this.Title = title;
            this.Xpath = $"//a [@class =\"card-header-title\" and text()=\"{title}\"]" +
                //карточка дерева
                $" //ancestor::div[@class=\"card\"] ";

        }

        public string Xpath { get; }
        public string Title { get; }
        /// <summary>
        /// Открывает страницу дерева
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TreeEditPage Open()
        {
            return new TreeEditPage();
        }
    }
}