using System.Collections.Generic;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;

namespace RepairBusinessLogic.Interfaces
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> GetList();
        WarehouseViewModel GetElement(int id);
        void AddElement(WarehouseBindingModel model);
        void UpdElement(WarehouseBindingModel model);
        void DelElement(int id);
        void AddMaterial(WarehouseMaterialBindingModel model);
    }
}
