To run docker image under a container named "webserver"

docker run -d -p 8090:8090 --name webserver  ananthrs/hello-jenkins-web
8097 is the localhost port


To list the running images
docker ps

To stop a docker image
docker stop {containerid}

To remove a named docker container

docker container rm webserver

To stop and remove the container
docker container rm webserver -f

Container logs
docker container logs 964f46921b5a


To look like processes running within a container:

docker exec 964f46921b5a ps -f

docker-compose up

docker run --name jira -v E:/demo/jira/home:/opt/jira/home -v E:/demo/jira/install:/opt/jira/install -e JIRA_HOME=/opt/jira/home -e JIRA_INSTALL=/opt/jira/install --detach --publish 8010:8080 cptactionhank/atlassian-jira:latest

docker stop --time=30 jira

docker start jira