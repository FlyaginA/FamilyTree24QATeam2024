using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases.EditProfilePage
{
    public class Case_16_18_20_EditProfile_Negative : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("ID_16_18_20_Сценарий_Изменений профиля(Negative)", homePage => ProfileEditScript(homePage)));
            return caseCollection;
        }

        User TestUser = new User(new List<string>() {"JohnИванDoe", "Алексеева", "validationSample4@test.me", "complex_password_sample" });
        //4 значения 
        List<string> TestEmail = new List<string>() { " ", "example.nameexample.com", "@example.com", "example@.com" };
        //Пароль -
        List<string> TestPasword = new List<string>() { "", "a", "1", "*", "ab" , "12", "**", "abcde", "12345", "*****" };
        /// <summary>
        /// Тест 15 17 19
        /// Flyagin
        /// Этот тест объединяет в себе все положительные тест-кейсы на 
        /// редактирование профиля, тем самым создавая сценарий изменения профиля.
        /// </summary>
        /// <param name="homePage"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ProfileEditScript(MobileHomePage homePage)
        {
            throw new NotImplementedException();
        }
    }
}