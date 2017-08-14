 
 
PRINT 'Table SDArea, entity SDArea'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDArea 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDArea 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDArea 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDArea 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDArea 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDArea 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDArea', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDArea 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDAreaPerson, entity SDAreaPerson'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDAreaPerson', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDAreaPerson 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDCase, entity SDCase'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDCase 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDCase 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDCase 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDCase 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDCase 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDCase 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCase', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDCase 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDCaseFile, entity SDCaseFile'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseFile', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDCaseFile 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDCaseHistory, entity SDCaseHistory'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistory', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDCaseHistory 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDCaseHistoryFile, entity SDCaseHistoryFile'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseHistoryFile', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDCaseHistoryFile 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDCasePriority, entity SDCasePriority'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCasePriority', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDCasePriority 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDCaseState, entity SDCaseState'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDCaseState', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDCaseState 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDFile, entity SDFile'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDFile 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDFile 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDFile 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDFile 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDFile 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDFile 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDFile', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDFile 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDOrganization, entity SDOrganization'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDOrganization', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDOrganization 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO
PRINT 'Table SDPerson, entity SDPerson'
-- GuidCompany
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'GuidCompany','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add GuidCompany uniqueidentifier null 
end
GO
-- CreatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'CreatedDate','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add CreatedDate DATETIME null 
end
GO
-- UpdatedDate
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'UpdatedDate','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add UpdatedDate DATETIME null 
end
GO
-- CreatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'CreatedBy','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add CreatedBy uniqueidentifier null 
end
GO
-- UpdatedBy
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'UpdatedBy','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add UpdatedBy uniqueidentifier null 
end
GO

-- Bytes
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'Bytes','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add Bytes [int] null 
end
GO

-- IsDeleted
if COLUMNPROPERTY(OBJECT_ID(N'SD.SDPerson', N'U'),'IsDeleted','ColumnId') is null
begin 
  alter table SD.SDPerson 
  add IsDeleted [bit] null DEFAULT ('false') 
end
GO

