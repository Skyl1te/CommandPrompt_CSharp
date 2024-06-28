# CommandPrompt_CSharp

## Overview
CommandPrompt_CSharp is a command-line tool for managing files and directories with various operations. It includes functionalities to create, move, delete, clone files and directories, and clean duplicate files based on their hashes.

## Features
- **Change Directory (`cd`)**: Change the current working directory.
- **Show Directories (`showDirs`)**: List all directories within the current directory.
- **Create File (`createFile`)**: Create a new file in the current directory.
- **Create Directory (`createDir`)**: Create a new directory in the current directory.
- **Move File (`moveFile`)**: Move a file from one location to another.
- **Move Directory (`moveDir`)**: Move a directory from one location to another.
- **Delete File (`deleteFile`)**: Delete a specified file.
- **Delete Directory (`deleteDir`)**: Delete a specified directory.
- **Clean Clones (`cleanClones`)**: Remove duplicate files within the current directory.
- **Clear Console (`cls`)**: Clear the console screen.
- **Show Commands (`showCommands`)**: Display a list of all available commands.
- **Show Files (`showFiles`)**: List all files within the current directory.
- **Clone File (`cloneFile`)**: Create a duplicate of a specified file.
- **Clone Directory (`cloneDir`)**: Create a duplicate of a specified directory.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/CommandPrompt_CSharp.git
   cd CommandPrompt_CSharp
   ```
2. Build the project:
   ```sh
   dotnet build
   ```

### Usage
1. Navigate to the project directory and run the application:
   ```sh
   dotnet run
   ```
2. Enter commands as prompted. Type `showCommands` to see the list of available commands.

## Commands

### `cd`
Change the current working directory.
```sh
cd
```
Prompts for the new path.

### `showDirs`
List all directories within the current directory.
```sh
showDirs
```

### `createFile`
Create a new file in the current directory.
```sh
createFile
```
Prompts for the file name.

### `createDir`
Create a new directory in the current directory.
```sh
createDir
```
Prompts for the directory name.

### `moveFile`
Move a file from one location to another.
```sh
moveFile
```
Prompts for the source file path and the destination file path.

### `moveDir`
Move a directory from one location to another.
```sh
moveDir
```
Prompts for the source directory path and the destination directory path.

### `deleteFile`
Delete a specified file.
```sh
deleteFile
```
Prompts for the file path.

### `deleteDir`
Delete a specified directory.
```sh
deleteDir
```
Prompts for the directory path.

### `cleanClones`
Remove duplicate files within the current directory.
```sh
cleanClones
```

### `cls`
Clear the console screen.
```sh
cls
```

### `showCommands`
Display a list of all available commands.
```sh
showCommands
```

### `showFiles`
List all files within the current directory.
```sh
showFiles
```

### `cloneFile`
Create a duplicate of a specified file.
```sh
cloneFile
```
Prompts for the file path.

### `cloneDir`
Create a duplicate of a specified directory.
```sh
cloneDir
```
Prompts for the directory path.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
