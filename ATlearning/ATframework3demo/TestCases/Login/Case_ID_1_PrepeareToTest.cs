using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_ID_1_PrepeareToTest : CaseCollectionBuilder
    {
        
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_1_Регистрация(Positive)", homePage => Registration(homePage)));
            return caseCollection;
        }

        private static List<User> TestData = new List<User>
        {
            new User(new List<string>() { "1", "Иван", "Иванов", "User123", "mypassword123" }),
            new User(new List<string>() { "2", "John Doe", "Петров", "tech_demo", "technology2024" }),
            new User(new List<string>() { "3", "Анна", "Сергеев", "TestUser", "ComplexPassword99" }),
            new User(new List<string>() { "4", "JohnИванDoe", "Алексеева", "sample_login", "complex_password_sample" }),
            new User(new List<string>() { "5", "Саша.Александров", "Кузнецова", "Sasha_A2024", "SAlex@1234" }),
            new User(new List<string>() { "6", "UserИмя2024", "Александров", "User2024", "UserpAssword24!" }),
            new User(new List<string>() { "7", "Иван_Иванович", "Макеев", "Ivan_Iv2024", "Pass@Word!2424" }),
            new User(new List<string>() { "8", "JohnИван.Doe", "Миронова", "Jo_Iv_Doe50", "Pa$SworD5024!" }),
            new User(new List<string>() { "9", "Иван.Ivan50", "Жуковский", "Ivan_iv202402", "ivanpA$sworD504!" }),
            new User(new List<string>() { "10", "Имя2024.Имя2024", "Константинопольский", "Name_Resources2024", "PasswordRsrc24#" })
        };
        /// <summary>
        /// Author:Flyagin
        /// TestCase#1
        /// Регистрация пользователей (позитивный кейс)
        /// Предварительные условия:
        /// Проверить отсутствие в базе данных строк, совпадающих с набором данных			
        /// </summary>
        /// <param name="homePage"></param>


        public static void Registration(ServiceHomePage homePage) 
        {
            foreach (var i in TestData)
            {
                if (
                    homePage
                        .mainPage
                        //выход из профиля
                        .LogOut()
                        //переход в форму регистрации
                        .OpenRegistrationForm()
                        //Ввод Имени
                        .EnterName(i.Name)
                        //Ввод Фамилии
                        .EnterSurname(i.Surname)
                        //Ввод Логина
                        .EnterLogin(i.Login)
                        //Ввод Пароля
                        .EnterPassword(i.Password)
                        //Нажатие на кнопку регистрации
                        .RegistrationButton()
                        //проверка что регистрация прошла успешно и мы находимся
                        //на главной странице с деревьями
                        .IsMainPage()
                    )
                {
                    Log.Info($"Round {i.Id}: Success ");
                }
                else
                {
                    Log.Error($"Round {i.Id}: Fail " +
                        $"\nmessage {new WebItem("//font [@class=\"errortext\"]", "Сообщение об ошибке").InnerText()}");
                    return;
                }

            }
        }

    }
}
