using System;
using System.Collections.Generic;

namespace APIBurger.Data.Models;

public partial class Burger
{
    public int BurgerId { get; set; }

    public string BurgerName { get; set; } = null!;

    public bool WithCheese { get; set; }

    public double Price { get; set; }

    public virtual ICollection<Promo> Promos { get; set; } = new List<Promo>();
}
