
// Amir Moeini Rad
// September 2025

// Main Concept: Inheritance
// 'Inheritance' means that a class (derived class or subclass) can inherit
// the fields and methods of another class (base class or superclass).


using System;


namespace Inheritance
{
    internal class Student
    {
        // Private fields
        private int registrationNumber;
        private string name;
        private DateTime dateOfBirth;


        // Default constructor
        public Student()
        {
            Console.WriteLine("A Student created. Parameterless constructor called...");
        }


        // Custom constructor
        public Student(int registrationNumber, string name, DateTime dateOfBirth)
        {
            this.registrationNumber = registrationNumber;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            Console.WriteLine("A new Student Created. Parameterized constructor called...");
        }


        // Public properties
        // A read-only property
        public int RegisterationNumber
        {
            get { return registrationNumber; }
        }


        // A read-write property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        // Another read-write property
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }


        // A public method that calculates age.
        public int GetAge()
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            return age;
        }


        // A protected method
        // A 'Protected Method' is accessible within its class and by derived class instances.
        protected void DoWork()
        {
            Console.WriteLine("DoWork() called...");
        }


        // A virtual method
        // A 'Virtual Method' is a method that can be overridden in a derived class.
        public virtual void TestMethod()
        {
            Console.WriteLine("TestMethod() in base class...");
        }


        // Another virtual method
        public virtual void Graduate()
        {
            Console.WriteLine("Student is going to graduate...");
        }
    }


    ////////////////////////////////////////////////////////////////////////


    internal class SchoolStudent : Student
    {
        // Private Fields
        private int totalMarks;
        private int totalObtainedMarks;
        private double percentage;


        // Default Constructor
        public SchoolStudent()
        {
            Console.WriteLine("A new SchoolStudent created. Parameterless constructor called...");
            DoWork();
        }


        // Custom Constructor
        public SchoolStudent(int regNum, string name, DateTime dob, int totalMarks, int totalObtainedMarks)
            : base(regNum, name, dob)
        {
            this.totalMarks = totalMarks;
            this.totalObtainedMarks = totalObtainedMarks;
            Console.WriteLine("A new SchoolStudent created. Parameterized constructor called...");
        }


        // Public Properties
        public int TotalMarks
        {
            get { return totalMarks; }
            set { totalMarks = value; }
        }


        public int TotalObtainedMarks
        {
            get { return totalObtainedMarks; }
            set { totalObtainedMarks = value; }
        }


        // A Public Method that calculates percentage.
        public double GetPercentage()
        {
            percentage = (double)totalObtainedMarks / totalMarks * 100;
            return percentage;
        }


        // A override method
        // This method overrides the base class method.
        public override void TestMethod()
        {
            Console.WriteLine("TestMethod() in subclass: SchoolStudent...");
        }


        // A non-override method
        // This method hides the base class method.
        public new void Graduate()
        {
            Console.WriteLine("SchoolStudent is going to graduate...");
        }
    }


    ////////////////////////////////////////////////////////////////////////


    // A sealed class
    // Sealed classes cannot be inherited.
    internal sealed class SealedStudent : Student
    {
        // override method
        public override void TestMethod()
        {
            //base.TestMethod ();
            Console.WriteLine("TestMethod() in subclass: SealedStudent...");
        }

    }


    ////////////////////////////////////////////////////////////////////////


    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Inheritance in C#.NET.");
            Console.WriteLine("----------------------\n");


            Student st = new Student(1, "Amir", new DateTime(1980, 08, 10));
            Console.WriteLine("Age of student, {0}, is {1}.\n", st.Name, st.GetAge());

            SchoolStudent schStd = new SchoolStudent();
            schStd.Name = "Newton";
            schStd.DateOfBirth = new DateTime(1981, 4, 1);
            schStd.TotalMarks = 500;
            schStd.TotalObtainedMarks = 476;
            Console.WriteLine("Age of school student, {0}, is {1}. {0} got {2}% of the marks.\n",
                schStd.Name, schStd.GetAge(), schStd.GetPercentage());

            Student stdObj1 = new SchoolStudent();   // dynamic binding or late binding or runtime binding
            stdObj1.TestMethod();                    // override or polymorphic method. 'TestMethod()' is called from 'SchoolStudent' class.
            stdObj1.Graduate();                      // non-override or non-polymorphic method. 'Graduate()' is called from 'Student' class.
            Console.WriteLine();

            Student stdObj2 = new Student();         // static binding
            stdObj2.TestMethod();                    // override or polymorphic method. 'TestMethod()' is called from 'Student' class.
            stdObj2.Graduate();                      // non-override or non-polymorphic method. 'Graduate()' is called from 'Student' class.
            Console.WriteLine();

            SchoolStudent stdObj3 = new SchoolStudent();  // static binding
            stdObj3.TestMethod();                         // override or polymorphic method. 'TestMethod()' is called from 'SchoolStudent' class.
            stdObj3.Graduate();                     // non-override or non-polymorphic method. 'Graduate()' is called from 'SchoolStudent' class.
            Console.WriteLine();

            Console.WriteLine("stdObj3.GetType(): {0}", stdObj3.GetType());
            Console.WriteLine("stdObj3.ToString(): {0}\n", stdObj3.ToString());            

            Student[] stdArray = { new SchoolStudent(), new SealedStudent() };            
            for (int i = 0; i <= 1; i++)
            {                
                stdArray[i].TestMethod();
            }


            Console.WriteLine("\nDone.");
        }
    }
}
