namespace BakeryApp
{
    public class Person
    {
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }

        public Person(string name, string surName)
        {
            this.Name = name;
            this.SurName = surName;
        }
    }
}
