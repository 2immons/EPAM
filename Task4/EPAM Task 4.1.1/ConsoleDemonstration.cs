namespace FileManagementSystem
{
    class Program
    {
        static void SelectOption(FileManager fileManager)
        {
            Console.WriteLine("Select option:");
            Console.WriteLine("1) Save changes\n2) Backup\n3) Exit");
            int choiseIndex = int.Parse(Console.ReadLine());

            switch (choiseIndex)
            {
                case 1:
                    fileManager.CreateDirectoryCopy();
                    break;
                case 2:
                    fileManager.CreateBackupDirectory();
                    break;
                case 3:
                    Console.WriteLine("Exit...");
                    return;
                default:
                    Console.WriteLine("Incorrect option, try again!\n");
                    break;
            }
            SelectOption(fileManager);
        }

        static void StartUp()
        {
            Console.WriteLine("Hello! Enter the path to your folder:");
            string ?inputDirPath = Console.ReadLine();
            while (!Directory.Exists(inputDirPath))
            {
                Console.WriteLine("\nIncorrect path: directory doesn't exist!\n");
                inputDirPath = Console.ReadLine();
            }
            FileManager fileSystemManager = new(inputDirPath);
            SelectOption(fileSystemManager);
        }

        static void Main() => StartUp();
    }
}