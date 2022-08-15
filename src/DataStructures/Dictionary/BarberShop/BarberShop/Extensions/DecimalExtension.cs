using System;
namespace BarberShop.Extensions
{
    public static class DecimalExtension
    {
        public static string AsCurrency(this decimal number, char sign)
        {
            return $"{sign}{number}";
        }

    }
}

