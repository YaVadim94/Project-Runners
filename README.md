# Project-Runners

На сервере перидически появляются прогоны.
Прогоны включают в себя несколько задач, которые необходимо выполнить клиентам.
Задачи не зависят друг от друга и могут быть выполнены любыми клиентами в любом порядке.

Клиенту требуется 5 секунд на выполнение задачи.
Клиент может выполнить успешно и неуспешно свою задачу. (50/50)

После выполнения задачи: 
	1. Клиент отсылает результат выполнения на сервер.
	2. Клиент может взять другую задачу.
	3. Если задач на выполнение нет, то ждёт.

Не успешные задачи должны быть прогнаны ещё раз на любом из доступных клиентов.
Как только все задачи выполнены успешно прогон считается закрытым.

В БД хранится:
	1. Список всех возможных задач
	2. Список прогонов
	3. Результаты по прогонам/задачам
