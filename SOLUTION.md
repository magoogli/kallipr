# How you would run this in Azure or AWS (key services and how components fit together)

I have no experience with Azure or AWS, but I have used a Kubernetes cluster as well as Google Cloud, and I assume those concepts would translate well to other cloud platforms. The first step to make this production-ready would be to ensure the backend is containerized. Once a Docker image can be built in CI, I would ensure that it gets uploaded to an artifact registry somewhere on the cloud platform.

In Google Cloud, I would probably use Cloud Run, which is an abstraction over a Kubernetes-like environment that allows you to deploy containers, scale them dynamically, and split traffic between different versions. I would then enable and configure a load balancer to route traffic to my spun-up container. I would assign a static IP to the load balancer and register a DNS record so that traffic hitting a public URL would correctly route to the load balancer, which would then route to my backend. I could also use a pure Kubernetes environment if I really needed to. I would also use whatever secrets management the platform provides so that I could inject secrets into the container via environment variables in a secure way.

# How you would isolate multiple customers’ data and requests

So in a multi-tenant setup, you could spin up a database per customer. That is the safest and least likely approach for data to leak between tenants, but it is also the most complex to manage. The approach of segregating all data by a tenantId inside the tables in a database also works, but it must be extensively tested to ensure data is never leaked.

In a production system, I would expect the Identity Provider to add a claim to an auth token that specifies the TenantId.

# How you would handle higher event volumes and protect the system during bursts

In a system like this, I would definitely use some kind of queue to separate the devices sending the events from actually ingesting them into the database. Kafka is a perfect fit here and is designed to handle high volumes of events. This would mean devices would be able to immediately write their events to Kafka, regardless of the load on the database or backend. The backend would then be able to read events off Kafka at a rate it can handle. This decoupling is key to a system like this.

# A simple CI/CD approach from commit to deployment with automated checks you would add

I would configure CI to always run the unit and integration tests for any pull request to the develop branch. This is vital to ensure any code merged into the development branch is tested and doesn’t break anything.

For continuous delivery, as soon as a request is merged, a Docker image for the backend would be built and tagged with the Git commit hash. This image would be pushed to a registry and deployed to a QA environment in Kubernetes, Cloud Run, or an equivalent. This would mean that as soon as there is any change to the development branch, there is an environment where it is live.

# How you would evolve the data model and deploy changes safely over time

In an ideal world, any change to the data model would be backwards compatible, i.e., properties are only ever added to the data models, which in turn means migrations only ever add columns to the corresponding tables. This is fairly safe and means existing data does not need to be moved around or mutated in any way.

As soon as breaking changes are introduced, it means migrations that mutate or move data around are necessary. This is much harder to manage, especially at scale, without locking up tables or turning off the system (or a portion of it) for a period of time.
