//1
using System;

class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
    public Car()
    {
    }
    public Car(int id)
    {
        Id = id;
    }
    public Car(int id, string brand)
    {
        Id = id;
        Brand = brand;
    }
    public Car(int id, string brand, double price)
    {
        Id = id;
        Brand = brand;
        Price = price;
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car();
        Car car2 = new Car(1);
        Car car3 = new Car(2, "BMW");
        Car car4 = new Car(3, "Mercedes", 1500000);

        Console.WriteLine(car1.Id);
        Console.WriteLine(car2.Id);
        Console.WriteLine(car3.Brand);
        Console.WriteLine(car4.Price);
    }
}




//2
class Calculator
{

    public int Sum(int x, int y)
    {
        return x + y;
    }

    public int Sum(int x, int y, int z)
    {
        return x + y + z;
    }

    public double Sum(double x, double y)
    {
        return x + y;
    }
}

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();

        Console.WriteLine(calculator.Sum(10, 20));

        Console.WriteLine(calculator.Sum(10, 20, 30));

        Console.WriteLine(calculator.Sum(10.5, 20.5));
    }
}
//Method overloading improves readability by using the same meaningful method name for similar operations, while allowing different parameter types or numbers.
//It also improves reusability because we can use the same method name for different inputs without writing separate method names.


//3

class Parent
{
    public int X { get; set; }
    public int Y { get; set; }

    public Parent(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Child : Parent
{
    public int Z { get; set; }

    public Child(int x, int y, int z) : base(x, y)
    {
        Z = z;
    }
}

class Program
{
    static void Main()
    {
        Child child = new Child(10, 20, 30);

        Console.WriteLine(child.X);
        Console.WriteLine(child.Y);
        Console.WriteLine(child.Z);
    }
}

//Constructor chaining ensures that the base class is properly initialized before the derived class.


//4 باستخدام ال new

class Parent
{
    public int X;
    public int Y;

    public Parent(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Product()
    {
        return X * Y;
    }
}

class Child : Parent
{
    public Child(int x, int y) : base(x, y)
    {
    }

    public new int Product()
    {
        return X * Y + 10;
    }
}


//باستخدام ال override
class Parent
{
    public int X;
    public int Y;

    public Parent(int x, int y)
    {
        X = x;
        Y = y;
    }

    public virtual int Product()
    {
        return X * Y;
    }
}

class Child : Parent
{
    public Child(int x, int y) : base(x, y)
    {
    }

    public override int Product()
    {
        return X * Y + 10;
    }
}



//new hides the base class method, so the method that is called depends on the reference type.
//override overrides a virtual method, so the method that is called depends on the actual object type at runtime.

//5

class Parent
{
    public int X;
    public int Y;

    public Parent(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Child : Parent
{
    public int Z;

    public Child(int x, int y, int z) : base(x, y)
    {
        Z = z;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}
Parent p = new Parent(10, 20);

Child c = new Child(10, 20, 30);

Console.WriteLine(p);
Console.WriteLine(c);

//ToString() is often overridden to provide a meaningful and readable string representation of an object, making it easier to display and debug its data.


//6

interface IShape
{
    double Area { get; }
    void Draw();
}

class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area
    {
        get
        {
            return Width * Height;
        }
    }

    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle");
    }
}

Rectangle rectangle = new Rectangle(5, 4);

Console.WriteLine("Area = " + rectangle.Area);

rectangle.Draw();

//You cannot create an instance of an interface directly because an interface only defines a contract and does not provide a complete implementation.
//A class must implement the interface before an object can be created.


//7
interface IShape
{
    double Area { get; }

    void Draw();

    void PrintDetails()
    {
        Console.WriteLine("This is a shape.");
    }
}
class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area
    {
        get
        {
            return Math.PI * Radius * Radius;
        }
    }

    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}
Circle circle = new Circle(5);

Console.WriteLine("Area = " + circle.Area);

circle.Draw();

IShape shape = circle;

shape.PrintDetails();

//Default implementations in interfaces allow developers to add new methods with a default implementation without forcing existing classes to implement those methods immediately.
//This improves backward compatibility, code reuse, and makes interfaces easier to evolve



//8

interface IMovable
{
    void Move();
}

class Car : IMovable
{
    public void Move()
    {
        Console.WriteLine("The car is moving.");
    }
}


IMovable movable = new Car();

movable.Move();


//Using an interface reference provides flexibility and supports polymorphism.
//It allows us to work with different classes that implement the same interface without depending on a specific class.
//This makes the code more reusable and easier to maintain.


//9

interface IReadable
{
    void Read();
}
interface IWritable
{
    void Write();
}

class File : IReadable, IWritable
{
    public void Read()
    {
        Console.WriteLine("Reading from file...");
    }

    public void Write()
    {
        Console.WriteLine("Writing to file...");
    }
}

File file = new File();

file.Read();
file.Write();


//C# supports multiple interface implementation, allowing a class to implement multiple interfaces even though it can inherit from only one class.
//This provides a way to combine multiple behaviors or contracts in a single class without the problems of multiple class inheritance.

