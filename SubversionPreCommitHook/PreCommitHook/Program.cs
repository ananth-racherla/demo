///Adopted from: https://reasoncodeexample.com/2012/09/24/subversion-hooks-in-c-sharp/
using System;
using System.Text;
using System.Text.RegularExpressions;
namespace PreCommitHook {
    public class PreCommitHook {
        private const string SkipValidationPhrase = "force commit";
        private enum ValidationResult {
            Succes = 0,
            Failed = 1,
            InvalidParameters = 2,
            Exception = 3
        }

        public static int Main(string[] args)
        {
            if (args.Length < 2) {
                Console.Error.WriteLine("Expected at least 2 parameters (repository path and transaction name).");
                return (int)ValidationResult.InvalidParameters;
            }

            try {
                string repositoryPath = args[0];
                string transactionName = args[1];

                if (ShouldSkipValidation(repositoryPath, transactionName))
                    return (int)ValidationResult.Succes;

                string checkResults = RunPreCommitChecks(repositoryPath, transactionName);
                if (string.IsNullOrEmpty(checkResults))
                    return (int)ValidationResult.Succes;

                Console.Error.WriteLine(checkResults);
                Console.Error.WriteLine();
                Console.Error.WriteLine("To commit changes without validation, enter \"{0}\" as part of the comment/log message.", SkipValidationPhrase);
                return (int)ValidationResult.Failed;
            } catch (Exception ex) {
                Console.Error.WriteLine(ex.ToString());
                return (int)ValidationResult.Exception;
            }
        }

        private static bool ShouldSkipValidation(string repositoryPath, string transactionName)
        {
            string comment = SvnlookFacade.GetComment(repositoryPath, transactionName);
            return Regex.IsMatch(comment, SkipValidationPhrase, RegexOptions.IgnoreCase);
        }

        private static string RunPreCommitChecks(string repositoryPath, string transactionName)
        {
            var preCommitChecks = new PreCommitCheck[] {
                //new EmptyCommentCheck(repositoryPath, transactionName),
                new JiraCommentCheck(repositoryPath, transactionName)
            };

            StringBuilder checkResults = new StringBuilder();
            foreach (PreCommitCheck preCommitCheck in preCommitChecks) {
                checkResults.AppendLine(preCommitCheck.GetCheckResult());
            }
            return checkResults.ToString().Trim();
        }
    }
}