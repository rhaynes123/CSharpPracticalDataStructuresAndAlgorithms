DROP PROCEDURE IF EXISTS GetAllTransactions;
-- CALL GetAllTransactions();
-- Delimiter isn't needed when using the Mysql Connector  https://github.com/mysql-net/MySqlConnector/issues/645

CREATE PROCEDURE GetAllTransactions()
BEGIN
	SELECT
	t.Id AS Id
	,t.Amount as Amount
	,t.TransactionDate as TransactionDate
	FROM Snacks.Transactions t;
END;