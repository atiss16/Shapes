SELECT p.Name as ProductName, c.Name AS CategoryName
FROM Product p 
LEFT JOIN ProductCatergory pc 
	ON pc.ProductId = p.Id 
LEFT JOIN Catergory c
	ON c.Id = pc.CatergoryId;