CREATE DATABASE IF NOT EXISTS dishesDb;
use  dishesDb;

create table IF NOT EXISTS dishes(
 DishId int(11) auto_increment,
 Name varchar(45),
 Chef varchar(45),
 Tastinness int(11),
 Calories int(11),
 Description text,
 CreatedAt datetime default current_timestamp,
 UpdateAt datetime default current_timestamp,
 primary key(DishId)
 );
 
insert into dishes(Name,Chef,Tastinness,Calories,Description) values("Pizza","Flavio",5,305,"Excelente");
insert into dishes(Name,Chef,Tastinness,Calories,Description) values("Hamburguesa","Alex",1,510,"Falto Sazon");
insert into dishes(Name,Chef,Tastinness,Calories,Description) values("Completo","Rodrigo",3,800,"3/5 Puede mejorar");

select * from dishes;