﻿using Microsoft.AspNetCore.Mvc;
using SeventhdGuard.API.Interfaces;
using SeventhdGuard.BO;
using SeventhdGuard.ENTITY;

using System.Net.NetworkInformation;

namespace SeventhdGuard.API.Controllers
{
    [Route("api/servers")]
    [ApiController]
    public partial class ServidorController : ControllerBase, IServidorController
    {
        #region "Variables"

        private ServidorBo? _servidorBo;

        #endregion

        #region "Properties"

        private ServidorBo ServidorBo
        {
            get { return _servidorBo ?? (_servidorBo = new ServidorBo()); }
        }

        #endregion

        #region "Public Methods"

        #region "GET"

        [HttpGet]
        public ObjectResult GetAll()
        {
            var result = ServidorBo.GetAll();

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{serverId}")]
        public ObjectResult Get(string serverId)
        {
            var result = ServidorBo.Get(serverId);

            if (result.Success)
            {
                return Ok(result.Item);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("available/{serverId}")]
        public bool ServerVerify(string serverId)
        {
            return false;
        }

        #endregion

        #region "POST"

        [HttpPost]
        public ObjectResult Add([FromBody] Servidor entity)
        {
            var result = ServidorBo.Add(entity);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        #endregion

        #region "DELETE"

        [HttpDelete("{serverId}")]
        public ObjectResult Delete(string serverId)
        {
            var result = ServidorBo.Delete(serverId);

            if (result.Success) 
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        #endregion

        #endregion
    }
}
