namespace MatrixSwapper;

/// <summary>
/// Лабораторная работа №1
/// Задание 1. 
/// В двумерном целочисленном массиве размером 4 строки, 5 столбцов поменяйте местами строки, 
/// симметричные относительно середины массива (вертикальной линии).
/// </summary>
static class MatrixSwapper {
    
    /// <summary>
    /// Предложить пользователю заполнить матрицу
    /// </summary>
    /// <returns>Возвращает True, если пользователь хочет выйти из программы.</returns>
    private static bool Message() {
        Console.WriteLine("Хотите заполнить матрицу? y/n");
        return Console.ReadLine() != "y";
    }

    /// <summary>
    /// Выводит матрицу
    /// </summary>
    /// <param name="a">Матрица</param>
    private static void print_matrix(int[,] a)
    {
        var numRows = a.GetLength(0);
        var numCols = a.GetLength(1);
        for (var i = 0; i < numRows; i++)
        {
            for (var j = 0; j < numCols; j++)
            {
                Console.Write("{0} ", a[i, j]);
            }
            Console.WriteLine("");
        }
    }
    /// <summary>
    /// Переворачивает матрицу и сразу ее выводит
    /// </summary>
    /// <param name="a">Матрица</param>
    private static void reverse_matrix(int[,] a)
    {
        var numRows = a.GetLength(0);
        var numCols = a.GetLength(1);
        
        for (var j = 0; j < numCols / 2; j++)
        {
            for (var i = 0; i < numRows; i++)
            { 
                (a[i, j], a[i, numCols - 1 - j]) = (a[i, numCols - 1 - j], a[i, j]);
            }
        }
        print_matrix(a);
    }
    /// <summary>
    /// Ввод Int с проверкой
    /// </summary>
    /// <param name="message">Выдает сообщение пользователю</param>
    /// <returns>Возвращает значение, который ввел пользователь</returns>
    private static int InputInt(String message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out var result))
            {
                return result;
            }
        } 
    }
    /// <summary>
    /// Точка входа
    /// </summary>
    public static void Main() {
        if (Message())
            return;
        var h = InputInt("Задайте количество строк: ");
        
        var w = InputInt("Задайте количество столбцов: ");
        
        var a = new int[h, w];
        
        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < w; j++)
            {
                a[i, j] = InputInt($"a[{i + 1}, {j + 1}]: ");
            }
        }
        Console.WriteLine("Оригинальная матрица:");
        print_matrix(a);
        Console.WriteLine("Перевернутая матрица:");
        reverse_matrix(a);
    }
}