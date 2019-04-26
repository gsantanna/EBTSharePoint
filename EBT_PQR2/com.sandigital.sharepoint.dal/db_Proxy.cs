using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Reflection;
using System.Data.Linq.Mapping;

namespace com.sandigital.sharepoint.dal
{


    public class EventoRedeDataContext : _EventoRedeDataContext
    {
        public EventoRedeDataContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["EVENTOS"].ConnectionString)
        {}


        //AJUSTE STORED PROCEDURE       
        public  ISingleResult<RelatorioEventoDetalhe> EVT_ConsultaRelatorioEventoDetalheExp([Parameter(DbType = "VarChar(100)")] string usuario, [Parameter(DbType = "Int")] System.Nullable<int> id_comunidade, [Parameter(Name = "Filtro", DbType = "VarChar(100)")] string filtro)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), usuario, id_comunidade, filtro);
            return ((ISingleResult<RelatorioEventoDetalhe>)(result.ReturnValue));
        }
		
    }

    public class GirGrdDataContext : _GirGrdDataContext
    {
        public GirGrdDataContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GIR"].ConnectionString)
        {}
    }

    public class EmbratelDataContext : _EmbratelDataContext
    {
         public EmbratelDataContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["EMBRATEL"].ConnectionString)
        {}
    }






    
    



}
