using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ProjectBard.Simple;
using ProjectBard.Framework;


namespace ProjectBard.ContentTool
{
    public class SimpleContentTool : IContentTool
    {
        

        public SimpleContentTool(IState ReturnState, IRepository Repository)
        {
            this.Repository = Repository;
            this.Repository.Initialize();
            Directory = "content";
            Entity = "string";
            Entities = new List<string> { "string" };
            this.ReturnState = ReturnState;
        }

        public ITextContent StateDescription
        {
            get
            {
                return new TextContent
                (
                    "Content Tool Console\n"+
                    $"Directory: {Directory}\n"+
                    $"Entity: {Entity}"
                    );
            }
        }

        public ITextContent ValidCommands
        {
            get
            {
                return TextContentFactories.EligibleCommands
                (
                    new List<string> {                        
                        "directory - View the current directory",
                        "changedir [directory] - Change the current directory",
                        "entity - View the current entity type",
                        "changeentity [entity] - Change the current entity type",
                        "intializeempty - Create an empty data set",
                        "entities - View a list of all entity types",
                        "data - Show all content for this entity type",
                        "details [id] - Show details for content of a given id for this entity type",
                        "save - Save all data",
                        "load - Load in most recently saved data",
                        "loadexact [id] - Load in an exact data set",                        
                        "add [content] - Add content for the current entity type",                        
                        "remove [content] - Remove content for current entity type",
                        "exit - Return to start of game state"
                    }
                );
            }
        }

        public IResult Process(ICommand Command)
        {
            IResult result = null;
            switch (Command.CommandString)
            {
                case "directory":
                    {
                        result = ResultFactories.InformationalResult(Command, this, new TextContent($"The current directory is: {Directory}"), new TextContent("Type in a command."));
                        break;
                    }
                case "changedir":
                    {
                        if (Command.Arguments.Count > 0)
                        {
                            Directory = Command.Arguments[0];
                            result = ResultFactories.StateChangedResult(Command, this, new TextContent($"The directory has been set to: {Directory}"), new TextContent("Type in a command."));
                        }
                        else
                        {
                            result = ResultFactories.InformationalResult(Command, this, new TextContent($"ERROR: Directory name not included."), new TextContent("Type in a command."));
                        }
                        break;
                    }
                case "entity":
                    {
                        result = ResultFactories.InformationalResult(Command, this, new TextContent($"The current entity is: {Entity}"), new TextContent("Type in a command."));
                        break;
                    }
                case "changeentity":
                    {
                        if (Command.Arguments.Count > 0)
                        {
                            if (Entities.Contains(Command.Arguments[0].ToLower()))
                            {
                                Entity = Command.Arguments[0].ToLower();
                                result = ResultFactories.StateChangedResult(Command, this, new TextContent($"The entity has been set to: {Entity}"), new TextContent("Type in a command."));
                            }
                            else
                            {
                                result = ResultFactories.InformationalResult(Command, this, new TextContent($"ERROR: Selected entity does not exist."), new TextContent("Type in a command."));
                            }
                        }
                        else
                        {
                            result = ResultFactories.InformationalResult(Command, this, new TextContent($"ERROR: Entity name not included."), new TextContent("Type in a command."));
                        }
                        break;
                    }
                case "initializeempty":
                    {
                        Repository.Initialize();
                        result = ResultFactories.StateChangedResult(Command, this, new TextContent($"Empty data set initialized."), new TextContent("Type in a command."));
                        break;
                    }
                case "entities":
                    {
                        StringBuilder entitiesString = new StringBuilder("List of entities:\n");
                        foreach (string entity in Entities)
                        {
                            entitiesString.Append($"- {entity}\n");
                        }
                        result = ResultFactories.InformationalResult(Command, this, new TextContent(entitiesString.ToString()), new TextContent("Type in a command."));
                        break;
                    }
                case "data":
                    {
                        StringBuilder content = new StringBuilder($"All content items for entity {Entity}\n");
                        content.Append(string.Join("\n",Repository.GetContent(Entity)));
                        result = ResultFactories.InformationalResult(Command, this, new TextContent(content.ToString()), new TextContent("Type in a command."));
                        break;
                    }
                case "details":
                    {
                        return ResultFactories.EmptyResult(Command, this);
                    }
                case "save":
                    {
                        result = Save(Command);
                        break;
                    }
                case "load":
                    {
                        result = Load(Command);
                        break;
                    }
                case "loadexact":
                    {
                        if (Command.Arguments.Count == 0)
                        {
                            result = ResultFactories.InformationalResult(Command, this, new TextContent($"ERROR: Folder of exact data set not included."), new TextContent("Type in a command."));
                        }
                        else
                        {
                            result = Load(Command, Command.Arguments[0]);
                        }
                        break;
                    }
                case "add":
                    {                        
                        result = AddToRepository(Command, Entity);                        
                        break;
                    }                
                case "remove":
                    {
                        result = RemoveFromRepository(Command, Entity);
                        break;
                    }                    
                case "exit":
                    {
                        result = ResultFactories.StateChangedResult(Command, ReturnState, new TextContent($"Returning to previous state...\n\n").Append(ReturnState.StateDescription), new TextContent("Type in a command."));
                        break;
                    }
                default:
                    {
                        result = ResultFactories.InformationalResult(Command, this, new TextContent("ERROR: Invalid command."), new TextContent("Type in a command."));
                        break;
                    }
            }

            return result;
        }                    

