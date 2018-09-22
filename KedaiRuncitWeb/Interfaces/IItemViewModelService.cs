using System.Collections;
using System.Collections.Generic;
using KedaiRuncitWeb.ViewModels;

namespace KedaiRuncitWeb.Interfaces
{
    public interface IItemViewModelService
    {
        IEnumerable<ItemViewModel> GetItems();
    }
}
