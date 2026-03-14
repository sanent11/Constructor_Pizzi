using System;

class PizzaBases : MenuItem

{
    public PizzaBases(string name, decimal price) : base(name, price) { }

    public override string GetInfo()
    {
        return $"Основа | Название: {Name}; цена: {Price} р.";
    }
}
