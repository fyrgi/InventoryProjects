using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryProjects.Common
{
    public interface IMenuOption
    {
        string Text { get; }
        Action Action { get; }
    }

    public class MenuOption : IMenuOption
    {
        public string Text { get; }
        public Action Action { get; }

        public MenuOption(string text, Action action)
        {
            Text = text;
            Action = action;
        }
    }
}
