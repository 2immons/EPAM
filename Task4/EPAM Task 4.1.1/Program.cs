using System.Text;

namespace FileManagementSystem
{
    // Дана папка, которая является хранилищем файлов.

    // Для всех текстовых файлов(*.txt), находящихся в этой папке или вложенных подпапках,
    // реализовать сохранение истории изменений с возможностью отката состояния к любому моменту.

    // Принцип работы программы:
    //  1. При запуске программа спрашивает пользователя, какой из режимов он хочет включить:
    //     наблюдения или отката изменений. Как вариант, можно использовать ключи командной
    //     строки.
    //  2. При выборе режима наблюдения все происходящие с текстовыми файлами изменения
    //     логируются до момента закрытия программы. Как вариант, можно создавать на диске в
    //     отдельной папке копии файлов по состоянию на момент изменения.
    //  3. При выборе режима отката изменений пользователь вводит дату и время, на которые
    //     должен быть осуществлён откат, после чего все текстовые файлы в папке должны принять
    //     вид, соответствующий указанному времени.
    // Возможностью изменения файлов в момент, когда программа не находится в режиме
    // отслеживания изменений, пренебречь.

    public class FileManager
    {
        static string directoryPath = "D:/GitHub/EPAM/Task4/EPAM Task 4.1.1";
        string logFilePath = Path.Combine(directoryPath, "log.txt");

        public static int MakeChoise()
        {
            Console.WriteLine("Hello! You have 2 options:");
            Console.WriteLine("1) Only read mode\n2) Backup mode");
            int choiseIndex = int.Parse(Console.ReadLine());
            return choiseIndex;
        }

        public void DirectoryCreator()
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(directoryPath));

                di.Delete();
                Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void BackupFileCreator()
        {
            string fileName = "testname"; // придумать генератор
            string filePath = Path.Combine(directoryPath, fileName);

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Logger()
        {
            using (FileStream fs = File.Create(logFilePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is log file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        // delegates: https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/delegates/using-delegates

        public delegate void DelegateStartUp(int mode);
        DelegateStartUp startUp = StartUp;

        public static bool CheckForExitCommand()
        {
            if (Console.ReadLine().ToLower() == "exit")
                return false;
            else return true;
        }
        
        private static void StartUp(int mode)
        {
            switch (mode)
            {
                case 1:
                    Console.WriteLine("[READ MODE]");
                    break;
                case 2:
                    Console.WriteLine("[BACKUP MODE]");
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }

        static void Main()
        {
            while (CheckForExitCommand()) 
            {
                StartUp(MakeChoise());

            }
        }
        
    }


}