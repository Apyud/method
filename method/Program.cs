




static string[] CreateArr(int num) // метод будет использоваться для формирования цветов и названий животных
{
    var result = new string[num];
    return result;
}


static bool Checknum(string number, out int corrnumber)
{
    if (int.TryParse(number, out int intnum) && intnum > 0)
    {
        corrnumber = intnum;
        return false;
    }
    {
        corrnumber = 0;
        return true;
    }
}


static string GetValidName()
{
    while (true)
    {
        string name = Console.ReadLine();
        if
            (!string.IsNullOrEmpty(name) && name.All(char.IsLetter))
        {
            return name;
        }
        Console.WriteLine("Слово должно содержать буквы");
    }
}



static (string Name, string LastName, int Age, string[] ArrPets, string[] ArrColor) EnterUsers()
{
    (string Name, string LastName, int Age, string[] ArrPets, string[] ArrColor) User;


    Console.WriteLine("Введите имя");
    User.Name = GetValidName();


    Console.WriteLine("Введите фамилию");

    User.LastName = GetValidName();

    string age;
    int intage;

    do
    {
        Console.WriteLine("Введите возраст цифрами");
        age = Console.ReadLine();
    }
    while (Checknum(age, out intage));
    User.Age = intage;

    Console.WriteLine("Наличие питомцев?");
    string havePets;
    do
    {
        havePets = Console.ReadLine();

        if (havePets != "да" && havePets != "нет")
        {
            Console.WriteLine("некорректный ввод");
        }

    } while (havePets != "да" && havePets != "нет");

    string[] ArrPets = Array.Empty<string>();

    if (havePets == "да")
    {
        int petsCount;
        do
        {
            Console.WriteLine("Введите количество животных");
            age = Console.ReadLine();
        }
        while (Checknum(age, out petsCount));

        ArrPets = CreateArr(petsCount);

        for (int i = 0; i < ArrPets.Length; i++)
        {
            Console.WriteLine("Имя питомца");
            ArrPets[i] = Console.ReadLine();
            //User.ArrPets = ArrPets;
        }
    }

    else if (havePets == "нет")
    {
        Console.WriteLine("Животных нет");
    }

    User.ArrPets = ArrPets;


    // Программа вывода о наличии любимых цветов 

    Console.WriteLine("Есть любимые цвета?");
    string haveColor;
    do
    {
        haveColor = Console.ReadLine();
        if (haveColor != "да" && haveColor != "нет")
        {
            Console.WriteLine("некорректный ввод");
        }

    } while (haveColor != "да" && haveColor != "нет");


    string[] ArrColor = Array.Empty<string>();
    if (haveColor == "да")
    {
        int colorCount;
        do
        {
            Console.WriteLine("Введите количество любимых цветов");
            age = Console.ReadLine();
        }
        while (Checknum(age, out colorCount));

        ArrColor = CreateArr(colorCount);
        for (int i = 0; i < ArrColor.Length; i++)
        {
            Console.WriteLine("Название цветов");
            ArrColor[i] = Console.ReadLine();
        }
    }

    else if (haveColor == "нет")
    {
        Console.WriteLine("Отсутствует любимый цвет");
    }

    User.ArrColor = ArrColor;

    return User;
}






static void DisplayInfo((string Name, string LastName, int Age, string[] ArrPets, string[] ArrColor) User)
{
    Console.WriteLine($"Имя: {User.Name}");
    Console.WriteLine($"Фамилия: {User.LastName}");
    Console.WriteLine($"Возраст: {User.Age}");
    Console.WriteLine("Питомцы");
    if (User.ArrPets != null && User.ArrPets.Length > 0)
    {
        for (int i = 0; i < User.ArrPets.Length; i++)
        {
            Console.WriteLine($" {i + 1}: {User.ArrPets[i]}");
        }
    }
    else
    {
        Console.WriteLine("Животных нет");
    }



    Console.WriteLine("Цвета");
    if (User.ArrColor != null && User.ArrColor.Length > 0)
    {
        for (int i = 0; i < User.ArrColor.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {User.ArrColor[i]}");


        }
    }
    else
    {
        Console.WriteLine("Цвета отсутствуют");
    }
}

var Users = EnterUsers();
DisplayInfo(Users);
