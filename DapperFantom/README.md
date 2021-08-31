# Dapper Fantom

Blog manager with Dapper ORM

- [Entities](Entities):
POCO classes that represent the tables on the Db.

- [Controllers](Controllers):
Where the HTTP request methods are stored. Used by the View pages and uses the methods from the Service classes.

- [Models](Models):
Represents the objects to be used on the View pages. Also, used to make the relationship between the POCO classes on the Entities.

- [Views](Views):
Represents the webpages to be shown on the browser.

- [Services](Services):
Stores the methods that make the necessary operations on the Db.

- [Helpers](Helpers):
  Auxiliary classes that execute operations that don't fit into the previous categories (layers).
