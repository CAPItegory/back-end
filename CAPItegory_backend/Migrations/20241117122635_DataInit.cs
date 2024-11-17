using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAPItegory_backend.Migrations
{
    /// <inheritdoc />
    public partial class DataInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreationDate", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("2cee80b2-6399-4302-acb5-7613af8daa95"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7492), "Art", null },
                    { new Guid("4912e1ed-dc26-4f4f-a11c-8650cf744e79"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7508), "Sports", null },
                    { new Guid("517f999d-5016-436b-b637-e46f866ff06b"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7558), "Science", null },
                    { new Guid("575b513b-86cc-4b64-b66a-64256098f778"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7518), "Literature", null },
                    { new Guid("9354b27c-fc41-4160-a468-8e26777e2287"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7525), "History", null },
                    { new Guid("9e676cf0-d2d4-4b20-92b4-ed617a811cde"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7500), "Music", null },
                    { new Guid("a3bcd498-276a-4cb7-ad45-d09360c23789"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7393), "Technology", null },
                    { new Guid("053e35a8-e95f-40b8-8fc3-867b4d576499"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7456), "Databases", new Guid("a3bcd498-276a-4cb7-ad45-d09360c23789") },
                    { new Guid("19f749e6-64ea-43ab-8e0b-3be6f338b7fc"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7520), "Fiction", new Guid("575b513b-86cc-4b64-b66a-64256098f778") },
                    { new Guid("290a1e66-f452-4465-bb06-9e6069a94998"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7555), "Modern", new Guid("9354b27c-fc41-4160-a468-8e26777e2287") },
                    { new Guid("3995002e-99f5-4a11-922d-09b82b613ca2"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7435), "Programming", new Guid("a3bcd498-276a-4cb7-ad45-d09360c23789") },
                    { new Guid("3d37b1ba-c612-4c30-bdd4-f352361e78f9"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7495), "Painting", new Guid("2cee80b2-6399-4302-acb5-7613af8daa95") },
                    { new Guid("478c4296-4e07-4f37-a594-2f6d7973b74f"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7503), "Classical", new Guid("9e676cf0-d2d4-4b20-92b4-ed617a811cde") },
                    { new Guid("4f7f9971-77ed-4d89-8d1c-8939953d5cb6"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7506), "Rock", new Guid("9e676cf0-d2d4-4b20-92b4-ed617a811cde") },
                    { new Guid("6225d0af-5c63-4fde-9eb8-4b353130f878"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7523), "Non-Fiction", new Guid("575b513b-86cc-4b64-b66a-64256098f778") },
                    { new Guid("7c3977c2-522f-4d45-b79d-b68c3f9671d3"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7475), "DevOps", new Guid("a3bcd498-276a-4cb7-ad45-d09360c23789") },
                    { new Guid("7f1303b0-4292-42e4-bcfb-9345884669a3"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7560), "Physics", new Guid("517f999d-5016-436b-b637-e46f866ff06b") },
                    { new Guid("883e1c5d-0c21-49bb-85a3-7e0da663550b"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7515), "Basketball", new Guid("4912e1ed-dc26-4f4f-a11c-8650cf744e79") },
                    { new Guid("9116495b-687a-4926-affd-b4f20f22efa3"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7528), "Ancient", new Guid("9354b27c-fc41-4160-a468-8e26777e2287") },
                    { new Guid("a2a682d1-829f-4f8d-8495-02e43fe1e0c1"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7562), "Chemistry", new Guid("517f999d-5016-436b-b637-e46f866ff06b") },
                    { new Guid("de0ec14b-c82a-45ae-b577-5fbf85111464"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7513), "Football", new Guid("4912e1ed-dc26-4f4f-a11c-8650cf744e79") },
                    { new Guid("df1ece28-8286-48f1-bd7d-7c3a60ac0ebc"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7498), "Sculpture", new Guid("2cee80b2-6399-4302-acb5-7613af8daa95") },
                    { new Guid("f341e088-7c8f-40c1-9e3d-fe1e93e58503"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7564), "Biology", new Guid("517f999d-5016-436b-b637-e46f866ff06b") },
                    { new Guid("064a0a38-9b3b-4776-b854-0297b68acac8"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7477), "CI/CD", new Guid("7c3977c2-522f-4d45-b79d-b68c3f9671d3") },
                    { new Guid("221933d9-2175-4ce6-ae18-1cc6915f9e5c"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7438), "Languages", new Guid("3995002e-99f5-4a11-922d-09b82b613ca2") },
                    { new Guid("480d9706-14d7-4ac3-bf82-49a80c1c7a80"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7448), "Frameworks", new Guid("3995002e-99f5-4a11-922d-09b82b613ca2") },
                    { new Guid("5d6a4a1a-3c54-41f6-a132-2e6b05cd583f"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7488), "Docker", new Guid("7c3977c2-522f-4d45-b79d-b68c3f9671d3") },
                    { new Guid("7f3377ec-aaf2-44c9-8954-35192f41d9d2"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7466), "NoSQL", new Guid("053e35a8-e95f-40b8-8fc3-867b4d576499") },
                    { new Guid("9c672a70-200e-4ad9-a4fb-2e5b44e3e4ba"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7490), "Kubernetes", new Guid("7c3977c2-522f-4d45-b79d-b68c3f9671d3") },
                    { new Guid("a811967d-97e0-4fd3-bea3-98766ea2fc65"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7458), "SQL", new Guid("053e35a8-e95f-40b8-8fc3-867b4d576499") },
                    { new Guid("016cad32-67ab-45e3-82ad-9305f19c209c"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7451), ".NET", new Guid("480d9706-14d7-4ac3-bf82-49a80c1c7a80") },
                    { new Guid("2ab35904-af7c-4e47-85db-27b89bedc3cb"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7461), "MySQL", new Guid("a811967d-97e0-4fd3-bea3-98766ea2fc65") },
                    { new Guid("325bad03-9ae7-4c42-ac4b-647ed60a20f9"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7454), "Node.js", new Guid("480d9706-14d7-4ac3-bf82-49a80c1c7a80") },
                    { new Guid("37efe3ed-3f47-4105-80b3-d8ef986a4fcc"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7446), "JavaScript", new Guid("221933d9-2175-4ce6-ae18-1cc6915f9e5c") },
                    { new Guid("57690f2d-42c2-4bd5-a46b-c36d67471a53"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7482), "Jenkins", new Guid("064a0a38-9b3b-4776-b854-0297b68acac8") },
                    { new Guid("6df438e1-2abe-40b0-be6d-14e6e08b0fa6"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7464), "PostgreSQL", new Guid("a811967d-97e0-4fd3-bea3-98766ea2fc65") },
                    { new Guid("9664372c-8b34-46e2-b200-b5b7ac3f85d2"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7485), "GitLab CI", new Guid("064a0a38-9b3b-4776-b854-0297b68acac8") },
                    { new Guid("e17be77b-62d9-4610-9e51-9a9407d4ef3f"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7469), "MongoDB", new Guid("7f3377ec-aaf2-44c9-8954-35192f41d9d2") },
                    { new Guid("eb97e739-0923-4574-9b5d-98357af2ca7f"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7443), "C#", new Guid("221933d9-2175-4ce6-ae18-1cc6915f9e5c") },
                    { new Guid("f79a9ab7-5e5c-4028-ae14-70ae238e3e66"), new DateTime(2024, 11, 17, 13, 26, 35, 136, DateTimeKind.Local).AddTicks(7472), "Cassandra", new Guid("7f3377ec-aaf2-44c9-8954-35192f41d9d2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("016cad32-67ab-45e3-82ad-9305f19c209c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("19f749e6-64ea-43ab-8e0b-3be6f338b7fc"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("290a1e66-f452-4465-bb06-9e6069a94998"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2ab35904-af7c-4e47-85db-27b89bedc3cb"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("325bad03-9ae7-4c42-ac4b-647ed60a20f9"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("37efe3ed-3f47-4105-80b3-d8ef986a4fcc"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3d37b1ba-c612-4c30-bdd4-f352361e78f9"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("478c4296-4e07-4f37-a594-2f6d7973b74f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4f7f9971-77ed-4d89-8d1c-8939953d5cb6"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("57690f2d-42c2-4bd5-a46b-c36d67471a53"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5d6a4a1a-3c54-41f6-a132-2e6b05cd583f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("6225d0af-5c63-4fde-9eb8-4b353130f878"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("6df438e1-2abe-40b0-be6d-14e6e08b0fa6"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7f1303b0-4292-42e4-bcfb-9345884669a3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("883e1c5d-0c21-49bb-85a3-7e0da663550b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9116495b-687a-4926-affd-b4f20f22efa3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9664372c-8b34-46e2-b200-b5b7ac3f85d2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9c672a70-200e-4ad9-a4fb-2e5b44e3e4ba"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a2a682d1-829f-4f8d-8495-02e43fe1e0c1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("de0ec14b-c82a-45ae-b577-5fbf85111464"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("df1ece28-8286-48f1-bd7d-7c3a60ac0ebc"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e17be77b-62d9-4610-9e51-9a9407d4ef3f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("eb97e739-0923-4574-9b5d-98357af2ca7f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f341e088-7c8f-40c1-9e3d-fe1e93e58503"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f79a9ab7-5e5c-4028-ae14-70ae238e3e66"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("064a0a38-9b3b-4776-b854-0297b68acac8"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("221933d9-2175-4ce6-ae18-1cc6915f9e5c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2cee80b2-6399-4302-acb5-7613af8daa95"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("480d9706-14d7-4ac3-bf82-49a80c1c7a80"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4912e1ed-dc26-4f4f-a11c-8650cf744e79"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("517f999d-5016-436b-b637-e46f866ff06b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("575b513b-86cc-4b64-b66a-64256098f778"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7f3377ec-aaf2-44c9-8954-35192f41d9d2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9354b27c-fc41-4160-a468-8e26777e2287"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9e676cf0-d2d4-4b20-92b4-ed617a811cde"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a811967d-97e0-4fd3-bea3-98766ea2fc65"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("053e35a8-e95f-40b8-8fc3-867b4d576499"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3995002e-99f5-4a11-922d-09b82b613ca2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7c3977c2-522f-4d45-b79d-b68c3f9671d3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a3bcd498-276a-4cb7-ad45-d09360c23789"));
        }
    }
}
