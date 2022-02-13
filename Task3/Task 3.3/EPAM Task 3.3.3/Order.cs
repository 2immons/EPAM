namespace EPAM_Task_3._3._3
{
    public class Order
    {
        private int orderPizzaIndex;
        private int orderNumber;
        public DateTime FinishCookingTime { get; set; }
        public Order(int pizzaIndex)
        {
            this.orderPizzaIndex = pizzaIndex;
            this.orderNumber = random.Next(1000, 9999);
            this.FinishCookingTime = DateTime.Now.AddMinutes(Pizza.catalog[pizzaIndex].Time);
        }

        Random random = new();
        static List<Order> ordersList = new();
        public static void MakeOrder()
        {
            Pizza.CatalogPrint();
            Console.Write("Enter index of Pizza, which you want: ");
            int pizzaIndex = int.Parse(Console.ReadLine());
            Order order = new(pizzaIndex);
            ordersList.Add(order);
            Console.Write($"Thank you for your order! " +
                $"Pizza {Pizza.PizzaTypeToString(Pizza.catalog[pizzaIndex].Name)} is a great choice!\n" +
                $"Waiting time will be {Pizza.catalog[pizzaIndex].Time} mins! " +
                $"Your order's number - #{order.orderNumber}\n");
            Thread.Sleep(3000);
            Alert(order.orderNumber);
        }

        public static void Alert(int orderNumber)
        {
            Console.WriteLine($"Please, get your order (#{orderNumber})!");
            Console.WriteLine("*the customer picks up the pizza after seeing the inscription on the order board*");
            GetOrder(orderNumber);
        }
        public static void GetOrder(int orderNumber)
        {
            for (int i = 0; i < ordersList.Count; i++)
            {
                if (ordersList[i].orderNumber == orderNumber)
                {
                    ordersList.RemoveAt(i);
                    break;
                }
            }
            Console.Write("Bon appetit!");
        }

    }
}
