Use Bear;

Create Table Role
(role_id int Identity(1,1) Primary Key Not Null,
name varchar(20) Not Null
)
Go
Create Table Users
(user_id int IDENTITY(1,1) Primary KEY Not Null,
role_id int FOREIGN KEY REFERENCES Role Not Null,
name varchar(15) Not Null,
surname varchar(15) Not Null,
passport_number varchar(20) Not Null,
login varchar(20) Not Null,
password varchar(128) Not Null
)
Go 
Create Table Equipment
(eq_id int Identity(1,1) Primary Key Not Null,
name varchar(20) Not Null
)
Go
Create Table Type
(type_id int Identity(1,1) Primary Key Not Null,
name varchar(20) Not Null
)
Go
Create Table Factory
(fact_id int Identity(1,1) Primary Key Not Null,
user_id int Foreign Key References Users Not Null,
name varchar(20) Not Null,
country varchar(20) Not Null,
city varchar(20) Not Null
)
Go
Create Table Store
(store_id int Identity(1,1) Primary Key Not Null,
name varchar(20) Not Null,
user_id int Foreign Key References Users Not Null,
capacity int Not Null,
country varchar(20) Not Null,
city varchar(20) Not Null
)
Go
Create Table Shop
(shop_id int Identity(1,1) Primary Key Not Null,
name varchar(20) Not Null,
user_id int Foreign Key References Users Not Null,
type_id int Foreign Key References Type Not Null,
count int Not Null
)
Go
Create Table Ingredients
(ingr_id int Identity(1,1) Primary Key Not Null,
name varchar(20)
)
Go
Create Table EquipmentFactory
(eqFact_id int Identity(1,1) Primary Key Not Null,
factory_id int Foreign Key References Factory Not Null,
eqip_id int Foreign Key References Equipment Not Null
)
Go
Create Table IngredientsBear
(ingBear_id int Identity(1,1) Primary Key Not Null,
ingr_id int Foreign Key References Ingredients Not Null,
typeBear_id int Foreign Key References Type Not Null
)
Go