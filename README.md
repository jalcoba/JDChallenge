# JDChallenge
N5Now challenge backend TL

This project implements three services to manage employee permissions: get permissions, request permission and modify permission. Each request to these services is enqueued in Kafka for request tracking. Additionally, each permission change is indexed in Elasticsearch. The project follows the CQRS pattern.

Getting Started
To run this project, you will need Docker installed. Simply clone the repository and run the docker-compose project:

Kafka Integration
Each request to the permission services is enqueued in Kafka for tracking purposes. The Kafka topics used are "permissionoperation" for request tracking.

Elasticsearch Integration
Each permission change is indexed in Elasticsearch for easy querying and auditing. The Elasticsearch index used is "permission".

Testing
The project includes a test suite for each endpoint and integration tests.
