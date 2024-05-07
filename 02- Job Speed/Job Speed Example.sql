CREATE DATABASE [TestProcedureDB];


USE [TestProcedureDB];


CREATE TABLE ElectricityBills (
	BillID INT
	,CustomerID VARCHAR(10) NOT NULL
	,BillingPeriodStart DATE NOT NULL
	,BillingPeriodEnd DATE NOT NULL
	,TotalUsageKWh NUMERIC(18, 3) NOT NULL
	);
	
	
CREATE CLUSTERED INDEX BillIDClusteredIndex 
ON ElectricityBills (BillID);


CREATE TABLE DailyElectricityBills_UsingLoop (
	CustomerID VARCHAR(10) NOT NULL
	,DateOf DATE NOT NULL
	,TotalUsageKWh NUMERIC(18, 3) NOT NULL
	);
	
	
CREATE TABLE DailyElectricityBills_UsingBulk (
	CustomerID VARCHAR(10) NOT NULL
	,DateOf DATE NOT NULL
	,TotalUsageKWh NUMERIC(18, 3) NOT NULL
	);
	
	
WITH cte
AS (
	SELECT 1 AS id
	
	UNION ALL
	
	SELECT id + 1
	FROM cte
	WHERE id < 50000
	)
INSERT INTO ElectricityBills (
	BillID
	,CustomerID
	,BillingPeriodStart
	,BillingPeriodEnd
	,TotalUsageKWh
	)
SELECT id
	,FORMAT(abs(CHECKSUM(NewId())) % 9999999, '00000000')
	,CAST(GETDATE() - 70 AS DATE)
	,CAST(GETDATE() - 10 AS DATE)
	,600 + CHECKSUM(NewId()) % 200
FROM cte
OPTION (MAXRECURSION 0);


CREATE PROCEDURE [dbo].[ConvertPeriodToDayUsingLoop]
AS
DECLARE @RowId INT = 1;
DECLARE @RowCount BIGINT = 0;
DECLARE @StartDate DATE;
DECLARE @EndDate DATE;
DECLARE @CustomerID VARCHAR(10);
DECLARE @DailyUsage NUMERIC(18, 3) = 0;
-- Count of Total rows to process 
SELECT @RowCount = count(1)
FROM ElectricityBills;

WHILE @RowId <= @RowCount
BEGIN
	SELECT @CustomerID = t.CustomerID
		,@DailyUsage = (t.TotalUsageKWh / datediff(day, t.BillingPeriodStart, t.BillingPeriodEnd))
		,@StartDate = t.BillingPeriodStart
		,@EndDate = t.BillingPeriodEnd
	FROM ElectricityBills t
	WHERE t.BillID = @RowId;
	WHILE @StartDate < @EndDate
	BEGIN
		INSERT INTO DailyElectricityBills_UsingLoop (
			CustomerID
			,DateOf
			,TotalUsageKWh
			)
		VALUES (
			@CustomerID
			,@StartDate
			,@DailyUsage
			);
		SET @StartDate = DATEADD(DAY, 1, @StartDate);
	END
	SET @RowId = @RowId + 1;
END;


CREATE PROCEDURE [dbo].[ConvertPeriodToDayUsingBulk]
AS
BEGIN
	/* Step 1 : Determine the earliest start date and latest end date of the electricity     
    billing period, and calculate the total duration in days */
	SELECT min(t1.BillingPeriodStart) MinStartDate
		,max(t1.BillingPeriodEnd) MaxEndDate
		,DATEDIFF(day, min(t1.BillingPeriodStart), max(t1.BillingPeriodEnd)) MaxDuration
	INTO #Temp1
	FROM ElectricityBills t1;
    
	/*Step 2: Generate a sequence of numbers from 0 to 'MaxDuration' 
    using a recursive CTE and store the sequence in a new temporary table '#Temp2' */
	WITH cte
	AS (
		SELECT 0 AS id
		
		UNION ALL
		
		SELECT id + 1
		FROM cte
		WHERE id < (
				SELECT MaxDuration
				FROM #Temp1
				)
		)
	SELECT *
	INTO #Temp2
	FROM cte;
    
	/*Step 3: Create a continuous sequence of dates, each representing a unique day, 
    spanning from the earliest start date to the latest end date of the 
    electricity billing period, and store it in the '#TempDate' table. */
	SELECT DATEADD(day, id, t1.MinStartDate) dateof
	INTO #TempDate
	FROM #Temp1 t1
	CROSS JOIN #Temp2;
    
	/* Step 4: Utilize the #TempDate table created from steps 1 to 3 to join 
    with the ElectricityBills table. This join is based on the condition 
    that 't3.dateof' falls within the billing period defined by
    't4.BillingPeriodStart' and 't4.BillingPeriodEnd'. This expands 
    each ElectricityBills record across the number of days in its billing period,
    effectively distributing the total usage evenly across each day without 
    the need for a loop, thus optimizing the calculation process. */
	INSERT INTO DailyElectricityBills_UsingBulk (
		CustomerID
		,DateOf
		,TotalUsageKWh
		)
	SELECT t4.CustomerID
		,t3.dateof
		,t4.TotalUsageKWh / DATEDIFF(day, t4.BillingPeriodStart, t4.BillingPeriodEnd)
	FROM ElectricityBills t4
	INNER JOIN #TempDate t3
		ON t3.dateof >= t4.BillingPeriodStart
			AND t3.dateof < t4.BillingPeriodEnd;
END;

EXEC [ConvertPeriodToDayUsingLoop];

EXEC ConvertPeriodToDayUsingBulk;