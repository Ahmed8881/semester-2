
use Assignment;
-- -- 1
-- SELECT *
-- FROM dbo.Employee;

-- -- 2
-- SELECT salary
-- FROM dbo.Employee;

-- -- 3 
-- SELECT DISTINCT job_name
-- FROM dbo.Employee

-- -- 4
-- SELECT emp_name, CONCAT('$',salary * 1.15) AS increased_salary
-- FROM dbo.Employee;

-- -- 5
-- SELECT CONCAT(emp_name, ' & ', job_name) AS emp_job
-- FROM dbo.Employee;

-- -- 6
-- SELECT CONCAT(e.emp_name,'(',m.emp_name,')') AS Employee
-- FROM dbo.Employee AS e
--     LEFT JOIN dbo.Employee AS m ON e.manager_id = m.manager_id;

-- -- 7 
-- SELECT emp_id, emp_name, salary, hire_date
-- FROM dbo.Employee
-- WHERE hire_date = '1991-02-22';

-- -- 8
-- SELECT LEN(REPLACE(emp_name,' ',''))
-- from dbo.Employee;

-- -- 9
-- SELECT emp_id, salary, commission
-- FROM dbo.Employee

-- -- 10
-- SELECT Distinct d.dep_id, e.job_name
-- FROM dbo.Department as d, dbo.Employee as e
-- WHERE e.dep_id = d.dep_id

-- -- 11
-- SELECT *
-- FROM dbo.Employee
-- WHERE dep_id <> 2001;

-- -- 12
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) < 1991;

-- -- 13
-- SELECT AVG(salary) AS Average_Salary
-- FROM dbo.Employee
-- WHERE job_name = 'ANALYST';

-- -- 14
-- SELECT *
-- FROM dbo.Employee
-- WHERE emp_name = 'BLAZE';

-- -- 15
-- SELECT *
-- FROM dbo.Employee
-- where commission > salary;

-- -- 16
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary * 1.25 > 3000;

-- -- 17
-- SELECT emp_name
-- FROM dbo.Employee
-- WHERE LEN(emp_name) = 6;

-- -- 18
-- SELECT *
-- FROM dbo.Employee
-- WHERE MONTH(hire_date) = 2;

-- 19
-- SELECT CONCAT(e.emp_name,' works for ',m.emp_name)
-- FROM dbo.Employee AS e
--     LEFT JOIN dbo.Employee AS m ON e.emp_id = m.manager_id
-- WHERE m.emp_name IS NOT NULL;

-- -- 20
-- SELECT *
-- FROM dbo.Employee;
-- WHERE job_name = 'CLERK';

-- -- 21
-- SELECT *
-- FROM dbo.Employee
-- WHERE DATEDIFF(YEAR,hire_date,GETDATE()) > 27;  

-- -- 22
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary < 3500;

-- -- 23
-- SELECT emp_name, job_name, salary
-- FROM dbo.Employee
-- WHERE job_name = 'ANALYST';

-- -- 24
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) = 1991;

-- -- 25
-- SELECT emp_id, emp_name, job_name, salary
-- FROM dbo.Employee
-- WHERE hire_date < '1991-04-01';

-- -- 26
-- SELECT emp_name, job_name
-- FROM dbo.Employee
-- WHERE manager_id IS NULL OR manager_id = '';

-- -- 27
-- SELECT *
-- FROM dbo.Employee
-- WHERE hire_date = '1991-05-01';

-- -- 28
-- SELECT emp_id, emp_name, salary, DATEDIFF(YEAR,hire_date,GETDATE()) AS experience
-- FROM dbo.Employee
-- WHERE manager_id = 68319;   

-- -- 29
-- SELECT emp_id, emp_name, salary, DATEDIFF(YEAR,hire_date,GETDATE()) AS experience
-- FROM dbo.Employee
-- WHERE salary/30 > 100;

-- -- 30
-- SELECT emp_name
-- FROM dbo.Employee
-- WHERE DATEDIFF(YEAR,hire_date,'1999-12-31') >= 8;

-- -- 31
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary % 2 <> 0;

-- -- 32
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary BETWEEN 100 AND 999;

