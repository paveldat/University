/*Представления*/
/*
Create View Workers As
Select user_id, u.name, surname, r.name as Role From Users u, Role r
Where u.role_id=r.role_id
*/
