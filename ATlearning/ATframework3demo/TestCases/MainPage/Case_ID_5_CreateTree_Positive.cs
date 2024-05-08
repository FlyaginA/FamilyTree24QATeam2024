using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.MainPage
{
    /// <summary>
    /// Author:Flyagin
    /// TestCase 5
    /// проверка поля создания дерева
    /// предварительные условия - аналогичные создаваемым в ходе 
    /// тест-кейса карточки, должны отсутствовать.
    /// </summary>
    public class Case_ID_5_CreateTree_Positive : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание дерева(Positive)", (ServiceHomePage HomePage) => CreateTreePositive(HomePage)));
            return caseCollection;
        }

        private static List<TreeItem> TreeItems = new List<TreeItem>()
        {
            new TreeItem("Семейное дерево Ивановых"),
            new TreeItem("Родословная семьи Петровых"),
            new TreeItem(new string('А', 70)),
            new TreeItem("История рода Сидоровых на протяжении веков"),
            new TreeItem("Семейное дерево семьи Ивановых и их наследия сквозь поколения        #")
        };
        private void CreateTreePositive(ServiceHomePage HomePage)
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
                    Log.Info($"Round {i}: Success ");
                }
                else
                {
                    
                    Log.Error($"Tree with name \"{Tree.Title}\"");
                    return;
                }
            }
            
        }

       
            


    }
}
