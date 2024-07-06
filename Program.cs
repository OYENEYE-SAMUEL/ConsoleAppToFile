// See https://aka.ms/new-console-template for more information
using ConsoleAppFishFarminngToFile.FileMananger;
using ConsoleAppFishFarminngToFile.Menu;


FileService fileService= new FileService();
fileService.CreateFile();
MainMenu mainMenu= new MainMenu();
mainMenu.Menu();
Console.ReadKey();