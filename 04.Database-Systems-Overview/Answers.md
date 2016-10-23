## Answers:

1.  What database models do you know?
    * _Relational databases._
    * _NoSQL databases._
1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    * _A relational database management system (RDBMS) is a program that lets you create, update, and administer a relational database. Most commercial RDBMS's use the Structured Query Language (SQL) to access the database._
1.  Define what is "table" in database terms.
    * _In relational databases and flat file databases, a table is a set of data elements (values) using a model of vertical columns (identifiable by name) and horizontal rows, the cell being the unit where a row and column intersect._
1.  Explain the difference between a primary and a foreign key.
    * **Primary key**:
      1. Primary key uniquely identify a record in the table.
      1. Primary Key can't accept null values.
      1. By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index.
      1. We can have only one Primary key in a table.
    * **Foreign key**:
      1. Foreign key is a field in the table that is primary key in another table.
      1. Foreign key can accept multiple null value.
      1. Foreign key do not automatically create an index, clustered or non-clustered.
    	   You can manually create an index on foreign key.
      1. We can have more than one foreign key in a table.
1.  Explain the different kinds of relationships between tables in relational databases.
    * **One-to-Many Relationship**
    	  - This is the most common type of relationship. In this type of relationship, a row in table A can have many matching rows in table B, but a row in table B can have only one matching row in table A.
    * **Many-to-Many**
    	- A row in table A can have many matching rows in table B, and vice versa. You create such a relationship by defining a third table, called a junction table, whose primary key consists of the foreign keys from both table A and table B.
1.  When is a certain database schema normalized?
    * Database normalization is the process of organizing the columns (attributes) and tables (relations) of a relational database to reduce data redundancy and improve data integrity.
	* **What are the advantages of normalized databases?**
      - Normalization is the aim of well design Relational Database Management System (RDBMS). It is step by step set of rules by which data is put in its simplest forms. We normalize the relational database management system because of the following reasons:
          1. Minimize data redundancy i.e. no unnecessarily duplication of data.
          1. To make database structure flexible i.e. it should be possible to add new data values and rows without reorganizing the database structure.
          3. Data should be consistent throughout the database i.e. it should not suffer from following anomalies.
1.  What are database integrity constraints and when are they used?
	* _Constraints are part of a database schema definition.A constraint is usually associated with a table and is created with a CREATE CONSTRAINT or CREATE ASSERTION SQL statement._
	* They define certain properties that data in a database must comply with.
1.  Point out the pros and cons of using indexes in a database.
	* Advantages:
    	- Can be used to quickly locate specific rows or ranges of rows.
    	- Even if the index cannot be used to match the seek predicate directly it can be used to limit the number of pages read (can be quicker to scan a narrower covering non clustered index than the whole table).
    	- Can be used to avoid a sort operation by providing the data pre-sorted.
    	- When ever finds the value, it stops the searching process.
    * Disadvantages:
    	- Insert/Update performance when indexed columns are modified will be worse.
    	- More indexes will use more disk space.
1.  What's the main purpose of the SQL language?
	* SQL is short for Structured Query Language. It is a standard programming language used in the management of data stored in a relational database management system. It supports distributed databases, offering users great flexibility. 
1.  What are transactions used for?
	* A transaction is a unit of work that is performed against a database. Transactions are units or sequences of work accomplished in a logical order.
	* A transaction is the propagation of one or more changes to the database.
  	* **Give an example.**
    	  - If you are creating a record or updating a record or deleting a record from the table, then you are performing transaction on the table.
1.  What is a NoSQL database?
	* A NoSQL database provides a mechanism for storage and retrieval of data which is modeled in means other than the tabular relations used in relational databases.
	* The data structures used by NoSQL databases (e.g. key-value, wide column, graph, or document) are different from those used by default in relational databases, making some operations faster in NoSQL.
1.  Explain the classical non-relational data models.
	* The non-relational data model would look more like a sheet of paper. In fact, the concept of one entity and all the data that pertains to that one entity is known in Mongo as a "document", so truly this is a decent way to think about it.