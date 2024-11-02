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

# get namespaces
kubectl get namespaces

# get pods
kubectl get pods
kubectl get pods --namespace ingress-nginx

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

# stop pods/ delete deployments
kubectl delete deployment identity-svc
kubectl delete deployment auction-svc
kubectl delete deployment mongo
...
```

### Installing SSL for K8S ingress

```sh
# from inside infra/devcerts
mkcert -key-file server.key -cert-file server.crt app.carsties.local api.carsties.local id.carsties.local
# then create kube secrets
kubectl create secret tls carsties-app-tls --key server.key --cert server.crt
kubectl get secrets

# Update ingress-svc.yml file with corresponding values from above
# then apply the changes
kubectl apply -f ingress-svc.yml
```

## Deploy services to local K8S

On Docker Desktop settings make sure Kubernetes is enabled and is running.

```sh
cd infra/ingress
# Deplpy ingress
kubectl apply -f ingress-depl.yml
# Verify ingress-controller is running
kubectl get pods --namespace ingress-nginx
NAME                                        READY   STATUS      RESTARTS   AGE
ingress-nginx-admission-create-dxlpx        0/1     Completed   0          6d
ingress-nginx-admission-patch-ct8m9         0/1     Completed   1          6d
ingress-nginx-controller-6568cc55cd-6d9hq   1/1     Running     0          4m54s

# Deploy services
cd infra/K8S/
kubectl apply -f .
# Verify all services are running
NAME                            READY   STATUS    RESTARTS   AGE
auction-svc-d95566ddc-hk4xr     1/1     Running   0          88s
bid-svc-57b6f4b5f5-48chz        1/1     Running   0          88s
gateway-svc-8574cf4c9c-nh5c2    1/1     Running   0          88s
identity-svc-68d75d5f49-82g9r   1/1     Running   0          88s
mongo-7d8646c75f-gglgf          1/1     Running   0          87s
notify-svc-5c47d5c6dc-fd4gz     1/1     Running   0          87s
postgres-9cbd95468-hj5kd        1/1     Running   0          87s
rabbitmq-5b9545d6c4-txxs2       1/1     Running   0          87s
search-svc-f5f94b885-sxxs6      1/1     Running   0          87s
webapp-svc-66fd5f8474-fqvrb     1/1     Running   0          86s
```

Visit local url: https://app.carsties.local
