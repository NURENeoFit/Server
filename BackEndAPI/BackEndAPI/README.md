# NeoFit Backend API

## Настройка локальной базы данных

### Предварительные требования
1. Установленный .NET 8.0 SDK
2. Установленный SQL Server (можно использовать LocalDB)
3. Visual Studio 2022 или Visual Studio Code

### Шаги по настройке базы данных

1. **Установка SQL Server LocalDB**
   - Если у вас еще не установлен SQL Server LocalDB, вы можете установить его через Visual Studio Installer
   - Или скачать SQL Server Express LocalDB с официального сайта Microsoft

2. **Клонирование репозитория**
   ```bash
   git clone [URL вашего репозитория]
   cd BackEndAPI
   ```

3. **Проверка строки подключения**
   - Откройте файл `appsettings.json`
   - Убедитесь, что строка подключения соответствует вашей локальной конфигурации:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NeoFitDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. **Установка инструментов Entity Framework Core**
   ```bash
   dotnet tool install --global dotnet-ef
   ```

5. **Создание миграции**
   ```bash
   dotnet ef migrations add InitialCreate
   ```

6. **Применение миграции к базе данных**
   ```bash
   dotnet ef database update
   ```

### Проверка установки

1. Запустите приложение:
   ```bash
   dotnet run
   ```

2. Откройте Swagger UI по адресу: `https://localhost:5001/swagger` или `http://localhost:5000/swagger`

### Возможные проблемы и их решения

1. **Ошибка подключения к базе данных**
   - Убедитесь, что SQL Server LocalDB запущен
   - Проверьте строку подключения в `appsettings.json`
   - Убедитесь, что у вас есть права на создание базы данных

2. **Ошибка при выполнении миграции**
   - Удалите папку Migrations (если она существует)
   - Удалите базу данных NeoFitDB (если она существует)
   - Повторите шаги создания и применения миграции

3. **Проблемы с зависимостями**
   - Выполните команду `dotnet restore` для восстановления всех пакетов
   - Убедитесь, что все необходимые пакеты NuGet установлены

### Дополнительная информация

- Для просмотра структуры базы данных можно использовать SQL Server Management Studio (SSMS)
- Для отладки SQL-запросов можно использовать встроенный инструмент в Visual Studio
- При необходимости можно изменить строку подключения для использования полноценного SQL Server вместо LocalDB 