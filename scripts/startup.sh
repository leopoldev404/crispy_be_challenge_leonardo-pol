echo "Starting Setup..."

echo "Setting Environment Variables..."
export POSTGRES_USERNAME=dev
export POSTGRES_PASSWORD=devpsw
export AUTHENTICATION_APIKEY=df5cb460a71dc6d56ad068cafa6c9280
export DATABASESETTINGS_CONNECTIONSTRING="Host=todo-database;Port=5432;Database=todo;Username=dev;Password=devpsw;"
echo "Done!"

echo "Initializing Docker Containers..."
docker-compose -f docker/docker-compose.yml up --build -d
echo "Done!"

echo "Setup Completed! 🚀"
echo "Open your browser on port 4000 and Enjoy!"