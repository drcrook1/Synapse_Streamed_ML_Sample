cd DataProducer
dotnet publish -c Release
docker stop synapsedataproducer
docker rm synapsedataproducer
docker build -t synapsedataproducer .
docker run --name synapsedataproducer --env-file ./dev.env synapsedataproducer
cd ..