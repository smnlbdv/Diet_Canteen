using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    class Product
    {
        public string name;
        public double colorij;
        public double beloc;
        public double jiri;
        public double uglevod;
        public int count = 0;
        public int gram;

        public Product(string name, double colorij, double beloc, double jiri, double uglevod, int gram)
        {
            this.name = name;
            this.colorij = colorij;
            this.beloc = beloc;
            this.jiri = jiri;
            this.uglevod = uglevod;
            this.gram = gram;
        }

        public string GetDescription(int count)
        {
            return count + ". Название: " + this.name + ";" + "\n\t Колорийность (на 100 г) : " + this.colorij + "ккал. ;" + "\n\t Содежрание белков : " + this.beloc + "г. ;" + "\n\t Содежрание жиров : " + this.jiri + "г. ;" + "\n\t Содежрание углеводов : " + this.uglevod + "г. ;" + "\n\t На складе : " + this.gram + "кг. ;";
        }

    }

    class Bludo : Sostav
    {
        public List<Sostav> listSostav = new List<Sostav>();
        public string name;
        public int store;
        public double kkal;
        public bool cheek;
        public string GetSostav(int count)
        {
            return count + ". Название блюда: " + this.name + ";" + " Стоимость: " + this.store + " byn;" + " Наличие: " + this.cheek + ";" + " Коларийность: " + this.kkal + " ккал.;";
        }
    }
    class Sostav
    {
        public string name_product;
        public int count_product;
        public string processing;

        public string GetComponents(int count)
        {
            return "\tНазвание продукта: " + this.name_product + ";" + " Колличество продукта: " + this.count_product + "г. ;" + " Вид обработки: " + this.processing + ";";
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.Title = "СОСТАВЛЯЙКА";
            List<Product> listProduct = new List<Product>()
            {
                new Product("Лук зеленый", 80, 2.5, 0.9, 10.2, 8000),
                new Product("Картофель", 77, 2.05, 0.09, 17.49, 5000),
                new Product("Вода", 0, 0, 0, 0, 2000),
                new Product("Соль", 0, 0, 0, 0, 8000),
                new Product("Говядина", 475, 26.17, 3.51, 0, 1500),
                new Product("Сахар", 387, 0, 0, 99.8, 2000),
                new Product("Свекла варенная очищенная", 49, 1.8, 0, 10.8, 2000),
            };
            List<Bludo> listBludo = new List<Bludo>();
            List<Bludo> Menu = new List<Bludo>();
            metka2:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Добро пожаловать в программу 'СОСТАВЛЯЙКА'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Выберете пункт из предложенных вариантов:");
            Console.WriteLine();
            Console.WriteLine("Press 1 -----> Посмотреть / Добавить товар");
            Console.WriteLine("Press 2 -----> Посмотреть / Составить блюдо");
            Console.WriteLine("Press 3 -----> Посмотреть / Составить меню");
            Console.WriteLine("Press 4 -----> Вывести меню в файл");
            Console.WriteLine();
            int PreAdd = 0;
            try
            {
                PreAdd = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено некорректное значение");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
                goto metka2;
            }
            switch (PreAdd)
            {
                case 1:
                    {
                        metka1:
                        Console.Clear();
                        Console.WriteLine("************************ ПОСМОТРЕТЬ / ДОБАВИТЬ ТОВАР ************************");
                        Console.WriteLine();
                        Console.Write("Список продуктов: ");
                        int counts = listProduct.Count;
                        Console.WriteLine("{0} шт.", counts);
                        Console.WriteLine();
                        int countList = 1;

                        foreach (var izdanie in listProduct)
                        {
                            Console.WriteLine();
                            Console.WriteLine(izdanie.GetDescription(countList));
                            Console.WriteLine();
                            countList += 1;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Добавить продукт --> 1 Выйти в меню --> 2");
                        try
                        {
                            int callback = int.Parse(Console.ReadLine());
                            if (callback == 1)
                            {
                                Console.Clear();
                                goto metka8;
                            }
                            else if (callback == 2)
                            {
                                Console.Clear();
                                goto metka2;
                            } 
                            else
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Введено некорректное значение");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                                goto metka1;
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введено некорректное значение");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            goto metka1;
                        }
                        metka8:
                        Console.Write("Сколько продуктов хотите добавить: ");
                        try
                        {
                            int count = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            while (count != 0)
                            {
                                Console.Write("Введите наименование продукта: ");
                                string name = Console.ReadLine();
                                foreach (var izdanie in listProduct)
                                {

                                    if (izdanie.name.ToLower() == name.ToLower())
                                    {
                                        prihod:
                                        Console.Write("Введите приход (кг.): ");
                                        try
                                        {
                                            int grames = int.Parse(Console.ReadLine());
                                            izdanie.gram += grames;
                                            goto vihod;
                                        }
                                        catch
                                        {
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Введено некорректное значение");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            goto prihod;
                                        }
                                    }
                                }
                                productInfo:
                                try
                                {
                                    Console.Write("Введите калорийность (Ккал): ");
                                    int colorij = int.Parse(Console.ReadLine());
                                    Console.Write("Содержание жиров (г.): ");
                                    int jiri = int.Parse(Console.ReadLine());
                                    Console.Write("Содержание белков (г.): ");
                                    int beloc = int.Parse(Console.ReadLine());
                                    Console.Write("Содержание углеводов (г.): ");
                                    int uglevod = int.Parse(Console.ReadLine());
                                    Console.Write("Введите сколько кг в наличии (кг.): ");
                                    int gram = int.Parse(Console.ReadLine());
                                    Product newPoduct = new Product(name, colorij, beloc, jiri, uglevod, gram);
                                    listProduct.Add(newPoduct);
                                }
                                catch
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Введено некорректное значение");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine();
                                    goto productInfo;
                                }
                            vihod:
                                count--;
                            }
                            Console.Clear();
                            Console.WriteLine("Продукт(-ы) успешно занесен (-ы), вот что получилось: ");
                            Console.WriteLine();

                            int countListTwo = 1;
                            foreach (var izdanie in listProduct)
                            {
                                Console.WriteLine(izdanie.GetDescription(countListTwo));
                                countListTwo += 1;
                            }
                            metka6:
                            Console.WriteLine();
                            Console.WriteLine("Продолжить --> 1 Закончить --> 2");
                            try
                            {
                                int callback = int.Parse(Console.ReadLine());
                                if (callback == 1)
                                {
                                    Console.Clear();
                                    goto metka8;
                                }
                                else if (callback == 2)
                                {
                                    Console.Clear();
                                    goto metka2;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введено некорректное значение");
                                goto metka6;
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введено некорректное значение");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            goto metka2;
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("************************ ПОСМОТРЕТЬ / ДОБАВИТЬ БЛЮДО ************************");
                        Console.WriteLine();
                        foreach (var item in listBludo)
                        {
                            foreach (var menu in Menu)
                            {
                                if (item.name == menu.name)
                                {
                                    item.cheek = true;
                                }
                            }
                        }
                        metka3:
                        Console.Write("Список блюд: ");
                        int counts = listBludo.Count;
                        Console.WriteLine("{0} шт.", counts);
                        Console.WriteLine();
                        int countSostav = 1;
                        foreach (var izdanie in listBludo)
                        {
                            Console.WriteLine(izdanie.GetSostav(countSostav));
                            foreach (var item in izdanie.listSostav)
                            {
                                Console.WriteLine(item.GetComponents(countSostav));
                            }
                            countSostav += 1;
                        }
                        Console.WriteLine();
                        newCreateBludo:
                        try
                        {
                            Console.Write("Сколько блюд хотите добавить: ");
                            int countBlud = int.Parse(Console.ReadLine());
                            while (countBlud != 0)
                            {
                                Bludo newBludo = new Bludo();
                                Console.WriteLine();
                                bludoName:
                                try
                                {
                                    Console.Write("Введите название блюда: ");
                                    newBludo.name = Console.ReadLine();
                                }
                                catch
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Введено некорректное значение");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine();
                                    goto bludoName;
                                }
                                bludoSale:
                                try
                                {
                                    Console.Write("Стоимость блюда (byn): ");
                                    newBludo.store = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Введено некорректное значение");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine();
                                    goto bludoSale;
                                }
                                Console.Write("Наличие в меню: ");
                                Console.WriteLine(newBludo.cheek);
                                components:
                                try
                                {
                                    Console.Write("Сколько будет компонентов: ");
                                    int sostavCount = int.Parse(Console.ReadLine());
                                    while (sostavCount != 0)
                                    {
                                        metka10:
                                        Sostav newSostav = new Sostav();
                                        Console.WriteLine();
                                        Console.Write("\tВведите название продукта: ");
                                        string name_product = Console.ReadLine();
                                        newSostav.name_product = name_product;
                                        countComponents:
                                        try
                                        {
                                            Console.Write("\tВведите кол-во продукта (кг): ");
                                            newSostav.count_product = int.Parse(Console.ReadLine());
                                            foreach (var izdanie in listProduct)
                                            {
                                                if (izdanie.name.ToLower() == name_product.ToLower())
                                                {
                                                    if (izdanie.gram < newSostav.count_product)
                                                    {
                                                        Console.WriteLine();
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\tУ ВАС НЕДОСТАТОЧНО ТОВАРА ДЛЯ ДАННОГО БЛЮДА \n");
                                                        Console.WriteLine();
                                                        Console.WriteLine("\tКол-во продукта: {0}", izdanie.gram);
                                                        Console.WriteLine();
                                                        Console.WriteLine("\tКол-во в блюде: {0}", newSostav.count_product);
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        goto metka10;
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("\tВсе отличноо! Товара достаточно");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        newBludo.kkal += newSostav.count_product / 100 * izdanie.colorij;
                                                        izdanie.gram -= newSostav.count_product;
                                                        goto obtv;
                                                    }
                                                }
                                                else if (izdanie.name.ToLower() != name_product.ToLower())
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Введено некорректное значение");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            goto countComponents;
                                        }
                                        obtv:
                                        try
                                        {
                                            Console.Write("\tВведите вид обработки: ");
                                            newSostav.processing = Console.ReadLine();
                                            newBludo.listSostav.Add(newSostav);
                                            sostavCount--;
                                        }
                                        catch
                                        {
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Введено некорректное значение");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            goto obtv;
                                        }
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Введено некорректное значение");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine();
                                    goto components;
                                }
                                listBludo.Add(newBludo);
                                countBlud--;
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введено некорректное значение");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            goto newCreateBludo;
                        }
                        Console.Clear();
                        Console.WriteLine("Блюдо(-а) успешно занесено(-ы), вот что получилось: ");
                        countSostav = 1;
                        Console.WriteLine();
                        if (listBludo.Count == 0)
                        {
                            Console.WriteLine("Пусто :(");
                        }
                        foreach (var izdanie in listBludo)
                        {
                            Console.WriteLine(izdanie.GetSostav(countSostav));
                            foreach (var item in izdanie.listSostav)
                            {
                                Console.WriteLine(item.GetComponents(countSostav));
                            }
                            countSostav += 1;
                        }
                        Console.WriteLine();
                        vozv:
                        Console.WriteLine();
                        Console.WriteLine("Продолжить --> 1 Закончить --> 2");
                        int callback = int.Parse(Console.ReadLine());
                        if (callback == 1)
                        {
                            Console.Clear();
                            goto metka3;
                        }
                        else if (callback == 2)
                        {
                            Console.Clear();
                            goto metka2;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введено некорректное значение");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto vozv;
                        }
                    }
                case 3:
                    {
                        metka9:
                        double countColl = 0;
                        string vibor;
                        List<Bludo> res = new List<Bludo>();
                        Console.Clear();
                        Console.WriteLine("************************ ПОСМОТРЕТЬ / ДОБАВИТЬ МЕНЮ ************************");
                        Console.WriteLine();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        if (Menu.Count == 1)
                        {
                                foreach (var menuItem in Menu)
                                {
                                    countColl += menuItem.kkal;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Меню на {0} создано с калорийностью {1} ккал.", dateTime.ToString("dd/MM/yyyy"), countColl);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                int countMenu = 1;
                                foreach (var menuItem in Menu)
                                {
                                    Console.WriteLine(menuItem.GetSostav(countMenu));
                                    Console.WriteLine();
                                    countMenu++;
                                }
                                vozv:
                                Console.WriteLine("Создать меню --> 1 Закончить --> 2");
                                int callback = int.Parse(Console.ReadLine());
                                switch (callback)
                                {
                                    case 1:
                                        {
                                            countColl = 0;
                                            Menu.Clear();
                                            foreach (var bludoItem in listBludo)
                                            {
                                                bludoItem.cheek = false;
                                            }
                                            Console.Clear();
                                            goto metka9;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            goto metka2;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Введено некорректное значение");
                                            goto vozv;
                                        }
                                }
                        }
                        else
                        {
                            Console.Write("Составление меню на: ");
                            Console.WriteLine(dateTime.ToString("dd/MM/yyyy"));
                            Console.WriteLine();
                            int maxColl = 0;
                            readMaxColl:
                            try
                            {
                                Console.Write("Введите максимальную калорийность на день: ");
                                maxColl = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Введено некорректное значение");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                goto readMaxColl;
                            }
                            metka13:
                            Console.WriteLine();
                            Console.WriteLine("Выберете блюдо из предложенных: ");
                            Console.WriteLine();
                            int countSostav = 1;
                            switch (listBludo.Count)
                            {
                                case 0:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("У вас нет готовых блюд :(");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine();
                                        metka6:
                                        Console.WriteLine("Закончить --> 1");
                                        try
                                        {
                                            int callbacker = int.Parse(Console.ReadLine());
                                            switch (callbacker)
                                            {
                                                case 1:
                                                    {
                                                        Console.Clear();
                                                        goto metka2;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine();
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Введено некорректное значение");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine();
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        goto metka6;
                                                    }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Введено некорректное значение");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            Console.Clear();
                                            goto metka6;
                                        }
                                        
                                    }
                                    default:
                                    {
                                        int countTrues = 0;
                                        foreach (var list in listBludo)
                                        {
                                            if (list.cheek == true)
                                            {
                                                countTrues += 1;
                                                if(countTrues == listBludo.Count)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("У вас кончились блюда");
                                                    Console.WriteLine("Недобор по колориям: {0} ", maxColl - list.kkal);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    countColl = 0;
                                                    Menu.Clear();
                                                    foreach (var bludoItem in listBludo)
                                                    {
                                                        bludoItem.cheek = false;
                                                    }
                                                    Console.ReadKey();
                                                    goto metka2;
                                                }
                                                continue;
                                            }
                                            else
                                            {
                                                Console.WriteLine(list.GetSostav(countSostav));
                                                foreach (var item in list.listSostav)
                                                {
                                                    Console.WriteLine(item.GetComponents(countSostav));
                                                }
                                                countSostav += 1;
                                            }
                                        }
                                        Console.WriteLine();
                                        Console.Write("Введите блюдо, которое хотите добавить: ");
                                        vibor = Console.ReadLine();
                                        Console.WriteLine();

                                        foreach (var bludoItems in listBludo)
                                        {
                                            if (bludoItems.name == vibor)
                                            {
                                                countColl += bludoItems.kkal;
                                                if (countColl <= maxColl)
                                                {
                                                    res.Add(bludoItems);
                                                    Menu.Add(bludoItems);
                                                    bludoItems.cheek = true;
                                                    goto metka13;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    res.Add(bludoItems);
                                                    Menu.Add(bludoItems);
                                                    bludoItems.cheek = true;
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Достигнут лимит калорий на день");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine();
                                                    goto metka9;
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }

                                            if (res.Count == 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\tТакого блюда нет!!");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.ReadKey();
                                                Console.Clear();
                                                goto metka13;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }   
                case 4:
                    {
                        if(Menu.Count !=0)
                        {
                            FileStream file1 = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Новое меню.txt", FileMode.Create);
                            StreamWriter writer = new StreamWriter(file1);
                            int countListTree = 1;
                            DateTime dateTime = DateTime.UtcNow.Date;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Меню на {0} загружено!", dateTime.ToString("dd/MM/yyyy"));
                            Console.ForegroundColor = ConsoleColor.White;
                            writer.WriteLine(" ");
                            writer.WriteLine("Меню на {0} загружено!", dateTime.ToString("dd/MM/yyyy"));
                            foreach (var izdanie in Menu)
                            {
                                writer.WriteLine(izdanie.GetSostav(countListTree));
                                countListTree += 1;
                            }
                            writer.Close();
                            Console.ReadKey();
                            break;
                        } 
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("У вас нет составленного меню");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Console.Clear();
                            goto metka2;
                        }
                    }
                default:
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введено некорректное значение");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.Clear();
                        goto metka2;
                    }
            }
        }
    }
}
