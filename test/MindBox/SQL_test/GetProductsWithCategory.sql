USE CategoryProducts

SELECT
	Product.Name Product,
	Category.Name Category
FROM 
	Product
LEFT JOIN CategoryProduct
	ON CategoryProduct.ProductId = Product.ProductId
LEFT JOIN Category
	ON Category.CategoryId = CategoryProduct.CategoryId
