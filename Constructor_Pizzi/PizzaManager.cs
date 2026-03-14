using System;
using System.Collections.Generic;

class PizzaManager
{
    public List<Pizza> Pizzas = new List<Pizza>();
    public List<PizzaBases> PizzaBases = new List<PizzaBases>();
    public List<PizzaIngredient> PizzaIngredients = new List<PizzaIngredient>();


    public bool CheckBase(string base_name)
    {
        foreach (PizzaBases bases in PizzaBases)
            if (bases.Name == base_name) return false;
        return true;
    }

    public bool CheckIngredient(string ingredient_name)
    {
        foreach (PizzaIngredient ingredient in PizzaIngredients)
            if (ingredient.Name == ingredient_name) return false;
        return true;
    }

    public PizzaBases GetClassicalBase()
    {
        foreach (PizzaBases bases in PizzaBases)
        {
            string name = bases.Name.ToLower();
            if (name == "классическая" || name == "классическое")
                return bases;
        }
        return null;
    }

   

    public void ShowBases()
    {
        if (PizzaBases.Count == 0)
            Console.WriteLine("(пусто)");
        else
            foreach (PizzaBases base_pizza in PizzaBases)
                Console.WriteLine(base_pizza.GetInfo());
    }

    public void CreateBase()
    {
        Console.WriteLine("================ СОЗДАНИЕ ОСНОВЫ ================\n");
        Console.Write("Введите название основы: ");
        string base_name = Console.ReadLine();
        bool isClassical = base_name.ToLower() == "классическая" || base_name.ToLower() == "классическое";

        if (GetClassicalBase() == null && !isClassical)
        {
            Console.WriteLine("Сначала создайте классическую основу!");
            return;
        }

        if (!CheckBase(base_name))
        {
            Console.WriteLine("Такая основа уже существует!");
            return;
        }

        Console.Write("Введите цену основы: ");
        decimal base_price;
        while (!decimal.TryParse(Console.ReadLine(), out base_price) || base_price < 0)
            Console.Write("Некорректная цена! Введите снова: ");

        if (!isClassical)
        {
            decimal max_price = GetClassicalBase().Price * 1.20m;
            if (base_price > max_price)
            {
                Console.WriteLine($"Цена не может превышать 20% от классической! Максимум: {max_price} р.");
                return;
            }
        }

        PizzaBases.Add(new PizzaBases(base_name, base_price));
        Console.WriteLine("Основа успешно создана!");
    }

    public void EditBase()
    {
        Console.WriteLine("================ РЕДАКТИРОВАНИЕ ОСНОВЫ ================\n");
        Console.Write("Введите название основы: ");
        string base_name = Console.ReadLine();
        Console.Write("Введите новое название: ");
        string new_base_name = Console.ReadLine();

        if (!CheckBase(new_base_name))
        {
            Console.WriteLine("Такая основа уже существует!");
            return;
        }

        Console.Write("Введите новую цену: ");
        decimal new_base_price;
        while (!decimal.TryParse(Console.ReadLine(), out new_base_price) || new_base_price < 0)
            Console.Write("Некорректная цена! Введите снова: ");

        for (int i = 0; i < PizzaBases.Count; i++)
        {
            if (PizzaBases[i].Name == base_name)
            {
                PizzaBases[i] = new PizzaBases(new_base_name, new_base_price);
                Console.WriteLine("Основа успешно отредактирована!");
                return;
            }
        }
        Console.WriteLine("Основа не найдена!");
    }

    public void DeleteBase()
    {
        Console.WriteLine("================ УДАЛЕНИЕ ОСНОВЫ ================\n");
        Console.Write("Введите название основы: ");
        string base_name = Console.ReadLine();

        for (int i = 0; i < PizzaBases.Count; i++)
        {
            if (PizzaBases[i].Name == base_name)
            {
                PizzaBases.RemoveAt(i);
                Console.WriteLine("Основа успешно удалена!");
                return;
            }
        }
        Console.WriteLine("Основа не найдена!");
    }

    public void ShowIngredients()
    {
        if (PizzaIngredients.Count == 0)
            Console.WriteLine("(пусто)");
        else
            foreach (PizzaIngredient ingredient in PizzaIngredients)
                Console.WriteLine(ingredient.GetInfo());
    }

