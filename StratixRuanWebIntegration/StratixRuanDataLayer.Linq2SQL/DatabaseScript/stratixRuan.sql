
/****** Object:  Table [dbo].[SMCODEXMLTYPE]    Script Date: 6/3/2021 2:29:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SMCODEXMLTYPE](
	[SMXMLNumber] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SMXMLCode] [nvarchar](50) NOT NULL,
	[SMXMLDescription] [nvarchar](100) NOT NULL,
	[SMXMLCreatedOn] [datetime] NULL,
	[SMXMLCreatedAt] [datetime] NULL,
	[SMXMLCreatedBy] [bigint] NULL,
	[SMXMLCreatedWS] [bigint] NULL,
	[SMXMLLastChgOn] [datetime] NULL,
	[SMXMLLastChgAt] [datetime] NULL,
	[SMXMLLastChgBy] [bigint] NULL,
	[SMXMLLastChgWS] [bigint] NULL,
	[SMXMLPostedOn] [datetime] NULL,
	[SMXMLPostedAt] [datetime] NULL,
	[SMXMLPostedBy] [bigint] NULL,
	[SMXMLPostedWS] [bigint] NULL,
	[SMXMLDeletedOn] [datetime] NULL,
	[SMXMLDeletedAt] [datetime] NULL,
	[SMXMLDeletedBy] [bigint] NULL,
	[SMXMLDeletedWS] [bigint] NULL,
	[SMXMLHeaderSpecVersion] [nvarchar](10) NULL,
 CONSTRAINT [PK_SMCODEXMLTYPE] PRIMARY KEY CLUSTERED 
(
	[SMXMLNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SMCODEXMLTYPE] ADD  CONSTRAINT [DF_SMCODEXMLTYPE_SMXMLCreatedOn]  DEFAULT (getdate()) FOR [SMXMLCreatedOn]
GO

ALTER TABLE [dbo].[SMCODEXMLTYPE] ADD  CONSTRAINT [DF_SMCODEXMLTYPE_SMXMLCreatedAt]  DEFAULT (getdate()) FOR [SMXMLCreatedAt]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'XML Type Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'XML Type Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'XML Type Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLDescription'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLCreatedOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLCreatedAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLCreatedBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLCreatedWS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLLastChgOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLLastChgAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLLastChgBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLLastChgWS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLPostedOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLPostedAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLPostedBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLPostedWS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLDeletedOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLDeletedAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLDeletedBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMCODEXMLTYPE', @level2type=N'COLUMN',@level2name=N'SMXMLDeletedWS'
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TSRuanXML](
	[TSRNXNumber] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SMXMLNumber] [bigint] NOT NULL,
	[TSRNXXML] [xml] NOT NULL,
	[TSRNXCreatedOn] [datetime] NULL,
	[TSRNXCreatedAt] [datetime] NULL,
	[TSRNXCreatedBy] [bigint] NULL,
	[TSRNXCreatedWS] [bigint] NULL,
	[TSRNXLastChgOn] [datetime] NULL,
	[TSRNXLastChgAt] [datetime] NULL,
	[TSRNXLastChgBy] [bigint] NULL,
	[TSRNXLastChgWS] [bigint] NULL,
	[TSRNXPostedOn] [datetime] NULL,
	[TSRNXPostedAt] [datetime] NULL,
	[TSRNXPostedBy] [bigint] NULL,
	[TSRNXPostedWS] [bigint] NULL,
	[TSRNXDeletedOn] [datetime] NULL,
	[TSRNXDeletedAt] [datetime] NULL,
	[TSRNXDeletedBy] [bigint] NULL,
	[TSRNXDeletedWS] [bigint] NULL,
 CONSTRAINT [PK_TSRuanXML] PRIMARY KEY CLUSTERED 
(
	[TSRNXNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TSRuanXML] ADD  CONSTRAINT [DF_TSRuanXML_TSRNXCreatedOn]  DEFAULT (getdate()) FOR [TSRNXCreatedOn]
GO

ALTER TABLE [dbo].[TSRuanXML] ADD  CONSTRAINT [DF_TSRuanXML_TSRNXCreatedAt]  DEFAULT (getdate()) FOR [TSRNXCreatedAt]
GO

ALTER TABLE [dbo].[TSRuanXML]  WITH CHECK ADD  CONSTRAINT [FK_TSRuanXML_SMXMLNumber_SMCODEXMLTYPE] FOREIGN KEY([SMXMLNumber])
REFERENCES [dbo].[SMCODEXMLTYPE] ([SMXMLNumber])
GO

ALTER TABLE [dbo].[TSRuanXML] CHECK CONSTRAINT [FK_TSRuanXML_SMXMLNumber_SMCODEXMLTYPE]
GO


INSERT INTO [dbo].[SMCODEXMLTYPE] ([SMXMLCode], [SMXMLDescription])
SELECT 'APIReleaseOrder', 'Trucklist Order File from Stratix to RUAN' UNION ALL
SELECT 'APIActualShipment', 'Actual Manifest Shipment from Stratix to RUAN' 

INSERT INTO [dbo].[SMCODEXMLTYPE] ([SMXMLCode], [SMXMLDescription])
SELECT 'APITransportationShipment', 'Transportation Assigned File from Ruan' UNION ALL
SELECT 'APIOrderStatus', 'Delivery File from Ruan' 


SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ADTABLE](
	[ADTBLNumber] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ADTBLCode] [varchar](30) NOT NULL,
	[ADTBLDesc] [varchar](50) NULL,
	[ADTBLAllowUDF] [bit] NOT NULL,
	[ADTBLAllowMmo] [bit] NOT NULL,
	[ADTBLUsesAudit] [bit] NOT NULL,
	[ADTBLDisplayType] [varchar](1) NULL,
	[ADTBLEcbWidth] [int] NULL,
	[ADTBLPrefix] [varchar](10) NULL,
	[ADTBLCreatedOn] [datetime] NULL,
	[ADTBLCreatedAt] [datetime] NULL,
	[ADTBLCreatedBy] [bigint] NULL,
	[ADTBLCreatedWS] [bigint] NULL,
	[ADTBLLastChgOn] [datetime] NULL,
	[ADTBLLastChgAt] [datetime] NULL,
	[ADTBLLastChgBy] [bigint] NULL,
	[ADTBLLastChgWS] [bigint] NULL,
	[ADTBLPostedOn] [datetime] NULL,
	[ADTBLPostedAt] [datetime] NULL,
	[ADTBLPostedBy] [bigint] NULL,
	[ADTBLPostedWS] [bigint] NULL,
	[ADTBLDeletedOn] [datetime] NULL,
	[ADTBLDeletedAt] [datetime] NULL,
	[ADTBLDeletedBy] [bigint] NULL,
	[ADTBLDeletedWS] [bigint] NULL,
 CONSTRAINT [PK_ADTABLE] PRIMARY KEY CLUSTERED 
(
	[ADTBLNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_ADTABLE] UNIQUE NONCLUSTERED 
(
	[ADTBLCode] ASC,
	[ADTBLDeletedAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ADTABLE] ADD  CONSTRAINT [DF_ADTABLE_ADTBLCreatedOn]  DEFAULT (getdate()) FOR [ADTBLCreatedOn]
GO

ALTER TABLE [dbo].[ADTABLE] ADD  CONSTRAINT [DF_ADTABLE_ADTBLCreatedAt]  DEFAULT (getdate()) FOR [ADTBLCreatedAt]
GO

ALTER TABLE [dbo].[ADTABLE] ADD  CONSTRAINT [DF_ADTABLE_ADTBLLastChgOn]  DEFAULT (getdate()) FOR [ADTBLLastChgOn]
GO

ALTER TABLE [dbo].[ADTABLE] ADD  CONSTRAINT [DF_ADTABLE_ADTBLLastChgAt]  DEFAULT (getdate()) FOR [ADTBLLastChgAt]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLDesc'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allow UDF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLAllowUDF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allow Memo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLAllowMmo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Uses Audit Trail' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLUsesAudit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Display Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLDisplayType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Combo Popup Width' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLEcbWidth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table Prefix' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLPrefix'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLCreatedOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLCreatedAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLCreatedBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Created Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLCreatedWS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLLastChgOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLLastChgAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLLastChgBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Changed Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLLastChgWS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLPostedOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLPostedAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLPostedBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Posted Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLPostedWS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted On' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLDeletedOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted At' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLDeletedAt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted By' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLDeletedBy'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted Station' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADTABLE', @level2type=N'COLUMN',@level2name=N'ADTBLDeletedWS'
GO



INSERT INTO [dbo].[ADTABLE]
           ([ADTBLCode]
           ,[ADTBLDesc]
           ,[ADTBLAllowUDF]
           ,[ADTBLAllowMmo]
           ,[ADTBLUsesAudit]
           ,[ADTBLDisplayType]
           ,[ADTBLEcbWidth]          
           ,[ADTBLCreatedOn]
           ,[ADTBLCreatedAt]
          )
           
     VALUES
           ('SMCODEXMLTYPE'
           ,''
           ,0
           ,0
           ,0
           ,'N'
           ,300           
           ,GETDATE()
           ,GETDATE()
           )
GO