-- -- 33
-- SELECT *
-- FROM dbo.Employee
-- WHERE MONTH(hire_date) = 4;

-- -- 34
-- SELECT *
-- FROM dbo.Employee
-- WHERE DAY(hire_date) BETWEEN 1 AND 18;

-- -- 35
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name = 'SALESMAN' AND DATEDIFF(MONTH,hire_date,GETDATE())/12 > 10;    

-- -- 36
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) = 1991 AND (dep_id = 3001 or dep_id = 1001);

-- -- 37 
-- SELECT *
-- FROM dbo.Employee
-- WHERE dep_id = 1001 or dep_id = 2001;

-- -- 38
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name = 'CLERK' AND dep_id = 2001;

-- -- 39
-- SELECT emp_id, emp_name, salary, job_name
-- FROM dbo.Employee
-- WHERE (salary > commission AND (salary + commission) * 12 < 34000)
--     OR (job_name = 'SALESMAN' AND dep_id = 3001);

-- -- 40
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name = 'CLERK' OR job_name = 'MANAGER';

-- -- 41
-- SELECT *
-- FROM dbo.Employee
-- WHERE MONTH(hire_date) <> 2;

-- -- 42
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) = 1991;

-- -- 43
-- SELECT *
-- FROM dbo.Employee
-- WHERE MONTH(hire_date) = 6
--     AND YEAR(hire_date) = 1991;

-- -- 44
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary * 12 BETWEEN 24000 AND 50000;

-- -- 45
-- SELECT *
-- FROM dbo.Employee
-- WHERE hire_date IN ('1991-02-20','1991-05-01','1991-12-03');

-- -- 46
-- SELECT *
-- FROM dbo.Employee
-- WHERE manager_id IN (63679, 68319, 66564,69000);

-- -- 47
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) = 1991
--     AND MONTH(hire_date) > 6;

-- -- 48
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) BETWEEN 1990 AND 1999;

-- -- 49
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name = 'MANAGER'
--     AND dep_id IN (1001,2001);

-- -- 50
-- SELECT *
-- FROM dbo.Employee
-- WHERE MONTH(hire_date) = 2 AND salary BETWEEN 1001 AND 2000;

-- -- 51
-- SELECT *
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) <> 1991;

-- -- 52
-- SELECT e.*, d.dep_name
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id;

-- -- 53
-- SELECT e.emp_name, e.job_name, 12*e.salary AS annual_salary, e.dep_id, s.grade
-- FROM dbo.Employee AS e, dbo.Salary_grade AS s
-- WHERE (e.salary BETWEEN s.min_salary AND s.max_salary)
--     AND (e.job_name <> 'ANALYST' OR salary*12 >= 60000);

-- -- 54
-- SELECT e.emp_name AS employee_name, e.job_name, e.manager_id, e.salary, m.emp_name AS manager_name, m.salary AS manager_salary
-- FROM dbo.Employee AS e
--     LEFT JOIN dbo.Employee AS m ON e.manager_id = m.emp_id
-- WHERE e.salary > m.salary;

-- -- 55
-- SELECT e.emp_name, e.dep_id, e.salary, e.commission
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id
--     AND d.dep_location = 'PERTH'
--     AND e.salary BETWEEN 2000 AND 5000;

-- -- 56
-- SELECT s.grade, e.emp_name
-- FROM dbo.Employee AS e, dbo.Salary_grade as s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
--     AND s.grade <> 4
--     AND e.dep_id IN (1001,3001)
--     AND e.hire_date < '1992-12-31';

-- -- 57
-- SELECT e.emp_id, e.emp_name, e.job_name, e.manager_id, e.hire_date, e.salary, e.dep_id, m.emp_name AS manager_name
-- FROM dbo.Employee AS e, dbo.Employee AS m
-- WHERE e.manager_id = m.emp_id
--     AND m.emp_name = 'JONAS';

-- 58

-- -- 59
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name IN ('MANAGER','ANALYST')
--     AND salary BETWEEN 2000 AND 5000;

-- -- 60
-- SELECT e.emp_id, e.emp_name, e.dep_id, e.salary, d.dep_location
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id
--     AND d.dep_location IN ('PERTH','MELBOURNE')
--     AND DATEDIFF(MONTH,hire_date,GETDATE())/12 > 10;    

