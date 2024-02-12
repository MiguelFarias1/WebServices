using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations;

/// <inheritdoc />
public partial class PopulaProdutos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder mb)
    {
        mb.Sql("insert into products(Name, Description, Price, ImageUrl,Quantity,CreatedAt,CategoryId)" +
            " values('Coca-Cola Zero', 'Refrigerante zero açúcar', 5.45, 'cocacola.jpg',50, now(),1)"
            + ", ('Lanche de Atum', 'Atum ao Molho', 9.99, 'atum.jpg', 20, now(), 2)"
            + ", ('Pudim', 'Pudim de leite condensado', 14.99, 'pudim.jpg', 30, now(), 3)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder mb)
    {
        mb.Sql("delete from products");
    }
}