    public void CreateIngredient()
    {
        Console.WriteLine("================ СОЗДАНИЕ ИНГРЕДИЕНТА ================\n");
        Console.Write("Введите название ингредиента: ");
        string ingredient_name = Console.ReadLine();

        if (!CheckIngredient(ingredient_name))
        {
            Console.WriteLine("Такой ингредиент уже существует!");
            return;
        }

        Console.Write("Введите цену ингредиента: ");
        decimal ingredient_price;
        while (!decimal.TryParse(Console.ReadLine(), out ingredient_price) || ingredient_price < 0)
            Console.Write("Некорректная цена! Введите снова: ");

        PizzaIngredients.Add(new PizzaIngredient(ingredient_name, ingredient_price));
        Console.WriteLine("Ингредиент успешно создан!");
    }

    public void EditIngredient()
    {
        Console.WriteLine("================ РЕДАКТИРОВАНИЕ ИНГРЕДИЕНТА ================\n");
        Console.Write("Введите название ингредиента: ");
        string ingredient_name = Console.ReadLine();
        Console.Write("Введите новое название: ");
        string new_ingredient_name = Console.ReadLine();

        if (!CheckIngredient(new_ingredient_name))
        {
            Console.WriteLine("Такой ингредиент уже существует!");
            return;
        }

        Console.Write("Введите новую цену: ");
        decimal new_ingredient_price;
        while (!decimal.TryParse(Console.ReadLine(), out new_ingredient_price) || new_ingredient_price < 0)
            Console.Write("Некорректная цена! Введите снова: ");

        for (int i = 0; i < PizzaIngredients.Count; i++)
        {
            if (PizzaIngredients[i].Name == ingredient_name)
            {
                PizzaIngredients[i] = new PizzaIngredient(new_ingredient_name, new_ingredient_price);
                Console.WriteLine("Ингредиент успешно отредактирован!");
                return;
            }
        }
        Console.WriteLine("Ингредиент не найден!");
    }

    public void DeleteIngredient()
    {
        Console.WriteLine("================ УДАЛЕНИЕ ИНГРЕДИЕНТА ================\n");
        Console.Write("Введите название ингредиента: ");
        string ingredient_name = Console.ReadLine();

        for (int i = 0; i < PizzaIngredients.Count; i++)
        {
            if (PizzaIngredients[i].Name == ingredient_name)
            {
                PizzaIngredients.RemoveAt(i);
                Console.WriteLine("Ингредиент успешно удалён!");
                return;
            }
        }
        Console.WriteLine("Ингредиент не найден!");
    }

    public void ShowPizzas()
    {
        if (Pizzas.Count == 0)
            Console.WriteLine("(пусто)");
        else
            foreach (Pizza pizza in Pizzas)
                Console.WriteLine(pizza.GetInfo());
    }

    public void CreatePizza()
    {
        Console.WriteLine("================ СОЗДАНИЕ ПИЦЦЫ ================\n");
        Console.Write("Введите название пиццы: ");
        string pizza_name = Console.ReadLine();

        Console.WriteLine("==========");
        ShowBases();
        Console.WriteLine("==========");
        Console.Write("Выберите основу: ");

        PizzaBases pizza_base = null;
        string pizza_base_name = Console.ReadLine();
        foreach (PizzaBases bases in PizzaBases)
        {
            if (bases.Name == pizza_base_name)
            {
                pizza_base = bases;
                break;
            }
        }
        if (pizza_base == null)
        {
            Console.WriteLine("Основа не найдена!");
            return;
        }

        Console.WriteLine("==========");
        ShowIngredients();
        Console.WriteLine("==========");

        List<PizzaIngredient> ingredient = new List<PizzaIngredient>();
        List<string> ingredient_names = new List<string>();
        bool ingr_choice = false;

        while (!ingr_choice)
        {
            Console.Write("Выберите ингредиент (= - продолжить): ");
            string pizza_ingredient_name = Console.ReadLine();
            if (pizza_ingredient_name == "=")
            {
                ingr_choice = true;
            }
            else
            {
                bool find = false;
                foreach (PizzaIngredient ingredients in PizzaIngredients)
                {
                    if (ingredients.Name == pizza_ingredient_name)
                    {
                        ingredient.Add(ingredients);
                        ingredient_names.Add(pizza_ingredient_name);
                        find = true;
                    }
                }
                if (!find)
                {
                    Console.WriteLine("Ингредиент не найден!");
                    return;
                }
            }
        }

        decimal ingredient_price = 0;
        foreach (PizzaIngredient ingr in ingredient)
            ingredient_price += ingr.Price;

        Pizzas.Add(new Pizza(pizza_name, pizza_base.Name, ingredient_names, ingredient_price + pizza_base.Price));
        Console.WriteLine("Пицца успешно создана!");
    }

