using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCommitHook {
    public abstract class PreCommitCheck {
        protected string RepositoryPath { get; private set; }
        protected string TransactionName { get; private set; }

        protected PreCommitCheck(string repositoryPath, string transactionName)
        {
            RepositoryPath = repositoryPath;
            TransactionName = transactionName;
        }

        public abstract string GetCheckResult();
    }
}
