/*
Post-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.    
 Use SQLCMD syntax to include a file in the post-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the post-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/
/* Inserting rows into aspnet_SchemaVersions table */
INSERT INTO [aspnet_SchemaVersions]
  ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion])
  VALUES
  ('common', 1, 1)

INSERT INTO [aspnet_SchemaVersions]
  ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion])
  VALUES
  ('health monitoring', 1, 1)

INSERT INTO [aspnet_SchemaVersions]
  ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion])
  VALUES
  ('membership', 1, 1)

INSERT INTO [aspnet_SchemaVersions]
  ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion])
  VALUES
  ('personalization', 1, 1)

INSERT INTO [aspnet_SchemaVersions]
  ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion])
  VALUES
  ('profile', 1, 1)

INSERT INTO [aspnet_SchemaVersions]
  ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion])
  VALUES
  ('role manager', 1, 1)

GO