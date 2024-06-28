using CommandPrompt_CSharp.DublicateFileCleaner;
using CommandPrompt_CSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace CommandPrompt_CSharp
{
    public static class CommandManager
    {
        private static List<string> _commands = new List<string>()
        {
            "cd", "showDirs", "createFile", "createDir",
            "moveFile", "moveDir", "deleteFile", "deleteDir",
            "cleanClones", "cls", "showFiles", "showCommands", "cloneFile",
            "cloneDir"
        };

        private static string _currentPath = "C:/";

        public static void OperateCommand(string command)
        {
            switch (command)
            {
                case "cd":
                    ChangeDirectory();
                    break;
                case "showDirs":
                    ShowDirectories();
                    break;
                case "createFile":
                    CreateFile();
                    break;
                case "createDir":
                    CreateDirectory();
                    break;
                case "moveFile":
                    MoveFile();
                    break;
                case "moveDir":
                    MoveDirectory();
                    break;
                case "deleteFile":
                    DeleteFile();
                    break;
                case "deleteDir":
                    DeleteDirectory();
                    break;
                case "cleanClones":
                    CleanClones();
                    break;
                case "cls":
                    ConsoleClear();
                    break;
                case "showCommands":
                    ShowCommands();
                    break;
                case "showFiles":
                    ShowFiles();
                    break;
                case "cloneFile":
                    CloneFile();
                    break;
                case "cloneDir":
                    CloneDir();
                    break;
                default:
                    Logger.WriteLine("Unknown command", ConsoleColor.Red);
                    break;
            }
        }

        private static void ChangeDirectory()
        {
            try
            {
                Logger.Write("Enter new path: ", ConsoleColor.Yellow);
                string newPath = Console.ReadLine();
                if (Directory.Exists(newPath))
                {
                    _currentPath = newPath;
                    Logger.WriteLine($"Changed directory to: {_currentPath}", ConsoleColor.Green);
                }
                else
                {
                    throw new DirectoryNotFoundException("Invalid path");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to change directory", ex);
            }
        }

        private static void ShowDirectories()
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(_currentPath, "", SearchOption.AllDirectories))
                {
                    Logger.WriteLine(dir, ConsoleColor.Green);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to show directories", ex);
            }
        }

        private static void CreateFile()
        {
            try
            {
                Logger.Write("Enter file name: ", ConsoleColor.Yellow);
                string fileName = Console.ReadLine();
                string filePath = Path.Combine(_currentPath, fileName);
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    Logger.WriteLine("File created", ConsoleColor.Green);
                }
                else
                {
                    Logger.WriteLine("File already exists", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to create file", ex);
            }
        }

        private static void CreateDirectory()
        {
            try
            {
                Logger.Write("Enter directory name: ", ConsoleColor.Yellow);
                string dirName = Console.ReadLine();
                string dirPath = Path.Combine(_currentPath, dirName);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    Logger.WriteLine("Directory created", ConsoleColor.Green);
                }
                else
                {
                    Logger.WriteLine("Directory already exists", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to create directory", ex);
            }
        }
        private static void DeleteFile()
        {
            try
            {
                Logger.Write("Enter file path: ", ConsoleColor.Yellow);
                string filePath = Console.ReadLine();
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Logger.WriteLine("File deleted", ConsoleColor.Green);
                }
                else
                {
                    Logger.WriteLine("File not found", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to delete file", ex);
            }
        }

        private static void DeleteDirectory()
        {
            try
            {
                Logger.Write("Enter directory path: ", ConsoleColor.Yellow);
                string dirPath = Console.ReadLine();
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                    Logger.WriteLine("Directory deleted", ConsoleColor.Green);
                }
                else
                {
                    Logger.WriteLine("Directory not found", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to delete directory", ex);
            }
        }

        private static void CleanClones()
        {
            try
            {
                var getFileHashes = new GetFileHashes();
                var filesHashes = getFileHashes.GetAllFilesHashes(_currentPath, SearchOption.AllDirectories);
                FileManager.DeleteDublicateFiles(filesHashes);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to clean clones", ex);
            }
        }

        private static void ConsoleClear()
        {
            try
            {
                Console.Clear();
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to clear console", ex);
            }
        }

        private static void ShowCommands()
        {
            try
            {
                foreach (var command in _commands)
                {
                    Logger.Write($"'{command}' ", ConsoleColor.DarkMagenta);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to show commands", ex);
            }
        }

        private static void ShowFiles()
        {
            try
            {
                foreach (string file in Directory.GetFiles(_currentPath, "", SearchOption.AllDirectories))
                {
                    Logger.WriteLine(file, ConsoleColor.Green);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to show files", ex);
            }
        }

        private static void CloneFile()
        {
            try
            {
                Logger.Write("Enter path to file, which you wanna clone: ", ConsoleColor.Yellow);
                string filePath = Console.ReadLine();
                if (!File.Exists(filePath))
                {
                    Logger.WriteLine("File not found", ConsoleColor.Red);
                    return;
                }

                int fileCopiesCount = 0;
                string fileDirectory = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileName(filePath);
                string newFilePath;

                do
                {
                    newFilePath = Path.Combine(fileDirectory, $"Copy{fileCopiesCount}-{fileName}");
                    fileCopiesCount++;
                } while (File.Exists(newFilePath));

                File.Copy(filePath, newFilePath);
                Logger.WriteLine("File is cloned", ConsoleColor.Yellow);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to clone file", ex);
            }
        }

        private static void CloneDir()
        {
            try
            {
                Logger.Write("Enter path to directory, which you wanna clone: ", ConsoleColor.Yellow);
                string dirPath = Console.ReadLine();
                if (!Directory.Exists(dirPath))
                {
                    Logger.WriteLine("Directory not found", ConsoleColor.Red);
                    return;
                }

                int dirCopiesCount = 0;
                string parentDirectory = Path.GetDirectoryName(dirPath);
                string dirName = Path.GetFileName(dirPath);
                string newDirPath;

                do
                {
                    newDirPath = Path.Combine(parentDirectory, $"Copy{dirName}-{dirCopiesCount}");
                    dirCopiesCount++;
                } while (Directory.Exists(newDirPath));

                CopyDirectory(dirPath, newDirPath);
                Logger.WriteLine("Directory is cloned", ConsoleColor.Yellow);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to clone directory", ex);
            }
        }

        private static void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile);
            }

            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectory(dir, destSubDir);
            }

        }

        private static void MoveFile()
        {
            try
            {
                Logger.Write("Enter source file path: ", ConsoleColor.Yellow);
                string sourceFilePath = Console.ReadLine();
                Logger.Write("Enter destination file path: ", ConsoleColor.Yellow);
                string destinationFilePath = Console.ReadLine();

                if (File.Exists(sourceFilePath))
                {
                    if (!File.Exists(destinationFilePath))
                    {
                        File.Move(sourceFilePath, destinationFilePath);
                        Logger.WriteLine("File moved successfully", ConsoleColor.Green);
                    }
                    else
                    {
                        Logger.WriteLine("Destination file already exists", ConsoleColor.Red);
                    }
                }
                else
                {
                    Logger.WriteLine("Source file not found", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to move file", ex);
            }
        }

        private static void MoveDirectory()
        {
            try
            {
                Logger.Write("Enter source directory path: ", ConsoleColor.Yellow);
                string sourceDirPath = Console.ReadLine();
                Logger.Write("Enter destination directory path: ", ConsoleColor.Yellow);
                string destinationDirPath = Console.ReadLine();

                if (Directory.Exists(sourceDirPath))
                {
                    if (!Directory.Exists(destinationDirPath))
                    {
                        Directory.Move(sourceDirPath, destinationDirPath);
                        Logger.WriteLine("Directory moved successfully", ConsoleColor.Green);
                    }
                    else
                    {
                        Logger.WriteLine("Destination directory already exists", ConsoleColor.Red);
                    }
                }
                else
                {
                    Logger.WriteLine("Source directory not found", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                throw new Exception("Failed to move directory", ex);
            }
        }
    }
}
