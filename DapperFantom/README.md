# Dapper Fantom

Blog manager with Dapper ORM

- [Entities](Entities):
POCO classes that represents the tables on the Db.

- [Controllers](Controllers):
Where thee HTTP request methods are stored. Used by the View pages and uses the the methods on the Service classes.

- [Models](Models):
Represents the objects to be used on the View pages. Also, used to make the relationship between the POCO classes on the Entities.

- [Views](Views):
Represents the webpages to be shown on the browser.

- [Services](Services):
Stores the methods that makes the necessary operations on the Db.

- [Helpers](Helpers):
Auxiliary classes that executes operations that doesn't fit into the previous categories (layers).