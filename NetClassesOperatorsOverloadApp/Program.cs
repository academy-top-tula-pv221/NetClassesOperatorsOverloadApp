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
    
    class Matrix
    {
        int[,] matrix;
        public Matrix(int rows, int cols)
        {
            matrix = new int[rows, cols];
        }
        public int this[int row, int col]
        {
            get => matrix[row, col];
            set => matrix[row, col] = value;
        }
    }

    class User
    {
        string name = "";
        string phone = "";
        int age = 0;

        public string this[string prop]
        {
            get
            {
                switch(prop)
                {
                    case "name": return name;
                    case "phone": return phone;
                    case "age": return age.ToString();
                    default: throw new Exception("Wrong property name");
                }
            }
            set
            {
                switch (prop)
                {
                    case "name": name = value; break;
                    case "phone": phone = value; break;
                    case "age": age = Int32.Parse(value); break;
                    default: throw new Exception("Wrong property name");
                }
            }
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
            set
            {   if(index >= 0 && index < students.Length)
                    students[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
            get
            {
                if (index >= 0 && index < students.Length)
                    return students[index];
                else
                    throw new IndexOutOfRangeException();
            }
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

            User user = new User();
            user["name"] = "Leo";
            user["phone"] = "8 999 123-45-67";
            user["age"] = "23";
        }
    }
}