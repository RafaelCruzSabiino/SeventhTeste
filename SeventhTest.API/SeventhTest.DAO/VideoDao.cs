﻿using SeventhTest.DAO.Base;
using SeventhTest.DAO.Interfaces;
using SeventhTest.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;

namespace SeventhTest.DAO
{
    public class VideoDao : BaseDao<Video>, IVideoDao
    {
        #region "Constants"

        #region "Procedures"

        private const string Sdg00020001 = "SP_SGD_0002_0001";
        private const string Sdg00020002 = "SP_SGD_0002_0002";
        private const string Sdg00020003 = "SP_SGD_0002_0003";
        private const string Sdg00020004 = "SP_SGD_0002_0004";
        private const string Sdg00020005 = "SP_SGD_0002_0005";
        private const string Sdg00020006 = "SP_SGD_0002_0006";

        #endregion

        #region "Parameters"

        protected const string ParamIdServer    = "pID_SERVER";
        protected const string ParamDescription = "pDESCRIPTION";

        #endregion

        #endregion

        #region "Construct"

        public VideoDao() 
        {
            DbNameToDtoName.Add("ID_SERVER",   "IdServer");
            DbNameToDtoName.Add("DESCRIPTION", "Description");
        }

        #endregion

        public int Add(Video entity)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020001;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,          entity.Id);
                cmd.Parameters.AddWithValue(ParamIdServer,    entity.IdServer);
                cmd.Parameters.AddWithValue(ParamDescription, entity.Description);
                cmd.Parameters.AddWithValue(ParamDateAlter,   entity.DateAlter);
                cmd.Parameters.AddWithValue(ParamDateInsert,  entity.DateInsert);

                using (var RetBase = cmd.ExecuteReader())
                {
                    while (RetBase.Read())
                    {
                        lastInsertId = Convert.ToInt32(RetBase[ParamReturnValue]);
                    }
                }
            }

            CloseConnection();

            return lastInsertId;
        }

        public int Update(Video entity)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020002;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,          entity.Id);
                cmd.Parameters.AddWithValue(ParamIdServer,    entity.IdServer);
                cmd.Parameters.AddWithValue(ParamDescription, entity.Description);
                cmd.Parameters.AddWithValue(ParamDateAlter,   entity.DateAlter);

                using (var RetBase = cmd.ExecuteReader())
                {
                    while (RetBase.Read())
                    {
                        rowsAffected = Convert.ToInt32(RetBase[ParamReturnValue]);
                    }
                }
            }

            CloseConnection();

            return rowsAffected;
        }

        public int Delete(int id)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020003;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId, id);

                using (var RetBase = cmd.ExecuteReader())
                {
                    while (RetBase.Read())
                    {
                        rowsAffected = Convert.ToInt32(RetBase[ParamReturnValue]);
                    }
                }
            }

            CloseConnection();

            return rowsAffected;
        }

        public Video Get(int id)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020004;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId, id);

                using (var RetBase = cmd.ExecuteReader())
                {
                    return DataReaderToEntity(RetBase);
                }
            }
        }

        public IEnumerable<Video> GetAll()
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020005;
                cmd.CommandTimeout = 0;

                using (var RetBase = cmd.ExecuteReader())
                {
                    return DataReaderToEntities(RetBase);
                }
            }
        }

        public IEnumerable<Video> GetVideoByServer(int idServer)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020006;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamIdServer, idServer);

                using (var RetBase = cmd.ExecuteReader())
                {
                    return DataReaderToEntities(RetBase);
                }
            }
        }
    }
}