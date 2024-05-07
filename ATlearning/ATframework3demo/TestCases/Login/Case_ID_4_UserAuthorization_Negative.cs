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

        private static List<User> TestUsers = new List<User>()
        {
            new User(new List<string>() { "", "", "Te", "TechPassword" }),
            new User(new List<string>() { new string("O"), "",
                "ReallyComplexLoginNameThatExceedsTheLimitRe" + "allyComplexLoginNameThatExceedsTheLimitReallyComplexLoginNameThatExceedsTheLimit",
                "ComplexPassword" }),
            new User(new List<string>() { "", "", "sample_login", "pass" }),
            new User(new List<string>() { "", "", "S", new string("E") }),
            new User(new List<string>() { "", "", "User2024",
                "VeryLongPasswordThatExceedsTheMaximumAllowedLimitVeryLongPasswordThatExceedsTheMaximumAllowedLimit" }),};
        /// <summary>
        /// Author:Flyagin
        /// TestCase #4
        /// Авторизация пользователей(Negative)
        /// </summary>
        /// <param name="homePage"></param>
        public static void Authorization(ServiceHomePage homePage)
        {
            int iterator = 0;
            var ThisScreen = homePage
                    .leftmenu
                    .LogOut();

            foreach (var User in TestUsers)
            {
                iterator++;

                if (ThisScreen
                    .Login(User)
                    .mainPage
                    .IsMainPage()
                    )
                {
                    Log.Error($"Round {iterator}: Fail " +
                        $"\nmessage {new WebItem("//font [@class=\"errortext\"]", "Сообщение об ошибке").InnerText()}");
                    return;

                }
                else
                {
                    Log.Info($"Round {iterator}: Success ");
                }

            }
        }
    }
}
