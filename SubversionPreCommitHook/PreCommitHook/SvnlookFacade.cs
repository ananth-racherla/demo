using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace PreCommitHook {
    public static class SvnlookFacade {
        public static string GetComment(string repositoryPath, string transactionName)
        {
            string commandLineArguments = string.Format("log --transaction {0} \"{1}\"", transactionName, repositoryPath);
            return GetSvnlookOutput(commandLineArguments) ?? string.Empty;
        }

        private static string GetSvnlookOutput(string commandLineArguments)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"svnlook.exe";
            process.StartInfo.Arguments = commandLineArguments;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }

        public static IEnumerable<string> GetChangedFileNames(string repositoryPath, string transactionName)
        {
            string commandLineArguments = string.Format("changed --transaction {0} \"{1}\"", transactionName, repositoryPath);
            string output = GetSvnlookOutput(commandLineArguments);
            string[] fileNames = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return fileNames.Select(RemoveChangeDescriptorPrefix).ToArray();
        }

        private static string RemoveChangeDescriptorPrefix(string fileName)
        {
            // Prefix denoting "item added", "item deleted", "file contents changed",
            // "item properties changed", "file contents and properties changed"
            string[] changeDescriptors = new[] { "A ", "D ", "U ", "_U", "UU" };
            foreach (string changeDescriptor in changeDescriptors) {
                if (fileName.StartsWith(changeDescriptor))
                    return fileName.Substring(changeDescriptor.Length).Trim();
            }
            return fileName;
        }

        public static string GetFileContents(string repositoryPath, string transactionName, string fileName)
        {
            string commandLineArguments = string.Format("cat --transaction {0} \"{1}\" \"{2}\"", transactionName, repositoryPath, fileName);
            return GetSvnlookOutput(commandLineArguments);
        }
    }
}