CREATE TABLE Country (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Area FLOAT,
    Continent NVARCHAR(100),
    Population INT
);

-- Create Capitalss table
CREATE TABLE Capitalss (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    CountryID INT FOREIGN KEY REFERENCES Countriess(ID),
    Population INT
);

-- Create BigCitiess table
CREATE TABLE BigCitiess (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    CountryID INT FOREIGN KEY REFERENCES Countriess(ID),
    Population INT
);

INSERT INTO Country (Name, Area, Continent, Population)
VALUES
('Ukraine', 603, 'Europe', 41730000),
('Russia', 17130000, 'Europe', 144500000),
('USA', 9373000, 'North America', 331000000),
('China', 9597000, 'Asia', 1440000000),
('India', 3287000, 'Asia', 1393409038),
('Australia', 7690000, 'Oceania', 25690000),
('Brazil', 8516000, 'South America', 211000000),
('Japan', 377900, 'Asia', 126800000);

-- Insert data into Capitalss
INSERT INTO Capitalss (Name, CountryID, Population)
VALUES
('Kyiv', 1, 2930000),
('Moscow', 2, 12580000),
('Washington, D.C.', 3, 692000),
('Beijing', 4, 21540000),
('New Delhi', 5, 31870000),
('Canberra', 6, 431000),
('Brasília', 7, 3010000),
('Tokyo', 8, 13929000);

-- Insert data into BigCitiess
INSERT INTO BigCitiess (Name, CountryID, Population)
VALUES
('Kyiv', 1, 9000000),
('Lviv', 1, 720000),
('Kharkiv', 1, 1400000),
('Moscow', 2, 12480000),
('Saint Petersburg', 2, 5000000),
('Yekaterinburg', 2, 1500000),
('Washington, D.C.', 3, 692000),
('Los Angeles', 3, 4000000),
('New York City', 3, 8400000),
('Beijing', 4, 21610000),
('Shanghai', 4, 24280000),
('Chengdu', 4, 16000000),
('New Delhi', 5, 31870000),
('Mumbai', 5, 12480000),
('Kolkata', 5, 14960000),
('Canberra', 6, 431000),
('Sydney', 6, 5310000),
('Melbourne', 6, 4740000),
('Brasília', 7, 3010000),
('São Paulo', 7, 12252023),
('Rio de Janeiro', 7, 6768000),
('Tokyo', 8, 13929000),
('Osaka', 8, 8830000);