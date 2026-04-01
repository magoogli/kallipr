• How you would run this in Azure or AWS (key services and how components fit together)

I have no experience with Azure or AWS, but I have used a kubernetes cluster as well as the Google Cloud and I assume those concepts would translate well to other cloud platforms. First step to make this production ready would be to ensure the backend is containerized. Once a docker image can be made in CI, I would ensure that it gets uploaded to an artifact registry somewhere on the Cloud platform. In Google Cloud I would then probably use Cloud Run which is just an abstraction over a kubernetes like environment which allows you to deploy containers, scale them dynamically and split traffic between different versions. I would then enable and configure a load balancer to route traffic to my spun up container. I would assign a static IP to the load balancer and register a DNS record to so that traffic hitting a public URL would corrrectly route to the load balancer and it would route to my backend. I could also use a pure kubernetes environment if I really needed too. I would also use whatever secrets management the platform provided so that I could inject secrets into the container via environment variables in a secure way.

• How you would isolate multiple customers’ data and requests

So in a multi tenant setup you could spin up a database per customer - that is the safest and least likely for data to leak between tenants, but it is also the most complex to manage. The approach of segregating all data on a tenantid inside the tables in a db also works, but It must be extensively tested to ensure data is never leaked. In a production system I would hope that the Identity Provider would be able to add a Claim to a Auth Token which would specify the TenantId. The approach of setting a

• How you would handle higher event volumes and protect the system during bursts

In a system like this I would definitely use some kind of queue to separate the devices sending the events from actually ingesting them into the database. Kafka is a perfect fit here and designed to handle high volumes of event data.

• A simple CI/CD approach from commit to deployment with automated checks you would add

• How you would evolve the data model and deploy changes safely over time
