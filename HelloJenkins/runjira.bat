docker run --name jira -v E:/demo/jira/home:/opt/jira/home -v E:/demo/jira/install:/opt/jira/install -e JIRA_HOME=/opt/jira/home -e JIRA_INSTALL=/opt/jira/install --detach --publish 8010:8080 cptactionhank/atlassian-jira:latest