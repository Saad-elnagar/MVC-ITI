namespace MVC_3Tir.Models;

public class ProductBL
{
    private List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 15000, Image = "1.jpg" },
        new Product { Id = 2, Name = "Phone", Price = 8000, Image = "2.jpg" }
    };

    public List<Product> GetAll() => products;

    public Product GetById(int id) => products.FirstOrDefault(p => p.Id == id)!;
    
    
}