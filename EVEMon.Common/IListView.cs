using System;
using System.Collections.Generic;
using EVEMon.Common.SettingsObjects;

namespace EVEMon.Common
{
    public interface IListView
    {
        /// <summary> 
        /// Gets or sets the grouping of a listview. 
        /// </summary> 
        Enum Grouping { get; set; }

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>The columns.</value>
        IEnumerable<IColumnSettings> Columns { get; set; }

        /// <summary>
        /// Updates the columns.
        /// </summary>
        void UpdateColumns();
    }
}