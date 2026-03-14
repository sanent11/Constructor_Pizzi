using System;

class MenuItem
{
    private string _name;
    private decimal _price;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public MenuItem(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public virtual string GetInfo()
    {
        return $"Название: {Name}; цена: {Price} р.";
    }
}