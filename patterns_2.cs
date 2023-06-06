using System;
using System.Collections.Generic;

// Абстрактная фабрика для создания одежды
interface IClothingFactory
{
    IShirt CreateShirt();
    IPants CreatePants();
}

// Фабрика для создания одежды мужского стиля
class MenClothingFactory : IClothingFactory
{
    public IShirt CreateShirt()
    {
        return new MenShirt();
    }

    public IPants CreatePants()
    {
        return new MenPants();
    }
}

// Фабрика для создания одежды женского стиля
class WomenClothingFactory : IClothingFactory
{
    public IShirt CreateShirt()
    {
        return new WomenShirt();
    }

    public IPants CreatePants()
    {
        return new WomenPants();
    }
}

// Интерфейс для создания рубашек
interface IShirt
{
    void Display();
}

// Интерфейс для создания брюк
interface IPants
{
    void Display();
}

// Реализация мужской рубашки
class MenShirt : IShirt
{
    public void Display()
    {
        Console.WriteLine("Мужская рубашка");
    }
}

// Реализация женской рубашки
class WomenShirt : IShirt
{
    public void Display()
    {
        Console.WriteLine("Женская рубашка");
    }
}

// Реализация мужских брюк
class MenPants : IPants
{
    public void Display()
    {
        Console.WriteLine("Мужские брюки");
    }
}

// Реализация женских брюк
class WomenPants : IPants
{
    public void Display()
    {
        Console.WriteLine("Женские брюки");
    }
}

// Хранитель, сохраняющий состояние объекта
class ClothingMemento
{
    public List<string> ClothingItems { get; }

    public ClothingMemento(List<string> clothingItems)
    {
        ClothingItems = clothingItems;
    }
}

// Опекун, управляющий сохранением и восстановлением состояния объекта
class ClothingCaretaker
{
    private ClothingMemento _memento;

    public ClothingMemento GetMemento()
    {
        return _memento;
    }

    public void SetMemento(ClothingMemento memento)
    {
        _memento = memento;
    }
}

// Клиентский код
class Program
{
    static void Main(string[] args)
    {
        // Создание фабрики одежды
        IClothingFactory factory = new MenClothingFactory();

        // Создание списка одежды
        var clothingItems = new List<string>();

        // Создание рубашки и брюк
        IShirt shirt = factory.CreateShirt();
        IPants pants = factory.CreatePants();

        // Отображение и сохранение состояния одежды
        clothingItems.Add(shirt.GetType().Name);
        clothingItems.Add(pants.GetType().Name);
        DisplayClothing(clothingItems);

        // Сохранение состояния одежды
        ClothingMemento memento = new ClothingMemento(clothingItems);
        ClothingCaretaker caretaker = new ClothingCaretaker();
        caretaker.SetMemento(memento);

        // Изменение фабрики одежды на женскую
        factory = new WomenClothingFactory();

        // Создание новой рубашки и брюк
        shirt = factory.CreateShirt();
        pants = factory.CreatePants();

        // Отображение и восстановление состояния одежды
        clothingItems = caretaker.GetMemento().ClothingItems;
        clothingItems.Add(shirt.GetType().Name);
        clothingItems.Add(pants.GetType().Name);
        DisplayClothing(clothingItems);

        Console.ReadLine();
    }

    static void DisplayClothing(List<string> clothingItems)
    {
        Console.WriteLine("Текущая одежда:");
        foreach (var item in clothingItems)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}
