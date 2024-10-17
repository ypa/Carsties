# Useful commands

## Building individual docker containers

```sh
docker compose build auction-svc
docker compose build search-svc
docker compose build identity-svc
...

```

## Running the containers

```sh
docker compose up -d
```

## Stopping the containers

```sh
docker compose down
```

## Debugging on VS Code

How to at [Udemy video](https://www.udemy.com/course/build-a-microservices-app-with-dotnet-and-nextjs-from-scratch/learn/lecture/39040800#notes)

## Creating local dev certificates

```sh
mkcert -install
mkdir devcerts
cd devcerts/
mkcert -key-file carsties.local.key -cert-file carsties.local.crt app.carsties.local api.carsties.local id.carsties.local
```
