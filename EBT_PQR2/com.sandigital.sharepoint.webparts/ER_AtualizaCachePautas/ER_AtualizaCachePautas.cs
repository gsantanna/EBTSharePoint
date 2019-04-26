using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using com.sandigital.sharepoint.webparts.Modelos;

namespace com.sandigital.sharepoint.webparts.ER_AtualizaCachePautas
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_AtualizaCachePautas : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            

            base.ItemAdded(properties);
            AtualizaCachePautas(properties);
        }

        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            AtualizaCachePautas(properties);
        }

        /// <summary>
        /// An item was deleted.
        /// </summary>
        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);
            AtualizaCachePautas(properties);
        }

        /// <summary>
        /// An attachment was added to the item.
        /// </summary>
        public override void ItemAttachmentAdded(SPItemEventProperties properties)
        {
            base.ItemAttachmentAdded(properties);
            AtualizaCachePautas(properties);
        }

        /// <summary>
        /// An attachment was removed from the item.
        /// </summary>
        public override void ItemAttachmentDeleted(SPItemEventProperties properties)
        {
            base.ItemAttachmentDeleted(properties);
            AtualizaCachePautas(properties);
        }

        public object _lock = new object();

        public void AtualizaCachePautas(SPItemEventProperties properties)
        {
            if (properties.List.Title == "Pautas" || properties.List.Title == "Tarefas Da Pauta")
            {
                lock (_lock)
                {
                    //SPContext.Current.Site.Cache["Pautas"] = Pauta.Pautas();
                    properties.List.ParentWeb.Site.Cache["Pautas"] = "RELOAD";

                }
            }
           
        }



    }
}