namespace LogicLayer.Interfaces;

public interface IProcessOrder
{
    bool Execute(int orderId, string adminUserName );
}