    public void EditPizza()
    {
        Console.WriteLine("================ РЕДАКТИРОВАНИЕ ПИЦЦЫ ================\n");
        Console.Write("Введите название пиццы: ");
        string pizza_name = Console.ReadLine();

        Pizza target = null;
        foreach (Pizza pizza in Pizzas)
            if (pizza.Name == pizza_name) { target = pizza; break; }

        if (target == null) { Console.WriteLine("Пицца не найдена!"); return; }

        Console.Write("Что хотите изменить?: 1. Название, 2. Основа, 3. Ингредиенты; --> ");
        string user2 = Console.ReadLine();

        if (user2 == "1")
        {
            Console.Write("Введите новое название пиццы: ");
            target.Name = Console.ReadLine();
            Console.WriteLine("Название успешно изменено!");
        }

        if (user2 == "2")
        {
            Console.WriteLine("==========");
            ShowBases();
            Console.WriteLine("==========");
            Console.Write("Выберите новую основу: ");
            string new_pizza_base = Console.ReadLine();

            foreach (PizzaBases pizza_base in PizzaBases)
            {
                if (pizza_base.Name == new_pizza_base)
                {
                    decimal old_base_price = 0;
                    foreach (PizzaBases b in PizzaBases)
                        if (b.Name == target.Basis) { old_base_price = b.Price; break; }

                    target.Price = target.Price - old_base_price + pizza_base.Price;
                    target.Basis = new_pizza_base;
                    Console.WriteLine("Основа успешно изменена!");
                    return;
                }
            }
            Console.WriteLine("Основа не найдена!");
        }

        if (user2 == "3")
        {
            decimal old_ingredients_price = 0;
            foreach (PizzaIngredient ingredient in PizzaIngredients)
                foreach (string name in target.Ingridients)
                    if (ingredient.Name == name) old_ingredients_price += ingredient.Price;

            Console.WriteLine("==========");
            ShowIngredients();
            Console.WriteLine("==========");

            List<PizzaIngredient> new_ingredient = new List<PizzaIngredient>();
            List<string> new_ingredient_names = new List<string>();
            bool new_ingr_choice = false;

            while (!new_ingr_choice)
            {
                Console.Write("Выберите ингредиент (= - продолжить): ");
                string new_pizza_ingredient_name = Console.ReadLine();
                if (new_pizza_ingredient_name == "=")
                {
                    new_ingr_choice = true;
                }
                else
                {
                    foreach (PizzaIngredient ingredients in PizzaIngredients)
                        if (ingredients.Name == new_pizza_ingredient_name)
                        {
                            new_ingredient.Add(ingredients);
                            new_ingredient_names.Add(new_pizza_ingredient_name);
                        }
                }
            }

            decimal new_ingredient_price = 0;
            foreach (PizzaIngredient ingr in new_ingredient)
                new_ingredient_price += ingr.Price;

            target.Ingridients = new_ingredient_names;
            target.Price = target.Price - old_ingredients_price + new_ingredient_price;
            Console.WriteLine("Ингредиенты успешно изменены!");
        }
    }

    public void DeletePizza()
    {
        Console.WriteLine("================ УДАЛЕНИЕ ПИЦЦЫ ================\n");
        Console.Write("Введите название пиццы: ");
        string pizza_name = Console.ReadLine();

        for (int i = 0; i < Pizzas.Count; i++)
        {
            if (Pizzas[i].Name == pizza_name)
            {
                Pizzas.RemoveAt(i);
                Console.WriteLine("Пицца удалена!");
                return;
            }
        }
        Console.WriteLine("Пицца не найдена!");
    }
}