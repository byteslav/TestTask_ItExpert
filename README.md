# Тестовое задание Full-stack C#/React

## Задача 1

#### Серверная часть 🖥️

:checkered_flag: Реализовано [веб-приложение на Asp.Net Core](https://github.com/byteslav/TestTask_ItExpert/tree/main/Backend%20(Task%201))

| Метод 1                                      | Метод 2                                            |
|----------------------------------------------|----------------------------------------------------|
| Получает на вход JSON и сохраняет его в БД  | Возвращает данные клиенту из таблицы     |
| Перед сохранением данных очищает таблицу  | Предоставляет возможность фильтрации данных |
| Описание объекта: ● code – код (int). ● value – значение (string) | Возвращаемые данные: ● порядковый номер ● код ● значение |

*Описание структуры базы данных (PostgreSQL):*

```sql
CREATE TABLE Products (
    Id SERIAL PRIMARY KEY,    
    code INT,                            
    value VARCHAR(255)                      
);

COMMENT ON TABLE Products IS 'Таблица для хранения всех полей продукта';

COMMENT ON COLUMN Products.Id IS 'Уникальный идентификатор записи';
COMMENT ON COLUMN Products.code IS 'Код (целое число)';
COMMENT ON COLUMN Products.value IS 'Значение (строка до 255 символов)';
```



#### Клиентская часть :bow:

:checkered_flag: Сделана загрузка и отображение списка с использованием вышеупомянутых методов с помощью [приложения React](https://github.com/byteslav/TestTask_ItExpert/tree/main/Frontend%20(Task%201))

Ниже привёл пример короткого ролика работы приложения от лица пользователя

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/wdQjmZnT_3w/0.jpg)](https://www.youtube.com/watch?v=wdQjmZnT_3w)



## Задача 2 (выполнена с помощью MS SQL)

Даны таблицы:

**Clients** - клиенты
```sql
(
    Id bigint, -- Id клиента
    ClientName nvarchar(200) -- Наименование клиента
);
```

**ClientContacts** - контакты клиентов
```sql
(
    Id bigint, -- Id контакта
    ClientId bigint, -- Id клиента
    ContactType nvarchar(255), -- тип контакта
    ContactValue nvarchar(255) --  значение контакта
);
```

Написано 2 запроса решающих задачи:
1. возвращает наименование клиентов и кол-во контактов клиентов
2. возвращает список клиентов, у которых есть более 2 контактов*

:checkered_flag: SQL-код инициализации БД и решения задачи можно найти [здесь](https://github.com/byteslav/TestTask_ItExpert/tree/main/SQL%20(Task%202))



## Задача 3 (выполнена с помощью MS SQL)

Дана таблица:

**Dates** - клиенты
```sql
(
    Id bigint,
    Dt date
);
```
Написан запрос, который возвращает интервалы для одинаковых Id в таблице

:checkered_flag: SQL-код инициализации БД и решения задачи можно найти [здесь](https://github.com/byteslav/TestTask_ItExpert/tree/main/SQL%20(Task%203))

