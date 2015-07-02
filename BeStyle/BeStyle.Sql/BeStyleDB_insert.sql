USE BeStyleDB;

GO

SET IDENTITY_INSERT tblAdmin ON;
INSERT INTO tblAdmin(Id, FirstName, LastName, Email, Phone)

VALUES
	(1,'Vitaly','Mogola','vitalijmogola@gmail.com','+38073357055'),
	(2,'Andriy','Tsap','lembergtsap@gmail.com','+38073357055'),
	(3,'Volodymyr','Teodorovich','vladukteo@gmail.com','');
	
INSERT INTO tblAdminCredential(AdminId, Login, Password)
VALUES
		(1, 'Vitaly','Vitaly'),
		(2, 'Andriy','Andriy'),
		(3, 'Volodia','Volodia');
		