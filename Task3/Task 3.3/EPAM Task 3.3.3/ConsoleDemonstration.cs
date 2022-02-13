namespace EPAM_Task_3._3._3
{
    class ConsoleDemonstration
    {
        static void Main()
        {
            Console.WriteLine("Hello!");
            Pizza.CatalogInit();
            while (true)
            {
                Order.MakeOrder();
                Console.WriteLine("\n\n");
            }
        }
    }
}
