﻿using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface TaskAllocationDetailController
    {

        int SaveTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail);
        int UpdateTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail);

        List<TaskAllocationDetail> GetAllTaskAllocationDetail();
        List<TaskAllocationDetail> GetAllTaskAllocationDetail(bool withProjectTask, bool withTaskType, bool withTaskAllocation);
        TaskAllocationDetail GetTaskAllocationDetail(int id, bool withProjectTask, bool withTaskType, bool withTaskAllocation);
        int DeleteTaskAllocationDetail(int allocationId, int detailId);
        List<TaskAllocationDetail> GetTaskAllocationDetail(int depId, DateTime date);

        List<TaskAllocationDetail> GetAllTaskAllocationDetailByTaskAllocationId(int taskId);

    }

    public class TaskAllocationDetailControllerImpl : TaskAllocationDetailController
    {

        DBConnection dBConnection;
        TaskAllocationDetailDAO taskAllocationDetailDAO = DAOFactory.CreateTaskAllocationDetailDAO();

        TaskTypeDAO taskTypeDAO = DAOFactory.CreateTaskTypeDAO();
        public int SaveTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail)
        {

            try
            {
                dBConnection = new DBConnection();
                return taskAllocationDetailDAO.SaveTaskAllocationDetail(taskAllocationDetail, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
        public List<TaskAllocationDetail> GetAllTaskAllocationDetail()
        {
            try
            {
                dBConnection = new DBConnection();

                List<TaskAllocationDetail> listTaskAllocationDetail = taskAllocationDetailDAO.GetAllTaskAllocationDetail(dBConnection);
                return listTaskAllocationDetail;
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<TaskAllocationDetail> GetTaskAllocationDetail(int depId, DateTime date)
        {
            try
            {
                dBConnection = new DBConnection();

                List<TaskAllocationDetail> listTaskAllocationDetail = taskAllocationDetailDAO.GetTaskAllocationDetail(dBConnection, depId, date);

                List<TaskType> listTaskType = taskTypeDAO.GetAllTaskType(dBConnection);

                foreach (var taskName in listTaskAllocationDetail)
                {
                    taskName._TaskType = listTaskType.Where(x => x.TaskTypeId == taskName.TaskTypeId).Single();
                }

                return listTaskAllocationDetail;
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdateTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail)
        {

            try
            {
                dBConnection = new DBConnection();
                var taskAllocationDetails = taskAllocationDetailDAO.UpdateTaskAllocationDetail(taskAllocationDetail, dBConnection);
                return taskAllocationDetails;
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<TaskAllocationDetail> GetAllTaskAllocationDetailByTaskAllocationId(int taskId)
        {
            try
            {
                dBConnection = new DBConnection();

                List<TaskAllocationDetail> listTaskAllocationDetail = taskAllocationDetailDAO.GetAllTaskAllocationDetailByTaskAllocationId(taskId, dBConnection);
                List<TaskType> listTaskType = taskTypeDAO.GetAllTaskType(dBConnection);

                foreach (var taskName in listTaskAllocationDetail)
                {
                    taskName._TaskType = listTaskType.Where(x => x.TaskTypeId == taskName.TaskTypeId).Single();
                }
                return listTaskAllocationDetail;
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<TaskAllocationDetail> GetAllTaskAllocationDetail(bool withProjectTask, bool withTaskType, bool withTaskAllocation)
        {
            try
            {
                dBConnection = new DBConnection();
                List<TaskAllocationDetail> list = taskAllocationDetailDAO.GetAllTaskAllocationDetail(dBConnection);
                TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
                List<TaskAllocation> listTaskAllocation = taskAllocationController.GetAllTaskAllocationWithDepartmentUnitPosition();

                if (withTaskAllocation)
                {
                    TaskAllocationDAO _TaskAllocationDAO = DAOFactory.CreateTaskAllocationDAO();
                    foreach (var item in list)
                    {
                        item._TaskAllocation = listTaskAllocation.Where(x => x.TaskAllocationId == item.TaskAllocationId).Single();
                    }

                }

                if (withTaskType)
                {
                    TaskTypeDAO _TaskTypeController = DAOFactory.CreateTaskTypeDAO();
                    List<TaskType> listTaskType = _TaskTypeController.GetAllTaskType(dBConnection);

                    foreach (var item in list)
                    {
                        item._TaskType = listTaskType.Where(a => a.TaskTypeId == item.TaskTypeId).Single();
                    }
                }


                if (withProjectTask)
                {
                    ProjectTaskDAO _ProjectTaskController = DAOFactory.CreateProjectTaskDAO();
                    List<ProjectTask> listProjectTask = _ProjectTaskController.GetAllProjectTask(dBConnection);

                    foreach (var item in list)
                    {
                        item._ProjectTask = listProjectTask.Where(a => a.TaskAllocationDetailId == item.TaskAllocationDetailId).ToList();

                    }

                }

                //if (withProjectTask)
                //{
                //    ProjectTaskDAO _ProjectTaskDAO = DAOFactory.CreateProjectTaskDAO();
                //    foreach (var item in list)
                //    {
                //        item._ProjectTask = _ProjectTaskDAO.GetProjectTaskByTaskAllocationDetailId(item.TaskAllocationDetailId, dBConnection);
                //    }
                //}


                return list;

            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public TaskAllocationDetail GetTaskAllocationDetail(int id, bool withProjectTask, bool withTaskType, bool withTaskAllocation)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TaskAllocationDetailDAO DAO = DAOFactory.CreateTaskAllocationDetailDAO();
                TaskAllocationDetail _TaskAllocationDetail = DAO.GetTaskAllocationDetail(id, dbConnection);



                if (withTaskAllocation)
                {
                    TaskAllocationDAO _TaskAllocationController = DAOFactory.CreateTaskAllocationDAO();
                    _TaskAllocationDetail._TaskAllocation = _TaskAllocationController.GetTaskAllocation(_TaskAllocationDetail.TaskAllocationDetailId, dbConnection);

                }

                if (withTaskType)
                {
                    TaskTypeDAO _TaskTypeController = DAOFactory.CreateTaskTypeDAO();
                    _TaskAllocationDetail._TaskType = _TaskTypeController.GetTaskType(_TaskAllocationDetail.TaskAllocationDetailId, dbConnection);

                }


                if (withProjectTask)
                {
                    ProjectTaskDAO _ProjectTaskController = DAOFactory.CreateProjectTaskDAO();
                    _TaskAllocationDetail._ProjectTask = _ProjectTaskController.GetProjectTaskByTaskAllocationDetailId(_TaskAllocationDetail.TaskAllocationDetailId, dbConnection);

                }
                return _TaskAllocationDetail;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }


        public int DeleteTaskAllocationDetail(int allocationId, int detailId)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TaskAllocationDetailDAO DAO = DAOFactory.CreateTaskAllocationDetailDAO();
                int id = DAO.DeleteTaskAllocationDetail(detailId, dbConnection);

                //if (id != 0)
                //{
                //    TaskAllocationDAO taskAllocationDAO = DAOFactory.CreateTaskAllocationDAO();
                //    taskAllocationDAO.DeleteTaskAllocation(allocationId, dbConnection);
                //}

                return 1;

            }
            catch
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }

        }


    }
}

