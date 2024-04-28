



namespace ATframework3demo.PageObjects.TreePage
{
    public class NodeEditPage
    {
        /// <summary>
        /// Ввод в поле имени
        /// </summary>
        /// <returns></returns>
        public NodeEditPage EnterName(string name)
        {

            return this;
        }

        /// <summary>
        /// Ввод в поле фамилии
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public NodeEditPage EnterSurname(string surname)
        {
            return this;
        }
        /// <summary>
        /// Ввод в поле даты рождения
        /// </summary>
        /// <param name="bornDate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public NodeEditPage EnterBornDate(string bornDate)
        {
            return this;
        }
        /// <summary>
        /// Ввод в поле даты смерти
        /// </summary>
        /// <param name="deathDate"></param>
        /// <returns></returns>
        public NodeEditPage EnterDeathDate(string deathDate)
        {
            return this;
        }

        /// <summary>
        /// Установка в поле "пол"
        /// </summary>
        /// <param name="sexField"></param>
        /// <returns></returns>
        public NodeEditPage EnterSexField(string sexField)
        {
            return this;
        }

        /// <summary>
        /// Установка флага в поле important
        /// </summary>
        /// <param name="importantField"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public NodeEditPage EnterImportantFlag(bool importantField)
        {
            return this;
        }

        public TreeEditPage Save()
        {
            return new TreeEditPage();
        }
    }
}