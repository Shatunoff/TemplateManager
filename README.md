# TemplateManager
Задание с одного из собеседований. Выполнение показалось мне интересным и в целом понравилось, поэтому решил добавить его в свое портфолио.
# Задача проекта
Программа, реализующая функционал формирования печатных форм на основе шаблона (получение данных, формирование печатной формы, отправка).

На входе наименование шаблона и список параметров.

Поля в шаблоне заполняются на основании значений, переданных в программу.

С готовым сформированным документом на основе шаблона могут быть выполнены следующие действия: распечатан или отправлен по почте.

Дополнительно организовать логгирование результатов в БД.
# Используемые технологии
* Язык программирования - C#
* Оболочка - Windows Forms
* Паттерн - MVP
* ORM - NHibernate
* База данных - SQL Server
# Перед запуском
Перед запуском необходимо создать БД, в которую будет осуществляться логгирование данных.
Также необходимо обновить файл `hibernate.cfg.xml` в соответствии со своими SQL-сервером и БД.
```xml
<property name="connection.connection_string">Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TemplateManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False</property>
```
При необходимости (если ваш SQL Server более ранний) изменить диалект ([см. Диалекты в NHibernate](https://nhibernate.info/doc/nh/en/index.html#configuration-optional-dialects)):
```xml
<property name="dialect">NHibernate.Dialect.MsSql2012Dialect</property>
```
