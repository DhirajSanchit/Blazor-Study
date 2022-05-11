using DataLayer.Dtos;

namespace DataLayer.Interfaces;

public interface IShoppingCartDal
{
    public IList<ShoppingCartDto> GetAll();
    public ShoppingCartDto GetById(int id);

    public ShoppingCartDto AddItem();

}