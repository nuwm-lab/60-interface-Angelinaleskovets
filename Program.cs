using System;

class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public int BirthDay { get; set; }
    public int BirthMonth { get; set; }
    public int BirthYear { get; set; }

    // Метод введення даних
    public virtual void InputData()
    {
        Console.Write("Введіть ім'я: ");
        Name = Console.ReadLine();

        Console.Write("Введіть прізвище: ");
        Surname = Console.ReadLine();

        Console.Write("Введіть по-батькові: ");
        Patronymic = Console.ReadLine();

        Console.Write("День народження: ");
        BirthDay = int.Parse(Console.ReadLine());

        Console.Write("Місяць народження: ");
        BirthMonth = int.Parse(Console.ReadLine());

        Console.Write("Рік народження: ");
        BirthYear = int.Parse(Console.ReadLine());
    }

    // Метод визначення віку
    public virtual int GetAge(DateTime currentDate)
    {
        int age = currentDate.Year - BirthYear;
        if (currentDate.Month < BirthMonth ||
            (currentDate.Month == BirthMonth && currentDate.Day < BirthDay))
        {
            age--;
        }
        return age;
    }

    // Метод підрахунку літери в прізвищі
    public int CountLetter(char letter)
    {
        int count = 0;
        foreach (char c in Surname.ToLower())
            if (c == char.ToLower(letter))
                count++;

        return count;
    }
}

class Student : Person
{
    public int AdmissionYear { get; set; }
    public string Specialty { get; set; }

    public override void InputData()
    {
        base.InputData();

        Console.Write("Введіть рік вступу до ВУЗу: ");
        AdmissionYear = int.Parse(Console.ReadLine());

        Console.Write("Введіть спеціальність: ");
        Specialty = Console.ReadLine();
    }

    public override int GetAge(DateTime currentDate)
    {
        return base.GetAge(currentDate);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Введення даних людини ===");
        Person person = new Person();
        person.InputData();

        Console.WriteLine("\n=== Введення даних студента ===");
        Student student = new Student();
        student.InputData();

        Console.WriteLine("\n=== Введення поточної дати ===");
        Console.Write("День: ");
        int d = int.Parse(Console.ReadLine());
        Console.Write("Місяць: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Рік: ");
        int y = int.Parse(Console.ReadLine());

        DateTime currentDate = new DateTime(y, m, d);

        Console.WriteLine($"\nВік студента: {student.GetAge(currentDate)} років");

        Console.Write("\nВведіть літеру для підрахунку в прізвищі людини: ");
        char letter = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.WriteLine($"Кількість зустрічань літери '{letter}' у прізвищі: {person.CountLetter(letter)}");
    }
}
