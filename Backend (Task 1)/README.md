# Приложение ASP.NET Core

Этот проект является backend приложением для [тестового задания](https://github.com/byteslav/TestTask_ItExpert/blob/main/README.md)

## Используемые технологии

- .NET 7
- ASP.NET Core
- Entity Framework Core
- MediatR
- PostgreSQL
- Docker Compose

## API

### Endpoints

#### GET /api/products/get-filtered-data
Получает отфильтрованные данные из БД

#### POST /api/products/insert-array
Фильтрует пришедший массив по полю Code и сохраняет в БД
