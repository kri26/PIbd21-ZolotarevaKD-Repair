using System.Collections.Generic;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;

namespace RepairBusinessLogic.Interfaces
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> Read(WarehouseBindingModel model);
        void CreateOrUpdate(WarehouseBindingModel model);
        void Delete(WarehouseBindingModel model);
        void AddMaterial(WarehouseMaterialBindingModel model);
        void WriteOffMaterials(OrderViewModel model);
    }
}
