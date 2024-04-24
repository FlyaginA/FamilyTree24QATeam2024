using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_ID_1_User_Registration_Positive : CaseCollectionBuilder
    {
        
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_1_Регистрация(Positive)", homePage => Registration(homePage)));
            return caseCollection;
        }

        private static List<List<string>> TestData = new List<List<string>>()
        {
            new List<string>() { "1", "Иван", "Иванов", "User123", "mypassword123" },
            new List<string>() { "2", "John Doe", "Петров", "tech_demo", "technology2024" },
            new List<string>() { "3", "Анна", "Сергеев", "TestUser", "ComplexPassword99" },
            new List<string>() { "4", "JohnИванDoe", "Алексеева", "sample_login", "complex_password_sample" },
            new List<string>() { "5", "Саша.Александров", "Кузнецова", "Sasha_A2024", "SAlex@1234" },
            new List<string>() { "6", "UserИмя2024", "Александров", "User2024", "UserpAssword24!" },
            new List<string>() { "7", "Иван_Иванович", "Макеев", "Ivan_Iv2024", "Pass@Word!2424" },
            new List<string>() { "8", "JohnИван.Doe", "Миронова", "Jo_Iv_Doe50", "Pa$SworD5024!" },
            new List<string>() { "9", "Иван.Ivan50", "Жуковский", "Ivan_iv202402", "ivanpA$sworD504!" },
            new List<string>() { "10", "Имя2024.Имя2024", "Константинопольский", "Name_Resources2024", "PasswordRsrc24#" }
        };
        /// <summary>
        /// TestCase#1
        /// Регистрация пользователей
        /// </summary>
        /// <param name="homePage"></param>


        public static void Registration(ServiceHomePage homePage) 
        {
            foreach (var i in Case_ID_1_User_Registration_Positive.TestData)
            {
                if (
                    homePage
                        .mainPage
                        //выход из профиля
                        .LogOut()
                        //переход в форму регистрации
                        .OpenRegistrationForm()
                        //Ввод Имени
                        .EnterName(i[1])
                        //Ввод Фамилии
                        .EnterSurname(i[2])
                        //Ввод Логина
                        .EnterLogin(i[3])
                        //Ввод Пароля
                        .EnterPassword(i[4])
                        //Нажатие на кнопку регистрации
                        .RegistrationButton()
                        //проверка что регистрация прошла успешно и мы находимся
                        //на главной странице с деревьями
                        .IsMainPage()
                    )
                {
                    Log.Info($"Round {i[0]}: Success ");
                }
                else
                {
                    Log.Error($"Round {i[0]}: Fail ");
                    return;
                }

            }
                    







        }

    }
}
