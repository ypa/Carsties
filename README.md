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

## K8S

Useful kubectl commands:

```sh
# deploy the service
kubectl apply -f auction-depl.yml

# Apply the configs
kubectl apply -f config.yml

# get pods
kubectl get pods

# describe the pod
kubectl describe pod postgres-9cbd95468-grdkc

# get services
kubectl get services

# get deployments
kubectl get deployments

# restarting the deployed service
kubectl rollout restart deployment auction-svc

# get namespaces
kubectl get namespaces
```
