using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCoreTester.Helpers
{
    public static class PropertyBuilderExtension
    {
        /// <summary>
        /// Varchar database column type
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PropertyBuilder Varchar(this PropertyBuilder builder, int length = 1)
        {
            return builder.HasColumnType($"varchar({length})");
        }

        /// <summary>
        /// Decimal database column type
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="length"></param>
        /// <param name="decimalPlace"></param>
        /// <returns></returns>
        public static PropertyBuilder Decimal(this PropertyBuilder builder, int length = 18, int decimalPlace = 2)
        {
            return builder.HasColumnType($"decimal({length}, {decimalPlace})");
        }

        /// <summary>
        /// Nvarchar database column type
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PropertyBuilder Nvarchar(this PropertyBuilder builder, int length = 1)
        {
            return builder.HasColumnType($"nvarchar({length})");
        }

        /// <summary>
        /// Nvarchar database column type
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PropertyBuilder Text(this PropertyBuilder builder, int length = 1)
        {
            return builder.HasColumnType($"text({length})");
        }
    }
}
