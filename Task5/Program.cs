// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("Введите кол-во строк: ");
string? rows = Console.ReadLine();

int matrixRows = CheckForNumber(rows, "Введите кол-во строк: ");

Console.WriteLine("Введите кол-во столбцов: ");
string? columns = Console.ReadLine();

int matrixColumns = CheckForNumber(columns, "Введите кол-во столбцов: ");

string[,] myMatrix = new string[matrixRows, matrixColumns];
MatrixSpiralFilling(myMatrix);
PrintMatrix(myMatrix);

//--//--//--//

void MatrixSpiralFilling(string[,] matrix)
{
    int n = 1;
    int initialPositionForRows = matrix.GetLength(0);
    int initialPositionForColumns = matrix.GetLength(1);
    int iterationID = Math.Min(initialPositionForRows, initialPositionForColumns) / 2;

    for (int j = 0; j < iterationID; j++)
    {
        // Заполняем первую строку (слева направо)
        for (int i = j; i < initialPositionForColumns - j; i++)
        {
            matrix[j, i] = n < 10 ? $"0{n}" : n.ToString();
            n++;
        }

        // Заполняем последнюю колонку (сверху вниз)
        for (int i = j + 1; i < initialPositionForRows - j; i++)
        {
            matrix[i, initialPositionForColumns - 1 - j] = n < 10 ? $"0{n}" : n.ToString();
            n++;
        }

        // Заполняем последнюю строку (справа налево)
        for (int i = initialPositionForColumns - 2 - j; i >= j; i--)
        {
            matrix[initialPositionForRows - 1 - j, i] = n < 10 ? $"0{n}" : n.ToString();
            n++;
        }

        // Заполняем первую колонку (снизу вверх)
        for (int i = initialPositionForRows - 2 - j; i > j; i--)
        {
            matrix[i, j] = n < 10 ? $"0{n}" : n.ToString();
            n++;
        }
    }
    // Проверяем матрицу на нечетность, чтобы заполнить центр
    if (initialPositionForRows % 2 == 1 && initialPositionForColumns % 2 == 1 &&
    initialPositionForRows < initialPositionForColumns)
    {
        int rowID = initialPositionForRows / 2;
        int columnID = initialPositionForColumns / 2 - 1;
        for (int i = 0; i <= Math.Abs(initialPositionForColumns - initialPositionForRows); i++)
        {
            matrix[rowID, columnID] = n < 10 ? $"0{n}" : n.ToString();
            columnID++;
            n++;
        }
    }
    else if (initialPositionForRows % 2 == 1 && initialPositionForColumns % 2 == 1 &&
    initialPositionForRows == initialPositionForColumns)
    {
        int matrixCenter = initialPositionForRows / 2;
        matrix[matrixCenter, matrixCenter] = n < 10 ? $"0{n}" : n.ToString();
    }
    else if (initialPositionForRows % 2 == 1 && initialPositionForColumns % 2 == 1 &&
    initialPositionForRows > initialPositionForColumns)
    {
        int rowID = initialPositionForRows / 2 - 1;
        int columnID = initialPositionForColumns / 2;
        for (int i = 0; i <= Math.Abs(initialPositionForColumns - initialPositionForRows); i++)
        {
            matrix[rowID, columnID] = n < 10 ? $"0{n}" : n.ToString();
            rowID++;
            n++;
        }
    }
}

void PrintMatrix(string[,] matrix)
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