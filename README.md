# FamilyTree24QATeam2024

This framework is for testing the Bitrix24 project of the 4th group as part of the 2024 training program. This framework is based on an instance provided as part of the training.
Test cases and checklist https://docs.google.com/spreadsheets/d/1eQEqKODR0mucfYRi990q2O5nL-cJNp5LBRvlTsY7S3Y/edit#gid=0

When creating an autotest, you first need to create an autotest file. Specify the first and last name of the author, the id and the name of the test.

Push changes only after the autotest is fully completed.

Each created entity must be accompanied by a description in the format described below:

Method
    /// <summary>
    /// Вход на ресурс
    /// </summary>
    /// <param name="admin"></param>
    /// <returns></returns>

Page
    /// <summary>
    /// Главная страница ресурса, меню деревьев
    /// </summary>

Test Entity
    /// <summary>
    /// Объект пользователя.
    /// используется при входе на ресурс.
    /// </summary>

TestCase
    /// <summary>
    /// ArtyomFlyagin
    /// TestCase#1
    /// Регистрация пользователей (позитивный кейс)
    /// Предварительные условия:
    /// Проверить отсутствие в базе данных строк, совпадающих с набором данных			
    /// </summary>
    /// <param name="homePage"></param>
