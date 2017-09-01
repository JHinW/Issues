#Tomcat

**connector**
1. connector will define how service get request  
(you can compare connector with the concept of "coommunicationListener" in Service Fabric)


```csharp
        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[0];
        }
```


**container**  
1. container will define how to process data from request
A Container is an object that can execute requests received from a client, and return responses based on those requests. A Container may optionally support a pipeline of Valves that process the request in an order configured at runtime, by implementing the Pipeline interface as well.

2. you can deeply understand it if you know Microsoft Azure Service Fabric


```csharp
        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                // do your logic
            }
}
```


