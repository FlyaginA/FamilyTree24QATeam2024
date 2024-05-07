using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.HomePage;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.MainPage
{
    /// <summary>
    /// Author:Flyagin
    /// TestCase 5
    /// </summary>
    public class Case_ID_6_CreateTree_Negative : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_6_Создание дерева(Negative)", (ServiceHomePage HomePage) => CreateTreeNegative(HomePage)));
            return caseCollection;
        }
        
        private static List<TreeItem> TreeItems = new List<TreeItem>()
        {
            new TreeItem ( ""),
            new TreeItem ( "    "),
            new TreeItem ( "                     "),
            new TreeItem ( "Генеалогия фамилии Романовых - от ранних истоков до последнего русского царя, краткий анализ их влияния на историю Европы")

        };
        /// <summary>
        /// Author:Flyagin
        /// TestCase #6
        /// Проверка поля создания кейса (негативная)
        /// </summary>
        /// <param name="HomePage"></param>
        private void CreateTreeNegative(ServiceHomePage HomePage)
        {
            var ThisScreen =
                HomePage
                    .mainPage;
            int i = 0;
            foreach (var Tree in TreeItems)
            {
                i++;
                if (
                    ThisScreen
                    //Ввести название древа
                    .TreeTitleInput(Tree.Title)
                    //Нажать кнопку "создать дерево
                    .ClickButtonAddNewTree()
                    //проверить наличие объекта дерева на экране
                    .TreeIsExist(Tree)
                    )
                {
                    Log.Error($"Tree with name {Tree.Title} ");
                    
                }
                else
                {

                    Log.Info($"Round {i}: Success ");
                    return;
                }
            }

        }

    }    
}
