 
 
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDArea' and i.name = 'SDArea_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDArea_FullStatics_Idx 
    on SD.SDArea ( 
GuidArea 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDAreaPerson' and i.name = 'SDAreaPerson_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDAreaPerson_FullStatics_Idx 
    on SD.SDAreaPerson ( 
GuidAreaPerson 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDCase' and i.name = 'SDCase_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDCase_FullStatics_Idx 
    on SD.SDCase ( 
GuidCase 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDCaseFile' and i.name = 'SDCaseFile_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDCaseFile_FullStatics_Idx 
    on SD.SDCaseFile ( 
GuidCasefile 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDCaseHistory' and i.name = 'SDCaseHistory_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDCaseHistory_FullStatics_Idx 
    on SD.SDCaseHistory ( 
GuidCaseHistory 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDCaseHistoryFile' and i.name = 'SDCaseHistoryFile_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDCaseHistoryFile_FullStatics_Idx 
    on SD.SDCaseHistoryFile ( 
GuidCasehistoryFile 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDCasePriority' and i.name = 'SDCasePriority_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDCasePriority_FullStatics_Idx 
    on SD.SDCasePriority ( 
GuidCasePriority 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDCaseState' and i.name = 'SDCaseState_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDCaseState_FullStatics_Idx 
    on SD.SDCaseState ( 
GuidCaseState 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDFile' and i.name = 'SDFile_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDFile_FullStatics_Idx 
    on SD.SDFile ( 
GuidFile 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDOrganization' and i.name = 'SDOrganization_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDOrganization_FullStatics_Idx 
    on SD.SDOrganization ( 
GuidOrganization 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)
IF NOT EXISTS (
    SELECT * FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.indexes i on i.object_id = t.object_id
    WHERE s.name = 'SD' AND t.name = 'SDPerson' and i.name = 'SDPerson_FullStatics_Idx'
) 
    CREATE NONCLUSTERED INDEX SDPerson_FullStatics_Idx 
    on SD.SDPerson ( 
GuidPerson 

        ,CreatedDate desc 

	,UpdatedDate desc 
		,CreatedBy 
		,GuidCompany 
		,IsDeleted desc
    ) 
	
	INCLUDE(Bytes)
	WITH (ONLINE = ON)

