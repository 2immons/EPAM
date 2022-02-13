namespace EPAM_Task_3._3._3
{
    public class Pizza
    {
        //Смоделируйте работу пиццерии в вашем приложении.
        //К сожалению, в вашей пиццерии ещё не работает доставка.
        //Две ключевые сущности: пользователь и пиццерия взаимодействуют через заказ и пиццу.
        //Пользователь делает заказ в заведении, после чего ждет оповещения о том, что пицца готова.
        //Например – его имя высветится на табло.После этого пользователь сам забирает пиццу.
        //Ключевая фишка и особенность вашей пиццерии – вы не храните данные о покупателях. У вас нет
        //листа покупателей, массива или отдельных переменных. Потому пользователи вам доверяют – они
        //уверены, что после вашей пиццерии им не начнут «названивать назойливые продавцы и
        //рекламщики».
        //Подумайте, как может выглядеть такое приложение? Какой минимум данных необходим для
        //реализации?
        //Наличие консольного интерфейса не обязательно. Можете продемонстрировать работу с помощью
        //базовых Console.WriteLine(…)
        //Обязательно наличие вменяемой архитектуры, прописанных сущностей и базового
        //взаимодействия.

        public PizzaName Name { get; set; }
        public int Time { get; set; }
        public double Price { get; set; }
        public DateTime FinishCookingTime { get; set; }
        public Pizza()
        {
            this.Name = PizzaName.None;
            this.Time = 10;
            this.Price = 999.9;
        }
        public Pizza(PizzaName name, int time, double price)
        {
            this.Name = name;
            this.Time = time;
            this.Price = price;
        }

        public enum PizzaName
        {
            None = 0,
            Margarita = 1,
            Crudo = 2,
            Neapoletano = 3,
        }

        public static string PizzaTypeToString(PizzaName name)
        {
            switch (name)
            {
                case PizzaName.Margarita:
                    return "Margarita";
                case PizzaName.Crudo:
                    return "Crudo";
                case PizzaName.Neapoletano:
                    return "Neapoletano";
                default:
                    return "Nothing selected";
            }
        }

        public static List<Pizza> catalog = new();

        public static void CatalogInit()
        {
            catalog.Add(new Pizza(PizzaName.Margarita, 20, 120));
            catalog.Add(new Pizza(PizzaName.Crudo, 30, 80));
            catalog.Add(new Pizza(PizzaName.Neapoletano, 30, 65));
        }

        public void AddPizzaToCatalog(PizzaName name, int time, double price) => catalog.Add(new Pizza(name, time, price));

        public static void CatalogPrint()
        {
            Console.WriteLine("WE HAVE TODAY:");
            for (int i = 0; i < catalog.Count; i++)
                Console.Write($"{i}) {catalog[i].Name} (cooking time: {catalog[i].Time}) for {catalog[i].Price}\n");
        }
    }

}