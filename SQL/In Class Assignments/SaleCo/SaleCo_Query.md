1.  Write a query to count the number of invoices.

      SELECT COUNT (INV_NUMBER)
      FROM DBO.INVOICE;

2.  Write a query to count the number of customers with a balance of more than $500.

      SELECT COUNT (CUS_BALANCE)
      FROM DBO.CUSTOMER
      WHERE CUS_BALANCE > '500';

3.  Generate a listing of all purchases made by the customers. Sort the results by customer code, invoice number, and product description.

      SELECT INV_NUMBER, CUS_CODE, P_DESCRIPT
      FROM DBO.INVOICE, DBO.PRODUCT
      ORDER BY CUS_CODE, INV_NUMBER, P_DESCRIPT;

4.  Use a query to show the invoices and invoice totals. Sort the results by customer code.

      SELECT CUS_CODE, INVOICE.INV_NUMBER, SUM (LINE_UNITS * LINE_PRICE) AS "Invoice Total"
      FROM INVOICE JOIN LINE ON INVOICE.INV_NUMBER = LINE.INV_NUMBER
      GROUP BY CUS_CODE, INVOICE.INV_NUMBER;


