using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_ID_1_User_authorization : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Авторизация(Positive)", homePage => Authorization(homePage)));
            return caseCollection;
        }
        /// <summary>
        /// TestCase #3
        /// Авторизация пользователей.
        /// Предварительные условия:
        /// Все аккаунты должны быть уже зарегестрированны
        /// </summary>
        /// <param name="homePage"></param>
        public static void Authorization(ServiceHomePage homePage)
            {
           


            }

    }
}

