cd DataProducer
dotnet publish -c Release
docker build -t synapsedataproducer .
cd ..