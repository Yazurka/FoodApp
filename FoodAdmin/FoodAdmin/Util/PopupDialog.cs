using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace FoodAdmin.Util
{
    [Export]
    public class PopupDialog
    {
        public IDialogCoordinator Dialog => DialogCoordinator.Instance;
    }
}