-- -- 61
-- SELECT e.emp_id, e.emp_name, e.dep_id, e.salary, d.dep_location
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id
--     AND YEAR(hire_date) = 1991
--     AND d.dep_location IN ('SYDNEY','MELBOURNE')
--     AND e.salary BETWEEN 2000 AND 5000;

-- -- 62
-- SELECT e.dep_id, e.emp_id, e.emp_name, e.salary, d.dep_name, d.dep_location, s.grade
-- FROM dbo.Employee AS e, dbo.Department AS d, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
--     AND e.dep_id = d.dep_id
--     AND d.dep_name = 'MARKETING'
--     AND d.dep_location IN ('MELBOURNE','PERTH')
--     AND s.grade IN (3,4,5)
--     AND DATEDIFF(YEAR,e.hire_date,GETDATE()) >= 25;

-- -- 63
-- SELECT e.*
-- FROM dbo.Employee AS e, dbo.Employee AS m
-- WHERE e.manager_id = m.emp_id
--     AND e.hire_date < m.hire_date;

-- -- 64
-- SELECT e.*, s.grade
-- FROM dbo.Employee AS e, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary - 1 AND s.max_salary - 1
--     AND s.grade = 4;

-- -- 65
-- SELECT e.emp_name
-- FROM dbo.Employee AS e
--     JOIN dbo.Department AS d ON e.dep_id = d.dep_id
-- WHERE e.hire_date > '1991-12-31'
--     AND e.emp_name NOT IN ('MARKER', 'ADELYN')
--     AND d.dep_name IN ('PRODUCTION', 'AUDIT');

-- -- 66
-- SELECT *
-- FROM dbo.Employee
-- ORDER BY salary ASC;

-- -- 67
-- SELECT *
-- FROM dbo.Employee
-- ORDER BY dep_id ASC, job_name DESC;

-- -- 68
-- SELECT DISTINCT job_name
-- FROM dbo.Employee
-- ORDER BY job_name DESC;

-- -- 69 
-- SELECT emp_id, emp_name, salary AS Monthly_Salary, salary/30 AS Daily_Salary, salary*12 AS Annual_Salary
-- FROM dbo.Employee
-- ORDER BY salary * 12 ASC;

-- -- 70
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name IN ('CLERK','ANALYST')
-- ORDER BY job_name DESC;

-- -- 71
-- SELECT d.dep_location
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id
--     AND e.emp_name = 'CLARE';

-- 72
-- SELECT *
-- FROM dbo.Employee
-- WHERE hire_date IN ('1991-05-01','1991-12-03','1990-01-19')
-- ORDER BY hire_date ASC;

-- -- 73
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary < 1000
-- ORDER BY salary ASC;

-- -- 74
-- SELECT *
-- FROM dbo.Employee
-- ORDER BY salary ASC;

-- -- 75
-- SELECT *
-- FROM dbo.Employee
-- ORDER BY job_name ASC,emp_id DESC;

-- -- 76
-- SELECT DISTINCT job_name
-- FROM dbo.Employee
-- WHERE dep_id IN (2001,3001)
-- ORDER BY job_name DESC;

-- -- 77
-- SELECT *
-- FROM dbo.Employee
-- WHERE job_name NOT IN ('PRESIDENT','MANAGER')
-- ORDER BY salary ASC;

-- -- 78
-- SELECT *
-- FROM dbo.Employee
-- WHERE salary*12 < 25000
-- ORDER BY salary ASC;

-- -- 79
-- SELECT emp_id, emp_name, salary*12 AS Annual_Salary, salary/30 AS Daily_Salary
-- FROM dbo.Employee
-- WHERE job_name = 'SALESMAN'
-- ORDER BY salary*12 ASC;

-- -- 80
-- SELECT emp_id, emp_name, hire_date, GETDATE() AS date, DATEDIFF(YEAR, hire_date, GETDATE()) AS experience
-- FROM dbo.Employee
-- ORDER BY experience ASC;

-- -- 81
-- SELECT *
-- FROM dbo.Employee
-- WHERE hire_date > '1991-06-30'
-- ORDER BY job_name ASC;

