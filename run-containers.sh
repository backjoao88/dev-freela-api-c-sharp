#!/bin/sh
docker-compose down
docker container stop $(docker container ls -qa) --remove-orphans
docker-compose up -d --build