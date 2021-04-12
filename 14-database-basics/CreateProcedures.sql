USE RewardingUsers
GO

CREATE OR ALTER PROCEDURE InsertUser(
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@birthdate date)
AS
	INSERT INTO Users(FirstName, LastName, Birthdate)
	VALUES(@firstName, @lastName, @birthdate)
GO

CREATE OR ALTER PROCEDURE InsertReward(
	@title nvarchar(50),
	@description nvarchar(250))
AS
	INSERT INTO Rewards(Title, DescriptionReward)
	VALUES(@title, @description)
GO

CREATE OR ALTER PROCEDURE InsertUserReward(
	@userID int,
	@rewardID int)
AS
	INSERT INTO UserRewards(UserID, RewardID)
	VALUES (@userID, @rewardID)
GO

CREATE OR ALTER PROCEDURE DeleteUser(@userID int)
AS
	DELETE FROM Users WHERE UserID = @userID
GO

CREATE OR ALTER PROCEDURE DeleteReward(@rewardID int)
AS
	DELETE FROM Rewards WHERE RewardID = @rewardID
GO

CREATE OR ALTER PROCEDURE DeleteUserReward(@userID int)
AS
	DELETE FROM UserRewards WHERE UserID = @userID
GO

CREATE OR ALTER PROCEDURE DeleteRewardOfUser(@rewardID int)
AS
	DELETE FROM UserRewards WHERE RewardID = @rewardID
GO

CREATE OR ALTER PROCEDURE UpdateUser(
	@userID int,
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@birthdate date)
AS
	UPDATE Users
	SET 
		FirstName = @firstName,
		LastName = @lastName,
		Birthdate = @birthdate

	WHERE UserID = @userID
GO

CREATE OR ALTER PROCEDURE UpdateReward(
	@rewardID int,
	@title nvarchar(50),
	@description nvarchar(250))
AS
	UPDATE Rewards
	SET
		Title = @title,
		DescriptionReward = @description

	WHERE RewardID = @rewardID
GO

CREATE OR ALTER PROCEDURE GetUsers
AS
	SELECT * FROM Users
GO

CREATE OR ALTER PROCEDURE GetRewards
AS
	SELECT * FROM Rewards
GO

CREATE OR ALTER PROCEDURE GetRewardsOfUser(@userID int)
AS
	SELECT Rewards.RewardID
		,Title
		,DescriptionReward
	FROM UserRewards
	INNER JOIN Rewards
	ON UserRewards.RewardID = Rewards.RewardID
	WHERE UserID = @userID
GO