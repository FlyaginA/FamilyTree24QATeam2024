using ATframework3demo.PageObjects.TreePage;
using System.Runtime.CompilerServices;

namespace ATframework3demo.TestEntities
{
    public class NodeItem
    {
        public NodeItem(string name, string surname, string dateborn, string datedeath, string sexfield, bool important)
        {
            Name = name;
            Surname = surname;
            BornDate = dateborn;
            DeathDate = datedeath;
            SexField = sexfield;
            ImportantField = important;
        }

        public string Name { get; }
        public string Surname { get; }
        public string BornDate { get; }
        public string DeathDate { get; }
        public string SexField { get; }
        public bool ImportantField { get; }


        /// <summary>
        /// Открывает окно редактирования ноды
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public NodeEditPage Edit()
        {
            return new NodeEditPage();
        }
    }




}
