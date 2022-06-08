namespace Program
{
    public abstract class Program1
    {
        protected abstract void Zapol(double[] XY, double[] YX);
        protected abstract void Phigur(double[] XY, double[] YX);
        protected abstract void Naloj();
    }
    public class Program2 : Program1
    {
        private double[] firstX = new double[4]; // Массив для всех значений х первой фигуры.
        private double[] firstY = new double[4]; // Массив для всех значений у первой фигуры.

        private double[] secondX = new double[4]; // Массив для всех значений х вторй фигуры.
        private double[] secondY = new double[4]; // Массив для всех значений у вторй фигуры.

        
        protected override void Zapol(double[] XY, double[] YX) // Метод для заполнения массивов.
        {
            Console.WriteLine("Введите коардинаты крайних точек параллелограмма:");
            for (int i = 0; i < 4; i++)
            {
                XY[i] = double.Parse(Console.ReadLine());
                YX[i] = double.Parse(Console.ReadLine());                
            }
            Phigur(XY, YX);
        }
        protected override void Phigur(double[] XY, double[] YX) // Метод проверки: параллелограмм ли введён.
        {
            int q = 1;
            double[] a = new double[4];
            for (int i = 0; i < 4; i++)
            {
                if (q == 4) q = 0;
                a[i] = Math.Sqrt(Math.Pow(XY[q] - XY[i], 2) + Math.Pow(YX[q] - YX[i], 2)); // Подсчёт длин сторон.
                q++;
            }
            if (a[0] == 0 || a[1] == 0 || a[2] == 0 || a[3] == 0) // Проверка: равена ли сторона нулю.
            {
                Console.WriteLine("Не параллелограмм!!!");
                Environment.Exit(0);
            }
            else if (a[0] == a[2] || a[1] == a[3]) // Праверка равенства противолежащих сторон.
            {
                Console.WriteLine("Параллелограмм!!!");
            }
            else
            {
                Console.WriteLine("Не параллелограмм!!!");
                Environment.Exit(0);
            }
        }
        protected override void Naloj() // Метод для проверки наложения фигур.
        {
            int r = 1;
            for (int i = 0; i < 4; i++)
            {
                if (r == 4) r = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (firstX[j] >= secondX[i] && firstX[i] <= secondX[r] && firstY[j] >= secondY[i] && firstY[i] <= secondY[r])
                    {
                        Console.WriteLine("Наложение!!!");
                        Environment.Exit(0);
                    }
                }
                r++;
            }
            Console.WriteLine("Наложение нет!!!");
        }
        public Program2()
        {
            Zapol(firstX, firstY);

            Zapol(secondX, secondY);

            Naloj();
        }
    }
    public class ProgramMain
    {
        static void Main()
        {
            Program2 program1 = new Program2();            
        }
    }
}