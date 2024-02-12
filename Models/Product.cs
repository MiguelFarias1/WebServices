using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("products")]
public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(60)]
    public string Name { get; set; }
    [Required]
    [StringLength(300)]
    public string Description { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required, StringLength(3000)]
    public string ImageUrl { get; set; }
    public float Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category Category { get; set; }
}
