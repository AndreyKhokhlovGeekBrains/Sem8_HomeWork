// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей 
// суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.WriteLine("Введите кол-во строк: ");
string? rows = Console.ReadLine();

int matrixRows = CheckForNumber(rows, "Введите кол-во строк: ");

Console.WriteLine("Введите кол-во столбцов: ");
string? columns = Console.ReadLine();

int matrixColumns = CheckForNumber(columns, "Введите кол-во столбцов: ");

int[,] myMatrix = Get2DMatrix(matrixRows, matrixColumns);
PrintMatrix(myMatrix);
Console.WriteLine();
PrintArray(GetArrayForRowsSum(myMatrix));
Console.WriteLine();
Console.WriteLine(
    $"Номер строки с минимальной суммой элементов = {FindMinimumSumRowIndex(GetArrayForRowsSum(myMatrix))}"
    );

//--//--//--//

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Сумма элеметов стороки {i + 1} = {array[i]}");
    }
}

int FindMinimumSumRowIndex(int[] array)
{
    int minIndex = 0;
    for (int k = 0; k < array.Length - 1; k++) // Поиск минимального значения в массиве сумм для строк
    {
        for (int m = k + 1; m < array.Length; m++)
        {
            if (array[m] < array[minIndex]) minIndex = m;
        }
    }
    return minIndex + 1;
}


int[] GetArrayForRowsSum(int[,] matrix)
{
    int[] rowIndexArray = new int[matrix.GetLength(0)]; // Массив для сохранения значений суммы строк
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
            rowIndexArray[i] = sum;
        }
    }
    return rowIndexArray;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"[{matrix[i, j]}]\t");
        }
        Console.WriteLine();
    }
}

int[,] Get2DMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(100);
        }
    }
    return matrix;
}

int CheckForNumber(string value, string prompt)
{
    if (int.TryParse(value, out int number) && number > 0) return number;
    else
    {
        Console.WriteLine("Введено некорректное значение.");
        Console.WriteLine(prompt);
        string? newValue = Console.ReadLine();
        return CheckForNumber(newValue, prompt);
    }
}