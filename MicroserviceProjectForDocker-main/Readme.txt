===================================
docker instructions:
===================================

github url: https://github.com/Rimbik/techlabs-assignment-ms

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






