# Database final web application

## Instructions for running
Version of visual studio: 8.0.3 (build 14)
Visual Studio 2019 

## Presentation
https://docs.google.com/presentation/d/1gu-lvGkOomA0BY5btKEcldfb4jXGg0vOIc8NAJI0U50/edit?usp=sharing

## Paper
See the home directory and the document titled Final-report.docx

## See the following references in order to see where each requirement is implemented

1. Print/display records from your database/tables
  - Bet/Controller/ApiControllers/
  - Bet/Controller/HomeController.cs
  - These classes query and pass data to the Views on the front end
2. Query for data/results with various parameters/filters
  - Picks page and Games page query and show data with filters available from the dropdown menu
3. Create a new record
  - Register, Login, and make a pick from the Games page
4. Delete records (soft delete function would be ideal)
  - Remove pick and delete account
5. Update records
  - Edit pick from the Picks page
6. Make use of transactions (commit & rollback)
  - Making multiple picks at once from the Games page implements transactions
7. Generate reports that can be exported (excel or csv format)
  - Export your picks from the Picks page
8. One query must perform an aggregation/group-by clause
  - The settings page allows you to count the number of time you've picked a certain team
9. One query must contain a sub-query
  - The get method in the GameApiController.cs uses a sub query to get the games for a specific team
10. Two queries must involve joins across at least 3 tables
  - PickApiController.cs and HomeController.cs both have queries with 4 joins
11. Enforce referential integrality (Constraints)
  - There are necessary foreign key constraints on all tables
12. Include Database Views, Indexes
  - Indices are on all the tables to help speed up queries with certain where clauses
13. Stored procedures
  - The register query and the login authentication use stored procedures that pass in the proper parameters.

## All of the DDL and DML statements used to create the tables and populate the data are in the DatabaseDDL directory

## Screen recording of all features in case there is an issue with running
https://d.pr/v/8RWJoI
