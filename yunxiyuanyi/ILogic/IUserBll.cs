using Entity.LogicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface IUserBll : IBaseBll<User>
    {
        /// <summary>
        /// ²éÑ¯µÇÂ¼ÓÃ»§
        /// </summary>
        User QueryLoginUser(string loginAccount);
    }
}
