echo "Starting Setup..."
export POSTGRES_USER=dev
export POSTGRES_PASSWORD=devpsw
docker-compose -f docker/docker-compose.yml up --build
echo "Init Containers! 🐋"
echo "Setup Completed! 🚀"