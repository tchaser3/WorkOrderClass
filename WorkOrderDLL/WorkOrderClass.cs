/* Title:           Work Order Class
 * Date:            7-31-17
 * Author:          Terry Holmes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace WorkOrderDLL
{
    public class WorkOrderClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        WorkOrdersDataSet aWorkOrdersDataSet;
        WorkOrdersDataSetTableAdapters.workordersTableAdapter aWorkOrdersTableAdapter;

        InsertWorkOrderEntryTableAdapters.QueriesTableAdapter aInsertWorkOrderEntryTableAdapter;

        UpdateWorkOrderStatusIDEntryTableAdapters.QueriesTableAdapter aUpdateWorkOrderStatusIDTableAdapter;

        UpdateWorkOrderStatusDateEntryTableAdapters.QueriesTableAdapter aUpdateWorkOrderStatusDateTableAdapter;

        FindWorkOrderByAddressIDDataSet aFindWorkOrderByAddressIDDataSet;
        FindWorkOrderByAddressIDDataSetTableAdapters.FindWorkOrderByAddressIDTableAdapter aFindWorkOrderByAddressIDTableAdapter;

        FindWorkOrderbyDateReceivedDataSet aFindWorkOrderByDateReceivedDateSet;
        FindWorkOrderbyDateReceivedDataSetTableAdapters.FindWorkOrderByDateReceivedTableAdapter aFindWorkOrderByDateReceivedTableAdapter;

        FindWorkOrderByStatusDateDataSet aFindWorkOrderByStatusDateDataSet;
        FindWorkOrderByStatusDateDataSetTableAdapters.FindWorkOrderByStatusDateRangeTableAdapter aFindWorkOrderByStatusDateTableAdapter;

        FindWorkOrderByDateScheduledDataSet aFindWorkOrderByDateScheduleDataSet;
        FindWorkOrderByDateScheduledDataSetTableAdapters.FindWorkOrderByDateScheduledDateRangeTableAdapter aFindWorkOrderbyDateScheduledTableAdapter;

        FindWorkOrderByWorkOrderTypeAndStatusIDDataSet aFindWorkOrderByTypAndStatusIDDataSet;
        FindWorkOrderByWorkOrderTypeAndStatusIDDataSetTableAdapters.FindWorkOrderByWorkOrderTypeAndStatusIDTableAdapter aFindWorkorderByTypeAndStatusIDTableAdapter;

        FindWorkOrderByWorkOrderNumberDataSet aFindWorkOrderByWorkOrderNumberDataSet;
        FindWorkOrderByWorkOrderNumberDataSetTableAdapters.FindWorkOrderByWorkOrderNumberTableAdapter aFindWorkOrderByWorkOrderNumberTableAdapter;

        WorkOrderStatusDataSet aWorkOrderStatusDataSet;
        WorkOrderStatusDataSetTableAdapters.workorderstatusTableAdapter aWorkOrderStatusTableAdpater;

        InsertWorkOrderStatusEntryTableAdapters.QueriesTableAdapter aInsertWorkOrderStatusTableAdapter;

        FindWorkOrderStatusByStatusIDDataSet aFindWorkOrderStatusByStatusIDDataSet;
        FindWorkOrderStatusByStatusIDDataSetTableAdapters.FindWorkOrderStatusByStatusIDTableAdapter aFindWorkOrderStatusbyStatusIDTableAdapter;

        FindWorkOrderStatusByStatusDataSet aFindWorkOrderStatusByStatusDataSet;
        FindWorkOrderStatusByStatusDataSetTableAdapters.FindWorkOrderStatusByStatusTableAdapter aFindWorkOrderStatusByStatusTableAdapter;

        FindWorkOrderStatusSortedDataSet aFindWorkOrderStatusSortedDataSet;
        FindWorkOrderStatusSortedDataSetTableAdapters.FindWorkOrderStatusSortedTableAdapter aFindWorkOrderStatusSortedTableAdapter;

        WorkOrderUpdatesDataSet aWorkOrderUpdatesDataSet;
        WorkOrderUpdatesDataSetTableAdapters.workorderupdatesTableAdapter aWorkOrderUpdatesTableAdapter;

        InsertWorkOrderUpdateEntryTableAdapters.QueriesTableAdapter aInsertWorkOrderUpdateTableAdapter;

        FindWorkOrderUpdatesDataSet aFindWorkOrderUpdatesDataSet;
        FindWorkOrderUpdatesDataSetTableAdapters.FindWorkOrderUpdatesTableAdapter aFindWorkOrderUpdatesTableAdapter;

        FindWorkOrderUpdatesByWorkOrderIDDataSet aFindWorkOrderUpdatesByWorkOrderIDDataSet;
        FindWorkOrderUpdatesByWorkOrderIDDataSetTableAdapters.FindWorkOrderUpdateByWorkOrderIDTableAdapter aFindWorkOrderUpdatesByWorkOrderIDTableAdapter;

        FindWorkOrderByStatusIDDataSet aFindWorkOrderByStatusIDDataSet;
        FindWorkOrderByStatusIDDataSetTableAdapters.FindWorkOrderByStatusIDTableAdapter aFindWorkOrderByStatusIDTableAdapter;

        FindOpenWorkOrdersByCustomerIDDataSet aFindOpenWorkOrderByCustomerIDDataSet;
        FindOpenWorkOrdersByCustomerIDDataSetTableAdapters.FindOpenWorkOrdersByCustomerIDTableAdapter aFindOpenWorkOrderByCustomerIDTableAdapter;

        FindPendingWorkOrdersByCustomerIDDataSet aFindPendingWorkOrdersByCustomerIDDataSet;
        FindPendingWorkOrdersByCustomerIDDataSetTableAdapters.FindPendingWorkOrdersByCustomerIDTableAdapter aFindPendingWorkOrdersByCustomerIDTableAdapter;

        FindWorkOrderbyStatusTypeandZoneDataSet aFindWorkOrderByStatusTypeZoneDataSet;
        FindWorkOrderbyStatusTypeandZoneDataSetTableAdapters.FindWorkOrderByStatusTypeandZoneTableAdapter aFindWorkOrderByStatusTypeandZoneTableAdapter;

        UpdateWorkOrderScheduleDateEntryTableAdapters.QueriesTableAdapter aUpdateWorkOrderScheduleDateTableAdpater;

        public bool UpdateWorkOrderScheduleDate(int intWorkOrderID, DateTime datScheduledDate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateWorkOrderScheduleDateTableAdpater = new UpdateWorkOrderScheduleDateEntryTableAdapters.QueriesTableAdapter();
                aUpdateWorkOrderScheduleDateTableAdpater.UpdateWorkOrderScheduledDate(intWorkOrderID, datScheduledDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Update Work Order Schedule Date " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindWorkOrderbyStatusTypeandZoneDataSet FindWorkOrderbyStatusTypeandZone(int intStatusID, string strWorkType, string strZone, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderByStatusTypeZoneDataSet = new FindWorkOrderbyStatusTypeandZoneDataSet();
                aFindWorkOrderByStatusTypeandZoneTableAdapter = new FindWorkOrderbyStatusTypeandZoneDataSetTableAdapters.FindWorkOrderByStatusTypeandZoneTableAdapter();
                aFindWorkOrderByStatusTypeandZoneTableAdapter.Fill(aFindWorkOrderByStatusTypeZoneDataSet.FindWorkOrderByStatusTypeandZone, intStatusID, strWorkType, strZone, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Status Type And Zone " + Ex.Message);
            }

            return aFindWorkOrderByStatusTypeZoneDataSet;
        }
        public FindPendingWorkOrdersByCustomerIDDataSet FindPendingWorkOrdersByCustomerID(int intCustomerID)
        {
            try
            {
                aFindPendingWorkOrdersByCustomerIDDataSet = new FindPendingWorkOrdersByCustomerIDDataSet();
                aFindPendingWorkOrdersByCustomerIDTableAdapter = new FindPendingWorkOrdersByCustomerIDDataSetTableAdapters.FindPendingWorkOrdersByCustomerIDTableAdapter();
                aFindPendingWorkOrdersByCustomerIDTableAdapter.Fill(aFindPendingWorkOrdersByCustomerIDDataSet.FindPendingWorkOrdersByCustomerID, intCustomerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Pending Work Orders By Customer ID " + Ex.Message);
            }

            return aFindPendingWorkOrdersByCustomerIDDataSet;
        }
        public FindOpenWorkOrdersByCustomerIDDataSet FindOpenWorkOrdersByCustomerID(int intCustomerID)
        {
            try
            {
                aFindOpenWorkOrderByCustomerIDDataSet = new FindOpenWorkOrdersByCustomerIDDataSet();
                aFindOpenWorkOrderByCustomerIDTableAdapter = new FindOpenWorkOrdersByCustomerIDDataSetTableAdapters.FindOpenWorkOrdersByCustomerIDTableAdapter();
                aFindOpenWorkOrderByCustomerIDTableAdapter.Fill(aFindOpenWorkOrderByCustomerIDDataSet.FindOpenWorkOrdersByCustomerID, intCustomerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Open Work Orders By Customer ID " + Ex.Message);
            }

            return aFindOpenWorkOrderByCustomerIDDataSet;
        }
        public FindWorkOrderByStatusIDDataSet FindWorkOrderByStatusID(int intStatusID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderByStatusIDDataSet = new FindWorkOrderByStatusIDDataSet();
                aFindWorkOrderByStatusIDTableAdapter = new FindWorkOrderByStatusIDDataSetTableAdapters.FindWorkOrderByStatusIDTableAdapter();
                aFindWorkOrderByStatusIDTableAdapter.Fill(aFindWorkOrderByStatusIDDataSet.FindWorkOrderByStatusID, intStatusID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Status ID " + Ex.Message);
            }

            return aFindWorkOrderByStatusIDDataSet;
        }
        public FindWorkOrderUpdatesByWorkOrderIDDataSet FindWorkOrderUpdatesByWorkOrderID(int intWorkOrderID)
        {
            try
            {
                aFindWorkOrderUpdatesByWorkOrderIDDataSet = new FindWorkOrderUpdatesByWorkOrderIDDataSet();
                aFindWorkOrderUpdatesByWorkOrderIDTableAdapter = new FindWorkOrderUpdatesByWorkOrderIDDataSetTableAdapters.FindWorkOrderUpdateByWorkOrderIDTableAdapter();
                aFindWorkOrderUpdatesByWorkOrderIDTableAdapter.Fill(aFindWorkOrderUpdatesByWorkOrderIDDataSet.FindWorkOrderUpdateByWorkOrderID, intWorkOrderID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order Updates By Work Order ID " + Ex.Message);
            }

            return aFindWorkOrderUpdatesByWorkOrderIDDataSet;
        }
        public FindWorkOrderUpdatesDataSet FindWorkOrderUpdatesByEmployeeIDAndDateRange(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderUpdatesDataSet = new FindWorkOrderUpdatesDataSet();
                aFindWorkOrderUpdatesTableAdapter = new FindWorkOrderUpdatesDataSetTableAdapters.FindWorkOrderUpdatesTableAdapter();
                aFindWorkOrderUpdatesTableAdapter.Fill(aFindWorkOrderUpdatesDataSet.FindWorkOrderUpdates, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order Updates " + Ex.Message);
            }

            return aFindWorkOrderUpdatesDataSet;
        }
        public bool InsertWorkOrderUpdate(int intWorkOrderID, int intEmployeeID, string strWorkOrderNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWorkOrderUpdateTableAdapter = new InsertWorkOrderUpdateEntryTableAdapters.QueriesTableAdapter();
                aInsertWorkOrderUpdateTableAdapter.InsertWorkOrderUpdate(intWorkOrderID, DateTime.Now, intEmployeeID, strWorkOrderNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Insert Work Order Update " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WorkOrderUpdatesDataSet GetWorkOrderUpdates()
        {
            try
            {
                aWorkOrderUpdatesDataSet = new WorkOrderUpdatesDataSet();
                aWorkOrderUpdatesTableAdapter = new WorkOrderUpdatesDataSetTableAdapters.workorderupdatesTableAdapter();
                aWorkOrderUpdatesTableAdapter.Fill(aWorkOrderUpdatesDataSet.workorderupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Get Work Order Updates " + Ex.Message);
            }

            return aWorkOrderUpdatesDataSet;
        }
        public void UpdateWorkOrderUpdatesDB(WorkOrderUpdatesDataSet aWorkOrderUpdatesDataSet)
        {
            try
            {
                aWorkOrderUpdatesTableAdapter = new WorkOrderUpdatesDataSetTableAdapters.workorderupdatesTableAdapter();
                aWorkOrderUpdatesTableAdapter.Update(aWorkOrderUpdatesDataSet.workorderupdates);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Get Work Order Updates " + Ex.Message);
            }
        }
        public FindWorkOrderStatusSortedDataSet FindWorkOrderStatusSorted()
        {
            try
            {
                aFindWorkOrderStatusSortedDataSet = new FindWorkOrderStatusSortedDataSet();
                aFindWorkOrderStatusSortedTableAdapter = new FindWorkOrderStatusSortedDataSetTableAdapters.FindWorkOrderStatusSortedTableAdapter();
                aFindWorkOrderStatusSortedTableAdapter.Fill(aFindWorkOrderStatusSortedDataSet.FindWorkOrderStatusSorted);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order Status Sorted " + Ex.Message);
            }

            return aFindWorkOrderStatusSortedDataSet;
        }
        public FindWorkOrderStatusByStatusDataSet FindWorkOrderStatusByStatus(string strWorkOrderStatus)
        {
            try
            {
                aFindWorkOrderStatusByStatusDataSet = new FindWorkOrderStatusByStatusDataSet();
                aFindWorkOrderStatusByStatusTableAdapter = new FindWorkOrderStatusByStatusDataSetTableAdapters.FindWorkOrderStatusByStatusTableAdapter();
                aFindWorkOrderStatusByStatusTableAdapter.Fill(aFindWorkOrderStatusByStatusDataSet.FindWorkOrderStatusByStatus, strWorkOrderStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order Status By Status " + Ex.Message);
            }

            return aFindWorkOrderStatusByStatusDataSet;
        }
        public FindWorkOrderStatusByStatusIDDataSet FindWorkOrderStatusByStatusID(int intStatusID)
        {
            try
            {
                aFindWorkOrderStatusByStatusIDDataSet = new FindWorkOrderStatusByStatusIDDataSet();
                aFindWorkOrderStatusbyStatusIDTableAdapter = new FindWorkOrderStatusByStatusIDDataSetTableAdapters.FindWorkOrderStatusByStatusIDTableAdapter();
                aFindWorkOrderStatusbyStatusIDTableAdapter.Fill(aFindWorkOrderStatusByStatusIDDataSet.FindWorkOrderStatusByStatusID, intStatusID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order Status By Status ID " + Ex.Message);
            }

            return aFindWorkOrderStatusByStatusIDDataSet;
        }
        public bool InsertWorkOrderStatus(string strWorkOrderStatus)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWorkOrderStatusTableAdapter = new InsertWorkOrderStatusEntryTableAdapters.QueriesTableAdapter();
                aInsertWorkOrderStatusTableAdapter.InsertWorkStatus(strWorkOrderStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Insert Work Order Status " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WorkOrderStatusDataSet GetWorkOrderStatusInfo()
        {
            try
            {
                aWorkOrderStatusDataSet = new WorkOrderStatusDataSet();
                aWorkOrderStatusTableAdpater = new WorkOrderStatusDataSetTableAdapters.workorderstatusTableAdapter();
                aWorkOrderStatusTableAdpater.Fill(aWorkOrderStatusDataSet.workorderstatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Get Work Order Status Info " + Ex.Message);
            }

            return aWorkOrderStatusDataSet;
        }
        public void UpdateWorkOrderStatusDB(WorkOrderStatusDataSet aWorkOrderStatusDataSet)
        {
            try
            {
                aWorkOrderStatusTableAdpater = new WorkOrderStatusDataSetTableAdapters.workorderstatusTableAdapter();
                aWorkOrderStatusTableAdpater.Update(aWorkOrderStatusDataSet.workorderstatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Update Work Order Status DB " + Ex.Message);
            }
        }
        public FindWorkOrderByWorkOrderNumberDataSet FindWorkOrderByWorkOrderNumber(string strWorkOrderNumber)
        {
            try
            {
                aFindWorkOrderByWorkOrderNumberDataSet = new FindWorkOrderByWorkOrderNumberDataSet();
                aFindWorkOrderByWorkOrderNumberTableAdapter = new FindWorkOrderByWorkOrderNumberDataSetTableAdapters.FindWorkOrderByWorkOrderNumberTableAdapter();
                aFindWorkOrderByWorkOrderNumberTableAdapter.Fill(aFindWorkOrderByWorkOrderNumberDataSet.FindWorkOrderByWorkOrderNumber, strWorkOrderNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Work Order Number " + Ex.Message);
            }

            return aFindWorkOrderByWorkOrderNumberDataSet;
        }
        public FindWorkOrderByWorkOrderTypeAndStatusIDDataSet FindWorkOrderByTypeAndStatusID(string strWorkOrderType, int intStatusID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderByTypAndStatusIDDataSet = new FindWorkOrderByWorkOrderTypeAndStatusIDDataSet();
                aFindWorkorderByTypeAndStatusIDTableAdapter = new FindWorkOrderByWorkOrderTypeAndStatusIDDataSetTableAdapters.FindWorkOrderByWorkOrderTypeAndStatusIDTableAdapter();
                aFindWorkorderByTypeAndStatusIDTableAdapter.Fill(aFindWorkOrderByTypAndStatusIDDataSet.FindWorkOrderByWorkOrderTypeAndStatusID, strWorkOrderType, intStatusID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Type and Status ID " + Ex.Message);
            }

            return aFindWorkOrderByTypAndStatusIDDataSet;
        }
        public FindWorkOrderByDateScheduledDataSet FindWorkOrderByDateScheduled(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderByDateScheduleDataSet = new FindWorkOrderByDateScheduledDataSet();
                aFindWorkOrderbyDateScheduledTableAdapter = new FindWorkOrderByDateScheduledDataSetTableAdapters.FindWorkOrderByDateScheduledDateRangeTableAdapter();
                aFindWorkOrderbyDateScheduledTableAdapter.Fill(aFindWorkOrderByDateScheduleDataSet.FindWorkOrderByDateScheduledDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Date Scheduled " + Ex.Message);
            }

            return aFindWorkOrderByDateScheduleDataSet;
        }
        public FindWorkOrderByStatusDateDataSet FindWorkOrderByStatusDate(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderByStatusDateDataSet = new FindWorkOrderByStatusDateDataSet();
                aFindWorkOrderByStatusDateTableAdapter = new FindWorkOrderByStatusDateDataSetTableAdapters.FindWorkOrderByStatusDateRangeTableAdapter();
                aFindWorkOrderByStatusDateTableAdapter.Fill(aFindWorkOrderByStatusDateDataSet.FindWorkOrderByStatusDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Status Date " + Ex.Message);
            }

            return aFindWorkOrderByStatusDateDataSet;
        }
        public bool UpdateWorkOrderStatusDate(int intWorkOrderID, DateTime datStatusDate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateWorkOrderStatusDateTableAdapter = new UpdateWorkOrderStatusDateEntryTableAdapters.QueriesTableAdapter();
                aUpdateWorkOrderStatusDateTableAdapter.UpdateWorkOrderStatusDate(intWorkOrderID, datStatusDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Update Work Order Status Date " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindWorkOrderbyDateReceivedDataSet FindWorkOrderByDateReceived(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWorkOrderByDateReceivedDateSet = new FindWorkOrderbyDateReceivedDataSet();
                aFindWorkOrderByDateReceivedTableAdapter = new FindWorkOrderbyDateReceivedDataSetTableAdapters.FindWorkOrderByDateReceivedTableAdapter();
                aFindWorkOrderByDateReceivedTableAdapter.Fill(aFindWorkOrderByDateReceivedDateSet.FindWorkOrderByDateReceived, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work By Date Received " + Ex.Message);
            }

            return aFindWorkOrderByDateReceivedDateSet;
        }
        public FindWorkOrderByAddressIDDataSet FindWorkOrderByAddressID(int intAddressID)
        {
            try
            {
                aFindWorkOrderByAddressIDDataSet = new FindWorkOrderByAddressIDDataSet();
                aFindWorkOrderByAddressIDTableAdapter = new FindWorkOrderByAddressIDDataSetTableAdapters.FindWorkOrderByAddressIDTableAdapter();
                aFindWorkOrderByAddressIDTableAdapter.Fill(aFindWorkOrderByAddressIDDataSet.FindWorkOrderByAddressID, intAddressID);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Find Work Order By Address ID " + ex.Message);
            }

            return aFindWorkOrderByAddressIDDataSet;
        }
        public bool UpdateWorkOrderStatusID(int intWorkOrderID, int intStatusID)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateWorkOrderStatusIDTableAdapter = new UpdateWorkOrderStatusIDEntryTableAdapters.QueriesTableAdapter();
                aUpdateWorkOrderStatusIDTableAdapter.UpdateWorkOrderStatusID(intWorkOrderID, intStatusID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Update Work Order Status ID " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertWorkOrder(string strWorkOrderNumber, int intTypeID, int intCustomerID, int intAddressID, DateTime datDateScheduled, DateTime datDateReceived, int intStatusID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWorkOrderEntryTableAdapter = new InsertWorkOrderEntryTableAdapters.QueriesTableAdapter();
                aInsertWorkOrderEntryTableAdapter.InsertWorkOrder(strWorkOrderNumber, intTypeID, intCustomerID, intAddressID, DateTime.Now, datDateScheduled, datDateReceived, DateTime.Now, intStatusID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Orders Class // Insert Work Order " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WorkOrdersDataSet GetWorkOrdersInfo()
        {
            try
            {
                aWorkOrdersDataSet = new WorkOrdersDataSet();
                aWorkOrdersTableAdapter = new WorkOrdersDataSetTableAdapters.workordersTableAdapter();
                aWorkOrdersTableAdapter.Fill(aWorkOrdersDataSet.workorders);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Get Work Orders Info " + Ex.Message);
            }

            return aWorkOrdersDataSet;
        }
        public void UpdateWorkOrdersDB(WorkOrdersDataSet aWorkOrdersDataSet)
        {
            try
            {
                aWorkOrdersTableAdapter = new WorkOrdersDataSetTableAdapters.workordersTableAdapter();
                aWorkOrdersTableAdapter.Update(aWorkOrdersDataSet.workorders);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Order Class // Get Work Orders Info " + Ex.Message);
            }
        }
    }
}
