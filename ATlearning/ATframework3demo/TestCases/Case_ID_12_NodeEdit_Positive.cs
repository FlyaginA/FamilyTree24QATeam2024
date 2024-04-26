
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_ID_12_NodeEdit_Positive : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_12_Редактирование нод(Positive)", homePage => NodeEditPositive(homePage)));
            return caseCollection;
        }
        /// <summary>
        /// Flyagin
        /// Case ID 12
        /// </summary>
        /// <param name="homePage"></param>
        public void NodeEditPositive(ServiceHomePage homePage)
        {


        }
    }
}
