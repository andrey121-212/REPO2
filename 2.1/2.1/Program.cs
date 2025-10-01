using System;
class Person
{
    private string name;
    private int age;
    private string address;

    // Методы для установки значений
    public void SetName(string name)
    {
        this.name = name;
    }
    public void SetAge(int age)
    {
        this.age = age;
    }
    public void SetAddress(string address)
    {
        this.address = address;
    }

    // Методы для получения значений
    public string GetName()
    {
        return name;
    }
    public int GetAge()
    {
        return age;
    }

    public string GetAddress()
    {
        return address;
    }

    // Метод для вывода информации
    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Адрес: {address}");
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person();
        person1.SetName("Стен");
        person1.SetAge(52);
        person1.SetAddress("Нальчик");

        person1.DisplayInfo();
    }
}
