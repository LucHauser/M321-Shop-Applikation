USE ProductCatalog;

CREATE TABLE IF NOT EXISTS Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Price FLOAT NOT NULL,
    Stock INT NOT NULL
);

INSERT INTO Products (Name, Description, Price, Stock) VALUES
('Product 1', 'Description for product 1', 10.0, 100),
('Product 2', 'Description for product 2', 20.0, 200),
('Product 3', 'Description for product 3', 30.0, 300);