using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProF.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    coment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coment_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.coment_id);
                });

            migrationBuilder.CreateTable(
                name: "login_admins",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passward = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login_admins", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Registeration_USER_",
                columns: table => new
                {
                    Register_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    table_num = table.Column<int>(type: "int", nullable: false),
                    Register_DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registeration_USER_", x => x.Register_id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    table_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.table_num);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    item_Cost = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<int>(type: "int", nullable: false),
                    item_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_Cost = table.Column<float>(type: "real", nullable: false),
                    stars = table.Column<int>(type: "int", nullable: false),
                    item_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_items_login_admins_adminID",
                        column: x => x.adminID,
                        principalTable: "login_admins",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Register_id = table.Column<int>(type: "int", nullable: false),
                    Recipes_Num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity_of_each_recipe = table.Column<int>(type: "int", nullable: false),
                    Registeration_USER_Register_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_num);
                    table.ForeignKey(
                        name: "FK_Orders_Registeration_USER__Registeration_USER_Register_id",
                        column: x => x.Registeration_USER_Register_id,
                        principalTable: "Registeration_USER_",
                        principalColumn: "Register_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registeration_USER_comment",
                columns: table => new
                {
                    Registeration_USER_sRegister_id = table.Column<int>(type: "int", nullable: false),
                    commentscoment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registeration_USER_comment", x => new { x.Registeration_USER_sRegister_id, x.commentscoment_id });
                    table.ForeignKey(
                        name: "FK_Registeration_USER_comment_Registeration_USER__Registeration_USER_sRegister_id",
                        column: x => x.Registeration_USER_sRegister_id,
                        principalTable: "Registeration_USER_",
                        principalColumn: "Register_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registeration_USER_comment_comments_commentscoment_id",
                        column: x => x.commentscoment_id,
                        principalTable: "comments",
                        principalColumn: "coment_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registeration_USER_Table",
                columns: table => new
                {
                    Registeration_USER_sRegister_id = table.Column<int>(type: "int", nullable: false),
                    Tablestable_num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registeration_USER_Table", x => new { x.Registeration_USER_sRegister_id, x.Tablestable_num });
                    table.ForeignKey(
                        name: "FK_Registeration_USER_Table_Registeration_USER__Registeration_USER_sRegister_id",
                        column: x => x.Registeration_USER_sRegister_id,
                        principalTable: "Registeration_USER_",
                        principalColumn: "Register_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registeration_USER_Table_Tables_Tablestable_num",
                        column: x => x.Tablestable_num,
                        principalTable: "Tables",
                        principalColumn: "table_num",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_p = table.Column<int>(type: "int", nullable: false),
                    order_num = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_order_num",
                        column: x => x.order_num,
                        principalTable: "Orders",
                        principalColumn: "order_num");
                });

            migrationBuilder.CreateTable(
                name: "PaymentRegisteration_USER_",
                columns: table => new
                {
                    PaymentsPayment_Id = table.Column<int>(type: "int", nullable: false),
                    Registeration_USER_sRegister_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRegisteration_USER_", x => new { x.PaymentsPayment_Id, x.Registeration_USER_sRegister_id });
                    table.ForeignKey(
                        name: "FK_PaymentRegisteration_USER__Payments_PaymentsPayment_Id",
                        column: x => x.PaymentsPayment_Id,
                        principalTable: "Payments",
                        principalColumn: "Payment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRegisteration_USER__Registeration_USER__Registeration_USER_sRegister_id",
                        column: x => x.Registeration_USER_sRegister_id,
                        principalTable: "Registeration_USER_",
                        principalColumn: "Register_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_items_adminID",
                table: "items",
                column: "adminID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Registeration_USER_Register_id",
                table: "Orders",
                column: "Registeration_USER_Register_id");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRegisteration_USER__Registeration_USER_sRegister_id",
                table: "PaymentRegisteration_USER_",
                column: "Registeration_USER_sRegister_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_order_num",
                table: "Payments",
                column: "order_num");

            migrationBuilder.CreateIndex(
                name: "IX_Registeration_USER_comment_commentscoment_id",
                table: "Registeration_USER_comment",
                column: "commentscoment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Registeration_USER_Table_Tablestable_num",
                table: "Registeration_USER_Table",
                column: "Tablestable_num");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "PaymentRegisteration_USER_");

            migrationBuilder.DropTable(
                name: "Registeration_USER_comment");

            migrationBuilder.DropTable(
                name: "Registeration_USER_Table");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "login_admins");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Registeration_USER_");
        }
    }
}
