# ProductsStore

Tools and technologies:
-	MS Visual Studio 2017; 
-	MS SQL Server (in MS Visual Studio);
-	Entity Framework;
-	Microsoft.AspNet.Identity;
-	SimpleInjector;
- Windows Forms.

Main features and forms:
- Main Form (located DataGridView). Also on the form located: Group panel (grouping by Date, Company, City, Country, Surname Name), 
Main Panel (buttons: Create shipment (form), Update shipments (Update shipments from database), 
Delete shipment (Delete shipment can only owner (manager))), Menu (Change password, Administering (only for admins), Exit).

-  Create shipment Form. Rules: If first manager`s shipment - allow any data (Sum); 
If first manager`s shipment on current month and year (Sum<=Average Sum last month where were shipments for current manager+500); 
Sum<= average sum on current month for current manager +500.

- Administering Form (located TabControl Register and TabControl Edit/Delete). Administering Form only for admins. 
Register and Reset password without password reliability checking. User must change password (in there checking password reliability)

     -Register - Admin register new users/admins. 
  
     -Edit/Delete - Admin edit users/admins; Reset passwords (In here unlock user (after 3 consecutive inputs of the wrong password)); 
  Delete users/admins (If manager maked shipments - Manager got value deleted in database (table AspNetUsers, field Deleted)).
  
- Change password Form.

- Login Form. For admins (role = “admin”) LockoutEnabled = false. For users (role = “user”) LockoutEnabled = true (lock users after 3 
consecutive inputs of the wrong password).

- data validation (in all forms).

The project was made in three-layer architecture.

Users in database:
- Login: “administrator”, password: “Qwerty_123456789”, role: ”admin”;
- Login: “Petrov123”, password: “123QW_qw”, role: ”user”.
