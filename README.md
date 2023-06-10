# HotelManagerSystem

Технологии

CQRS
Mediator pattern
SMTP-сервис
PostgreSQL

Установка и запуск

Склонируй репозиторий на локальную машину.
Убедись, что установлены все зависимости, необходимые для проекта.
Установи и настрой базу данных PostgreSQL.
Windows: Скачай и установи PostgreSQL, следуя официальной инструкции по ссылке здесь (https://www.postgresql.org/download/windows/).
Mac: Установи PostgreSQL с помощью Homebrew командой: brew install postgresql.
Linux: Воспользуйся документацией своего дистрибутива Linux для установки PostgreSQL.
Внеси необходимые настройки конфигурации, такие как подключение к базе данных, SMTP-серверу и другие параметры.
Запусти проект, выполнив команду dotnet run в корневой папке проекта.

Пример настройки SMTP-сервиса
 "SMTPConfig": {
    "ServerAddress": "smtp.gmail.com",
    "Port": 587,
    "SenderEmail": "slarysit@gmail.com",
    "SenderPassword": "asdasdajlj2ljjda",
    "EnableSsl": true,
    "IsBodyHtml": true,
    "UseDefaultCredentials": false
    }

Пример настройки подключение к базе
"AllowedHosts": "*",
  "ConnectionStrings": {
    "HotelManagerSystemDbConnection": "Host=localhost;Port=5432;Database=HotelSystemManagerDb;Username=postgres;Password=1122"
  },

