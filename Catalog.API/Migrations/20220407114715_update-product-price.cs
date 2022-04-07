using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.API.Migrations
{
    public partial class updateproductprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("058ca6b6-d991-44ba-b39e-b256a07918bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2df6a0dd-b845-4a22-8729-e909431678c5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3cd2d89d-abb8-4f2c-acd4-df874b463e35"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("52b2ff1f-01ce-4fa1-bc35-326515ce9e41"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59c16e83-2145-4fb1-91f1-0de4e7cc6f7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7e6ec3c-842e-44fa-ad24-b3aba5378774"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFile", "Name", "Price", "Summary" },
                values: new object[,]
                {
                    { new Guid("292e344e-ce2e-4c50-8fd3-89a4ba911ae9"), "White Appliances", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-3.png", "Huawei Plus", 650.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("75e2cc1c-fd7f-47fd-97c2-5f6ebb74685b"), "Smart Phone", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-1.png", "IPhone X", 950.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("9d102b36-c424-4755-9c53-6cab179a7645"), "Smart Phone", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-5.png", "HTC U11+ Plus", 380.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("cd4e0bcd-d703-4e5a-a4b4-d065841abc0f"), "Smart Phone", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-2.png", "Samsung 10", 840.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("d9f6996d-3ab1-4bba-8fa5-52de30375cc5"), "Home Kitchen", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-6.png", "LG G7 ThinQ", 240.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("f454428a-3376-4c05-9ca9-b931ed51ef62"), "White Appliances", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-4.png", "Xiaomi Mi 9", 470.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("292e344e-ce2e-4c50-8fd3-89a4ba911ae9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75e2cc1c-fd7f-47fd-97c2-5f6ebb74685b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d102b36-c424-4755-9c53-6cab179a7645"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cd4e0bcd-d703-4e5a-a4b4-d065841abc0f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9f6996d-3ab1-4bba-8fa5-52de30375cc5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f454428a-3376-4c05-9ca9-b931ed51ef62"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageFile", "Name", "Price", "Summary" },
                values: new object[,]
                {
                    { new Guid("058ca6b6-d991-44ba-b39e-b256a07918bc"), "White Appliances", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-3.png", "Huawei Plus", 650.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("2df6a0dd-b845-4a22-8729-e909431678c5"), "White Appliances", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-4.png", "Xiaomi Mi 9", 470.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("3cd2d89d-abb8-4f2c-acd4-df874b463e35"), "Smart Phone", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-2.png", "Samsung 10", 840.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("52b2ff1f-01ce-4fa1-bc35-326515ce9e41"), "Smart Phone", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-1.png", "IPhone X", 950.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("59c16e83-2145-4fb1-91f1-0de4e7cc6f7f"), "Home Kitchen", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-6.png", "LG G7 ThinQ", 240.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." },
                    { new Guid("d7e6ec3c-842e-44fa-ad24-b3aba5378774"), "Smart Phone", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.", "product-5.png", "HTC U11+ Plus", 380.00m, "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless." }
                });
        }
    }
}
