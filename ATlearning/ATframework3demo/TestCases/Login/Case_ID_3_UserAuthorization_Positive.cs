using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.HomePage;

namespace ATframework3demo.TestCases.Login
{
    public class Case_ID_3_User_authorization : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_3_Авторизация(Positive)", homePage => Authorization(homePage)));
            return caseCollection;
        }

        private static List<User> TestData = new List<User>
        {
            new User(new List<string>() { "Иван", "Иванов", "testEmail1@example.com", "mypassword123" }),
            new User(new List<string>() { "John Doe", "Петров", "uniqueUser2@mail.net", "technology2024" }),
            new User(new List<string>() { "Анна", "Сергеев", "dataCheck3@inbox.org", "ComplexPassword99" }),
            new User(new List<string>() { "JohnИванDoe", "Алексеева", "validationSample4@test.me", "complex_password_sample" }),
            new User(new List<string>() { "Саша.Александров", "Кузнецова", "fieldEntry5@site.io", "SAlex@1234" }),
            new User(new List<string>() { "UserИмя2024", "Александров", "randomUser6@web.com", "UserpAssword24!" }),
            new User(new List<string>() { "Иван_Иванович", "Макеев", "emailTest7@check.edu", "Pass@Word!2424" }),
            new User(new List<string>() { "JohnИван.Doe", "Миронова", "testingField8@sample.org", "Pa$SworD5024!" }),
            new User(new List<string>() { "Иван.Ivan50", "Жуковский", "userInput9@mail.net", "ivanpA$sworD504!" }),
            new User(new List<string>() { "Имя2024.Имя2024", "Константинопольский", "validation10@example.com", "PasswordRsrc24#" })
        };


        /// <summary>
        /// Author:Flyagin
        /// TestCase #3
        /// Авторизация пользователей.
        /// Предварительные условия:
        /// Все аккаунты должны быть уже зарегестрированны
        /// </summary>
        /// <param name="homePage"></param>
        public static void Authorization(ServiceHomePage homePage)
        {
            int iterator = 0;
            foreach (var i in TestData)
            {
                iterator++; 
                if (
                homePage
                    .leftmenu
                    .LogOut()
                    .Login(i)
                    .mainPage
                    .IsMainPage()
                    )
                {
                    Log.Info($"Round {iterator}: Success ");
                }
                else
                {
                    Log.Error($"Round {iterator}: Fail " +
                        $"\nmessage {new WebItem("//font [@class=\"errortext\"]", "Сообщение об ошибке").InnerText()}");
                    return;
                }

            }
        }

    }
}

