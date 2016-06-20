<Query Kind="SQL">
  <Connection>
    <ID>82e8c497-b0cb-462b-9025-93f5957d8465</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>dbAuthenticationTest</Database>
  </Connection>
</Query>

SELECT * FROM users;
SELECT * FROM Applications;
SELECT * FROM Memberships;
SELECT * FROM Roles;


SELECT * FROM AspNet_Applications;
SELECT * FROM AspNet_Users;
SELECT * FROM AspNet_Membership;

DELETE FROM AspNet_Users;
DELETE FROM AspNet_Membership;

INSERT INTO AspNet_Users SELECT ApplicationId,UserId,UserName,UserName,null,IsAnonymous,LastActivityDate FROM Users;
INSERT INTO AspNet_Membership SELECT ApplicationId,UserId,Password,PasswordFormat,PasswordSalt,null,Email,Email,PasswordQuestion,PasswordAnswer,IsApproved,IsLockedOut,CreateDate,LastLoginDate,LastPasswordChangedDate,LastLockoutDate,FailedPasswordAttemptCount,FailedPasswordAttemptWindowStart,FailedPasswordAnswerAttemptCount,FailedPasswordAnswerAttemptWindowsStart,Comment FROM Memberships;