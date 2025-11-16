SET IDENTITY_INSERT [dbo].[Currency] ON 
INSERT [dbo].[Currency] ([CurrencyId], [CurrencyName], [ConversionRate]) VALUES (1, N'BDT', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Currency] ([CurrencyId], [CurrencyName], [ConversionRate]) VALUES (2, N'USD', CAST(118.50 AS Decimal(18, 2)))
INSERT [dbo].[Currency] ([CurrencyId], [CurrencyName], [ConversionRate]) VALUES (3, N'EUR', CAST(135.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO


SET IDENTITY_INSERT [dbo].[Employee] ON 
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName]) VALUES (1, N'Rubel DK')
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName]) VALUES (2, N'MD Zaman')
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName]) VALUES (3, N'Nabila rahman')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO


SET IDENTITY_INSERT [dbo].[Godown] ON 
INSERT [dbo].[Godown] ([AutoSlNo], [GodownNo], [GodownName], [EntryDate]) VALUES (1, N'GN_10001', N'Main Warehouse', CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Godown] ([AutoSlNo], [GodownNo], [GodownName], [EntryDate]) VALUES (4, N'GN_10002', N'Secondary Warehouse', CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Godown] ([AutoSlNo], [GodownNo], [GodownName], [EntryDate]) VALUES (5, N'GN_10002', N'Optional Warehouse', CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Godown] OFF
GO

