using Spectre.Console;
using OOP.LibraryManagementSystem;

UserInterface userInterface = new UserInterface();
userInterface.MainMenu();

/*
Puppy pup1 = new Puppy("Cujo", 1);
Animal dog1 = new Dog("Bubba", 6);

pup1.MakeSound();
dog1.MakeSound();
internal abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void MakeSound();
}

internal class Dog : Animal
{
    public Dog(string name, int age)
    : base(name, age)
    { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

internal class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Purr...purr...");

    }
}

internal class Puppy : Dog
{
    public Puppy(string name, int age) : base(name, age) { }
    public override void MakeSound()
    {
        Console.WriteLine($"The puppy's name is {Name}... and he whimpered!");
    }
}

*/