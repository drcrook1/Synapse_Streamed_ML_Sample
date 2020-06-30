cd DataProducer
dotnet publish -c Release
docker build -t synapsedataproducer .
docker run --name synapsedataproducer --env-file ./dev.env synapsedataproducer
cd ..