-- -- 82
-- SELECT e.*, d.dep_location
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id
--     AND d.dep_name IN ('FINANCE','AUDIT')
-- ORDER BY e.dep_id ASC;

-- -- 83
-- SELECT e.*, s.grade
-- FROM dbo.Employee AS e, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
-- ORDER BY s.grade ASC

-- -- 84
-- SELECT e.emp_name, e.job_name, d.dep_name, e.salary, s.grade
-- FROM dbo.Employee AS e, dbo.Department AS d, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
--     AND e.dep_id = d.dep_id
-- ORDER BY d.dep_name;

-- -- 85
-- SELECT e.emp_name, e.job_name, e.salary, s.grade, d.dep_name
-- FROM dbo.Employee AS e, dbo.Department AS d, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
--     AND e.dep_id = d.dep_id
--     AND e.job_name <> 'CLERK'
-- ORDER BY e.salary DESC;

-- 86
-- SELECT e.emp_name, e.job_name, e.salary, s.grade, d.dep_name
-- FROM dbo.Employee AS e, dbo.Department AS d, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
--     AND e.dep_id = d.dep_id
--     AND e.job_name <> 'CLERK'
-- ORDER BY e.salary DESC;

-- -- 87
-- SELECT e.*, d.dep_name, d.dep_location
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id;

-- -- 88
-- SELECT e.*
-- FROM dbo.Employee AS e, dbo.Employee AS m
-- WHERE e.manager_id = m.emp_id
--     AND e.hire_date < m.hire_date;

-- -- 89
-- SELECT emp_id, emp_name, salary, dep_id
-- FROM dbo.Employee
-- ORDER BY salary ASC;

-- -- 90
-- SELECT MAX(salary)
-- FROM dbo.Employee;

-- -- 91
-- SELECT job_name, AVG(salary) AS average_salary, AVG(salary + commission) AS average_total_remuneration
-- FROM dbo.Employee
-- GROUP BY job_name;

-- -- 92
-- SELECT job_name, SUM(salary * 12) AS total_annual_salary
-- FROM dbo.Employee
-- WHERE YEAR(hire_date) = 1991
-- GROUP BY job_name;

-- -- 93
-- SELECT e.emp_id, e.emp_name, e.dep_id, d.dep_location
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id;

-- -- 94
-- SELECT e.emp_id, e.emp_name, e.dep_id, d.dep_location, d.dep_name
-- FROM dbo.Employee AS e, dbo.Department AS d
-- WHERE e.dep_id = d.dep_id
--     AND e.dep_id IN (1001,2001);

-- -- 95
-- SELECT e.emp_id, e.emp_name, e.salary, s.grade
-- FROM dbo.Employee AS e, dbo.Salary_grade AS s
-- WHERE salary BETWEEN s.min_salary AND s.max_salary;

-- -- 96
-- SELECT manager_id, COUNT(*) AS number_of_employees
-- FROM dbo.Employee
-- WHERE manager_id IS NOT NULL
-- GROUP BY manager_id
-- ORDER BY manager_id ASC;

-- -- 97
-- SELECT dep_id, job_name, COUNT(*) AS number_of_employees
-- FROM dbo.Employee
-- GROUP BY dep_id, job_name;

-- -- 98
-- SELECT dep_id, COUNT(*) AS number_of_employees
-- FROM dbo.Employee
-- GROUP BY dep_id
-- HAVING COUNT(*) >= 2;

-- -- 99
-- SELECT s.grade, COUNT(*) AS number_of_employees, s.max_salary
-- FROM dbo.Employee AS e, dbo.Salary_grade AS s
-- WHERE e.salary BETWEEN s.min_salary AND s.max_salary
-- GROUP BY s.grade,s.max_salary;

-- -- 100
-- SELECT d.dep_name, s.grade, COUNT(*) AS number_of_employees
-- FROM dbo.Employee AS e
--     JOIN dbo.Department AS d ON e.dep_id = d.dep_id
--     JOIN dbo.Salary_grade AS s ON e.salary BETWEEN s.min_salary AND s.max_salary
-- WHERE e.job_name = 'SALESMAN'
-- GROUP BY d.dep_name, s.grade
-- HAVING COUNT(*) >= 2;