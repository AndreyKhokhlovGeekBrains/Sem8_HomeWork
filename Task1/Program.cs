// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки 
// двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine("Введите кол-во строк: ");
string? rows = Console.ReadLine();

int matrixRows = CheckForNumber(rows, "Введите кол-во строк: ");

Console.WriteLine("Введите кол-во столбцов: ");
string? columns = Console.ReadLine();

int matrixColumns = CheckForNumber(columns, "Введите кол-во столбцов: ");

int[,] myMatrix = Get2DMatrix(matrixRows, matrixColumns);
PrintMatrix(myMatrix);
Console.WriteLine();
SortMatrixRows(myMatrix);
PrintMatrix(myMatrix);

//--//--//--//

void SortMatrixRows(int[,] matrix)
{
    for (int k = 0; k < matrix.GetLength(0); k++) // Цикл для строк, где k - индекс строки
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++) // Цикл для столбцов, где i - индекс столбца
        {
            int indexOfMaxValue = i;
            for (int j = i + 1; j < matrix.GetLength(1); j++) // Цикл для поиска максимального элемента в строке
            {
                if (matrix[k, j] > matrix[k, indexOfMaxValue]) indexOfMaxValue = j;
            }
            int temp = matrix[k, i];
            matrix[k, i] = matrix[k, indexOfMaxValue];
            matrix[k, indexOfMaxValue] = temp;
        }
    }
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