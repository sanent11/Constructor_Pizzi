using System.Collections.Generic;

class Pizza
{
    private string _name;
    private string _basis;
    private List<string> _ingridients;
    private decimal _price;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Basis
    {
        get { return _basis; }
        set { _basis = value; }
    }
    public List<string> Ingridients
    {
        get { return _ingridients; }
        set { _ingridients = value; }
    }
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public Pizza(string name, string basis, List<string> ingridients, decimal price)
    {
        _name = name;
        _basis = basis;
        _ingridients = ingridients;
        _price = price;
    }

    public virtual string GetInfo()
    {
        return $"Название: {Name}; Основа: {Basis}; Ингредиенты: {string.Join(", ", Ingridients)}; Цена: {Price} р.";
    }
}