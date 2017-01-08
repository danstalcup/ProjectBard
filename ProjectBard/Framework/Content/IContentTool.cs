using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IContentTool : IState
    {
        IResult Save(ICommand Command, params string[] Arguments);

        IResult Load(ICommand Command, params string[] Arguments);

        string Directory { get; set; }

        string Entity { get; set; }

        IList<string> Entities { get; set; }

        IRepository Repository { get; set; }

        ITransformer Transformer { get; set; }

    }
}
