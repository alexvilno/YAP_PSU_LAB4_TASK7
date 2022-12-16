# Лабораторная работа 4, вариант 7, ПГНИУ ЯП МФТИ-1 2022

Решение всех задач оформить в виде одного класса со статическими методами, решающими поставленные задачи. В классе могут присутствовать методы со спецификатором доступа private вспомогательного характера.

## Задание 1. Бинарные файлы, содержащие числовые данные. 

Найти разность максимального и минимального элементов заданного файла.
Для заполнения файла случайными числами использована вспомогательная функция ```private static void FillRandomNumbers(string path, int n);```
Для чтения и записи в соответствии с заданием используются классы ```BinaryReader```  и ```BinaryWriter```, позволяющие считать/записать поток в бинарный файл. Исключения обрабатываются по следующему принципу:
```c#
try
{
    fin = new BinaryReader(File.OpenRead(read_path)); //пробуем открыть файл для чтения
    fout = new BinaryWriter(File.Open(write_path, FileMode.OpenOrCreate)); //пробуем открыть файл для записи
}
catch
{
    throw new Exception("Smth went wrong"); //Если что-то не так...
}
``` 
Такая обрабока будет использована во всех последующих задачах.

Решение этой задачи очень простое, просто разность максимального и минимального элементов массива
```c#
Console.WriteLine(arr.Max() - arr.Min());
fout.Write(arr.Max()-arr.Min());
```
Вывод:
```
ЗАДАНИЕ 1
Данные из файла: 26 48 -22 104 82 21 84 -116 68 104 
Разность максимального и минимального элементов файла равна: = 220
--------------------------------------------------------------------------------
```

## Задание 2. Скопировать элементы заданного файла в квадратную матрицу размером n×n . Заменить на нуль все вхождения максимального элемента.

Для вывода матрицы написана вспомагательная функция ```private static void MatrixOutput(ref double[,] matrix);``` и функция, генерирующая *n* случайных чисел(в диапазоне -128,128), записывающая их в бинарный файл ```FillRandomNumbers(read_path, n); ```

Здесь исключается ситуация, когда число элементов больше корня из размерности матрицы. 
```C#
if (matrix_n < (int)(Math.Sqrt(n)))
{
    throw new Exception("n can not be more than matrix n^2");
}
```
Ищется максимальный элемент(ы) в марице: 
```C#
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
```

и он(и) заменяется на ноль. Далее матрица выводится с помощью функции ```MatrixOutput``` на экран и матрица записывается в файл.
Вывод:
```
ЗАДАНИЕ 2
Исходная матрица: 
-107    88      -59     22
33      78      127     -120
20      -124    22      125
0       0       0       0

Преобразованная матрица: 
-107    88      -59     22
33      78      0       -120
20      -124    22      125
0       0       0       0

--------------------------------------------------------------------------------
```

Как мы видим, элемент 127 заменился на 0.

## 3. Бинарные файлы, содержащие величины типа struct 
Файл содержит сведения об игрушках: название игрушки, ее стоимость в рублях и возрастные границы (например, игрушка может предназначаться для детей от двух до пяти лет). Вывести названия наиболее дорогих игрушек (цена которых отличается от цены самой дорогой игрушки не более, чем на k руб.).

В этом задании используется функция-генератор игрушек ```public static void Generate_Toys(string path);```, генерирующая 10 игрушек со случайными ценами в диапазоне от 20-200$ и возрастом применения от 2 до 12 лет. Структура игрушки описана в отдельном файле ```Toy.cs```
```c#
namespace PSU_PL_LAB4_TASK7
{
    [Serializable] //объекты структуры могут быть сериализированны
    struct Toy
    {
        public string name { get; set; }
        public int price { get; set; }
        public int min_age { get; set; }
        public int max_age { get; set; }
    }
}  
```
В функции ```Generate_Toys``` используется сериализация, а в ```Task_3``` - десериализация. 
Находится игрушка, с максимальной ценой:
```c#
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
```
После чего выводятся на экран названия игрушек, у которых разница в цене меньше заданного *k* в сравнении с самой дорогой:

```c#
for (int i = 0; i < 10; ++i)
{
    if (Math.Abs(toy_list[i].price - toy_list[max_i].price) < k)
    {
        Console.Write(toy_list[i].name + " ");
    }
}
```

Вывод: 
```
ЗАДАНИЕ 3
Название игрушки: Bibi
Цена игрушки: 153$
Можно играть с 2 до 8 лет

Название игрушки: BrawlStars
Цена игрушки: 29$
Можно играть с 4 до 8 лет

Название игрушки: Buzz
Цена игрушки: 190$
Можно играть с 4 до 8 лет

Название игрушки: El Primo
Цена игрушки: 20$
Можно играть с 2 до 11 лет

Название игрушки: Spike
Цена игрушки: 140$
Можно играть с 5 до 8 лет

Название игрушки: Shelly
Цена игрушки: 64$
Можно играть с 3 до 7 лет

Название игрушки: Dymamike
Цена игрушки: 191$
Можно играть с 5 до 8 лет

Название игрушки: Nita
Цена игрушки: 48$
Можно играть с 2 до 6 лет

Название игрушки: Crow
Цена игрушки: 37$
Можно играть с 5 до 6 лет

Название игрушки: Bea
Цена игрушки: 151$
Можно играть с 4 до 8 лет

Bibi Buzz Spike Dymamike Bea 
--------------------------------------------------------------------------------
```
## Задание 4. Решить задачу с использованием структуры «текстовый файл»

Подсчитать количество вхождений максимального элемента в файл.

Абсолютно тривиальное задание, комментировать нечего. Ввод и вывод теперь работают через ```StreamReader``` и ```StreamWriter```:
```c#
StreamReader fin;
StreamWriter fout;
```

А информация из файла считывается в цикле:

```c#
string value;
while ((value = fin.ReadLine()) != null) //пока успешно считывается значение
{
    ...
}
```
Вывод:
```
Данные из файла:
123 12883 2772 126 123 1994 165 295 2547 
Число вхождений максимального элемента равно: 1
--------------------------------------------------------------------------------
```

## Задание 5. Решить задачу с использованием структуры «текстовый файл»
Вычислить количество чётных элементов.

Решение тривиально, полностью повторяет предыдущее.
Вывод:
```
ЗАДАНИЕ 5
Данные из файла: 1212 12 123123 123213 122 123213 
Количество четных элементов равно: 3
--------------------------------------------------------------------------------
```

## Задание 6. Решить задачу с использованием структуры «текстовый файл»
Переписать в другой файл строки, содержащие заданную комбинацию символов. Например, строка «Сегодня старшеклассники выполняли ЕГЭ по информатике и ИКТ» содержит комбинацию «форма».

Решение заключается в поиске подстроки в каждой строке из массива с последующей записью строк с найденным шаблоном в файл вывода:
```c#
while ((value = fin.ReadLine()) != null)
{
    Console.WriteLine(value);
    if (value.Contains(template))
    {
        fout.WriteLine(value);
        ans.Add(value);
    }
}
```
Ответ:

```
ЗАДАНИЕ 6
Данные из файла:
ABOBABOBA
BOBABOBA
BOBOBO
AAAAA
ABOBOBA
Строки, содержащие шаблон ABOBA:
ABOBABOBA
BOBABOBA\
--------------------------------------------------------------------------------
```

