===================================
docker instructions:
===================================

>> Check what process are running:
docker ps
docker ps --all

>> Killing a process
docker ps stop <<processId>>
docker container rm <<containerid>>

>>Check what images are in place
docker images

>> Kill/Delete images
docker rmi <<imageId>> --force

>>validate if the images is deleted sucessfully
docker images

Create Image and Container
===========================
For this use docker-compose
example:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
docker-compose -f ./docker-compose.yml -f ./docker-compose.override.yml up -d

Note: 
-f (file to use)
up (to make it start
-d (in detach mode)

At this stage run:
docker ps

example:
E:\MicroserLAB\LabDay2\dotnetConverted\MicroserviceProjectForDocker-main>docker ps
CONTAINER ID   IMAGE             COMMAND                  CREATED          STATUS          PORTS                  NAMES
ee65c02a74af   img-blogpostapi   "dotnet blogpost-api…"   35 seconds ago   Up 32 seconds   0.0.0.0:4001->80/tcp   microserviceprojectfordocker-main_blogpost-api_1
99de0a9f5350   img-eventbusapi   "dotnet eventbus-api…"   35 seconds ago   Up 33 seconds   0.0.0.0:4005->80/tcp   microserviceprojectfordocker-main_eventbus-api_1

this indicates both containers are up with port 4001 and 4005 to browse as: 
http://localhost:4001/swagger/index.html
http://localhost:4005/swagger/index.html

How you get port: 4001 and 4005
Ans: use port fwd in docker-compose.override.yml as
--------------- 
ports:
       - "4001:80"
---------------

For more container, keep adding DockerFile and then configure in docker-compose{}.yml also.
---------------------------------------------------------------------------------------------



Finally:
E:\MicroserLAB\LabDay2\dotnetConverted\MicroserviceProjectForDocker-main>docker images
REPOSITORY           TAG       IMAGE ID       CREATED         SIZE
img-eventbusapi      latest    1252ce059d67   7 minutes ago   212MB
img-blogcommentapi   latest    8cd449e915f1   7 minutes ago   212MB
img-blogpostapi      latest    8cd449e915f1   7 minutes ago   212MB
img-querymapi        latest    8cd449e915f1   7 minutes ago   212MB

E:\MicroserLAB\LabDay2\dotnetConverted\MicroserviceProjectForDocker-main>docker ps
CONTAINER ID   IMAGE                COMMAND                  CREATED          STATUS          PORTS                  NAMES
acf647974be1   img-eventbusapi      "dotnet eventbus-api…"   20 seconds ago   Up 16 seconds   0.0.0.0:4005->80/tcp   microserviceprojectfordocker-main_eventbus-api_1
45b8cbc126ab   img-blogpostapi      "dotnet blogpost-api…"   20 seconds ago   Up 16 seconds   0.0.0.0:4001->80/tcp   microserviceprojectfordocker-main_blogpost-api_1
66bdc5e8521c   img-querymapi        "dotnet blogpost-api…"   20 seconds ago   Up 17 seconds   0.0.0.0:4003->80/tcp   microserviceprojectfordocker-main_queryms-api_1
0b7f2c2d7ad2   img-blogcommentapi   "dotnet blogpost-api…"   20 seconds ago   Up 16 seconds   0.0.0.0:4002->80/tcp   microserviceprojectfordocker-main_blogcomment-api_1



