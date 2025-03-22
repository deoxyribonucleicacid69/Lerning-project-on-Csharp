using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library69
{
    /// <summary>
    /// Интерфейс для классов которые реализуют задачи имеющие две задачи.
    /// </summary>
    public interface IExecutionOfNestedMenuItems
    {
        string[] menu { get; }
        void Exit();
        void FirstTask(ref List<Visitor> visitors, ref string data);
        void SecondTask(ref List<Visitor> visitors,ref string data);
    }
}
