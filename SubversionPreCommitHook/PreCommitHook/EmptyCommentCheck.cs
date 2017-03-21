using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCommitHook {
    public class EmptyCommentCheck : PreCommitCheck {
        public EmptyCommentCheck(string repositoryPath, string transactionName)
          : base(repositoryPath, transactionName)
        {
        }

        public override string GetCheckResult()
        {
            string comment = SvnlookFacade.GetComment(RepositoryPath, TransactionName);
            return string.IsNullOrWhiteSpace(comment) ? "Please write a comment describing the changes you're committing." : string.Empty;
        }
    }
}
