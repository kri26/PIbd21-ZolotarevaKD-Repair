using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepairRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseLogic warehouseLogic;

        public WarehouseController(IWarehouseLogic warehouseLogic)
        {
            this.warehouseLogic = warehouseLogic;
        }

        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void AddMaterialToWarehouse(WarehouseMaterialBindingModel model) => warehouseLogic.AddMaterial(model);

        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => warehouseLogic.Delete(model);

        [HttpGet]
        public List<WarehouseViewModel> GetWarehouses() => warehouseLogic.Read(null);
    }
}