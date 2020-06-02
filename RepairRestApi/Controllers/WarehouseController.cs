using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DressesShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IWarehouseLogic warehouseLogic;

        public StorageController(IWarehouseLogic warehouseLogic)
        {
            this.warehouseLogic = warehouseLogic;
        }

        [HttpPost]
        public void CreateOrUpdateStorage(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void AddMaterialToStorage(WarehouseMaterialBindingModel model) => warehouseLogic.AddMaterial(model);

        [HttpPost]
        public void DeleteStorage(WarehouseBindingModel model) => warehouseLogic.Delete(model);

        [HttpGet]
        public List<WarehouseViewModel> GetStorages() => warehouseLogic.Read(null);
    }
}