﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.BusinessLogic;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairRestApi.Models;


namespace RepairRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IRepairWorkLogic _RepairWork;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IRepairWorkLogic product, MainLogic main)
        {
            _order = order;
            _RepairWork = product;
            _main = main;
        }

        [HttpGet]
        public List<RepairWork> GetRepairWorkList() => _RepairWork.Read(null)?.Select(rec => Convert(rec)).ToList();

        [HttpGet]
        public RepairWork GetRepairWork(int RepairWorkId) => Convert(_RepairWork.Read(new RepairWorkBindingModel
        {
            Id = RepairWorkId
        })?[0]);

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        {
            ClientId = clientId
        });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);

        private RepairWork Convert(RepairWorkViewModel model)
        {
            if (model == null) return null;
            return new RepairWork
            {
                Id = model.Id,
                RepairWorkName = model.RepairWorkName,
                Price = model.Price
            };
        }
    }
}
