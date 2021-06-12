using System;
using System.ComponentModel.DataAnnotations;

namespace bilicra.Models{
public class Product{
public int  Id { get; set; }
[Required]
public string Code { get; set; }
[Required]
public string Name { get; set; }

[Required]
[Range(1,999)]
public decimal Price { get; set; }

public string Photo { get; set; }

public DateTime LastUpdated { get; set; }=DateTime.UtcNow;

}
}
