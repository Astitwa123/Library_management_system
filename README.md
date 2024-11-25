# Library_management_system
The library management system is a web based application developed using asp.net that streamlines the management of library resources, offering a user-friendly interface for both administrators and members.The system implements Authentication, Authorization, and Role-Based Access Control to ensure a secure and effiecient library experience
Admin Functionalities
Add Books:

Admin can enter new book details such as title, author, genre, publication date, ISBN, and quantity.
The system validates the entered information to ensure it is complete.
The book is then added to the database, updating the library’s catalog for users to see.
Grant Books (Issue Books to Users):

Admin can search for a user by their ID or name to initiate the book-granting process.
Admin selects the desired book and assigns it to a specific user.
The system records the book's due date and updates the availability status in the inventory.
A notification or record is created for both the user and the admin about the granted book.
Remove User:

Admin can search for and view a list of registered users.
Admin selects a user to be removed from the system, typically due to violations or inactivity.
The system checks if the user has any outstanding borrowed books before allowing removal.
If all conditions are met, the user’s data is deleted from the database.
Add User:

Admin can manually register a new user by entering their details, including name, email, and contact information.
The system verifies the user’s information and creates an account in the database.
An initial password may be generated, and the user is prompted to change it upon first login.
Add Author:

Admin can input new author details such as name, biography, and a list of published works.
The author is added to the database, and books can now be associated with the new author.
This functionality can also update existing author information if necessary.
User Functionalities
Create Account (Sign Up):

Users can register a new account by providing essential details like name, email, password, and phone number.
The system checks if the email is unique to prevent duplicates.
The account is created, and user details are stored in the database for authentication.
Login:

Users enter their email/username and password to access their account.
The system verifies credentials against the database.
If successful, a session is created to track the authenticated user.
Logout:

Users can securely log out of their account by terminating the session.
The system removes session data to ensure no further access without re-authentication.
This prevents unauthorized access to the user’s account.
Security via Session
Session Management:
When a user or admin logs in, a session is created, which stores essential information like user ID and role.
This session is validated on each page to ensure the user is authenticated and has the proper access rights.
If a session expires (after a set timeout or user logout), the user is redirected to the login page.
Sensitive operations, like adding/removing books or granting access, are restricted based on the session data
