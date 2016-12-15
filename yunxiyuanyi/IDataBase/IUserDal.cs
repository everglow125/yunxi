using Entity.LogicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataBase
{
    public interface IUserDal : IBaseDal<User>
    {
        /// <summary>
        /// ²éÑ¯µÇÂ¼ÓÃ»§
        /// </summary>
        User QueryLoginUser(string loginAccount);
    }
}
