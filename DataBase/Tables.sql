
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
 
CREATE TABLE cities (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    region_id UNIQUEIDENTIFIER NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Cities_Rigions FOREIGN KEY (region_id)
        REFERENCES regions(id)
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
 
 ALTER TABLE cities
DROP CONSTRAINT FK_Cities_Rigions;


CREATE TABLE doc_identity_types (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_actived BIT NOT NULL DEFAULT 1 
);

CREATE TABLE client_categories (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_actived BIT NOT NULL DEFAULT 1 
);

CREATE TABLE client_types (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_actived BIT NOT NULL DEFAULT 1 
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
	contact_name NVARCHAR(100) NULL,
	contact_phone NVARCHAR(50) NULL,
    is_actived BIT NOT NULL DEFAULT 1,   
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

	CONSTRAINT FK_Clients_Streets FOREIGN KEY (street_id)
        REFERENCES streets(id)
        ON DELETE NO ACTION,
 
    CONSTRAINT FK_Clients_City FOREIGN KEY (city_id)
        REFERENCES cities(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Clients_Region FOREIGN KEY (region_id)
        REFERENCES regions(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Clients_Country FOREIGN KEY (country_id)
        REFERENCES countries(id)
        ON DELETE NO ACTION
);


CREATE TABLE companies (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    rnc NVARCHAR(50) NOT NULL,
    name NVARCHAR(100) NOT NULL,
    street_id UNIQUEIDENTIFIER NULL,
    city_id UNIQUEIDENTIFIER NULL,
    region_id UNIQUEIDENTIFIER NULL,
    country_id UNIQUEIDENTIFIER NULL,
    phone NVARCHAR(50) NULL,
    email NVARCHAR(100) NULL,
    line1 NVARCHAR(300) NULL,    
    line2 NVARCHAR(300) NULL,    
    is_actived BIT NOT NULL DEFAULT 1,   
    
	CONSTRAINT FK_Companies_Streets FOREIGN KEY (street_id)
        REFERENCES streets(id)
        ON DELETE NO ACTION,
 
    CONSTRAINT FK_Companies_City FOREIGN KEY (city_id)
        REFERENCES cities(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Companies_Region FOREIGN KEY (region_id)
        REFERENCES regions(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_Companies_Country FOREIGN KEY (country_id)
        REFERENCES countries(id)
        ON DELETE NO ACTION
);


CREATE TABLE users (
	id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	email NVARCHAR(50) NOT NULL,
	password NVARCHAR(20) NOT NULL,
	full_name NVARCHAR(50) NOT NUll,
	phone NVARCHAR(20) NOT NULL,
	rol NVARCHAR(15) NOT NULL,
	is_actived BIT NOT NULL DEFAULT 1
);

-- sin ejecutar de aqui para abajo


CREATE TABLE insurances (
	id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    name NVARCHAR(100) NOT NULL,
    street_id UNIQUEIDENTIFIER NULL,
    city_id UNIQUEIDENTIFIER NULL,
    region_id UNIQUEIDENTIFIER NULL,
    country_id UNIQUEIDENTIFIER NULL,
    phone NVARCHAR(50) NULL,
    email NVARCHAR(100) NULL,
    contact_name NVARCHAR(100) NULL,    
    contact_phone NVARCHAR(100) NULL,    
    is_actived BIT NOT NULL DEFAULT 1,   
);

CREATE TABLE policy_types (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_actived BIT NOT NULL DEFAULT 1,
	insurance_id UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Policy_Ensurance FOREIGN KEY (insurance_id) REFERENCES insurances(id)
);


CREATE TABLE policies (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    policy_no NVARCHAR(50) NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    client_id UNIQUEIDENTIFIER NOT NULL,
    insurance_id UNIQUEIDENTIFIER NOT NULL,
    type_id UNIQUEIDENTIFIER NOT NULL,
    pay_day INT NOT NULL,
    pay_frencuency NVARCHAR(50) NOT NULL,  -- Mensual, Trimestral, Semestral, Anual
    amount DECIMAL(18,2) NOT NULL,
    status NVARCHAR(50) NOT NULL DEFAULT 'Inactiva',  -- Activa, Suspendida, Cancelada, Inactiva
    note NVARCHAR(MAX) NULL,
    created_by UNIQUEIDENTIFIER NOT NULL,
    activate_by UNIQUEIDENTIFIER NULL,
    suspend_by UNIQUEIDENTIFIER NULL,
    cancel_by UNIQUEIDENTIFIER NULL,

    -- Foreign keys (asumiendo que existen las tablas clients, ensurances, types y users)
    CONSTRAINT FK_Policy_Client FOREIGN KEY (client_id) REFERENCES clients(id),
    CONSTRAINT FK_Policy_Ensurance FOREIGN KEY (insurance_id) REFERENCES insurances(id),
    CONSTRAINT FK_Policy_Type FOREIGN KEY (type_id) REFERENCES policy_types(id),
    CONSTRAINT FK_Policy_CreatedBy FOREIGN KEY (created_by) REFERENCES users(id),
    CONSTRAINT FK_Policy_ActivateBy FOREIGN KEY (activate_by) REFERENCES users(id),
    CONSTRAINT FK_Policy_SuspendBy FOREIGN KEY (suspend_by) REFERENCES users(id),
    CONSTRAINT FK_Policy_CancelBy FOREIGN KEY (cancel_by) REFERENCES users(id)
);


CREATE TABLE client_conversations
(
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,   -- Identificador único
    client_id UNIQUEIDENTIFIER NOT NULL,        -- Cliente relacionado
    channel NVARCHAR(20) NOT NULL,              -- "Telefono" o "WhatsApp"
    contact_number NVARCHAR(20) NOT NULL,       -- Número desde el cual o hacia el cual se realizó la conversación
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(), -- Fecha/hora de la conversación
    subject NVARCHAR(200) NULL,                 -- Título breve o motivo de la conversación
    message NVARCHAR(MAX) NOT NULL,             -- Contenido principal de la conversación
    created_by UNIQUEIDENTIFIER NOT NULL,       -- Usuario interno que registró la conversación
  
    -- Relaciones
    CONSTRAINT FK_Conversation_Client FOREIGN KEY (client_id) REFERENCES clients(id),
    CONSTRAINT FK_Conversation_User FOREIGN KEY (created_by) REFERENCES users(id),

    -- Restricciones para asegurar la integridad
    CONSTRAINT CK_Conversation_Channel CHECK (channel IN ('Telefono', 'WhatsApp'))
);

CREATE TABLE bank_accounts (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    name NVARCHAR(150) NOT NULL,             -- ValueBankAccountName
    number NVARCHAR(30) NOT NULL UNIQUE,     -- ValueBankAccountNumber
    type INT NOT NULL,                       -- BankAccountType (Enum)
    contact_name NVARCHAR(150) NULL,
    contact_phone NVARCHAR(20) NULL,
    is_actived BIT NOT NULL DEFAULT 1
);

CREATE TABLE bank_deposits (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    bank_account_id UNIQUEIDENTIFIER NOT NULL,       -- Relación con BankAccounts
	type NVARCHAR(50) NOT NULL,						-- Tipo de depósito: Efectivo, Cheque, Transferencia, Tarjeta
    amount DECIMAL(18,2) NOT NULL,                 -- Monto del depósito
    date DATETIME2 NOT NULL DEFAULT GETDATE(), -- Fecha del depósito
    reference NVARCHAR(100) NULL,                  -- No. de recibo, referencia bancaria
    note NVARCHAR(500) NULL,                       -- Comentario adicional
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    created_by UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_BankDeposits_BankAccounts FOREIGN KEY (bank_account_id)
        REFERENCES bank_accounts(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

