using AutoShortcut.Properties;
using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoShortcut
{
    public partial class Form1 : Form
    {
        string currentFolder = Settings.Default.currentFolder;
        string iconsDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Auto Shortcut Icons";
        string folderTemp, folderPrintPhoto, folderSublim, folderPhotomontage;
        string[] iconsArray = { "\\month.ico", "\\temp.ico", "\\photoPrint.ico", "\\sublim.ico", "\\photomontage.ico" };

        public Form1()
        {
            InitializeComponent();
            tbxCurrentFolder.Text = Settings.Default.currentFolder;
        }

        /// <summary>
        /// Создать ярлык Windows
        /// </summary>
        /// <param name="TargetPath">Файл, для которого нужно создать ярлык</param>
        /// <param name="ShortcutFile">Путь и имя файла ярлыка, включая расширение файла (.lnk)</param>
        /// <param name="Description">Описание ярлыка</param>
        /// <param name="Arguments">Аргументы командной строки</param>
        /// <param name="HotKey">Горячая клавиша быстрого доступа в виде строки, например "Ctrl+F"</param>
        /// <param name="WorkingDirectory">Параметр быстрого доступа "Начать в"</param>
        public static void CreateShortcut(string TargetPath, string ShortcutFile, string Description,
           string Arguments, string HotKey, string WorkingDirectory, string IconLocation)
        {
            // Сначала проверьте необходимые параметры:
            if (String.IsNullOrEmpty(TargetPath))
                throw new ArgumentNullException("TargetPath");
            if (String.IsNullOrEmpty(ShortcutFile))
                throw new ArgumentNullException("ShortcutFile");

            // Создайте экземпляр WshShellClass:
            var wshShell = new WshShellClass();

            // Создать объект ярлыка:
            IWshShortcut shorcut = (IWshShortcut)wshShell.CreateShortcut(ShortcutFile);

            // Назначьте свойства ярлыка:
            shorcut.TargetPath = TargetPath;
            shorcut.Description = Description;
            if (!String.IsNullOrEmpty(Arguments))
                shorcut.Arguments = Arguments;
            if (!String.IsNullOrEmpty(HotKey))
                shorcut.Hotkey = HotKey;
            if (!String.IsNullOrEmpty(WorkingDirectory))
                shorcut.WorkingDirectory = WorkingDirectory;

            shorcut.IconLocation = IconLocation;

            // Сохраните ярлык:
            shorcut.Save();
        }

        private bool FolderSearch()
        {
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(currentFolder);
            DirectoryInfo[] dirsInDirTemp = hdDirectoryInWhichToSearch.GetDirectories("*ВРЕМЕННО*.*");
            DirectoryInfo[] dirsInDirPrintPhoto = hdDirectoryInWhichToSearch.GetDirectories("*ПЕЧАТЬ ФОТО*.*");
            DirectoryInfo[] dirsInDirSublim = hdDirectoryInWhichToSearch.GetDirectories("*СУБЛИМАЦИЯ*.*");
            DirectoryInfo[] dirsInDirPhotomontage = hdDirectoryInWhichToSearch.GetDirectories("*ФОТОМОНТАЖ*.*");

            foreach (DirectoryInfo foundDir in dirsInDirTemp)
                folderTemp = foundDir.FullName;

            foreach (DirectoryInfo foundDir in dirsInDirPrintPhoto)
                folderPrintPhoto = foundDir.FullName;

            foreach (DirectoryInfo foundDir in dirsInDirSublim)
                folderSublim = foundDir.FullName;

            foreach (DirectoryInfo foundDir in dirsInDirPhotomontage)
                folderPhotomontage = foundDir.FullName;

            if (folderTemp == null || folderPrintPhoto == null || folderSublim == null || folderPhotomontage == null)
                return false;
            else
                return true;
        }

        private void btnCurrentFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.SelectedPath = Settings.Default.currentFolder;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                currentFolder = FBD.SelectedPath;
                tbxCurrentFolder.Text = currentFolder;
                Settings.Default.currentFolder = currentFolder;
                Settings.Default.Save();
            }
        }

        private void btnCreateShortcuts_Click(object sender, EventArgs e)
        {
            if (tbxCurrentFolder.Text != "")
            {
                Directory.CreateDirectory(iconsDir);

                using (FileStream stream = new FileStream(iconsDir + iconsArray[0], FileMode.Create))
                    Resources.month.Save(stream);

                using (FileStream stream = new FileStream(iconsDir + iconsArray[1], FileMode.Create))
                    Resources.temp.Save(stream);

                using (FileStream stream = new FileStream(iconsDir + iconsArray[2], FileMode.Create))
                    Resources.photoPrint.Save(stream);

                using (FileStream stream = new FileStream(iconsDir + iconsArray[3], FileMode.Create))
                    Resources.sublim.Save(stream);

                using (FileStream stream = new FileStream(iconsDir + iconsArray[4], FileMode.Create))
                    Resources.photomontage.Save(stream);

                Shortcut_Create();
            }
            else
            {
                DialogResult result = MessageBox.Show("Не указана текущая папка месяца.\nНажмите ОК, чтобы указать.", 
                    Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                    btnCurrentFolder.PerformClick();
            }
        }

        private void Shortcut_Create()
        {
            if (FolderSearch())
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string resultPath = currentFolder.Substring(currentFolder.LastIndexOf(" ")).Replace(" ", "");

                CreateShortcut(currentFolder, desktopPath + "\\" + resultPath + ".lnk", null, null, null, null, iconsDir + iconsArray[0]);
                CreateShortcut(folderTemp, desktopPath + "\\ВРЕМЕННО.lnk", null, null, null, null, iconsDir + iconsArray[1]);
                CreateShortcut(folderPrintPhoto, desktopPath + "\\ПЕЧАТЬ ФОТО.lnk", null, null, null, null, iconsDir + iconsArray[2]);
                CreateShortcut(folderSublim, desktopPath + "\\СУБЛИМАЦИЯ.lnk", null, null, null, null, iconsDir + iconsArray[3]);
                CreateShortcut(folderPhotomontage, desktopPath + "\\ФОТОМОНТАЖ.lnk", null, null, null, null, iconsDir + iconsArray[4]);
            }
            else
            {
                MessageBox.Show("Указана неправильная папка!",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
