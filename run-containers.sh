#!/bin/sh
docker-compose down
docker container stop $(docker container ls -qa) --remove-orphans
docker images rmi $(docker images -q)
docker-compose up -d --build