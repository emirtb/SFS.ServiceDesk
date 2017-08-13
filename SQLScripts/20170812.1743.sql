

/************ Update: Schemas ***************/

/* Add Schema: SD */
--CREATE SCHEMA SD;




/************ Update: Tables ***************/

/******************** Add Table: SD.SDArea ************************/

/* Build Table Structure */
CREATE TABLE SD.SDArea
(
	GuidArea UniqueIdentifier NOT NULL,
	Name VARCHAR(255) NULL,
	GuidAreaParent UniqueIdentifier NULL,
	GuidOrganization UniqueIdentifier NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDArea ADD CONSTRAINT pkSDArea
	PRIMARY KEY (GuidArea);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDArea', 'column', 'GuidArea';

EXEC sp_addextendedproperty 'MS_Description', 'Nombre del área', 'schema', 'SD', 
	'table', 'SDArea', 'column', 'Name';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con área padre', 'schema', 'SD', 
	'table', 'SDArea', 'column', 'GuidAreaParent';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con organización', 'schema', 'SD', 
	'table', 'SDArea', 'column', 'GuidOrganization';

EXEC sp_addextendedproperty 'MS_Description', 'Areas jerárquicas que representan un departamento o un área dentro de la organización.', 'schema', 'SD', 
	'table', SDArea, null, null;


/******************** Add Table: SD.SDAreaPerson ************************/

/* Build Table Structure */
CREATE TABLE SD.SDAreaPerson
(
	GuidAreaPerson UniqueIdentifier NOT NULL,
	GuidArea UniqueIdentifier NULL,
	GuidPerson UniqueIdentifier NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDAreaPerson ADD CONSTRAINT pkSDAreaPerson
	PRIMARY KEY (GuidAreaPerson);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDAreaPerson', 'column', 'GuidAreaPerson';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con Area', 'schema', 'SD', 
	'table', 'SDAreaPerson', 'column', 'GuidArea';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con Persona', 'schema', 'SD', 
	'table', 'SDAreaPerson', 'column', 'GuidPerson';

EXEC sp_addextendedproperty 'MS_Description', 'Relación de área con una persona', 'schema', 'SD', 
	'table', SDAreaPerson, null, null;


/******************** Add Table: SD.SDCase ************************/

/* Build Table Structure */
CREATE TABLE SD.SDCase
(
	GuidCase UniqueIdentifier NOT NULL,
	GuidCaseStatus UniqueIdentifier NOT NULL,
	GuidPersonClient UniqueIdentifier NULL,
	ClosedDateTime DATETIME NULL,
	BodyContent VARCHAR(MAX) NULL,
	PreviewContent VARCHAR(3000) NULL,
	GuidCasePriority UniqueIdentifier NOT NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDCase ADD CONSTRAINT pkSDCase
	PRIMARY KEY (GuidCase);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'GuidCase';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con estados', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'GuidCaseStatus';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con persona que creo el caso, se considera cliente del servicio', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'GuidPersonClient';

EXEC sp_addextendedproperty 'MS_Description', 'Fecha y hora en que se ha cerrado el caso', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'ClosedDateTime';

EXEC sp_addextendedproperty 'MS_Description', 'Cuerpo completo del caso', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'BodyContent';

EXEC sp_addextendedproperty 'MS_Description', 'Texto plano de caso cortado a máximo 3000 caracteres', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'PreviewContent';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con prioridad', 'schema', 'SD', 
	'table', 'SDCase', 'column', 'GuidCasePriority';

EXEC sp_addextendedproperty 'MS_Description', 'Catálogo de casos', 'schema', 'SD', 
	'table', SDCase, null, null;


/******************** Add Table: SD.SDCaseFile ************************/

/* Build Table Structure */
CREATE TABLE SD.SDCaseFile
(
	GuidCasefile UniqueIdentifier NOT NULL,
	GuidCase UniqueIdentifier NULL,
	GuidFile UniqueIdentifier NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDCaseFile ADD CONSTRAINT pkSDCaseFile
	PRIMARY KEY (GuidCasefile);


/******************** Add Table: SD.SDCaseHistory ************************/

/* Build Table Structure */
CREATE TABLE SD.SDCaseHistory
(
	GuidCaseHistory UniqueIdentifier NOT NULL,
	GuidCase UniqueIdentifier NOT NULL,
	GuidCaseStatus UniqueIdentifier NULL,
	BodyContent VARCHAR(255) NULL,
	PreviewContent VARCHAR(3000) NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDCaseHistory ADD CONSTRAINT pkSDCaseHistory
	PRIMARY KEY (GuidCaseHistory);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDCaseHistory', 'column', 'GuidCaseHistory';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con caso', 'schema', 'SD', 
	'table', 'SDCaseHistory', 'column', 'GuidCase';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con estado', 'schema', 'SD', 
	'table', 'SDCaseHistory', 'column', 'GuidCaseStatus';

EXEC sp_addextendedproperty 'MS_Description', 'Contenido completo del caso', 'schema', 'SD', 
	'table', 'SDCaseHistory', 'column', 'BodyContent';

EXEC sp_addextendedproperty 'MS_Description', 'Contenido previo o cortado o abreviado del caso, todo texto plano', 'schema', 'SD', 
	'table', 'SDCaseHistory', 'column', 'PreviewContent';

EXEC sp_addextendedproperty 'MS_Description', 'Historias de caso', 'schema', 'SD', 
	'table', SDCaseHistory, null, null;


/******************** Add Table: SD.SDCaseHistoryFile ************************/

/* Build Table Structure */
CREATE TABLE SD.SDCaseHistoryFile
(
	GuidCasehistoryFile UniqueIdentifier NOT NULL,
	GuidFile UniqueIdentifier NULL,
	GuidCaseHistory UniqueIdentifier NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDCaseHistoryFile ADD CONSTRAINT pkSDCaseHistoryFile
	PRIMARY KEY (GuidCasehistoryFile);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDCaseHistoryFile', 'column', 'GuidCasehistoryFile';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con archivo', 'schema', 'SD', 
	'table', 'SDCaseHistoryFile', 'column', 'GuidFile';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con historia de caso', 'schema', 'SD', 
	'table', 'SDCaseHistoryFile', 'column', 'GuidCaseHistory';

EXEC sp_addextendedproperty 'MS_Description', 'Relación de historia y archivo', 'schema', 'SD', 
	'table', SDCaseHistoryFile, null, null;


/******************** Add Table: SD.SDCasePriority ************************/

/* Build Table Structure */
CREATE TABLE SD.SDCasePriority
(
	GuidCasePriority UniqueIdentifier NOT NULL,
	Title VARCHAR(255) NOT NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDCasePriority ADD CONSTRAINT pkSDCasePriority
	PRIMARY KEY (GuidCasePriority);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDCasePriority', 'column', 'GuidCasePriority';

EXEC sp_addextendedproperty 'MS_Description', 'Título de la prioridad', 'schema', 'SD', 
	'table', 'SDCasePriority', 'column', 'Title';

EXEC sp_addextendedproperty 'MS_Description', 'Catálogo de niveles de prioridad', 'schema', 'SD', 
	'table', SDCasePriority, null, null;


/******************** Add Table: SD.SDCaseStatus ************************/

/* Build Table Structure */
CREATE TABLE SD.SDCaseStatus
(
	GuidCaseStatus UniqueIdentifier NOT NULL,
	Title VARCHAR(255) NOT NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDCaseStatus ADD CONSTRAINT pkSDCaseStatus
	PRIMARY KEY (GuidCaseStatus);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDCaseStatus', 'column', 'GuidCaseStatus';

EXEC sp_addextendedproperty 'MS_Description', 'Título del estado', 'schema', 'SD', 
	'table', 'SDCaseStatus', 'column', 'Title';

EXEC sp_addextendedproperty 'MS_Description', 'Catálogo de estados', 'schema', 'SD', 
	'table', SDCaseStatus, null, null;


/******************** Add Table: SD.SDFile ************************/

/* Build Table Structure */
CREATE TABLE SD.SDFile
(
	GuidFile UniqueIdentifier NOT NULL,
	FileName VARCHAR(255) NOT NULL,
	FileType VARCHAR(255) NULL,
	FileSize BIGINT NULL,
	FileData VARBINARY(MAX) NULL,
	StorageLocation VARCHAR(255) NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDFile ADD CONSTRAINT pkSDFile
	PRIMARY KEY (GuidFile);


/******************** Add Table: SD.SDOrganization ************************/

/* Build Table Structure */
CREATE TABLE SD.SDOrganization
(
	GuidOrganization UniqueIdentifier NOT NULL,
	FullName VARCHAR(255) NOT NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDOrganization ADD CONSTRAINT pkSDOrganization
	PRIMARY KEY (GuidOrganization);


/******************** Add Table: SD.SDPerson ************************/

/* Build Table Structure */
CREATE TABLE SD.SDPerson
(
	GuidPerson UniqueIdentifier NOT NULL,
	DisplayName VARCHAR(255) NULL,
	GuidUser UniqueIdentifier NULL,
	GuidOrganization UniqueIdentifier NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDPerson ADD CONSTRAINT pkSDPerson
	PRIMARY KEY (GuidPerson);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDPerson', 'column', 'GuidPerson';

EXEC sp_addextendedproperty 'MS_Description', 'Nombre visual', 'schema', 'SD', 
	'table', 'SDPerson', 'column', 'DisplayName';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con usuario de sistema', 'schema', 'SD', 
	'table', 'SDPerson', 'column', 'GuidUser';

EXEC sp_addextendedproperty 'MS_Description', 'Relación con organización', 'schema', 'SD', 
	'table', 'SDPerson', 'column', 'GuidOrganization';

EXEC sp_addextendedproperty 'MS_Description', 'Persona o empleado dentro de la organización', 'schema', 'SD', 
	'table', SDPerson, null, null;


/******************** Add Table: SD.SDProxyUser ************************/

/* Build Table Structure */
CREATE TABLE SD.SDProxyUser
(
	GuidUser UniqueIdentifier NOT NULL,
	Email VARCHAR(255) NULL,
	DisplayName VARCHAR(255) NULL
);

/* Add Primary Key */
ALTER TABLE SD.SDProxyUser ADD CONSTRAINT pkSDProxyUser
	PRIMARY KEY (GuidUser);

/* Add Comments */
EXEC sp_addextendedproperty 'MS_Description', 'Identificador', 'schema', 'SD', 
	'table', 'SDProxyUser', 'column', 'GuidUser';

EXEC sp_addextendedproperty 'MS_Description', 'Correo electrónico', 'schema', 'SD', 
	'table', 'SDProxyUser', 'column', 'Email';

EXEC sp_addextendedproperty 'MS_Description', 'Nombre visual', 'schema', 'SD', 
	'table', 'SDProxyUser', 'column', 'DisplayName';

EXEC sp_addextendedproperty 'MS_Description', 'Tabla auxiliar para guardar a los usarios', 'schema', 'SD', 
	'table', SDProxyUser, null, null;





/************ Add Foreign Keys ***************/

/* Add Foreign Key: fk_Area_Parent */
ALTER TABLE SD.SDArea ADD CONSTRAINT fk_Area_Parent
	FOREIGN KEY (GuidAreaParent) REFERENCES SD.SDArea (GuidArea)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdArea_SdOrganization */
ALTER TABLE SD.SDArea ADD CONSTRAINT fk_SdArea_SdOrganization
	FOREIGN KEY (GuidOrganization) REFERENCES SD.SDOrganization (GuidOrganization)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdAreaPerson_SdArea */
ALTER TABLE SD.SDAreaPerson ADD CONSTRAINT fk_SdAreaPerson_SdArea
	FOREIGN KEY (GuidArea) REFERENCES SD.SDArea (GuidArea)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdAreaPerson_SdPerson */
ALTER TABLE SD.SDAreaPerson ADD CONSTRAINT fk_SdAreaPerson_SdPerson
	FOREIGN KEY (GuidPerson) REFERENCES SD.SDPerson (GuidPerson)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_Case_Person_Client */
ALTER TABLE SD.SDCase ADD CONSTRAINT fk_Case_Person_Client
	FOREIGN KEY (GuidPersonClient) REFERENCES SD.SDPerson (GuidPerson)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCase_SdCasePriority */
ALTER TABLE SD.SDCase ADD CONSTRAINT fk_SdCase_SdCasePriority
	FOREIGN KEY (GuidCasePriority) REFERENCES SD.SDCasePriority (GuidCasePriority)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCase_SdCaseStatus */
ALTER TABLE SD.SDCase ADD CONSTRAINT fk_SdCase_SdCaseStatus
	FOREIGN KEY (GuidCaseStatus) REFERENCES SD.SDCaseStatus (GuidCaseStatus)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCaseFile_SdCase */
ALTER TABLE SD.SDCaseFile ADD CONSTRAINT fk_SdCaseFile_SdCase
	FOREIGN KEY (GuidCase) REFERENCES SD.SDCase (GuidCase)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCaseFile_SdFile */
ALTER TABLE SD.SDCaseFile ADD CONSTRAINT fk_SdCaseFile_SdFile
	FOREIGN KEY (GuidFile) REFERENCES SD.SDFile (GuidFile)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCaseHistory_SdCase */
ALTER TABLE SD.SDCaseHistory ADD CONSTRAINT fk_SdCaseHistory_SdCase
	FOREIGN KEY (GuidCase) REFERENCES SD.SDCase (GuidCase)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCaseHistory_SdCaseStatus */
ALTER TABLE SD.SDCaseHistory ADD CONSTRAINT fk_SdCaseHistory_SdCaseStatus
	FOREIGN KEY (GuidCaseStatus) REFERENCES SD.SDCaseStatus (GuidCaseStatus)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCaseHistoryFile_SdCaseHistory */
ALTER TABLE SD.SDCaseHistoryFile ADD CONSTRAINT fk_SdCaseHistoryFile_SdCaseHistory
	FOREIGN KEY (GuidCaseHistory) REFERENCES SD.SDCaseHistory (GuidCaseHistory)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdCaseHistoryFile_SdFile */
ALTER TABLE SD.SDCaseHistoryFile ADD CONSTRAINT fk_SdCaseHistoryFile_SdFile
	FOREIGN KEY (GuidFile) REFERENCES SD.SDFile (GuidFile)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdPerson_SdOrganization */
ALTER TABLE SD.SDPerson ADD CONSTRAINT fk_SdPerson_SdOrganization
	FOREIGN KEY (GuidOrganization) REFERENCES SD.SDOrganization (GuidOrganization)
	ON UPDATE NO ACTION ON DELETE NO ACTION;

/* Add Foreign Key: fk_SdPerson_SdProxyUser */
ALTER TABLE SD.SDPerson ADD CONSTRAINT fk_SdPerson_SdProxyUser
	FOREIGN KEY (GuidUser) REFERENCES SD.SDProxyUser (GuidUser)
	ON UPDATE NO ACTION ON DELETE NO ACTION;