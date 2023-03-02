using Csharp_HomeWork_Modul7;

//Просмотр всех записей.
//Просмотр одной записи. Функция должна на вход принимать параметр ID записи, которую необходимо вывести на экран. 
//Создание записи.
//Удаление записи.
//Загрузка записей в выбранном диапазоне дат.

if (File.Exists(@"D:\Workers") == false) File.Create(@"D:\Workers");

Repozitory repozitory = new Repozitory();

Console.WriteLine("Здравствуйте, вас приветствует справочник \"Сотрудники\"");

while (true)
{
    Console.WriteLine("Выберите команду:\n" +
        "Просмотр всех записей - 1\n" +
        "Просмотр одной записи по ID - 2\n" +
        "Создание записи - 3\n" +
        "Удаление записи по ID - 4\n" +
        "Загрузка записей в выбранном диапазоне дат - 5");

    int inputAnswer = int.Parse(Console.ReadLine());

    switch (inputAnswer)
    {
        case 1:
            Console.WriteLine("Выберите способ сортировки:\n" +
                "по ID - 1\n" +
                "по возросту - 2\n" +
                "по росту - 3\n" +
                "по дате - 4");
            inputAnswer = int.Parse(Console.ReadLine());
            switch (inputAnswer)
            {
                case 1:
                    foreach (var item in repozitory.GetAllWorkers().OrderBy(key => key.ID))
                    {
                        Console.WriteLine(item.Print());
                    }
                    break;
                case 2:
                    foreach (var item in repozitory.GetAllWorkers().OrderBy(key => key.Age))
                    {
                        Console.WriteLine(item.Print());
                    }
                    break;
                case 3:
                    foreach (var item in repozitory.GetAllWorkers().OrderBy(key => key.Height))
                    {
                        Console.WriteLine(item.Print());
                    }
                    break;
                case 4:
                    foreach (var item in repozitory.GetAllWorkers().OrderBy(key => key.Date))
                    {
                        Console.WriteLine(item.Print());
                    }
                    break;
            }
            break;
        case 2:
            Console.WriteLine("Введите ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(repozitory.GetWorkerById(id).Print());
            break;
        case 3:
            Console.WriteLine("\nДля записи нового сотрудника введите:\n" +
                "Ф. И. О.\n" +
                "Возраст\n" +
                "Рост\n" +
                "Дату рождения\n" +
                "Место рождения\n" +
                "каждый введенный пункт должен быть разделен решеткой - #");
            string worker = Console.ReadLine();
            repozitory.AddWorker(worker);
            break;
        case 4:
            Console.WriteLine("Введите ID:");
            id = int.Parse(Console.ReadLine());
            repozitory.DeleteWorker(id);
            break;
        case 5:
            Console.WriteLine("Введите начальную дату:");
            DateTime dateFrom = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите конечную дату:");
            DateTime dateTo = Convert.ToDateTime(Console.ReadLine());
            foreach (var item in repozitory.GetWorkersBetweenTwoDates(dateFrom, dateTo))
            {
                Console.WriteLine(item.Print());
            }
            break;   
    }
    Console.WriteLine("Хотите продолжить:\n" +
        "да - Y\n" +
        "нет - N");
    if (Console.ReadKey().Key == ConsoleKey.Y) continue;
    else break;
}