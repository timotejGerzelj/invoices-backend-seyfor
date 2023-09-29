-- Create tables
CREATE TABLE articles_table (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX) NOT NULL,
    price REAL NOT NULL
);

CREATE TABLE client_table (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX) NOT NULL,
    address NVARCHAR(MAX) NOT NULL
);

CREATE TABLE organisation_table (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX) NOT NULL,
    description NVARCHAR(MAX) NOT NULL
);

CREATE TABLE invoice_table (
    id INT IDENTITY(1,1) PRIMARY KEY,
    date_of_creation DATETIME2 NOT NULL,
    price REAL NOT NULL,
    org_id INT NOT NULL,
    client_id INT NOT NULL,
    FOREIGN KEY (org_id) REFERENCES organisation_table (id) ON DELETE CASCADE,
    FOREIGN KEY (client_id) REFERENCES client_table (id) ON DELETE CASCADE
);

CREATE TABLE line_items_table (
    id INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT NOT NULL,
    invoice_id INT NOT NULL,
    article_id INT NOT NULL,
    FOREIGN KEY (invoice_id) REFERENCES invoice_table (id) ON DELETE CASCADE
);

-- Create indexes
CREATE INDEX IX_invoice_table_client_id ON invoice_table (client_id);
CREATE INDEX IX_invoice_table_org_id ON invoice_table (org_id);
CREATE INDEX IX_line_items_table_invoice_id ON line_items_table (invoice_id);


-- Insert 10 Article records
DECLARE @articleCounter INT = 1;
WHILE @articleCounter <= 10
BEGIN
    INSERT INTO articles_table (name, price)
    VALUES ('Article' + CAST(@articleCounter AS NVARCHAR(MAX)), 10.00);

    SET @articleCounter = @articleCounter + 1;
END

-- Insert 2 Organisation records
INSERT INTO organisation_table (name, description)
VALUES ('Organisation1', 'Description 1');

-- Insert 1000 Client records
DECLARE @clientCounter INT = 1;
WHILE @clientCounter <= 1000
BEGIN
    INSERT INTO client_table (name, address)
    VALUES ('Client' + CAST(@clientCounter AS NVARCHAR(MAX)), 'Address' + CAST(@clientCounter AS NVARCHAR(MAX)));

    SET @clientCounter = @clientCounter + 1;
END

-- Create Invoice records with associated LineItems
DECLARE @invoiceCounter INT = 1;
WHILE @invoiceCounter <= 1000
BEGIN
    -- Set a random client_id between 1 and 500
    DECLARE @randomClientId INT = CAST(RAND() * (500 - 1) + 1 AS INT);

    INSERT INTO invoice_table (date_of_creation, price, org_id, client_id)
    VALUES ('2023-09-22', 50.00, 1, @randomClientId);

    -- Add 10 LineItem records for each Invoice with unique article_id
    DECLARE @lineItemCounter INT = 1;
    WHILE @lineItemCounter <= 5
    BEGIN
        INSERT INTO line_items_table (quantity, invoice_id, article_id)
        VALUES (1, @invoiceCounter, @lineItemCounter);

        SET @lineItemCounter = @lineItemCounter + 1;
    END

    SET @invoiceCounter = @invoiceCounter + 1;
END
