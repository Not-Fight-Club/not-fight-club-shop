--Values to insert for testing
INSERT INTO SEASONAL (SeasonalName, SeasonalStartDate, SeasonalEndDate)
VALUES ('Halloween 2021', '9-1-2021', '11-1-2021');

INSERT INTO SEASONAL (SeasonalName, SeasonalStartDate, SeasonalEndDate)
VALUES ('Christmas 2021', '11-1-2021', '1-1-2022');

INSERT INTO PRODUCT (ProductName, ProductPrice, ProductDescription)
VALUES ('Balloon', 20, 'You can hang balloons anywhere');

INSERT INTO PRODUCT (SeasonalId, ProductName, ProductPrice, ProductDescription)
VALUES (1, 'Spooky Balloon', 20, 'A spooky balloon for Halloween');

INSERT INTO PRODUCT (SeasonalId, ProductName, ProductPrice, ProductDescription)
VALUES (2, 'Christmas Balloon', 20, 'A festive balloon for those who celebrate Christmas');

INSERT INTO SEASONAL (SeasonalName, SeasonalStartDate, SeasonalStartDate)
VALUES('Christmas 2021', '11-1-2021', '1-1-2021');

UPDATE SEASONAL
SET SeasonalName = 'Holidays 2021', SeasonalStartDate = '11-1-2021', SeasonalEndDate = '1-1-2022'
WHERE SeasonalId = 2;

SELECT *
FROM SEASONAL;
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

--Execute the procedure
EXECUTE GetAllSeasonalItems '10-05-2021';