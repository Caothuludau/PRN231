DECLARE @i INT = 1;

WHILE @i <= 1000 -- Adjust the number of rows to insert as needed
BEGIN
    INSERT INTO [dbo].[Revervations] 
    (
        [userId], 
        [movieId], 
        [timeSlotId], 
        [seatId], 
        [reservationDate], 
        [status], 
        [totalAmount]
    )
    VALUES 
    (
        ABS(CHECKSUM(NEWID())) % 3 + 1, -- Random userId between 1 and 1000
        ABS(CHECKSUM(NEWID())) % 2 + 1,    -- Random movieId between 1 and 2
        ABS(CHECKSUM(NEWID())) % 16 + 1,   -- Random timeSlotId between 1 and 16
        ABS(CHECKSUM(NEWID())) % 108 + 1,  -- Random seatId between 1 and 108
        DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, GETDATE() - 365), -- Random reservationDate within the past year
        ABS(CHECKSUM(NEWID())) % 2,        -- Random status (0 or 1)
        CAST(ABS(CHECKSUM(NEWID())) % 5000 + 100 AS FLOAT) / 100 -- Random totalAmount between 1.00 and 50.00
    );

    SET @i = @i + 1;
END;

-- Check inserted data
SELECT * FROM [dbo].[Revervations];

