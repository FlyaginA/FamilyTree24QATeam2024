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
            caseCollection.Add(new TestCase("Регистрация(Negative)", homePage => Registration(homePage)));
            return caseCollection;
        }
        private static List<User> TestUsers = new List<User>()
        {
            new User(new List<string>() {  "", "", "NoAtSign.com", "12345" }),
            new User(new List<string>() {  new string('O',50), "вв", "@NoLeadingName.com", "123456" }),
            new User(new List<string>() { new string('G', 51), "testemail@.", "D", "E" }),
            new User(new List<string>() { new string('G', 51), "", "double@@double.com", new string('G', 51)}),
            new User(new List<string>() { "", new string('G', 51), "space in@address.com", new string('G', 51) }),
            new User(new List<string>() { new string('G', 50), "", "missingdomain@.com", "EEEEEE" })
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
            foreach (var User in TestUsers)
            {
                iterator ++;
                if (!ThisScreen
                        //Ввод Имени
                        .EnterName(User.Name)
                        //Ввод Фамилии
                        .EnterSurname(User.Surname)
                        //Ввод Логина
                        .EnterLogin(User.eMail)
                        //Ввод Пароля
                        .EnterPassword(User.Password)
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
                    
                    Log.Error($"Round {iterator}: Fail \n Сurrent Data: {string.Join("; ", User)} ");
                    return;
                }

            }
        }

    }
}
