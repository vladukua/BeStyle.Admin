USE BeStyleDB;

GO

SET IDENTITY_INSERT tblUser ON;
INSERT INTO tblUser(Id, FirstName, LastName, Email, Phone, Login, Password)
VALUES
	(1,'Vitaly','Mogola','vitalijmogola@gmail.com','+380673357055', 'Vitaly', 'Vitaly'),
	(2,'Andriy','Tsap','lembergtsap@gmail.com','', 'Andriy', 'Andriy'),
	(3,'Volodymyr','Teodorovich','vladukteo@gmail.com','','Volodia','Volodia');	
SET IDENTITY_INSERT tblUser OFF;

SET IDENTITY_INSERT tblUserRole ON;
INSERT INTO tblUserRole(Id, UserId, Role)
VALUES 
		(1,1, 'Master'),
		(2,2, 'Moderator'),
		(3,3, 'Editor');
SET IDENTITY_INSERT tblUserRole OFF;


	