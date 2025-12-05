
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
    is_active BIT NOT NULL DEFAULT 1 
);

CREATE TABLE clients_categories (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_active BIT NOT NULL DEFAULT 1 
);

CREATE TABLE client_types (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_active BIT NOT NULL DEFAULT 1 
);

CREATE TABLE clients (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    category NVARCHAR(100) NOT NULL,
    doc_identity_type NVARCHAR(100) NOT NULL,
    client_type NVARCHAR(100) NOT NULL,
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
    is_active BIT NOT NULL DEFAULT 1,   
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

	CONSTRAINT FK_clientss_Streets FOREIGN KEY (street_id)
        REFERENCES streets(id)
        ON DELETE NO ACTION,
 
    CONSTRAINT FK_clientss_City FOREIGN KEY (city_id)
        REFERENCES cities(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_clientss_Region FOREIGN KEY (region_id)
        REFERENCES regions(id)
        ON DELETE NO ACTION,

    CONSTRAINT FK_clientss_Country FOREIGN KEY (country_id)
        REFERENCES countries(id)
        ON DELETE NO ACTION
);


CREATE TABLE companies (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    rnc NVARCHAR(50) NOT NULL,
    name NVARCHAR(100) NOT NULL, 
    phone NVARCHAR(50) NULL,
    email NVARCHAR(100) NULL,
    line1 NVARCHAR(300) NULL,    
    line2 NVARCHAR(300) NULL,    
    is_active BIT NOT NULL DEFAULT 1,  
	logo VARBINARY(MAX) NULL,
);


CREATE TABLE users (
	id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	email NVARCHAR(50) NOT NULL,
	password NVARCHAR(20) NOT NULL,
	full_name NVARCHAR(50) NOT NUll,
	phone NVARCHAR(20) NOT NULL,
	rol NVARCHAR(15) NOT NULL,
	is_active BIT NOT NULL DEFAULT 1
);

-- sin ejecutar de aqui para abajo


CREATE TABLE insurances (
	id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    name NVARCHAR(100) NOT NULL,
    address NVARCHAR(300) NULL,
    phone NVARCHAR(50) NULL,
    email NVARCHAR(100) NULL,
    contact_name NVARCHAR(100) NULL,    
    contact_phone NVARCHAR(100) NULL,    
    is_active BIT NOT NULL DEFAULT 1,   
);

CREATE TABLE policy_types (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_active BIT NOT NULL DEFAULT 1,
	insurance_id UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Policy_type_Ensurance FOREIGN KEY (insurance_id) REFERENCES insurances(id)
);


CREATE TABLE policies (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    policy_no NVARCHAR(50) NOT NULL,
    policy_type NVARCHAR(50) NOT NULL,
    insurance_id UNIQUEIDENTIFIER NOT NULL,
    clients_id UNIQUEIDENTIFIER NOT NULL,
    payment_frencuency NVARCHAR(50) NOT NULL,  -- Mensual, Trimestral, Semestral, Anual
	payment_day INT NOT NULL,
    payment_installment INT DEFAULT 0 NOT NULL,
	amount DECIMAL(18,2) NOT NULL,
    note NVARCHAR(MAX) NULL,
    status NVARCHAR(50) NOT NULL DEFAULT 'Inactive',  -- Activa, Suspendida, Cancelada, Inactiva
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    
    -- Foreign keys (asumiendo que existen las tablas clientss, ensurances, types y users)
      CONSTRAINT FK_Policy_clients FOREIGN KEY (clients_id) REFERENCES clients(id),
      CONSTRAINT FK_Policy_Ensurance FOREIGN KEY (insurance_id) REFERENCES insurances(id),
);

ALTER TABLE policies DROP CONSTRAINT FK_Policy_Type ;



CREATE TABLE incomes (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    payment_date DATE NOT NULL,           
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    policy_id UNIQUEIDENTIFIER NOT NULL,
	client_id UNIQUEIDENTIFIER NOT NULL,
	income_type NVARCHAR(50) NOT NULL,
	payment_method  NVARCHAR(50) NOT NULL,
	made_in NVARCHAR(50) NOT NULL,
    created_by UNIQUEIDENTIFIER NULL,    -- Usuario que registró el pago
    amount DECIMAL(18,2) NOT NULL,      -- Monto pagado
    note NVARCHAR(MAX) NUll
);


CREATE TABLE clients_conversations
(
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,   -- Identificador único
    client_id UNIQUEIDENTIFIER NOT NULL,        -- clientse relacionado
    channel NVARCHAR(20) NOT NULL,              -- "Telefono", "WhatsApp" o "Correo"
    contact_number NVARCHAR(20) NOT NULL,       -- Número desde el cual o hacia el cual se realizó la conversación
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(), -- Fecha/hora de la conversación
    subject NVARCHAR(200) NOT NULL,                 -- Título breve o motivo de la conversación
    message TEXT NOT NULL,             -- Contenido principal de la conversación
    created_by UNIQUEIDENTIFIER NOT NULL,       -- Usuario interno que registró la conversación
  
    -- Relaciones
    CONSTRAINT FK_Conversation_clients FOREIGN KEY (clients_id) REFERENCES clients(id),
    CONSTRAINT FK_Conversation_User FOREIGN KEY (created_by) REFERENCES users(id),

    -- Restricciones para asegurar la integridad
    CONSTRAINT CK_Conversation_Channel CHECK (channel IN ('Teléfono', 'WhatsApp', 'Correo'))
);


CREATE TABLE expense_categories (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    name NVARCHAR(200) NOT NULL,
    is_active BIT NOT NULL DEFAULT 1 
);

CREATE TABLE expenses (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT GETDATE(),  
	category_id UNIQUEIDENTIFIER NOT NULL,         
	amount DECIMAL(18,2) NOT NULL,                  
    note NVARCHAR(200) NULL,
    is_active BIT NOT NULL DEFAULT 1,
	created_by UNIQUEIDENTIFIER NOT NULL, 
	CONSTRAINT FK_category_expense FOREIGN KEY (category_id) REFERENCES expense_categories(id)
);

CREATE TABLE bank_accounts (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    name NVARCHAR(150) NOT NULL,             -- ValueBankAccountName
    number NVARCHAR(30) NOT NULL UNIQUE,     -- ValueBankAccountNumber
    type NVARCHAR(30) NOT NULL,                       -- BankAccountType (Enum)
    contact_name NVARCHAR(150) NULL,
    contact_phone NVARCHAR(20) NULL,
    is_active BIT NOT NULL DEFAULT 1
);

CREATE TABLE bank_account_movements (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    bank_account_id UNIQUEIDENTIFIER NOT NULL,       -- Relación con BankAccounts
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
	type NVARCHAR(50) NOT NULL,						-- Tipo de depósito: Efectivo, Cheque, Transferencia, Tarjeta
    amount DECIMAL(18,2) NOT NULL,                 -- Monto del depósito
    date DATETIME2 NOT NULL DEFAULT GETDATE(), -- Fecha del depósito
    description NVARCHAR(500) NULL,                       -- Comentario adicional
    created_by UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_BankDeposits_BankAccounts FOREIGN KEY (bank_account_id)
        REFERENCES bank_accounts(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

