BULK INSERT [MyErp].[dbo].[EmployeeAttendances]
FROM 'D:\123.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Comma delimiter
    ROWTERMINATOR = '\n',   -- Newline character for row termination
    FIRSTROW = 2            -- Skip the header row if your CSV has one
);