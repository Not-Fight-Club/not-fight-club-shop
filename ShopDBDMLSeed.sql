INSERT INTO Category(Category)
VALUES('Trait'),
('Location'),
('Edit Character'),
('Weather'),
('Weapon')


INSERT INTO SEASONAL (SeasonalName, SeasonalStartDate, SeasonalEndDate)
VALUES ('Halloween 2021', '9-1-2021', '11-1-2021');

INSERT INTO PRODUCT (ProductName, ProductPrice, ProductDescription, CategoryId)
VALUES ('Balloon', 2500, 'You can hang balloons anywhere', 5),



INSERT INTO PRODUCT (SeasonalId, ProductName, ProductDiscount, ProductPrice, ProductDescription, CategoryId)
VALUES (1, 'Scary Mask',50, 50, 'A scary mask for Halloween', 5),
(1, 'Pumpkin', 2500, '300 pound pumpkin that you can toss at your opponent to negate one of their arguments', 5),
(1, 'Skeleton', 2500, 'A skeleton', 5),
(1, 'Murder Mystery Dinner Party', 2000, 'A skeleton', 2),
(1, 'Murder Mystery Dinner Party', 2000, 'A skeleton', 2),
