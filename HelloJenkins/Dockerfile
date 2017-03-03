FROM mono:4.2.3.4
RUN mkdir -p release/HelloJenkinsWeb
COPY HelloJenkinsWeb/bin/Release/* /release/HelloJenkinsWeb/
EXPOSE 8090
ENTRYPOINT [ "mono",  "release/HelloJenkinsWeb/HelloJenkinsWeb.exe" ]
