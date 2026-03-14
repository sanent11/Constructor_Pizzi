using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static PizzaManager manager = new PizzaManager();

    static void Main()
    {
        bool working = true;
        while (working)
        {
            Console.WriteLine("================ КОНСТРУКТОР ПИЦЦЫ ================\n");
            Console.WriteLine("1 - Пиццы");
            Console.WriteLine("2 - Основы");
            Console.WriteLine("3 - Ингридиенты");
            Console.WriteLine("4 - Выход\n");
            Console.Write("Ваш выбор: ");
            string user = Console.ReadLine();
            if (user == "1") Pizza_razdel();
            else if (user == "2") PizzaBase_razdel();
            else if (user == "3") Ingredients_razdel();
            else working = false;
        }
    }

    static void Pizza_razdel()
    {
        Console.WriteLine("================ ПИЦЦЫ ================\n");
        manager.ShowPizzas();
        Console.WriteLine("\n================");
        Console.WriteLine("1 - Создать пиццу");
        Console.WriteLine("2 - Редактировать пиццу");
        Console.WriteLine("3 - Удалить пиццу");
        Console.WriteLine("4 - Назад в главное меню\n");
        Console.Write("Ваш выбор: ");
        string user = Console.ReadLine();
        if (user == "1") manager.CreatePizza();
        else if (user == "2") manager.EditPizza();
        else if (user == "3") manager.DeletePizza();
    }

    static void PizzaBase_razdel()
    {
        Console.WriteLine("================ ОСНОВЫ ДЛЯ ПИЦЦ ================\n");
        manager.ShowBases();
        Console.WriteLine("\n================");
        Console.WriteLine("1 - Создать основу");
        Console.WriteLine("2 - Редактировать основу");
        Console.WriteLine("3 - Удалить основу");
        Console.WriteLine("4 - Назад в главное меню\n");
        Console.Write("Ваш выбор: ");
        string user = Console.ReadLine();
        if (user == "1") manager.CreateBase();
        else if (user == "2") manager.EditBase();
        else if (user == "3") manager.DeleteBase();
    }

    static void Ingredients_razdel()
    {
        Console.WriteLine("================ ИНГРЕДИЕНТЫ ДЛЯ ПИЦЦ ================\n");
        manager.ShowIngredients();
        Console.WriteLine("\n================");
        Console.WriteLine("1 - Создать ингредиент");
        Console.WriteLine("2 - Редактировать ингредиент");
        Console.WriteLine("3 - Удалить ингредиент");
        Console.WriteLine("4 - Назад в главное меню\n");
        Console.Write("Ваш выбор: ");
        string user = Console.ReadLine();
        if (user == "1") manager.CreateIngredient();
        else if (user == "2") manager.EditIngredient();
        else if (user == "3") manager.DeleteIngredient();
    }
}