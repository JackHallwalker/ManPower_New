﻿using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface PaymentVoucherDAO
    {
        int Save(PaymentVoucher paymentVoucher, DBConnection dbConnection);

        int Update(PaymentVoucher paymentVoucher, DBConnection dbConnection);

        List<PaymentVoucher> GetAllPaymentVoucher(DBConnection dbConnection);
    }

    public class PaymentVoucherDAOSqlImpl : PaymentVoucherDAO
    {
        public int Save(PaymentVoucher paymentVoucher, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Payment_Voucher (Supplier_Id, Voucher_Number, Voucher_Date, Payee_Name, Payee_Address, Cheque_Number, Total_Amount, Is_Voucher_Authorized, Vou_Authorized_Date, Vou_Authorized_User, Is_Pay_Authorized, Pay_Authorized_Date, Pay_Authorized_User, Is_Canceled, Canceled_Date, Canceled_User, Created_User, Created_Date, Bank_Account) " +
                "VALUES (@SupplierId, @VoucherNumber, @VoucherDate, @PayeeName, @PayeeAddress, @ChequeNumber, @TotalAmount, @IsVoucherAuthorized, @VouAuthorizedDate, @VouAuthorizedUser, @IsPayAuthorized, @PayAuthorizedDate, @PayAuthorizedUser, @IsCanceled, @CanceledDate, @CanceledUser, @CreatedUser, @CreatedDate, @BankAccount)";

            dbConnection.cmd.Parameters.AddWithValue("@SupplierId", paymentVoucher.SupplierId);
            dbConnection.cmd.Parameters.AddWithValue("@VoucherNumber", paymentVoucher.VoucherNumber);
            dbConnection.cmd.Parameters.AddWithValue("@VoucherDate", paymentVoucher.VoucherDate);
            dbConnection.cmd.Parameters.AddWithValue("@PayeeName", paymentVoucher.PayeeName);
            dbConnection.cmd.Parameters.AddWithValue("@PayeeAddress", paymentVoucher.PayeeAddress);
            dbConnection.cmd.Parameters.AddWithValue("@ChequeNumber", paymentVoucher.ChequeNumber);
            dbConnection.cmd.Parameters.AddWithValue("@TotalAmount", paymentVoucher.TotalAmount);
            dbConnection.cmd.Parameters.AddWithValue("@IsVoucherAuthorized", paymentVoucher.IsVoucherAuthorized);
            dbConnection.cmd.Parameters.AddWithValue("@VouAuthorizedDate", paymentVoucher.VouAuthorizedDate);
            dbConnection.cmd.Parameters.AddWithValue("@VouAuthorizedUser", paymentVoucher.VouAuthorizedUser);
            dbConnection.cmd.Parameters.AddWithValue("@IsPayAuthorized", paymentVoucher.IsPayAuthorized);
            dbConnection.cmd.Parameters.AddWithValue("@PayAuthorizedDate", paymentVoucher.PayAuthorizedDate);
            dbConnection.cmd.Parameters.AddWithValue("@PayAuthorizedUser", paymentVoucher.PayAuthorizedUser);
            dbConnection.cmd.Parameters.AddWithValue("@IsCanceled", paymentVoucher.IsCanceled);
            dbConnection.cmd.Parameters.AddWithValue("@CanceledDate", paymentVoucher.CanceledDate);
            dbConnection.cmd.Parameters.AddWithValue("@CanceledUser", paymentVoucher.CanceledUser);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", paymentVoucher.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", paymentVoucher.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@BankAccount", paymentVoucher.BankAccount);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());

            return output;
        }

        public int Update(PaymentVoucher paymentVoucher, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Payment_Voucher SET Supplier_Id = @SupplierId, Voucher_Number = @VoucherNumber, Voucher_Date = @VoucherDate, Payee_Name = @PayeeName, " +
                "Payee_Address = @PayeeAddress, Cheque_Number = @ChequeNumber, Total_Amount = @TotalAmount, Is_Voucher_Authorized = @IsVoucherAuthorized, Vou_Authorized_Date = @VouAuthorizedDate, " +
                "Vou_Authorized_User = @VouAuthorizedUser, Is_Pay_Authorized = @IsPayAuthorized, Pay_Authorized_Date = @PayAuthorizedDate, Pay_Authorized_User = @PayAuthorizedUser, " +
                "Is_Canceled = @IsCanceled, CanCeled_Date = @CanceledDate, Canceled_User = @CanceledUser, Bank_Account = @BankAccount WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Id", paymentVoucher.Id);
            dbConnection.cmd.Parameters.AddWithValue("@SupplierId", paymentVoucher.SupplierId);
            dbConnection.cmd.Parameters.AddWithValue("@VoucherNumber", paymentVoucher.VoucherNumber);
            dbConnection.cmd.Parameters.AddWithValue("@VoucherDate", paymentVoucher.VoucherDate);
            dbConnection.cmd.Parameters.AddWithValue("@PayeeName", paymentVoucher.PayeeName);
            dbConnection.cmd.Parameters.AddWithValue("@PayeeAddress", paymentVoucher.PayeeAddress);
            dbConnection.cmd.Parameters.AddWithValue("@ChequeNumber", paymentVoucher.ChequeNumber);
            dbConnection.cmd.Parameters.AddWithValue("@TotalAmount", paymentVoucher.TotalAmount);
            dbConnection.cmd.Parameters.AddWithValue("@IsVoucherAuthorized", paymentVoucher.IsVoucherAuthorized);
            dbConnection.cmd.Parameters.AddWithValue("@VouAuthorizedDate", paymentVoucher.VouAuthorizedDate);
            dbConnection.cmd.Parameters.AddWithValue("@VouAuthorizedUser", paymentVoucher.VouAuthorizedUser);
            dbConnection.cmd.Parameters.AddWithValue("@IsPayAuthorized", paymentVoucher.IsPayAuthorized);
            dbConnection.cmd.Parameters.AddWithValue("@PayAuthorizedDate", paymentVoucher.PayAuthorizedDate);
            dbConnection.cmd.Parameters.AddWithValue("@PayAuthorizedUser", paymentVoucher.PayAuthorizedUser);
            dbConnection.cmd.Parameters.AddWithValue("@IsCanceled", paymentVoucher.IsCanceled);
            dbConnection.cmd.Parameters.AddWithValue("@CanceledDate", paymentVoucher.CanceledDate);
            dbConnection.cmd.Parameters.AddWithValue("@CanceledUser", paymentVoucher.CanceledUser);
            dbConnection.cmd.Parameters.AddWithValue("@BankAccount", paymentVoucher.BankAccount);

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<PaymentVoucher> GetAllPaymentVoucher(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Payment_Voucher";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<PaymentVoucher>(dbConnection.dr);
        }
    }
}
