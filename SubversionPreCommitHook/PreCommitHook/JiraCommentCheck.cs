using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace PreCommitHook {
    public class JiraCommentCheck : PreCommitCheck {
        public JiraCommentCheck(string repositoryPath, string transactionName)
          : base(repositoryPath, transactionName)
        {
        }

        public override string GetCheckResult()
        {
            string comment = SvnlookFacade.GetComment(RepositoryPath, TransactionName);

            if (string.IsNullOrWhiteSpace(comment))
                return "Please write a comment describing the changes you're committing.";

            var matches = Regex.Matches(comment, @"^(?<TicketNum>\w{3}-\d+)\s+(?<Message>.+?)$", RegexOptions.Multiline);

            if(matches.Count != 1) {
                return "Please include a Jira issue ticket number and a log message.";
            }

            foreach (Match match in matches) {
                Console.WriteLine(match.Value);

                if(string.IsNullOrWhiteSpace(match.Groups["TicketNum"].Value))
                    return "Please include a Jira issue ticket number in the message";
            }

            return string.Empty;
        }
    }
}
