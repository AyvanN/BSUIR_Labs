# Лабораторные работы по учебной дисциплине ИСП

>### Лабораторная работа №1 
>>- Установить Ubuntu Linux одним из способов
>>- Научиться пользоваться, изучить простейшие консольные команды
>>- Установить git, создать локальный репозиторий в git и попробовать им
пользоваться
>>- Научиться работать с удаленным репозиторием, получая и отправляя
локальные изменения
>>- Написать простой скрипт на Python и запустить его
>>- Установить docker. Создать docker image, который запускает скрипт из пункта 5.
Изучить простейшие консольные команды для работы с docker

---

>### Лабораторная работа №2
>>- В ходе выполнения лабораторной работы студенту необходимо
реализовать сериализатор. Получившийся сериализатор должен корректно
сериализовывать (сохранять / упаковывать) и десериализовать
(восстанавливать / распаковывать) хранимую информацию. И разработать на
основе сериализатора консольную утилиту.
Код вашей программы должен содержать фабричный метод
create_serializer(), который будет порождать различные типы сериализаторов:
JSON, YAML, TOML, PICKLE. Должна быть возможность легко добавить новый
сериализатор, не изменяя архитектуру приложения.
>>- Каждый из сериализаторов должен реализовывать следующие методы :
>>>- dump(obj, fp) — сериализует Python объект в файл
>>>- — сериализует Python объект в строку
>>>- load(fp) — десериализует Python объект из файла
>>>- loads(s) — десериализует Python объект из строки
Дополнительные аргументы в методы можете передавать какие хотите :)
Сериализация/десериализация :
>>>- класса
>>>-объекта с простыми полями
>>>- объекта со сложными полями и функциями
>>>- функции
>>- Консольная утилита должна работать следующим образом:
>>- Конвертация сериализованных объектов из одного поддерживаемого
формата в другой. Путь к файлу (файлам) указывается относительным или
абсолютным путем, отдельным параметром передается новый формат. При
указании исходного формата конвертирование не должно выполняться.
>>- В случае передачи параметром файла конфигурации, вся информация
должна браться оттуда и все остальные параметры проигнорированы.

---

>### Лабораторная работа #3
>>- **Основные задания:**
>>>- Продумать необходимые сущности для описания
предметной области. Реализовать их в терминах
моделей, используя подходящие типы данных и связи
объектов.
>>>- Реализовать CRUD (create, read, update, delete)
операции;
>>>- Реализовать админскую панель (в случае выбора
фреймворка Flask);
>>>- Добавить все модели в админскую панель. Отобразить
связанные модели на одной странице;
>>>- Реализовать механизмы авторизации/аутентификации;
>>>- Добавить тесты на pytest. Использовать fixtures для
создания юзеров и соединения к базе данных.
Использовать parametrize;
>>>- Добавить logging;
>>>- Добавить тесты;
>>- **Требования:**
>>>- Проект представляет собой решение какой-либо
бизнес задачи, а не просто набор несвязных модулей;
>>>- Бекенд проекта должен быть написан либо на Django,
либо на Flask;
>>>- Использовать не sqlite базу данных;
>>>- Добавить индексы для полей по которым идет
выборка;
>>>- Реализовать связи many-to-many, one-to-many,
one-to-one;
>>>- Реализовать Join запросы;
>>>- Покрытие тестами кода на 80% и выше;
>>>- (*) Покрытие тестами кода на 95% и выше;
>>>- Приемлемый внешний вид. Использование css
(например бутстрап), при желании реализация своих
стилей (можете найти и скачать шаблоны в интернете);
>>>- Валидация форм как на стороне сервера, так и на
стороне клиента;
>>>- Использовать мощнейший фреймворк VanillaJS.
Например: реализация toaster в случае клика или
ошибки при валидации;
>>>- (*) Использовать JS фреймворки такие как: React JS,
Angular2, Vue JS;
>>>- Приложение должно считывать свою конфигурацию из
конфигурационного файла;
>>>- Поддержка разного уровня логирования (уровень
логирования брать из конфигурации приложения);
>>>- (*) Использование различного формата вывода логов
для режима разработки и продакшн запуска;
>>>- Ограничить использование API проекта для
неавторизованных запросов.

---

>### Лабораторная работа 4
>>- **Основные задания:**
>>>- Дополнить проект из лабораторной №3 модулем для
работы с параллельным кодом (можно использовать
asyncio, multiprocessing или multithreading на выбор);
>>>- API должно подыматься в production режиме;
>>>- Разработать Dockerfile для вашего проекта (или частей
проекта);
>>>- docker-compose файл, с помощью которого возможно
запустить проект локально (должен включать образы
вашего проекта (образы сделать публичными, чтобы
преподаватель мог запустить у себя) и базы данных +
возможно какие-то сервисы, необходимые для
проекта);
>>>- (*) добавить в проект возможность масштабирования
API. Пример: предположим у меня есть REST API,
которое умеет обрабатывать какие-то задачи в
асинхронном режиме, при этом на каждую задачу
создается уникальный ID, который возвращается в
ответе на запрос и по которому можно получить статус
задачи. Тогда если развернуть несколько экземпляров
API (несколько контейнеров), вы должны
гарантировать, что при одинаковом запросе на каждый
из них касательно статуса задачи, все они вернут один
и тот же результат. То есть например складывать
результат всех задач в базу данных или какое-нибудь
стороннее хранилище;
>>>- (*) закрыть приложение каким-нибудь веб-сервером
(например, NGINX) и поднять его в отдельном
контейнере;
>>>- (*) Настроить CI, которое будет уметь делать: 1) сборка
проекта; 2) запуск тестов; 3) пуш в dockerhub, если
сборка прошла успешно; (можно использовать github
actions или бесплатные CI/CD проекты: travis, circleci,
etc…)
>>>- Развернуть проект в облаке (например можно
использовать google cloud platform, которая
предоставляет бесплатную квоту в 300$ на год; но
можно использовать все, что угодно) (в зависимости от
темпов сдачи, тут может появиться * :));
>>>- (*) Настроить CD (непрерывное развертывание) на
сервер в облаке при пуше в master(main) ветку на
github.

---


