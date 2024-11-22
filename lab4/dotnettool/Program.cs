using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;
using LabLibrary;
namespace LabConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "labs",
                Description = "tool for run 1 2 3 labs"
            };

            app.Command("version", versionCmd =>
            {
                versionCmd.Description = "Display version info";
                versionCmd.OnExecute(() =>
                {
                    Console.WriteLine("Author: Adzhiiev A");
                    Console.WriteLine("Version: 1.0.0");
                    return 0;
                });
            });

            app.Command("run", runCmd =>
            {
                runCmd.Description = "Run a lab practical (lab1, lab2, or lab3)";

                var labOption = runCmd.Option(
                    "-l|--lab <LAB>",
                    "Lab number (lab1, lab2, lab3)",
                    CommandOptionType.SingleValue);

                var inputOption = runCmd.Option(
                    "-I|--input <INPUT>",
                    "Input file path",
                    CommandOptionType.SingleValue);

                var outputOption = runCmd.Option(
                    "-o|--output <OUTPUT>",
                    "Output file path",
                    CommandOptionType.SingleValue);

                runCmd.OnExecute(() =>
                {
                    string lab = labOption.Value();
                    string inputPath = inputOption.HasValue() ? inputOption.Value() : GetFilePath("INPUT.TXT");
                    string outputPath = outputOption.HasValue() ? outputOption.Value() : Path.Combine(Path.GetDirectoryName(inputPath), "OUTPUT.TXT");

                    if (lab == null)
                    {
                        Console.WriteLine("error please enter the lab number (lab1 or lab2 or lab3)");
                        return 1;
                    }

                    Console.WriteLine($"runing {lab} with input  {inputPath} and output  {outputPath}");

                    switch (lab)
                    {
                        case "lab1":
                            LabRunner.RunLab1(inputPath, outputPath);
                            break;
                        case "lab2":
                            LabRunner.RunLab2(inputPath, outputPath);
                            break;
                        case "lab3":
                            LabRunner.RunLab3(inputPath, outputPath);
                            break;
                        default:
                            Console.WriteLine("type lab1 or lab2 or lab3");
                            return 1;
                    }

                    Console.WriteLine("successfuly complete");
                    return 0;
                });
            });

            app.Command("set-path", setPathCmd =>
            {
                setPathCmd.Description = "Set the path for input and output file";

                var pathOption = setPathCmd.Option(
                    "-p|--path <PATH>",
                    "Path to input and output files",
                    CommandOptionType.SingleValue);

                setPathCmd.OnExecute(() =>
                {
                    string path = pathOption.Value();
                    if (string.IsNullOrEmpty(path))
                    {
                        Console.WriteLine("Error: Please provide a valid path ");
                        return 1;
                    }

                Environment.SetEnvironmentVariable("LAB_PATH", path);
                Console.WriteLine($"LAB_PATH set to: {path}");
                    return 0;
                });
            });
            app.Execute(args);
        }

        private static string GetFilePath(string fileName)
        {
            string pathFromArgs = Environment.GetEnvironmentVariable("LAB_PATH");
            if (!string.IsNullOrEmpty(pathFromArgs))
            {
                string path = Path.Combine(pathFromArgs, fileName);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string defaultPath = Path.Combine(homeDirectory, fileName);
            if (File.Exists(defaultPath))
            {
                return defaultPath;
            }
            throw new FileNotFoundException($"File '{fileName}' not found");
        }
    }
}