        public IResult Save(ICommand Command, params string[] Arguments)
        {
            Result result = ResultFactories.EmptyResult(Command, this);
            StringBuilder resultDetailsString = new StringBuilder();
            try
            {

                string[] filepaths = new string[] { $"{Directory}\\latest", $"{Directory}\\{DateTime.Now.Ticks}" };
                bool firsttime = true;
                foreach (string entity in Entities)
                {
                    foreach (string filepath in filepaths)
                    {
                        string filename = $"{filepath}\\{entity}.json";
                        if (firsttime)
                        {
                            FileInfo file = new System.IO.FileInfo(filename);
                            file.Directory.Create();
                        }
                        File.WriteAllText(filename, Repository.Serialize(entity));                                               
                    }
                    firsttime = false;
                    resultDetailsString.Append($"Saving entity type: {entity}\n");
                }
                resultDetailsString.Append($"Saving complete!\nSaved to \\{filepaths[0]} and \\{filepaths[1]}");
                result.StateChanged = true;                
            }
            catch (Exception e)
            {
                resultDetailsString.Append($"ERROR!\n{e.Message}");
            }
            result.ResultDetails = new TextContent(resultDetailsString.ToString());
            return result;
        }

        public IResult Load(ICommand Command, params string[] Arguments)
        {
            
            Result result = ResultFactories.EmptyResult(Command, this);
            StringBuilder resultDetailsString = new StringBuilder();

            
            try
            {
                string loadDirectory = "latest";
                if (Arguments.Length > 0)
                {
                    loadDirectory = Arguments[0];
                }

                string filepath = $"{Directory}\\{loadDirectory}";
                foreach (string entity in Entities)
                {
                    resultDetailsString.Append($"Loading entity type: {entity}\n");
                    string json = File.ReadAllText($"{filepath}\\{entity}.json");                    
                    Repository.Deserialize(entity, json);
                }
                resultDetailsString.Append("Loading complete!");
                result.StateChanged = true;
                result.ResultDetails = new TextContent(resultDetailsString.ToString());
            }
            catch (Exception e)
            {
                resultDetailsString.Append($"ERROR!\n{e.Message}");
            }
            return result;
        }

        private Result AddToRepository(ICommand Command, string Entity)
        {
            Result result = null;
            if (Command.Arguments.Count == 0)
            {
                result = ResultFactories.InformationalResult(Command, this, new TextContent($"ERROR: No information for new content provided."), new TextContent("Type in a command."));
            }
            else
            {
                try
                {
                    ITextContent addResult = Repository.Add(Entity, Command.Arguments.ToArray());
                    result = ResultFactories.StateChangedResult(Command, this, addResult, new TextContent("Type a command."));
                }
                catch(Exception e)
                {
                    result = ResultFactories.InformationalResult(Command, this, new TextContent(e.Message), new TextContent("Type a command."));
                }
            }


            return result;
        }

        private Result RemoveFromRepository(ICommand Command, string Entity)
        {
            Result result = null;
            if (Command.Arguments.Count == 0)
            {
                result = ResultFactories.InformationalResult(Command, this, new TextContent($"ERROR: No information for new content provided."), new TextContent("Type in a command."));
            }
            else
            {
                try
                {
                    ITextContent removeResult = Repository.Remove(Entity, Command.Arguments.ToArray());
                    result = ResultFactories.StateChangedResult(Command, this, removeResult, new TextContent("Type a command."));
                }
                catch (Exception e)
                {
                    result = ResultFactories.InformationalResult(Command, this, new TextContent(e.Message), new TextContent("Type a command."));
                }
            }

            return result;
        }
        
        public string Directory
        {
            get;set;
        }

        public string Entity
        {
            get; set;
        }

        public IList<string> Entities
        {
            get; set;
        }

        public IState ReturnState { get; set; }

        public IRepository Repository { get; set; }
    }
}
