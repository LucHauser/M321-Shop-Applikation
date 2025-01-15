USE Order;

CREATE TABLE IF NOT EXISTS Orders (
    OrderId INT AUTO_INCREMENT PRIMARY KEY,
    OrderDate DATETIME NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    Status VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS OrderItems (
    OrderItemId INT AUTO_INCREMENT PRIMARY KEY,
    OrderId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE
);

INSERT INTO Orders (OrderDate, TotalPrice, Status) VALUES
('2023-10-01 10:00:00', 100.00, 'In Bearbeitung'),
('2023-10-02 11:00:00', 150.50, 'Geliefert'),
('2023-10-03 12:00:00', 200.75, 'Versendet');

-- Insert example data into OrderItems table
INSERT INTO OrderItems (OrderId, Quantity, Price) VALUES
(1, 2, 50.00),
(1, 1, 50.00),
(2, 3, 50.00),
(2, 1, 50.50),
(3, 4, 50.00),
(3, 2, 50.75);
