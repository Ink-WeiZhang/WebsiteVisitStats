# News#360 Developement Task "Website Visits Stats"

## Task Description
Create a web service which generates statics from a provided csv file.

## Methedology
Use ASP.NET Core 2.1 to build a webapp which fullfills the task requirements.

## Technical Deviations
### Get Syntax
Replaced ```/unique-users?device=1,2&os-1,2``` with ```/unique/1,2/1,2``` as per standard ASP.NET URL formatting.

## Technical Assumptions
-"datetime" is in Unix seconds
-"user" is a userID which uniquely identifies users independant of their device (i.e. user accounts)
-"Unique" refers to distinct by user

## Instructions
### GET Unique Visit Data
Formatting is as follows
```url/api/VisitStats/unique/{deviceids}/{osids}```
i.e.
```localhost:8000/api/VisitStats/unique/1/1,2```
Deviceids and osids are optional and can be skipped by placing a whitespace character.
i.e.
```localhost:8000/api/VisitStats/unique/ /1,2```

### GET Loyal Visit Data
Formatting is as follows
```url/api/VisitStats/loyal/{deviceids}/{osids}```
i.e.
```localhost:8000/api/VisitStats/loyal/1/2,3```
Deviceids and osids are optional and can be skipped by placing a whitespace character.
i.e.
```localhost:8000/api/VisitStats/loyal/ /1,2```

## Challenges
* Docker appears to have compatiblity issues with ASP.NET Core 2.1

## Unfinished
* GET Loyal Visit Filter on Loyalty
* GET Unique Unit Testing
* GET Loyal Local Testing
* GET Loyal Unit Testing
* Docker support


## Tests History
### Local Testing
```
TestCases on Truncated 20 Entry CSV for Unique Visits
OS/Uses
0/0
1/2
2/17
3/1
4/0
5/0
6/0

Device/Uses
0/1
1/15
2/2
3/1
4/1
5/0

11 Unique UserID
All tests passed
```
