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

namespace FileManagementSystem
{
    public class FileManager
    {
        private readonly string reserveDirPath;
        private readonly string inputDirPath;
        public bool IsInputDirectoryExist { get => Directory.Exists(inputDirPath); }

        private string mainDirPath;
        private string backupDirectory;

        public FileManager(string inputDirPath)
        {
            if (inputDirPath[^1] != '\\')
                inputDirPath += @"\";

            this.inputDirPath = inputDirPath;

            if (!IsInputDirectoryExist)
                Console.WriteLine("\nIncorrect directory address: directory doesn't exist!\n");

            else
            {
                reserveDirPath = Directory.GetDirectoryRoot(inputDirPath) + new DirectoryInfo(inputDirPath).Name + " (reserve)\\";
                Directory.CreateDirectory(reserveDirPath);
            }
        }

        public void CreateDirectoryCopy()
        {
            mainDirPath = inputDirPath;
            backupDirectory = reserveDirPath + '\\' + DateTime.Now.ToString(@"dd-MM-yyyy HH-mm-s") + '\\';
            Directory.CreateDirectory(backupDirectory);
            
            CopyFiles(mainDirPath, backupDirectory);
            CopyDirectories(mainDirPath, backupDirectory);
        }

        public void CreateBackupDirectory()
        {
            mainDirPath = SelectRecoveryPoint();

            Directory.Delete(inputDirPath, true);
            Directory.CreateDirectory(inputDirPath);

            if (mainDirPath == null)
                return;

            backupDirectory = inputDirPath;
            CopyFiles(mainDirPath, backupDirectory);
            CopyDirectories(mainDirPath, backupDirectory);
            
        }

        private string SelectRecoveryPoint()
        {
            DirectoryInfo directoryInfo = new(reserveDirPath);
            DirectoryInfo[] reverseDirectories = directoryInfo.GetDirectories();
            Console.WriteLine("Select a recovery point:");
            for (int i = 0; i < reverseDirectories.Length; i++)
                Console.WriteLine($"{i + 1} : {reverseDirectories[i]}");

            int choiseIndex = int.Parse(Console.ReadLine());

            try
            {
                return reverseDirectories[choiseIndex - 1].FullName + @"\";
            }
            catch (Exception)
            {
                Console.WriteLine("\nIncorrect recovery point index!\n");
                return SelectRecoveryPoint();
            }
        }

        private void CopyDirectories(string inputDirPathTemp, string backupDirectory)
        {
            DirectoryInfo directoryInfo = new(inputDirPathTemp);
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Directory.CreateDirectory(backupDirectory + directory + @"\");
                CopyFiles(inputDirPathTemp + directory + @"\", this.backupDirectory);
                CopyDirectories(inputDirPathTemp + directory + @"\", backupDirectory + directory + @"\");
            }
        }

        private void CopyFiles(string directoryPath, string backupDirectory)
        {
            DirectoryInfo directoryInfo = new(directoryPath);
            string dirWithoutMain = directoryPath.Replace(mainDirPath, "");

            foreach (var file in directoryInfo.GetFiles("*.txt"))
                File.Copy(file.FullName, backupDirectory + dirWithoutMain + file.Name, true);
        }
    }
}