SET IDENTITY_INSERT [dbo].[Stock] ON 
INSERT [dbo].[Stock] ([AutoSlNo], [GodownAutoSlNo], [SubItemAutoSlNo], [Quantity], [EntryDate]) VALUES (1, 1, 1, CAST(987.00 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Stock] ([AutoSlNo], [GodownAutoSlNo], [SubItemAutoSlNo], [Quantity], [EntryDate]) VALUES (2, 1, 2, CAST(500.00 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Stock] ([AutoSlNo], [GodownAutoSlNo], [SubItemAutoSlNo], [Quantity], [EntryDate]) VALUES (3, 1, 3, CAST(197.00 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Stock] ([AutoSlNo], [GodownAutoSlNo], [SubItemAutoSlNo], [Quantity], [EntryDate]) VALUES (4, 4, 1, CAST(150.00 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Stock] ([AutoSlNo], [GodownAutoSlNo], [SubItemAutoSlNo], [Quantity], [EntryDate]) VALUES (5, 4, 2, CAST(248.00 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[Stock] ([AutoSlNo], [GodownAutoSlNo], [SubItemAutoSlNo], [Quantity], [EntryDate]) VALUES (6, 4, 3, CAST(300.00 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO


SET IDENTITY_INSERT [dbo].[StockDamage] ON 
INSERT [dbo].[StockDamage] ([AutoSlNo], [VoucherNo], [EntryDate], [GodownAutoSlNo], [SubItemAutoSlNo], [BatchNo], [CurrencyId], [Quantity], [Rate], [AmountIn], [ExchangeRate], [AmountBDT], [DrACHead], [EmployeeID], [Comments], [CreateDate]) VALUES (1, N'SD-20251115-203531', CAST(N'2025-11-15T00:00:00.0000000' AS DateTime2), 1, 1, N'NA', 1, CAST(11.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(220.00 AS Decimal(18, 2)), N'Stock Damage', 1, N'jjj', CAST(N'2025-11-16T02:35:31.3133333' AS DateTime2))
INSERT [dbo].[StockDamage] ([AutoSlNo], [VoucherNo], [EntryDate], [GodownAutoSlNo], [SubItemAutoSlNo], [BatchNo], [CurrencyId], [Quantity], [Rate], [AmountIn], [ExchangeRate], [AmountBDT], [DrACHead], [EmployeeID], [Comments], [CreateDate]) VALUES (2, N'SD-20251115-203531', CAST(N'2025-11-15T00:00:00.0000000' AS DateTime2), 4, 2, N'B001', 2, CAST(2.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(118.50 AS Decimal(18, 2)), CAST(711.00 AS Decimal(18, 2)), N'Stock Damage', 1, N'jjj', CAST(N'2025-11-16T02:35:31.3166667' AS DateTime2))
INSERT [dbo].[StockDamage] ([AutoSlNo], [VoucherNo], [EntryDate], [GodownAutoSlNo], [SubItemAutoSlNo], [BatchNo], [CurrencyId], [Quantity], [Rate], [AmountIn], [ExchangeRate], [AmountBDT], [DrACHead], [EmployeeID], [Comments], [CreateDate]) VALUES (3, N'SD-20251115-203741', CAST(N'2025-11-15T00:00:00.0000000' AS DateTime2), 1, 1, N'NA', 1, CAST(11.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(242.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(242.00 AS Decimal(18, 2)), N'Stock Damage', 1, N'yy', CAST(N'2025-11-15T20:37:41.2383226' AS DateTime2))
INSERT [dbo].[StockDamage] ([AutoSlNo], [VoucherNo], [EntryDate], [GodownAutoSlNo], [SubItemAutoSlNo], [BatchNo], [CurrencyId], [Quantity], [Rate], [AmountIn], [ExchangeRate], [AmountBDT], [DrACHead], [EmployeeID], [Comments], [CreateDate]) VALUES (4, N'SD-20251115-203741', CAST(N'2025-11-15T00:00:00.0000000' AS DateTime2), 4, 2, N'NA', 3, CAST(22.00 AS Decimal(18, 2)), CAST(1.33 AS Decimal(18, 2)), CAST(29.26 AS Decimal(18, 2)), CAST(135.00 AS Decimal(18, 2)), CAST(3950.10 AS Decimal(18, 2)), N'Stock Damage', 1, N'yy', CAST(N'2025-11-15T20:37:41.3074804' AS DateTime2))
INSERT [dbo].[StockDamage] ([AutoSlNo], [VoucherNo], [EntryDate], [GodownAutoSlNo], [SubItemAutoSlNo], [BatchNo], [CurrencyId], [Quantity], [Rate], [AmountIn], [ExchangeRate], [AmountBDT], [DrACHead], [EmployeeID], [Comments], [CreateDate]) VALUES (5, N'SD-20251115-212506', CAST(N'2025-11-15T00:00:00.0000000' AS DateTime2), 1, 1, N'B001', 2, CAST(2.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)), CAST(118.50 AS Decimal(18, 2)), CAST(3081.00 AS Decimal(18, 2)), N'Stock Damage', 2, N'All Is Okay', CAST(N'2025-11-16T03:25:06.4833333' AS DateTime2))
INSERT [dbo].[StockDamage] ([AutoSlNo], [VoucherNo], [EntryDate], [GodownAutoSlNo], [SubItemAutoSlNo], [BatchNo], [CurrencyId], [Quantity], [Rate], [AmountIn], [ExchangeRate], [AmountBDT], [DrACHead], [EmployeeID], [Comments], [CreateDate]) VALUES (6, N'SD-20251115-212506', CAST(N'2025-11-15T00:00:00.0000000' AS DateTime2), 1, 3, N'B003', 3, CAST(3.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), CAST(99.00 AS Decimal(18, 2)), CAST(135.00 AS Decimal(18, 2)), CAST(13365.00 AS Decimal(18, 2)), N'Stock Damage', 2, N'All Is Okay', CAST(N'2025-11-16T03:25:06.4866667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[StockDamage] OFF
GO


SET IDENTITY_INSERT [dbo].[SubItemCode] ON 
INSERT [dbo].[SubItemCode] ([AutoSlNo], [SubItemCodeValue], [SubItemName], [Unit], [Weight], [EntryDate]) VALUES (1, N'ITM001', N'Bolt 10mm', N'pcs', CAST(0.02 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[SubItemCode] ([AutoSlNo], [SubItemCodeValue], [SubItemName], [Unit], [Weight], [EntryDate]) VALUES (2, N'ITM002', N'Nut 10mm', N'pcs', CAST(0.01 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
INSERT [dbo].[SubItemCode] ([AutoSlNo], [SubItemCodeValue], [SubItemName], [Unit], [Weight], [EntryDate]) VALUES (3, N'ITM003', N'Washer 10mm', N'pcs', CAST(0.01 AS Decimal(18, 2)), CAST(N'2025-11-15T18:33:56.6830000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SubItemCode] OFF
GO



/****** Object:  StoredProcedure [dbo].[SP_GetStockDamage]    Script Date: 2025-11-16 3:34:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DEBORAJ
-- Create date: <16-11-2025>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetStockDamage]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        sd.AutoSlNo,
        sd.VoucherNo,
        sd.EntryDate,
        sd.GodownAutoSlNo,
        ISNULL(g.GodownName, '') AS GodownName,
        sd.SubItemAutoSlNo,
        ISNULL(si.SubItemName, '') AS SubItemName,
        ISNULL(si.SubItemCodeValue, '') AS SubItemCodeValue,
        ISNULL(si.Unit, '') AS Unit,
        sd.BatchNo,
        sd.CurrencyId,
        ISNULL(c.CurrencyName, '') AS CurrencyName,
        sd.Quantity,
        sd.Rate,
        sd.AmountIn,
        sd.ExchangeRate,
        sd.AmountBDT,
        sd.DrACHead,
        sd.EmployeeID,
        ISNULL(e.EmployeeName, '') AS EmployeeName,
        sd.Comments,
        sd.CreateDate
    FROM dbo.StockDamage sd
    LEFT JOIN dbo.Godown g ON sd.GodownAutoSlNo = g.AutoSlNo
    LEFT JOIN dbo.SubItemCode si ON sd.SubItemAutoSlNo = si.AutoSlNo
    LEFT JOIN dbo.Currency c ON sd.CurrencyId = c.CurrencyId
    LEFT JOIN dbo.Employee e ON sd.EmployeeID = e.EmployeeID
    ORDER BY sd.CreateDate DESC, sd.AutoSlNo DESC;
END

GO


/****** Object:  StoredProcedure [dbo].[SP_StockDamage_Save]    Script Date: 2025-11-16 3:34:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DEBORAJ
-- Create date: <16-11-2025>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SP_StockDamage_Save]
	@VoucherNo NVARCHAR(100) OUTPUT, -- if 0 or NULL, create header
    @EntryDate DATE,
    @GodownAutoSlNo INT,
    @SubItemAutoSlNo INT,
    @BatchNo NVARCHAR(50),
    @Currency BigInt,
    @Quantity DECIMAL(18,4),
    @Rate DECIMAL(18,4),
    @AmountIn DECIMAL(18,4),
    @ExchangeRate DECIMAL(18,6),
    @AmountBDT DECIMAL(18,4),
    @DrACHead NVARCHAR(200),
    @EmployeeID INT = NULL,
    @Comments NVARCHAR(1000) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF @VoucherNo IS NULL OR @VoucherNo = ''
        

        DECLARE @CurrentStock DECIMAL(18,4);
        SELECT @CurrentStock = Quantity FROM [dbo].[Stock] WHERE GodownAutoSlNo = @GodownAutoSlNo AND SubItemAutoSlNo = @SubItemAutoSlNo;

        IF @CurrentStock IS NULL
        BEGIN
            RAISERROR('Stock record not found for selected Warehouse and Item.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
 
        INSERT INTO [dbo].[StockDamage]
        (
            VoucherNo, EntryDate, GodownAutoSlNo, SubItemAutoSlNo, BatchNo,
            CurrencyId, Quantity, Rate, AmountIn, ExchangeRate, AmountBDT,
            DrACHead, EmployeeID, Comments, CreateDate
        )
        VALUES
        (
            @VoucherNo, @EntryDate, @GodownAutoSlNo, @SubItemAutoSlNo, @BatchNo,
            @Currency, @Quantity, @Rate, @AmountIn, @ExchangeRate, @AmountBDT,
            @DrACHead, @EmployeeID, @Comments, GETDATE()
        );

        UPDATE dbo.Stock
        SET Quantity = Quantity - @Quantity
        WHERE GodownAutoSlNo = @GodownAutoSlNo AND SubItemAutoSlNo = @SubItemAutoSlNo;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR('Error SP_StockDamage_Save: %s',16,1,@ErrMsg);
    END CATCH
	END

GO
