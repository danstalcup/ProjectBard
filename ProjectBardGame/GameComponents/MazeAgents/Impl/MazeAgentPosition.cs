using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents.MazeAgents.Impl
{
    public class MazeAgentPosition : IMazeAgentPosition
    {
        public MazeAgentPosition(IMazeAgent Agent, IMazeAgentPosition Position)
        {
            _agent = Agent;
        }

        public IMazeAgent Agent
        {
            get
            {
                return _agent;
            }
        }

        public IMazeCell Position
        {
            get; set;
        }

        private readonly IMazeAgent _agent;        
    }
}
