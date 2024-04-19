CREATE PROCEDURE PaginatedGetHistoria4
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
    DECLARE @TotalCount INT;

    SELECT @TotalCount = COUNT(*) FROM Historie;

    SELECT 
        ID,
        Imie,
        Nazwisko,
        GroupID,
        TypAkcji,
        Data
    FROM
        Historie
    ORDER BY
        ID
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT @TotalCount AS TotalCount;
END