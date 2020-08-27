using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAppWithUsers.Data
{
    public static class MigrationBuilderExtensions
    {
        public static void AddRole(
            this MigrationBuilder migrationBuilder,
            string roleName
            )
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return;
            }

            string normalizedRoleName = roleName.ToUpperInvariant();

            migrationBuilder.Sql($@"
                IF NOT EXISTS(SELECT * FROM [dbo].[AspnetRoles] WHERE [NormalizedName] = '{normalizedRoleName}')
                BEGIN
                    INSERT INTO [dbo].[AspNetRoles]");
        }
    }
}
