echo "Starting Cleanup..."
echo "Shutting Down Containers and Volumes ⛔"
docker-compose -f docker/docker-compose.yml down
echo "Cleanup Completed! ✅"