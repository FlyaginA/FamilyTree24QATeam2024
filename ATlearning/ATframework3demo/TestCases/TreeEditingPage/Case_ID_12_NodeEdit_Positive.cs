
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.TreeEditingPage
{
    public class Case_ID_12_NodeEdit_Positive : CaseCollectionBuilder
    {


        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Редактирование нод(Positive)", (ServiceHomePage HomePage) => NodeEditPositive(HomePage)));
            return caseCollection;
        }

        
        /// <summary>
        /// Flyagin
        /// Case ID 12
        /// Редактирование нод(Positive)
        /// </summary>
        /// <param name="homePage"></param>
        public void NodeEditPositive(ServiceHomePage homePage)
        {
            List<NodeItem> TestNodes = new List<NodeItem>
            {
                //1
                new NodeItem("Анна","Смирнова","01.01.1900","31.12.1950","Мужской","50","150","Без образования",true),
                //2
                new NodeItem("Александра","Константинопольская","29.02.1920","01.12.1980","Женский","65","165","Школьное",false),
                //3
                new NodeItem("Jean-Pierre", "Dupont", "31.07.1970", "31.07.2040", "Мужской", "75", "175", "Среднее", false),
                //4
                new NodeItem("Анна-Мария","Иванова-Петрова","30.06.1980","30.06.2050","Женский","85","185","Высшее",true),
                //5
                new NodeItem("D'Artagnan","de la Vallière","01.04.2000","31.12.2077","Мужской","95","195","Школьное",true),
                //6
                new NodeItem("Ян-Поль", "Д'Артаньян", "15.08.2010", "15.08.2080", "Женский", "105", "205", "Высшее", false),
            };
            TreeItem TestTree = new TreeItem("TestTree" + DateTime.Now);
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
            foreach (NodeItem Node in TestNodes)
            {
                i++;
                if (
                    ThisScreen
                    .nodeEditPage
                    //впишем имя
                    .EnterName(Node.Name)
                    //Фамилия
                    .EnterSurname(Node.Surname)
                    //Дата рождения
                    .EnterBirthDate(Node.BirthDate)
                    //Дата смерти
                    .EnterDeathDate(Node.DeathDate)
                    //Ввод Веса
                    .EnterWeight(Node.Weight)
                    //Ввод роста
                    .EnterHeight(Node.Height)
                    //Ввод пола
                    .EnterGender(Node.Gender)
                    //Ввод уровня образования
                    .EnterEducationLevel(Node.EducationLvl)
                    //Установка значения Important
                    .EnterImportantFlag(Node.ImportantField)
                    //сохраняем
                    .Save()
                    //проверяем что все данные были записаны и внесены соответственно заданным
                    .AssertNodeItemInfo(Node)
                    )
                {
                    Log.Info($"Log.Info($\"Round {i}: Success \");");
                }
                else
                {
                    Log.Error($"Round {i}: Fail \n Сurrent Data: {string.Join("; ", TestNodes)} ");
                    return;
                }
                //подготовка к следующему кругу
                //Открытие редактора ноды для следующей проверки
                ThisScreen
                    //выбираем текущую ноду
                    .ChooseNode(Node)
                    .Edit();
            }
        }
    }
}
