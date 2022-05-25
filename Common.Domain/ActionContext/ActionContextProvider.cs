using System;
using System.Collections.Generic;
using Common.Domain.User.ValueObjects;

namespace Common.Domain.ActionContext
{
    public class ActionContextProvider: IActionContextProvider
    {
        public ActionContext ActionContext { get; private set; }
        public UserId UserId => ActionContext?.UserId;
        
        public void RegisterContext(ActionContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException(nameof(actionContext));
            ActionContext = actionContext;
        }
    }
}
