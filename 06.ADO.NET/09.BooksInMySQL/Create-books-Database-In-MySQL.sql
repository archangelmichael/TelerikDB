create database books;

use books;

create table library (
Title VARCHAR(50) NOT null, 
Author VARCHAR(50) NOT NULL,
ReleaseDate DATE NOT NULL, 
ISBN INT NOT NULL, 
PRIMARY KEY ( ISBN )
);

insert into library (Title, Author, ReleaseDate, ISBN)
values ('Introduction to Programming', 'Stormy Attaway', '2013-06-17' , '123456789'),
('As Red as Blood', 'Stormy Attaway', '2012-12-31' , '765432543'),
('Body Count', 'Barbara Nadel', '2013-08-01' , '234567891'),
('A Good Time', 'Shannyn Schroeder', '2012-12-31' , '444432178'),
('A Shadow Of Light', 'Bella Forrest', '2013-07-30' , '567893454')

/* truncate table library */