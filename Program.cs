using PSU_PL_LAB4_TASK7;

class main
{
    public static void Main(String[] args)
    {
        string path_read_task1 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_1_read.dat";
        string path_write_task1 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_1_write.dat";
        string path_read_task2 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_2_read.dat";
        string path_write_task2 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_2_write.dat";
        string path_read_task3 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_3.dat";
        string path_read_task4 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_4_read.txt";
        string path_write_task4 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_4_write.txt";
        string path_read_task_5 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_5_read.txt";
        string path_write_task_5 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_5_write.txt";
        string path_read_task_6 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_6_read.txt";
        string path_write_task_6 = "/Users/alexvilno/Projects/PSU_PL_LAB4_TASK7/PSU_PL_LAB4_TASK7/task_6_write.txt";
        Files.Task_1(path_read_task1,path_write_task1,10);
        Files.Task_2(path_read_task2, path_write_task2, 12, 4);
        Files.Task_3(path_read_task3, 75);
        Files.Task_4(path_read_task4,path_write_task4);
        Files.Task_5(path_read_task_5, path_write_task_5);
        Files.Task_6(path_read_task_6, path_write_task_6, "ABOBA");
    }
}