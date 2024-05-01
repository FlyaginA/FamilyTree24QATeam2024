using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;

namespace ATframework3demo.TestCases.EditProfilePage
{
    public class Case_15_17_19_EditProfile_Positive : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_15_17_19_Сценарий_Изменений профиля", homePage => ProfileEditScript(homePage)));
            return caseCollection;
        }
        
        User TestUser = new User(new List<string>() {"JohnИванDoe", "Алексеева", "validationSample4@test.me", "complex_password_sample" });
        //Эл. Почта - 6 значения
        List<User> TestUsers = new List<User>()
        {
            new User(new List<string>() {"Ал", "Ли", "a@b.cd", "abcdef"}),
            new User(new List<string>() {"Alex", "Brown", "example@mail.com", "123456"}),
            new User(new List<string>() {"Елизавета", "Тейлор", "name.lastname@test.com", "******"}),
            new User(new List<string>() {"Максимилиан", "Шварценеггер", "1234567890abcdefghijklmnoprstuvzxy@testmail.com", "abcdefg"}),
            new User(new List<string>() {"Алиса", "Мартинес", "long.name.surname.middle.name.surname@longdomainname.com", "1234567"}),
            new User(new List<string>() {"Джейк", "Джонсон", "random.email@domain.co", "*******"}),
            new User(new List<string>() {"JohnИванDoe", "Алексеева", "validationSample4@test.me", "complex_password_sample" })
        };
        /// <summary>
        /// Тест 15 17 19
        /// Flyagin
        /// Этот тест объединяет в себе все положительные тест-кейсы на 
        /// редактирование профиля, тем самым создавая сценарий изменения профиля.
        /// </summary>
        /// <param name="homePage"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ProfileEditScript(ServiceHomePage homePage)
        {
            int i = 0;
            homePage.leftmenu.LogOut().Login(TestUser);
            foreach (var user in TestUsers)
            {
                i++;
                 if
                (
                    homePage
                    .header
                    //открытие страницы редактирования профиля
                    .ProfileEdit()
                    //изменение имени
                    .EnterNewName(user.Name)
                    //изменение фамилии
                    .EnterNewSurname(user.Surname)
                    //изменение электронной почты
                    .EnterNewEmail(user.eMail)
                    //изменение пароля
                    .EnterNewPassword(user.Password)
                    .EnterNewPasswordConfirm(user.Password)
                    //Сохранение изменений
                    .SaveChanges()
                    //Проверка внесения изменений
                    .AssertChangeProfile(user)
                )
                {
                    Log.Info($"Round {i} : Success");
                }
                else { Log.Error($"Round {i}: was Fail"); }
                
            }



        }
    }
}
