using System;

class PizzaIngredient : MenuItem
{
    public PizzaIngredient(string name, decimal price) : base(name, price) { }

    public override string GetInfo()
    {
        return $"Ингредиент | Название: {Name}; цена: {Price} р.";
    }
}