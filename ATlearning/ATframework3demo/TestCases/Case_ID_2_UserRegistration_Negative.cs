using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_ID_2_UserRegistration_Negative : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_2_Регистрация(Negative)", homePage => Registration(homePage)));
            return caseCollection;
        }
        private static List<User> TestData = new List<User>()
        {
            new User(new List<string>() { "1", "", "", "AA", "12345" }),
            new User(new List<string>() { "2", "ОООООООООООООООООООООООООООООООООООООООООООООООООО", "", "BB", "123456" }),
            new User(new List<string>() { "3", "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "ВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВ", "D", "E" }),
            new User(new List<string>() { "4", "ТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТ", "", "S", "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" }),
            new User(new List<string>() { "5", "", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "SS", "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" }),
            new User(new List<string>() { "6", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "", "", "EEEEEE" })
        };
        /// <summary>
        /// TestCase#2
        /// Регистрация пользователей (негативный кейс)
        /// Предварительные условия:
        /// Тест ID1 должен быть пройден			
        /// </summary>
        /// <param name="homePage"></param>
        public static void Registration(ServiceHomePage homePage)
        {
            var ThisScreen = homePage
                                .mainPage
                                //выход из профиля
                                .LogOut()
                                //переход в форму регистрации
                                .OpenRegistrationForm();
            foreach (var i in TestData)
            {
                if (!ThisScreen
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
                    Log.Info($"Round {i.Id}: Success " +
                        $"\nmessage {new WebItem("//font [@class=\"errortext\"]", "Сообщение об ошибке").InnerText()}");
                }
                else
                {
                    
                    Log.Error($"Round {i.Id}: Fail \n Сurrent Data: {string.Join("; ", i)} ");
                    return;
                }

            }
        }

    }
}
