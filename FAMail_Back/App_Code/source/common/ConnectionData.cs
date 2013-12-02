using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Email
{
   public class ConnectionData
    {
        #region Variables
        public static string _ConnectionString = "";
        public static System.Data.SqlClient.SqlConnection _MyConnection;
        public static System.Data.SqlClient.SqlTransaction _MyTransaction;
        private static int iCountConnect = 0;
        #endregion
        #region Public Methods
        public static void AddNewConnection()
        {
            _MyConnection = new System.Data.SqlClient.SqlConnection(_ConnectionString);
        }

        public static bool TestMyConnection()
        {
            try
            {
                _MyConnection.Open();
                if (_MyConnection.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                _MyConnection.Close();
            }
        }

        public static void OpenMyConnection()
        {
            try
            {
                if (_MyConnection.State==ConnectionState.Closed)
                {
                    _MyConnection.Open();
                }
                
            }
            catch (Exception ex)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public static void CloseMyConnection()
        {
            try
            {
                if ( _MyConnection.State == ConnectionState.Open)
                {
                    _MyConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public static void BeginMyTransaction()
        {
            try
            {
                _MyTransaction = _MyConnection.BeginTransaction();
            }
            catch (Exception ex)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public static void CommitMyTransaction()
        {
            try
            {
                _MyTransaction.Commit();
            }
            catch (Exception ex)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public static void RollbackMyTransaction()
        {
            try
            {
                _MyTransaction.Rollback();
            }
            catch (Exception ex)
            {
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }
        #endregion

    }
}


       