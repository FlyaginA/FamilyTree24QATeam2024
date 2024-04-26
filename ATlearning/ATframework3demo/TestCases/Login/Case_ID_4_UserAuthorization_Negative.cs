using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases.Login
{
    public class Case_ID_4_UserAuthorization_Negative : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_4_Авторизация(Negative)", homePage => Authorization(homePage)));
            return caseCollection;
        }

        private static List<User> TestData = new List<User>()
        {
            new User(new List<string>() { "1", "", "", "Te", "TechPassword" }),
            new User(new List<string>() { "2", "ОООООООООООООООООООООООООООООООООООООООООООООООООО", "", "ReallyComplexLoginNameThatExceedsTheLimitRe" +
                "allyComplexLoginNameThatExceedsTheLimitReallyComplexLoginNameThatExceedsTheLimit", "ComplexPassword" }),
            new User(new List<string>() { "3", "", "", "sample_login", "pass" }),
            new User(new List<string>() { "4", "", "", "S", "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" }),
            new User(new List<string>() { "5", "", "", "User2024", "VeryLongPasswordThatExceedsTheMaximumAllowedLimitVeryLongPasswordThatExceedsTheMaximumAllowedLimit" }),
        };
        /// <summary>
        /// Author:Flyagin
        /// TestCase #4
        /// Авторизация пользователей(Negative)
        /// </summary>
        /// <param name="homePage"></param>
        public static void Authorization(ServiceHomePage homePage)
        {
            var ThisScreen = homePage
                    .mainPage
                    .LogOut();

            foreach (var i in TestData)
            {

                if (ThisScreen
                    .TestLogIn(i)
                    .mainPage
                    .IsMainPage()
                    )
                {
                    Log.Error($"Round {i.Id}: Fail " +
                        $"\nmessage {new WebItem("//font [@class=\"errortext\"]", "Сообщение об ошибке").InnerText()}");
                    return;

                }
                else
                {
                    Log.Info($"Round {i.Id}: Success ");
                }

            }
        }
    }
}
