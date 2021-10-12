--Values to insert for testing
INSERT INTO SEASONAL (SeasonalName, SeasonalStartDate, SeasonalEndDate)
VALUES ('Halloween 2021', '9-1-2021', '11-1-2021');

INSERT INTO PRODUCT (ProductName, ProductPrice, ProductDescription)
VALUES ('Balloon', 20, 'You can hang balloons anywhere');

INSERT INTO PRODUCT (SeasonalId, ProductName, ProductPrice, ProductDescription)
VALUES (1, 'Spooky Balloon', 20, 'A spooky balloon for Halloween');
GO

--Stored Procedure to create
CREATE PROCEDURE GetAllSeasonalItems
	@SeasonalDate DATE
AS
BEGIN
	SELECT *
	FROM Product
	WHERE SeasonalId = (SELECT SeasonalId
	FROM Seasonal
	WHERE @SeasonalDate > SeasonalStartDate AND @SeasonalDate < SeasonalEndDate)
END
GO

--Cirnoizing the world
EXECUTE GetAllSeasonalItems '10-5-2021';