
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects.HomePage;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.TreeEditingPage
{
    public class Case_ID_12_NodeEdit_Positive : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_12_Редактирование нод(Positive)", homePage => NodeEditPositive(homePage)));
            return caseCollection;
        }

        private static List<NodeItem> TestData = new List<NodeItem>
        {
            new NodeItem("Анна","Смирнова","08.08.1990","","Female",true)
        };
        /// <summary>
        /// Flyagin
        /// Case ID 12
        /// Редактирование нод(Positive)
        /// </summary>
        /// <param name="homePage"></param>
        public void NodeEditPositive(ServiceHomePage homePage)
        {
            var TestTree = new TreeItem("TestTree" + DateTime.Now);
            var ThisScreen =
                homePage
                    .mainPage
                    //создадим новое дерево
                    .TreeTitleInput(TestTree.Title)
                    .ClickButtonAddNewTree()
                    //Зайти в новое дерево	
                    .ChooseTree(TestTree)
                    .Open();


            int i = 0;
            foreach (var TestNode in TestData)
            {
                i++;
                if (
                    ThisScreen
                    .nodeEditPage
                    //впишем имя
                    .EnterName(TestNode.Name)
                    //Фамилия
                    .EnterSurname(TestNode.Surname)
                    //Дата рождения
                    .EnterBornDate(TestNode.BornDate)
                    //Ввод пола
                    .EnterSexField(TestNode.SexField)
                    //Установка значения Important
                    .EnterImportantFlag(TestNode.ImportantField)
                    //сохраняем
                    .Save()
                    //проверяем что все данные были записаны и внесены соответственно заданным
                    .AssertNodeItemInfo(TestNode)
                    )
                {
                    Log.Info($"Log.Info($\"Round {i}: Success \");");
                }
                else
                {
                    Log.Error($"Round {i}: Fail \n Сurrent Data: {string.Join("; ", TestData)} ");
                    return;
                }
                //подготовка к следующему кругу
                //Открытие редактора ноды для следующей проверки
                ThisScreen
                    //выбираем текущую ноду
                    .ChooseNode(TestNode)
                    .Edit();
            }
        }
    }
}
