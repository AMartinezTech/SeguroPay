
CREATE TABLE countries (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE regions (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    country_id UNIQUEIDENTIFIER NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Regions_Countries FOREIGN KEY (country_id)
        REFERENCES countries(id)
        ON DELETE NO ACTION
);

CREATE TABLE postal_codes (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    code NVARCHAR(20) NOT NULL,
    region_id UNIQUEIDENTIFIER NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_PostalCodes_Regions FOREIGN KEY (region_id)
        REFERENCES regions(id)
        ON DELETE NO ACTION
);

CREATE TABLE cities (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    postal_code_id UNIQUEIDENTIFIER NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Cities_PostalCodes FOREIGN KEY (postal_code_id)
        REFERENCES postal_codes(id)
        ON DELETE NO ACTION
);

CREATE TABLE streets (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    street NVARCHAR(200) NOT NULL,
    city_id UNIQUEIDENTIFIER NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	CONSTRAINT FK_Streent_Cities FOREIGN KEY (city_id)
        REFERENCES cities(id)
        ON DELETE NO ACTION
);

CREATE TABLE clients (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    category_id UNIQUEIDENTIFIER NOT NULL,
    doc_identity_type_id UNIQUEIDENTIFIER NOT NULL,
    type_id UNIQUEIDENTIFIER NOT NULL,
    doc_identity NVARCHAR(50) NOT NULL,
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    street_id UNIQUEIDENTIFIER NULL,
    city_id UNIQUEIDENTIFIER NULL,
    postal_code_id UNIQUEIDENTIFIER NULL,
    region_id UNIQUEIDENTIFIER NULL,
    country_id UNIQUEIDENTIFIER NULL,
    phone NVARCHAR(50) NULL,
    email NVARCHAR(100) NULL,
    observation NVARCHAR(300) NULL,
	location_no NVARCHAR(50) NULL,        
    address_ref NVARCHAR(200) NULL,       
    is_actived BIT NOT NULL DEFAULT 1,   
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Clients_Streets FOREIGN KEY (street_id)
        REFERENCES streets(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Clients_City FOREIGN KEY (city_id)
        REFERENCES cities(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Clients_PostalCode FOREIGN KEY (postal_code_id)
        REFERENCES postal_codes(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Clients_Region FOREIGN KEY (region_id)
        REFERENCES regions(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Clients_Country FOREIGN KEY (country_id)
        REFERENCES countries(id)
        ON DELETE NO ACTION
);







