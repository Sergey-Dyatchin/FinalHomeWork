/*  Условие:
    Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам.
    Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
    При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами. */

Console.Clear(); // очистим консоль для красоты вывода.
string[] baseArray = ["Hi", "this", "is", "the", "default", "array"];  // Массив предлагаемый по умолчанию
Console.WriteLine($"Используем массив по умолчанию: [{String.Join(", ", baseArray)}]?");
Console.WriteLine("Введите \"yes\", если хотите использовать массив по умолчанию.");
Console.WriteLine("Введите любой другой символ, если хотите задать массив самостоятельно.");

if (Console.ReadLine() != "yes") 
    {
        baseArray = CreatingArrayStrings();
    }

Console.WriteLine($"Используем массив: [{String.Join(", ", baseArray)}]?"); // Выводим пользователю Массив с которым будем работать

string[] resultArray = CreatingArrayStringsElementsThreeOrless(baseArray, CountingElementsThreeOrless(baseArray));

Console.WriteLine($"Новый массив: [{String.Join(", ", resultArray)}]"); // Выводим пользователю итоговый масив


string[] CreatingArrayStrings() // Метод создания произвольного масива строк с вводом с клавиатуры
    {
    int size = RequestingSize(); 
    string[] array = new string[size]; 
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Введите {i} элемент масива : ");
        array[i] = Console.ReadLine()!;
    }
    return array;
    }

int RequestingSize() // функция запроса размера масива.
{
    string enterLine;
    int number;
    Console.Write("Введите размер масива (целое положительное число):");
    while (true)
    {
        enterLine = Console.ReadLine()!; // NULL проверка в следующей строке
        if (IsAllDigits(enterLine) && enterLine!="")
        {
            number = Convert.ToInt32(enterLine);
            if (number != 0)
                return number;
            else
                Console.WriteLine("Вы ввели:\"0\", повторите ввод!");
        }
        else
            Console.WriteLine("Вы ввели некоректное значение, повторите ввод!");
    }
}

bool IsAllDigits(string enterLine ) // Функция проверки, что ввели число.
{
    foreach (char symbol in enterLine)
    {
        if (!char.IsDigit(symbol))  
            return false;
    }
    return true;
}

int CountingElementsThreeOrless(string[] array) // Метод подсчета элементов масива с 3 или менее символов в элементе.
{
    int counter = 0;
    foreach (string element in array)
            if (element.Length <= 3)
                counter++;
    return counter;
}

string[] CreatingArrayStringsElementsThreeOrless (string[] array, int size) /* Метод создания  массива строк из существующего
                                                                            с элементами в которых количество символом 3 или менее*/
{
        int counter = 0;
        string[] newArray = new string[size];
        foreach (string element in array)
            if (element.Length <= 3)
            {
                newArray[counter] = element;
                counter++;
            }    
    return newArray;
}

