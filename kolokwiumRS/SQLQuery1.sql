CREATE PROCEDURE DodajStudenta
    @Imie NVARCHAR(100),
    @Nazwisko NVARCHAR(100),
    @GroupID INT
AS
BEGIN
    INSERT INTO Studenci (Imie, Nazwisko, GroupaID)
    VALUES (@Imie, @Nazwisko, @GroupID)
END