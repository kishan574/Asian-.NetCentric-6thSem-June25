#GITHUB USERNAMES OF STUDENTS
[https://docs.google.com/document/d/1g0KU_5AqMBo7lDADeZt7tNOuVywYrFuX5NXpuZF6AtI/edit?usp=sharing]
# AsianCollege-.NetCentric-6th-sem-Junr25
Repo has all the course contents; lab works and the assignments covered 

# Please Note! these assignments are part of your final lab assessment report.
1. Lab report document layout:
    1. Assignment N (Related Area)
        ```
        Assignment Description
        ```
    1. Implementation
        ```
        Relevant Code Sections Only
        ```
    1. Output Snapshots
        ```
        Attach snapshots taken during code execution
        ```
1. Manually create folders for each assignment under your repo root folder. Folder structure would be (Referring my repo, you use yours):
    ```
    > NetCentric.Vedas2080
        > ConsoleApp
        > Assignment 1
        > Assignment 2
        > ...
    ```
1. Save all your code snapshots in corresponding assignment folders. 

# Assignment 1 (Starter)

1. Create a new console application named **Greeter** under **Assignment 1** folder.
1. Modify **Program.cs** to define a variable **fullName** and assign some name.
1. Print value of **fullName** to console.
> Take a snapshot of your work here (Code + Output) and save it. 
4. Define another variable **cFullName** and initilize it with **fullName** in uppercase letters. (Hint: *ToUpper()* string helper)

1. Print value of **cFullName** to console in format: "Hello, [YourName] Ji!"
> Take a snapshot of your work here (Code + Output) and save it. 
6. Instead of initilizing **fullName**, get it from user. (Hint: *Console.ReadLine()*)
> Take a snapshot of your work here (Code + Output) and save it. 
7. Now also ask user to enter his/her "Date of Birth" and display user friendly date to console. At this point your output should look like assuming user enters dob as "2010/12/12": (Hint: *DateTime.Parse(dateString)*)
```
Hello, [Your Name]!
Your DOB: Sunday, 12 December 2010
```
> Take a snapshot of your work here (Code + Output) and save it. 
8. Your last task is to calculate his/her age as accurate as possible and dispaly it to console. (Hint: If you subract dob from current date, you will get TimeSpan value, TimeSpan will have properties like *.TotalDays*, *.TotalHours* etc.) End output will be like:
```
Hello, [Your Name]! Ji!
Your DOB: Sunday, 12 December 2010
Age as of now: 13 Years 2 Months 1 Week 1 Day
```
# Assignment 2 (OOP Concepts)

Think of a real world scenario where you can design classe(s), interface(s) and members as shown in following class diagram:

![image](https://github.com/user-attachments/assets/6dd1ab45-6fac-41d3-b6ec-3fa8982ad20c)

> **Note:** Please create new console app to demonstrate all this and push your changes and snapshots (if needed) to respective assignment folder.

# Assignment 3 (File Handling and LINQ)

You have csv data for inflation rate in Asia and the Pacific: `Assignment 3\Inflation.csv`. 
RegionalMember | Year |Inflation|Unit of Measurement| Subregion| Country Code|
--------|-------|------|------|------|-------------------------------------------
........|........|....|....|.......|..........
Armenia|	2022	|8.6|	%|	Central Asia|	ARM|
Armenia	|2023|	7|	%|	Central Asia|	ARM
Armenia	|2024|	6.2|	%|	Central Asia|	ARM
Azerbaijan|	2018|	2.4|	%|	Central Asia|	AZE
Azerbaijan|	2019|	2.7|	%|	Central Asia|	AZE
Azerbaijan|	2020|	2.8|	%|	Central Asia|	AZE
........|........|....|....|.......|..........

Now your tasks:
1. Create class **Inflation** with all column headers in csv file as properties.
2. Create another class **InflationAnalysis** with methods as needed to
    1. Read csv text file and populate `List<Inflation>` collection with the data read.
    2. To answer following queries related to inflation
        1. Find inflation rates for countries for the year 2021.
        2. A year when Nepal has highest inflation.
        3. List top 10 regions (countries) where inflation is highest for all time
        4. List top 3 south asian countries with lowest inflation rate for year 2020

> Note: Take snapshots as needed for your attempt progress (Code + Output).
> 
# Assignment 4. MovieManager Web Portal
### Movie Mangaer have three related models to deal with:
`Movie` (ID, Title, Rating, Budget, Gross, Release Date, Genre, Runtime, Summary)

`Actor`(ID, Name, Date of Birth, Birth City, Birth Country, Height (Inches), Biography, Gender, NetWorth)

`Charactor`(MovieID, ActorID, Character Name, Pay, Screentime)

### This app should have following features:
* Add new movies to database
* Add new actors to database
* Add new and update existing characters on database
* Use Identity server for auth 
* Dashboard page showing:
  * List of top 10 flop movies
  * List of top 5 highest paid actors and role they played

### Requirements
  1. `ASP.NET Core 7.0+`
  1. Please use `SQLite` as your database
  1. Plain `ADO.NET` or Entity Framework tools for data access
