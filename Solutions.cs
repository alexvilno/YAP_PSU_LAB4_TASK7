using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PSU_PL_LAB4_TASK7
{
    public class Files
    {
        public static void FillRandomNumbers(string path, int n)
        {
            BinaryWriter fout;
            Random rnd = new Random();
            try
            {
                fout = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            for (int i = 0; i < n; ++i)
            {
                fout.Write((double)rnd.Next(-128, 128));
            }
            fout.Close();
        }

        public static void Task_1(string read_path, string write_path, int n)
        {
            Console.WriteLine("ЗАДАНИЕ 1");

            FillRandomNumbers(read_path, n);
            BinaryReader fin;
            BinaryWriter fout;

            try
            {
                fin = new BinaryReader(File.OpenRead(read_path));
                fout = new BinaryWriter(File.Open(write_path, FileMode.OpenOrCreate));
            }
            catch
            {
                throw new Exception("Smth wrong");
            }

            double[] arr = new double[n];

            Console.Write("Данные из файла: ");

            for (int i = 0; i < n; ++i)
            {
                arr[i] = fin.ReadDouble();
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            Console.Write("Разность максимального и минимального элементов файла равна: = ");
            
            Console.WriteLine(arr.Max() - arr.Min());

            fout.Write(arr.Max()-arr.Min());
            fin.Close();
            fout.Close();

            Console.WriteLine(new String('-', 80));
        }

        private static void MatrixOutput(ref double[,] matrix)
        {
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; ++i)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; ++j)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Task_2(string read_path, string write_path, int n, int matrix_n)
        {
            Console.WriteLine("ЗАДАНИЕ 2");

            FillRandomNumbers(read_path, n);
            BinaryReader fin;
            BinaryWriter fout;

            try
            {
                fin = new BinaryReader(File.OpenRead(read_path));
                fout = new BinaryWriter(File.Open(write_path, FileMode.OpenOrCreate));
            }
            catch
            {
                throw new Exception("Smth wrong");
            }

            if (matrix_n < (int)(Math.Sqrt(n)))
            {
                throw new Exception("n can not be more than matrix n^2");
            }
            double[,] matrix = new double[matrix_n, matrix_n];

            double max = -99999;

            for (int i = 0, c = 0; i < matrix_n; ++i)
            {
                for (int j = 0; j < matrix_n; ++j, ++c)
                {
                    if (c < n)
                    {
                        double temp = fin.ReadDouble();
                        matrix[i, j] = temp;
                        if (max < temp)
                        {
                            max = temp;
                        }
                    }
                }
            }

            Console.WriteLine("Исходная матрица: ");
            MatrixOutput(ref matrix);

            for (int i = 0, c = 0; i < matrix_n; ++i)
            {
                for (int j = 0; j < matrix_n; ++j, ++c)
                {
                    if (matrix[i, j] == max)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            Console.WriteLine("Преобразованная матрица: ");
            MatrixOutput(ref matrix);

            fout.Write(1);
            fin.Close();
            fout.Close();

            Console.WriteLine(new String('-', 80));
        }

        public static void Generate_Toys(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            Random rnd = new Random();
            BinaryFormatter formatter = new BinaryFormatter();

            string[] toy_list = new string[] { "Bibi", "BrawlStars", "Buzz", "El Primo", "Spike", "Shelly", "Dymamike", "Nita", "Crow", "Bea" };
            for (int i = 0; i < 10; ++i)
            {
                Toy toy = new Toy();
                toy.name = toy_list[i];
                Console.WriteLine("Название игрушки: " + toy.name);
                toy.price = rnd.Next(20, 200);
                Console.WriteLine("Цена игрушки: " + toy.price + "$");
                toy.min_age = rnd.Next(2, 6);
                toy.max_age = rnd.Next(6, 12);
                Console.WriteLine("Можно играть с " + toy.min_age + " до " + toy.max_age + " лет" + '\n');


                formatter.Serialize(fs, toy);
            }
            fs.Close();
        }

        public static void Task_3(string read_path, int k)
        {
            Console.WriteLine("ЗАДАНИЕ 3");

            FileStream fs = new FileStream(read_path, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            Generate_Toys(read_path);

            List<Toy> toy_list = new List<Toy>();
            for (int i = 0; i < 10; ++i)
            {
                Toy toy = (Toy)formatter.Deserialize(fs);
                toy_list.Add(toy);
            }

            int max = -1;
            int max_i = 0;

            for (int i = 0; i < 10; ++i)
            {
                if (toy_list[i].price > max)
                {
                    max = toy_list[i].price;
                    max_i = i;
                }
            }

            for (int i = 0; i < 10; ++i)
            {
                if (Math.Abs(toy_list[i].price - toy_list[max_i].price) < k)
                {
                    Console.Write(toy_list[i].name + " ");
                }
            }

            Console.WriteLine();

            Console.WriteLine(new String('-', 80));
        }

        public static void Task_4(string read_path, string write_path)
        {
            Console.WriteLine("ЗАДАНИЕ 4");

            StreamReader fin;
            StreamWriter fout;
            try
            {
                fin = new StreamReader(read_path);
                fout = new StreamWriter(write_path, false);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Smth wrong");
                return;
            }
            string value;
            Console.WriteLine("Данные из файла:" );
            List<int> arr = new List<int>();
            while ((value = fin.ReadLine()) != null)
            {
                if (!int.TryParse(value, out int a))
                {
                    Console.WriteLine("You have submited some cringe");
                    fout.Write(true);
                    fin.Close();
                    fout.Close();
                }
                Console.Write(a + " ");
                arr.Add(a);

            }
            Console.WriteLine();
            int max = arr.Max();
            int c = 0;
            foreach (int i in arr)
            {
                if (i == max)
                {
                    c++;
                }
            }
            Console.WriteLine("Число вхождений максимального элемента равно: " + c);

            Console.WriteLine();
            fout.Write(c);
            fout.Close();
            fin.Close();
            Console.WriteLine(new String('-', 80));
        }

        public static void Task_5(string read_path, string write_path)
        {
            Console.WriteLine("ЗАДАНИЕ 5");

            StreamReader fin;
            StreamWriter fout;
            try
            {
                fin = new StreamReader(read_path);
                fout = new StreamWriter(write_path, false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Smth wrong");
                return;
            }
            string value;
            Console.Write("Данные из файла: ");
            List<int> arr = new List<int>();
            while ((value = fin.ReadLine()) != null)
            {
                if (!int.TryParse(value, out int a))
                {
                    Console.WriteLine("You have submited some cringe");
                    fout.Write(true);
                    fin.Close();
                    fout.Close();
                }
                Console.Write(a + " ");
                arr.Add(a);

            }
            Console.WriteLine();

            int c = 0;
            foreach (int i in arr)
            {
                if (i % 2 == 0)
                {
                    c++;
                }
            }
            Console.Write("Количество четных элементов равно: " + c);

            Console.WriteLine();
            fout.Write(c);
            fout.Close();
            fin.Close();

            Console.WriteLine(new String('-', 80));
        }

        public static void Task_6(string read_path, string write_path, string template)
        {
            Console.WriteLine("ЗАДАНИЕ 6");

            StreamReader fin;
            StreamWriter fout;
            try
            {
                fin = new StreamReader(read_path);
                fout = new StreamWriter(write_path, false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Smth wrong");
                return;
            }
            string value;
            List<string> ans = new List<string>();
            Console.WriteLine("Данные из файла:");
            while ((value = fin.ReadLine()) != null)
            {
                Console.WriteLine(value);
                if (value.Contains(template))
                {
                    fout.WriteLine(value);
                    ans.Add(value);
                }
            }

            Console.WriteLine("Строки, содержащие шаблон " + template + ":");
            foreach(var i in ans)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            fout.Close();
            fin.Close();

            Console.WriteLine(new String('-', 80));
        }
    } 
}