// This file is auto-generated, do not modify this file.
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace Wicresoft.WFH.Data
{
    public class FakeWorkFromHomeEntities : FakeWorkFromHomeEntitiesBase
    {
            #region Function Imports
        

            #endregion

    
        public override int SaveChanges()
        {
            return 0;
        }
    
        public override Task<int> SaveChangesAsync()
        {
            return Task.Run(()=>{ return 0;});
        }
        
        public override void DiscardChanges()
        {
        }
        
        public virtual IEnumerable<T> ExecuteFunction<T>(string functionName, params object[] parameters)
        {
            if (OnExecuteFunction != null) OnExecuteFunction(functionName, parameters);
            return Enumerable.Empty<T>();
        }
        
        public virtual int ExecuteFunction(string functionName, params object[] parameters)
        {
            if (OnExecuteFunction != null) OnExecuteFunction(functionName, parameters);
            return 0;
        }
        
        public Action<string, object[]> OnExecuteFunction;
    }
}


