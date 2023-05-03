namespace SmartProductQuotationTool.Models
{
    public static class Nav
    {
        public static int[] levels = { 1, 2, 3, 4, 5, 6, 7 };
        public static int activeLevel;



        public static int setActive(int level) => activeLevel = level;
        public static string getActive(int index) => levels[index] == activeLevel ? "active" : "";
    }
}
