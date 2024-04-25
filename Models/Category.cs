using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("categories")]
public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(60)]
    public string Name { get; set; }

    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; }

    [JsonIgnore]
    public List<Product> Products { get; set; } = [];
}
