

using ATframework3demo.TestEntities;
using OpenQA.Selenium.DevTools.V120.Accessibility;

namespace ATframework3demo.PageObjects.TreePage
{
    public class TreeEditPage
    {
        public NodeEditPage nodeEditPage => new NodeEditPage();


        /// <summary>
        /// Проверка данных ноды
        /// </summary>
        /// <param name="testNode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AssertNodeItemInfo(TestEntities.NodeItem testNode)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Клик по выбранной ноде
        /// </summary>
        /// <param name="testNode"></param>
        /// <returns></returns>
        public NodeItem ChooseNode(NodeItem testNode)
        {
            return testNode;
        }
    }
}