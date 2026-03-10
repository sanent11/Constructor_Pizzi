using System.Collections.Generic;

class Pizza
{
    public string Name;
    public string Basis;
    public List<string> Ingridients;
    public decimal Price;

    public Pizza(string name, string basis, List<string> ingridients, decimal price)
    {
        this.Name = name;
        this.Basis = basis;
        this.Ingridients = ingridients;
        this.Price = price;
    }
}

class PizzaBases

{
    public string Name;
    public decimal Price;
    
    public PizzaBases(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }
}

class PizzaIngredient
{
    public string Name;
    public decimal Price;

    public PizzaIngredient(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }
}

class Program
{
    static List<Pizza> pizzas = new List<Pizza>();
    static List<PizzaBases> pizza_bases = new List<PizzaBases>();
    static List<PizzaIngredient> pizza_ingredients = new List<PizzaIngredient>();

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
        if (pizzas.Count() == 0)
            Console.WriteLine("(пусто)");
        else
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine($"Название: {pizza.Name}; Основа: {pizza.Basis}; Ингредиенты: {String.Join(", ", pizza.Ingridients)}; Цена: {pizza.Price} р.");
            }
        Console.WriteLine("\n================");
        Console.WriteLine("1 - Создать пиццу");
        Console.WriteLine("2 - Редактировать пиццу");
        Console.WriteLine("3 - Удалить пиццу");
        Console.WriteLine("4 - Назад в главное меню\n");

        Console.Write("Ваш выбор: ");
        string user = Console.ReadLine();

        if (user == "1")
        {
            Console.WriteLine("================ СОЗДАНИЕ ПИЦЦЫ ================\n");
            Console.Write("Введите название пиццы: ");
            string pizza_name = Console.ReadLine();
            Console.WriteLine("==========");
            foreach (PizzaBases bases in pizza_bases)
            {
                Console.WriteLine($"Название: {bases.Name}, цена: {bases.Price} р.");
            }
            Console.WriteLine("==========");
            Console.Write("Выберите основу: ");

            PizzaBases pizza_base = null;
            string pizza_base_name = Console.ReadLine();
            foreach (PizzaBases bases in pizza_bases)
            {
                if (bases.Name == pizza_base_name)
                {
                    pizza_base = bases; 
                    break;
                }
            }

            Console.WriteLine("==========");
            foreach (PizzaIngredient ingr in pizza_ingredients)
            {
                Console.WriteLine($"Название: {ingr.Name}, цена: {ingr.Price} р.");
            }
            Console.WriteLine("==========");

            bool ingr_choice = false;

            List <PizzaIngredient> ingredient = new List<PizzaIngredient>();
            List <string> ingredient_names = new List<string>();
            while (ingr_choice == false)
            {
                Console.Write("Выберите ингредиент (= - продолжить): ");         
                string pizza_ingredient_name = Console.ReadLine();         
                if (pizza_ingredient_name == "=") ingr_choice = true;
                else
                {
                    foreach (PizzaIngredient ingredients in pizza_ingredients)
                        if (ingredients.Name == pizza_ingredient_name)
                        {
                            ingredient.Add(ingredients);
                            ingredient_names.Add(pizza_ingredient_name);
                        }
                }
                                                                
            }

            decimal ingredient_price = 0;
            for (int i = 0; i < ingredient.Count(); i++)
            {
                ingredient_price += ingredient[i].Price;
            }
            
            decimal pizza_price = ingredient_price + pizza_base.Price;

            Pizza pizza = new Pizza(pizza_name, pizza_base.Name, ingredient_names, pizza_price);
            pizzas.Add(pizza);
            Console.WriteLine("Пицца успешно создана!");         
        }

        if (user == "2")
        {
            Console.WriteLine("================ РЕДАКТИРОВАНИЕ ПИЦЦЫ ================\n");
            Console.Write("Введите название пиццы: ");
            string pizza_name = Console.ReadLine();

            Console.Write("Что хотите изменить?: 1. Название, 2. Основа, 3. Ингредиенты; --> ");
            string user2 = Console.ReadLine();
            if (user2 == "1")
            {
                Console.Write("Введите новое название пиццы: ");
                string new_pizza_name = Console.ReadLine();
                foreach (Pizza pizza in pizzas)
                {
                    if (pizza.Name == pizza_name)
                    {
                        pizza.Name = new_pizza_name;
                 
                        break;
                    }
                }
            }   
            
            if (user2 == "2")
            {
                bool flag = false; decimal old_base_price = 0; decimal new_base_price = 0;
                foreach (PizzaBases pizza_base in pizza_bases)
                {
                    Console.WriteLine($"Название: {pizza_base.Name}, цена: {pizza_base.Price} р.");
                    foreach (Pizza pizza in pizzas)
                    {
                        if (pizza.Basis == pizza_base.Name && pizza_name == pizza.Name) old_base_price += pizza_base.Price;
                    }
                }
                Console.WriteLine("============");
                Console.Write("Выберите новую основу: ");
                string new_pizza_base = Console.ReadLine();
                foreach (PizzaBases pizza_base in pizza_bases)
                {
                    if (pizza_base.Name == new_pizza_base)
                    {
                        flag = true;
                        new_base_price += pizza_base.Price;
                        break;
                    }                        
                }
                if (flag == true)
                {
                    foreach (Pizza pizza in pizzas)
                    {
                        if (pizza.Name == pizza_name)
                        {
                            pizza.Basis = new_pizza_base;
                            pizza.Price = pizza.Price - old_base_price + new_base_price;
                            break;
                        }
                    }
                }
                else Console.WriteLine("Основа не найдена!");
            }

            if (user2 == "3")
            {
                decimal old_ingredients_price = 0;
                foreach (PizzaIngredient ingredient in pizza_ingredients)
                {
                    Console.WriteLine($"Название: {ingredient.Name}, цена: {ingredient.Price} р.");
                    foreach (Pizza pizza in pizzas)
                    {
                        if (pizza.Name == pizza_name)
                        {
                            for (int i = 0; i < pizza.Ingridients.Count; i++)
                            {
                                if (pizza.Ingridients[i] == ingredient.Name)
                                {
                                    old_ingredients_price += ingredient.Price;
                                    continue;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("============");
                bool new_ingr_choice = false;

                List<PizzaIngredient> new_ingredient = new List<PizzaIngredient>();
                List<string> new_ingredient_names = new List<string>();
                while (new_ingr_choice == false)
                {
                    Console.Write("Выберите ингредиент (= - продолжить): ");
                    string new_pizza_ingredient_name = Console.ReadLine();
                    if (new_pizza_ingredient_name == "=") new_ingr_choice = true;
                    else
                    {
                        foreach (PizzaIngredient ingredients in pizza_ingredients)
                        {
                            if (ingredients.Name == new_pizza_ingredient_name)
                            {
                                new_ingredient.Add(ingredients);
                                new_ingredient_names.Add(new_pizza_ingredient_name);

                            }
                        }   

                    }
                }

                decimal new_ingredient_price = 0;
                for (int i = 0; i < new_ingredient.Count(); i++)
                {
                    new_ingredient_price += new_ingredient[i].Price;
                }

                foreach (Pizza pizza in pizzas)
                {
                    if (pizza.Name == pizza_name)
                    {
                        pizza.Ingridients = new_ingredient_names;
                        pizza.Price = pizza.Price - old_ingredients_price + new_ingredient_price;
                        break;
                    }
                }
            }
        }

        if (user == "3")
        {

            Console.WriteLine("================ УДАЛЕНИЕ ПИЦЦЫ ================\n");
            Console.Write("Введите название пиццы: ");
            string pizza_name = Console.ReadLine();
            foreach (Pizza pizza in pizzas)
            {
                if (pizza.Name == pizza_name)
                {
                    pizzas.Remove(pizza);
                    Console.WriteLine("Пицца удалена!");
                    break;
                }
            }

        }    


        if (user == "4") return;

    }

    static void PizzaBase_razdel()
    {
        Console.WriteLine("================ ОСНОВЫ ДЛЯ ПИЦЦ ================\n");
        if (pizza_bases.Count() == 0)
            Console.WriteLine("(пусто)");
        else
            foreach (PizzaBases pizza_base in pizza_bases)
            {
                Console.WriteLine($"Название: {pizza_base.Name}, цена: {pizza_base.Price} р.");
            }
        Console.WriteLine("\n================");
        Console.WriteLine("1 - Создать основу");
        Console.WriteLine("2 - Редактировать основу");
        Console.WriteLine("3 - Удалить основу");
        Console.WriteLine("4 - Назад в главное меню\n");
        Console.Write("Ваш выбор: ");
        string user = Console.ReadLine();
        if (user == "1")
        {
            Console.WriteLine("================ СОЗДАНИЕ ОСНОВЫ ================\n");
            Console.Write("Введите название основы: ");
            string base_name = Console.ReadLine();
            if (CheckBase(base_name) == false)
            {
                Console.WriteLine("Такая основа уже существует!");
            }
            else
            {
                Console.Write("Введите цену основы: ");
                decimal base_price = decimal.Parse(Console.ReadLine());

                PizzaBases base_pizza = new PizzaBases(base_name, base_price);
                pizza_bases.Add(base_pizza);
                Console.WriteLine("Основа успешно создана!");
            }    
         
        }

        if (user == "2")
        {
            Console.WriteLine("================ РЕДАКТИРОВАНИЕ ОСНОВЫ ================\n");
            Console.Write("Введите название основы: ");
            string base_name = Console.ReadLine();
            Console.Write("Введите новое название: ");
            string new_base_name = Console.ReadLine();
            if (CheckBase(new_base_name) == false)
            {
                Console.WriteLine("Такая основа уже существует!");
            }
            else
            {
                Console.Write("Введите новую цену: ");
                decimal new_base_price = decimal.Parse(Console.ReadLine());

                PizzaBases new_base_pizza = new PizzaBases(new_base_name, new_base_price);
                for (int i = 0; i < pizza_bases.Count; i++)
                {
                    if (pizza_bases[i].Name == base_name)
                    {
                        pizza_bases[i] = new_base_pizza;
                    }
                }

                Console.WriteLine("Основа успешно отредактирована!");
            }                
        }

        if (user == "3")
        {
            Console.WriteLine("================ УДАЛЕНИЕ ОСНОВЫ ================\n");
            Console.Write("Введите название основы: ");
            string base_name = Console.ReadLine();

            for (int i = 0; i < pizza_bases.Count; i++)
            {
                if (pizza_bases[i].Name == base_name)
                {
                    pizza_bases.Remove(pizza_bases[i]);
                }
            }

            Console.WriteLine("Основа успешно удалена!");
        }

        if (user == "4") return;
    }
    static bool CheckBase(string base_name)
    {
        foreach (PizzaBases bases in pizza_bases)
        {
            if (bases.Name == base_name) return false;
        }

        return true;
    }


    static void Ingredients_razdel()
    {
        Console.WriteLine("================ ИНГРЕДИЕНТЫ ДЛЯ ПИЦЦ ================\n");
        if (pizza_ingredients.Count() == 0)
            Console.WriteLine("(пусто)");
        else
            foreach (PizzaIngredient ingredient in pizza_ingredients)
            {
                Console.WriteLine($"Название: {ingredient.Name}, цена: {ingredient.Price} р.");
            }
        Console.WriteLine("\n================");
        Console.WriteLine("1 - Создать ингредиент");
        Console.WriteLine("2 - Редактировать ингредиент");
        Console.WriteLine("3 - Удалить ингредиент");
        Console.WriteLine("4 - Назад в главное меню\n");

        Console.Write("Ваш выбор: ");
        string user = Console.ReadLine();
        if (user == "1")
        {
            Console.WriteLine("================ СОЗДАНИЕ ИНГРЕДИЕНТА ================\n");
            Console.Write("Введите название ингредиента: ");
            string ingredient_name = Console.ReadLine();
            if (CheckIngredient(ingredient_name) == false)
            {
                Console.WriteLine("Такой ингредиент уже существует!");
            }
            else
            {
                Console.Write("Введите цену ингредиента: ");
                decimal ingredient_price = decimal.Parse(Console.ReadLine());

                PizzaIngredient pizza_ingredient = new PizzaIngredient(ingredient_name, ingredient_price);
                pizza_ingredients.Add(pizza_ingredient);
                Console.WriteLine("Ингредиент успешно создан!");
            }

        }

        if (user == "2")
        {
            Console.WriteLine("================ РЕДАКТИРОВАНИЕ ИНГРЕДИЕНТА ================\n");
            Console.Write("Введите название ингредиента: ");
            string ingredient_name = Console.ReadLine();
            Console.Write("Введите новое название: ");
            string new_ingredient_name = Console.ReadLine();
            if (CheckBase(new_ingredient_name) == false)
            {
                Console.WriteLine("Такой ингредиент уже существует!");
            }
            else
            {
                Console.Write("Введите новую цену: ");
                decimal new_ingredient_price = decimal.Parse(Console.ReadLine());

                PizzaIngredient new_ingredient_pizza = new PizzaIngredient(new_ingredient_name, new_ingredient_price);
                for (int i = 0; i < pizza_ingredients.Count; i++)
                {
                    if (pizza_ingredients[i].Name == ingredient_name)
                    {
                        pizza_ingredients[i] = new_ingredient_pizza;
                    }
                }

                Console.WriteLine("Ингредиент успешно отредактирован!");
            }
        }

        if (user == "3")
        {
            Console.WriteLine("================ УДАЛЕНИЕ ИНГРЕДИЕНТА ================\n");
            Console.Write("Введите название ингредиента: ");
            string ingredient_name = Console.ReadLine();

            for (int i = 0; i < pizza_ingredients.Count; i++)
            {
                if (pizza_ingredients[i].Name == ingredient_name)
                {
                    pizza_ingredients.Remove(pizza_ingredients[i]);
                }
            }

            Console.WriteLine("Основа успешно удалена!");
        }
        if (user == "4") return;
    }

    static bool CheckIngredient(string ingredient_name)
    {
        foreach (PizzaIngredient ingredients in pizza_ingredients)
        {
            if (ingredients.Name == ingredient_name) return false;
        }

        return true;
    }
}