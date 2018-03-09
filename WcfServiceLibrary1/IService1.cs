namespace WcfServiceLibrary1
{
    using DTO;
    using System.Collections.Generic;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<UserDTO> GetUsers();

        [OperationContract]
        List<BookDTO> GetBooks();

        [OperationContract]
        UserDTO GetByUserName(string name);

        [OperationContract]
        BookDTO GetBookById(int index);
    }
}
