using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PechShop.Migrations
{
    public partial class TransportationCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransportatoinCost",
                table: "Products",
                newName: "TransportationCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransportationCost",
                table: "Products",
                newName: "TransportatoinCost");
        }
    }
}
