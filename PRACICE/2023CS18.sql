--select * from student
select [FirstName] from student
select * from student where CGPA>3.5
select * from student where CGPA <3.5
select CONCAT(FirstName, ' ',LastName) as FullName from student
/* ACTIVITTY 2 */
/* Q 1 */
/*There are many scenarious in which precedence can cahnge the result let us take an example of simple arithmatic operators  */
/* Select 10 + 5 * 2 AS Result; */
/* it first Multiply 5 and 2 ad then add it in 10 ang gives 20 */
/*  select (10 + 5) * 2 AS Result;*/
/* now it first add numbers and then multiply it with 2 and gives 30 result */
/*  */
/*Q 2  */
/* When performing mathematical expressions involving NULL values in SQL, the result is typically NULL. This is due to the fact that NULL represents an unknown or missing value, so any  operation that involves  NULL results in NULL */
/*FOR EXAMPLE When you add somthing using select keyword  to a NULL that resilts in null same is the case with multiplication */
/* select 10 +NULL as Result */
/* select 10 * NULL as Result2 */
