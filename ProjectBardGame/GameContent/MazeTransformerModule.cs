using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

using ProjectBardGame.GameComponents;

namespace ProjectBardGame.GameContent
{
    public class MazeTransformerModule : ITransformerModule<IMaze>
    {
        public MazeTransformerModule(IList<IMaze> Mazes)
        {
            _mazes = Mazes;
        }
        public IMaze Construct(params string[] Parameters)
        {
            IMaze result = null;

            if(Parameters.Any())
            {

            }

            return result;
        }

        private readonly IList<IMaze> _mazes;
    }
}
