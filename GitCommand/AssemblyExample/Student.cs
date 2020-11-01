namespace AssemblyExample
{
    public class Student
    {
        private string _name;
        private double _grade;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public void M1()
        {
            //Code
        }

        public void M2()
        {
            //Code
        }

        public string M3()
        {
            return string.Empty;
        }

        public Student(string name, double grade)

        {
            this.Name = name;
            this.Grade = grade;
        }
    }
}