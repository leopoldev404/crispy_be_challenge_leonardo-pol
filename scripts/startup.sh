echo "Starting Setup..."
echo "Setting Environment Variables..."
export POSTGRES_USERNAME=dev
export POSTGRES_PASSWORD=devpsw
export SERVICE_API_KEY=key
docker-compose -f docker/docker-compose.yml up --build
echo "Init Containers! 🐋"
echo "Setup Completed! 🚀"