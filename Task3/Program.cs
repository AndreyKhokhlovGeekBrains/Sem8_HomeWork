// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Определение. Произведением двух матриц А и В называется матрица С, элемент которой, находящийся на пересечении 
// i-й строки и j-го столбца, равен сумме произведений элементов i-й строки матрицы А на соответствующие [по порядку] 
// элементы j-го столбца матрицы В.

// Mатрица C, которая является произведением двух матриц A и B: 2 Х 10 и 10 Х 5 = 2 Х 5

// 2 4 | 3 4
// 3 2 | 3 3

// 2*3 + 4*3 = 18; 2*4 + 4*3 = 20; 
// 3*3 + 2*3 = 15; 3*4 + 2*3 = 18;

//   A       B       A       B        C
// [0,0] * [0,0] + [0,1] * [1,0]
//   2   *   3   +   4   *   3 = 18 [0,0]
// [0,0] * [0,1] + [0,1] * [1,1]
//   2   *   4   +   4   *   3 = 20 [0,1]

// [1,0] * [0,0] + [1,1] * [1,0]
//   3   *   3   +   2   *   3 = 15 [1,0]
// [1,0] * [0,1] + [1,1] * [1,1]
//   3   *   4   +   2   *   3 = 18 [1,1]

Console.WriteLine("Введите кол-во строк для матрицы А: ");
string? rowsA = Console.ReadLine();

int matrixRowsA = CheckForNumber(rowsA, "Введите кол-во строк для матрицы А: ");

Console.WriteLine("Введите кол-во столбцов для матрицы А: ");
string? columnsA = Console.ReadLine();

int matrixColumnsA = CheckForNumber(columnsA, "Введите кол-во столбцов для матрицы А: ");

// Произведение двух матриц АВ имеет смысл только в том случае, когда число столбцов матрицы А совпадает с числом строк 
// матрицы В, поэтому числом строк для матрицы B будет число столбцов матрицы А.

int matrixRowsB = matrixColumnsA;

Console.WriteLine("Введите кол-во столбцов для матрицы B: ");
string? columnsB = Console.ReadLine();

int matrixColumnsB = CheckForNumber(columnsB, "Введите кол-во столбцов для матрицы B: ");

int[,] matrixA = Get2DMatrix(matrixRowsA, matrixColumnsA);
int[,] matrixB = Get2DMatrix(matrixRowsB, matrixColumnsB);

Console.WriteLine("Матрица A: ");
PrintMatrix(matrixA);
Console.WriteLine();
Console.WriteLine("Матрица B: ");
PrintMatrix(matrixB);
Console.WriteLine();

int[,] matrixC = Multiply2DMatrixes(matrixA, matrixB); // Mатрица C, которая является произведением двух матриц A и B

Console.WriteLine("Матирца C, которя является произведением матрицы А на мартицу B: ");
PrintMatrix(matrixC);

//--//--//--//

int[,] Multiply2DMatrixes(int[,] matrixA, int[,] martixB)
{
    int[,] result = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

    for (int i = 0; i < matrixA.GetLength(0); i++) // Цикл для заполнения строк матрицы C (строки С = строкам А)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++) // Цикл для заполнения столбцов матрицы С (столбцы С = столбцам B)
        {
            for (int k = 0; k < matrixA.GetLength(1); k++) // Цикл для итерации столбцов матрицы А
            {
                result[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return result;
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
            matrix[i, j] = new Random().Next(10);
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