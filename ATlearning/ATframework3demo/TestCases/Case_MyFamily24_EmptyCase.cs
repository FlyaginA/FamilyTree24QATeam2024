using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_MyFamily24_EmptyCase : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Пустой кейс", homePage => EmptyCase(homePage)));
            return caseCollection;
        }


        public static void EmptyCase(HomePage homePage) 
        {
            
        }
    }
}
