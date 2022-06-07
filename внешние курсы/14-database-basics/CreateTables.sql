USE RewardingUsers

DROP TABLE UserRewards

DROP TABLE Users

DROP TABLE Rewards

CREATE TABLE Users(
UserID int IDENTITY(1,1),
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
Birthdate date NOT NULL,
CONSTRAINT UserID_PK PRIMARY KEY (UserID)
)

CREATE TABLE Rewards(
RewardID int IDENTITY(1,1),
Title nvarchar(50) NOT NULL,
DescriptionReward nvarchar(250),
CONSTRAINT RewardID_PK PRIMARY KEY (RewardID)
)

CREATE TABLE UserRewards(
UserID int NOT NULL,
RewardID int NOT NULL,
CONSTRAINT UserReward_PK PRIMARY KEY (UserID, RewardID),
CONSTRAINT UserID_FK FOREIGN KEY (UserID) REFERENCES Users(UserID),
CONSTRAINT RewardID_FK FOREIGN KEY (RewardID) REFERENCES Rewards(RewardID)
)
