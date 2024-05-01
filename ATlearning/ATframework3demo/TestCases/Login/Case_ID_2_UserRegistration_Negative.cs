using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.HomePage;

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
            new User(new List<string>() {  "", "", "NoAtSign.com", "12345" }),
            new User(new List<string>() {  "ОООООООООООООООООООООООООООООООООООООООООООООООООО", "вв", "@NoLeadingName.com", "123456" }),
            new User(new List<string>() { "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "testemail@.", "D", "E" }),
            new User(new List<string>() { "ТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТТ", "", "double@@double.com", "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" }),
            new User(new List<string>() { "", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "space in@address.com", "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" }),
            new User(new List<string>() { "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "", "missingdomain@.com", "EEEEEE" })
        };
        /// <summary>
        /// Author:Flyagin
        /// TestCase#2
        /// Регистрация пользователей (негативный кейс)
        /// Предварительные условия:
        /// Тест ID1 должен быть пройден			
        /// </summary>
        /// <param name="homePage"></param>
        public static void Registration(ServiceHomePage homePage)
        {
            int iterator = 0;
            var ThisScreen = homePage
                                .leftmenu
                                //выход из профиля
                                .LogOut()
                                //переход в форму регистрации
                                .OpenRegistrationForm();
            foreach (var i in TestData)
            {
                iterator ++;
                if (!ThisScreen
                        //Ввод Имени
                        .EnterName(i.Name)
                        //Ввод Фамилии
                        .EnterSurname(i.Surname)
                        //Ввод Логина
                        .EnterLogin(i.eMail)
                        //Ввод Пароля
                        .EnterPassword(i.Password)
                        //Нажатие на кнопку регистрации
                        .RegistrationButton()
                        //проверка что регистрация прошла успешно и мы находимся
                        //на главной странице с деревьями
                        .IsMainPage()
                    )
                {
                    Log.Info($"Round {iterator}: Success " +
                        $"\nmessage {new WebItem("//font [@class=\"errortext\"]", "Сообщение об ошибке").InnerText()}");
                }
                else
                {
                    
                    Log.Error($"Round {iterator}: Fail \n Сurrent Data: {string.Join("; ", i)} ");
                    return;
                }

            }
        }

    }
}
