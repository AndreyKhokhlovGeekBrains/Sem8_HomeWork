// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет 
// построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.WriteLine("Введите кол-во знаков оси X: ");
string? x = Console.ReadLine();

int matrixX = CheckForNumber(x, "Введите кол-во знаков оси X: ");

Console.WriteLine("Введите кол-во знаков оси Y: ");
string? y = Console.ReadLine();

int matrixY = CheckForNumber(y, "Введите кол-во знаков оси Y: ");

Console.WriteLine("Введите кол-во знаков оси Z: ");
string? z = Console.ReadLine();

int matrixZ = CheckForNumber(z, "Введите кол-во знаков оси Z: ");

int[,,] myMatrix = Get3DMatrix(matrixX, matrixY, matrixZ);
PrintMatrix(myMatrix);

//--//--//--//

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
                Console.Write($"{matrix[j, k, i]} ({j}, {k}, {i})\t");
                Console.WriteLine();
        }
    }
}

int[,,] Get3DMatrix(int x, int y, int z)
{
    int[,,] matrix3D = new int[x, y, z];
    for (int i = 0; i < matrix3D.GetLength(0); i++)
    {
        for (int j = 0; j < matrix3D.GetLength(1); j++)
        {
            for (int k = 0; k < matrix3D.GetLength(2); k++)
            {
                int[] array = new int[i*j*k];
                int number = new Random().Next(10, 100);

                if(!array.Contains(number)) matrix3D[i, j, k] = number;
                else k--;
            }
                
        }
    }
    return matrix3D;
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