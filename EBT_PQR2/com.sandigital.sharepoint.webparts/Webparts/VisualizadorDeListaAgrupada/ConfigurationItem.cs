using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Webparts.VisualizadorDeListaAgrupada
{
    [Serializable]
    public class ConfigurationItem
    {
        public Guid Lista { get; set; }

        public List<ConfigurationItemColumn> Columns { get; set; }
        public List<ConfigurationItemColumn> GroupedColumns
        {
            get
            {
                return this.Columns.Where(f => f.Grouped).OrderBy(f=>f.Order).ToList();
            }
        }

        public List<ConfigurationItemColumn> VisibleColumns
        {
            get
            {
                return this.Columns.Where(f => f.Visible).OrderBy(f=> f.Order).ToList();
            }
        }

        [Serializable]
        public class ConfigurationItemColumn
        {
            public string InternalName { get; set; }
            public string DisplayName { get; set; }
            public string StaticName { get; set; }
            public string Order { get; set; }
            public bool Grouped { get; set; }
            public string Id { get; set; }
            public bool Visible { get; set; }
        }

    }


}

