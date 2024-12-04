namespace CaspianChemichalsWebAPI.Utilites.Helpers
{
    public static class StringFormat
    {
        public static string Capitalize(this string name)
        {
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return name;
        }
    }
}
