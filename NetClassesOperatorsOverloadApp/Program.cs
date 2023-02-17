namespace NetClassesOperatorsOverloadApp
{
    class Money
    {
        public int Rub { set; get; }
        public int Cop { set; get; }
    }
    class Fraction
    {
        public int Numerator { set; get; }

        int denominator;
        public int Denominator
        {
            get => denominator;
            set
            {
                if (value != 0)
                    denominator = value;
                else
                    throw new Exception("Denominator is not null");
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction()
            {
                Numerator = a.Numerator * b.Denominator + a.Denominator * b.Numerator,
                Denominator = a.Denominator * b.Denominator
            };
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator < a.Denominator * b.Numerator;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator > a.Denominator * b.Numerator;
        }

        public static Fraction operator ++(Fraction a)
        {
            return new Fraction()
            {
                Numerator = a.Numerator + a.Denominator,
                Denominator = a.Denominator
            };
        }

        public static bool operator true(Fraction a)
        {
            return a.Numerator != 0;
        }

        public static bool operator false(Fraction a)
        {
            return a.Numerator == 0;
        }

        public static explicit operator Money(Fraction a)
        {
            return new Money()
            {
                Rub = a.Numerator / a.Denominator,
                Cop = (a.Numerator % a.Denominator * 100) / a.Denominator
            };
        }
    }
    
    class Student
    {
        public string? Name { set; get; }
        public Student(string? name)
        {
            Name = name;
        }
    }

    class Group
    {
        Student[] students;

        public Group(Student[] students)
        {
            this.students = students;
        }

        public Student this[int index]
        {
            set => students[index] = value;
            get => students[index];
        }
        public int Size => students.Length;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Fraction f = new() { Numerator = 40, Denominator = 16 };
                Money m = new() { Rub = 25, Cop = 50 };

                Money m2 = (Money)f;

                int n = 10;
                float x = n;
                byte b = (byte)n;
            */
            Group group1 = new(
                new[]
                {
                    new Student("Bob"),
                    new Student("Joe"),
                    new Student("Tom")
                }
                );
            for(int i = 0; i < group1.Size; i++)
                Console.WriteLine(group1[i].Name);
        }
    }
}