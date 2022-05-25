using System.Reflection;
using System;

namespace ss
{
    class Programm
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Здравствуй, пользователь! Добро пожаловать в справочник аптеки, для начала взаимодействия, нажмите любую клавишую");
            Console.ReadKey();
            list();
        }
        //Метод списка, основа
        public static void list(){
        Console.WriteLine("\nУ справочника есть несколько функций: \n\nA - Вывести список всех доступных препаратов \n\nL - Вывести список доступных жидкостей (сиропы, бальзамы и т.д.) \n\nP - Вывести список доступных таблеток \n\nI - Вывести список доступных приспособлений (бинты, шприцы и т.д.)");
        string choice = Console.ReadLine();
        if(choice=="A"){
            //всё
            liquidList();
            pillsList();
            instrumentList();
            check();
        }else if(choice=="L"){
            //жидкости
            liquidList();
            check();
        }else if(choice=="P"){
            //таблетки
            pillsList();
            check();
        }else if(choice=="I"){
            //приспособления
            instrumentList();
            check();
        }else{
            //рекурсия если неверный ввод
            list();
        }
        }
        //Метод перепроверки
        public static void check(){
            Console.WriteLine("\nДля того чтобы вернуться в меню выбора, отправьте L. Для выхода из справочника отправьте любое значение, кроме L.\n");
            string choice = Console.ReadLine();
            if(choice=="L"){
                list();
            }else{
               Console.WriteLine("Спасибо за использования услуг справочника!");
               //Конец
            }
        }
        //Метод списка жидкостей
        public static void liquidList(){
            var a1 = new Liquid("Галоперидол", 578, 50, "Шизофрения", "Ампула");
            var a2 = new Liquid("Корвалол", 200, 150, "Сердечно-сосудистые заболевания", "Капли");
            var a3 = new Liquid("Лазолван", 242, 200, "Кашель", "Сироп");
            var a4 = new Liquid("Синэстрол ", 700, 10, "Гормональный дизбаланс", "Ампула");
            var a5 = new Liquid("Жабий камень", 81, 100, "Боль в суставах", "Бальзам");
            Liquid[] liquids = new Liquid[5]{a1, a2, a3, a4, a5};
            for(int i=0; i<liquids.Length; i++){
                liquids[i].Print();
            }
        }
        //Метод списка таблеток
        public static void pillsList(){
            var a1 = new Pills("Глицин", 150, 150, "Паника, проблемы с концентрацией внимания", 20);
            var a2 = new Pills("Аскорутин", 60, 150, "Сердечно-сосудистые заболевания", 25);
            var a3 = new Pills("Ибупрофен", 50, 100, "Кашель", 10);
            var a4 = new Pills("Персен ", 700, 10, "Бессоница", 12);
            var a5 = new Pills("Нерво-вит", 291, 100, "Невроз", 20);
            Pills[] pills = new Pills[5]{a1, a2, a3, a4, a5};
            for(int i=0; i<pills.Length; i++){
                pills[i].Print();
            }
        }
        //Метод списка приспособлений
        public static void instrumentList(){
            var a1 = new Instrument("Бинт", 50 );
            var a2 = new Instrument("Пластыри", 100);
            var a3 = new Instrument("Напальчник", 10);
            var a4 = new Instrument("Ессентуки", 150);
            var a5 = new Instrument("Шприц", 25);
            Instrument[] instruments = new Instrument[5]{a1, a2, a3, a4, a5};
            for(int i=0; i<instruments.Length; i++){
                instruments[i].Print();
            }
        }
       }
    }
    abstract class Medication
    {
        //Родительский класс, общая информация о медикаментах
        private string name = "Undefined";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int price = 0;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        private int weight = 0;
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string sickness = "Undefined";
        public string Sickness
        {
            get { return sickness; }
            set { sickness = value; }
        }
    }
        //Второй класс, жидкости
        class Liquid : Medication
        {
        private string type = "Undefined";
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
            //Конструктор жидкостей
            public Liquid(string _Name, int _Price, int _Weight, string _Sickness, string _Type)
            {
                Name = _Name;
                Price = _Price;
                Weight = _Weight;
                Sickness = _Sickness;
                Type = _Type;
            }
            public void Print(){
            Console.WriteLine("\nНазвание: " + Name);
            Console.WriteLine("Цена: " + Price + " рублей");
            Console.WriteLine("Вес: " + Weight + " грамм");
            Console.WriteLine("Лечение от: " + Sickness);
            Console.WriteLine("Тип: " + type);
            }
        }
        
        //Третий класс, таблетки
        class Pills : Medication
        {
        private int count = 0;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
            //Конструктор таблеток
            public Pills(string _Name, int _Price, int _Weight, string _Sickness, int _Count)
            {
                Name = _Name;
                Price = _Price;
                Weight = _Weight;
                Sickness = _Sickness;
                Count = _Count;
            }
            public void Print(){
            Console.WriteLine("\nНазвание: " + Name);
            Console.WriteLine("Цена: " + Price + " рублей");
            Console.WriteLine("Вес: " + Weight + " грамм");
            Console.WriteLine("Лечение от: " + Sickness);
            Console.WriteLine("Количество на упаковку: " + count + " штук");
            }
       }
      //Четвёртый класс, приспособления
       class Instrument{
        private string name = "Undefined";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int price = 0;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }        
            //Конструктор приспособлений
        public Instrument(string _Name, int _Price)
        {
            Name = _Name;
            Price = _Price;
        }
        public void Print(){
        Console.WriteLine("\nНазвание: " + name);
        Console.WriteLine("Цена: " + price + " рублей");
        }
}