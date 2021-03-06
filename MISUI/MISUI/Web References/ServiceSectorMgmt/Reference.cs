﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace MISUI.ServiceSectorMgmt {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SectorServiceSoap", Namespace="http://tempuri.org/")]
    public partial class SectorService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private AuthSoapHd authSoapHdValueField;
        
        private System.Threading.SendOrPostCallback PopulateAllSubSectorsOperationCompleted;
        
        private System.Threading.SendOrPostCallback PopulateAllSectorsOperationCompleted;
        
        private System.Threading.SendOrPostCallback PopulateSubSectorByIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddSubSectorOperationCompleted;
        
        private System.Threading.SendOrPostCallback PopulateSubSectorsBySectorIdOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SectorService() {
            this.Url = global::MISUI.Properties.Settings.Default.MISUI_ServiceSectorMgmt_SectorService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public AuthSoapHd AuthSoapHdValue {
            get {
                return this.authSoapHdValueField;
            }
            set {
                this.authSoapHdValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event PopulateAllSubSectorsCompletedEventHandler PopulateAllSubSectorsCompleted;
        
        /// <remarks/>
        public event PopulateAllSectorsCompletedEventHandler PopulateAllSectorsCompleted;
        
        /// <remarks/>
        public event PopulateSubSectorByIdCompletedEventHandler PopulateSubSectorByIdCompleted;
        
        /// <remarks/>
        public event AddSubSectorCompletedEventHandler AddSubSectorCompleted;
        
        /// <remarks/>
        public event PopulateSubSectorsBySectorIdCompletedEventHandler PopulateSubSectorsBySectorIdCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PopulateAllSubSectors", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable PopulateAllSubSectors(ComSubSector objComSubSector) {
            object[] results = this.Invoke("PopulateAllSubSectors", new object[] {
                        objComSubSector});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateAllSubSectorsAsync(ComSubSector objComSubSector) {
            this.PopulateAllSubSectorsAsync(objComSubSector, null);
        }
        
        /// <remarks/>
        public void PopulateAllSubSectorsAsync(ComSubSector objComSubSector, object userState) {
            if ((this.PopulateAllSubSectorsOperationCompleted == null)) {
                this.PopulateAllSubSectorsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateAllSubSectorsOperationCompleted);
            }
            this.InvokeAsync("PopulateAllSubSectors", new object[] {
                        objComSubSector}, this.PopulateAllSubSectorsOperationCompleted, userState);
        }
        
        private void OnPopulateAllSubSectorsOperationCompleted(object arg) {
            if ((this.PopulateAllSubSectorsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateAllSubSectorsCompleted(this, new PopulateAllSubSectorsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PopulateAllSectors", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable PopulateAllSectors(ComSubSector objComSubSector) {
            object[] results = this.Invoke("PopulateAllSectors", new object[] {
                        objComSubSector});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateAllSectorsAsync(ComSubSector objComSubSector) {
            this.PopulateAllSectorsAsync(objComSubSector, null);
        }
        
        /// <remarks/>
        public void PopulateAllSectorsAsync(ComSubSector objComSubSector, object userState) {
            if ((this.PopulateAllSectorsOperationCompleted == null)) {
                this.PopulateAllSectorsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateAllSectorsOperationCompleted);
            }
            this.InvokeAsync("PopulateAllSectors", new object[] {
                        objComSubSector}, this.PopulateAllSectorsOperationCompleted, userState);
        }
        
        private void OnPopulateAllSectorsOperationCompleted(object arg) {
            if ((this.PopulateAllSectorsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateAllSectorsCompleted(this, new PopulateAllSectorsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PopulateSubSectorById", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable PopulateSubSectorById(ComSubSector objComSubSector) {
            object[] results = this.Invoke("PopulateSubSectorById", new object[] {
                        objComSubSector});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateSubSectorByIdAsync(ComSubSector objComSubSector) {
            this.PopulateSubSectorByIdAsync(objComSubSector, null);
        }
        
        /// <remarks/>
        public void PopulateSubSectorByIdAsync(ComSubSector objComSubSector, object userState) {
            if ((this.PopulateSubSectorByIdOperationCompleted == null)) {
                this.PopulateSubSectorByIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateSubSectorByIdOperationCompleted);
            }
            this.InvokeAsync("PopulateSubSectorById", new object[] {
                        objComSubSector}, this.PopulateSubSectorByIdOperationCompleted, userState);
        }
        
        private void OnPopulateSubSectorByIdOperationCompleted(object arg) {
            if ((this.PopulateSubSectorByIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateSubSectorByIdCompleted(this, new PopulateSubSectorByIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddSubSector", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int AddSubSector(ComSubSector objComSubSector) {
            object[] results = this.Invoke("AddSubSector", new object[] {
                        objComSubSector});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddSubSectorAsync(ComSubSector objComSubSector) {
            this.AddSubSectorAsync(objComSubSector, null);
        }
        
        /// <remarks/>
        public void AddSubSectorAsync(ComSubSector objComSubSector, object userState) {
            if ((this.AddSubSectorOperationCompleted == null)) {
                this.AddSubSectorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddSubSectorOperationCompleted);
            }
            this.InvokeAsync("AddSubSector", new object[] {
                        objComSubSector}, this.AddSubSectorOperationCompleted, userState);
        }
        
        private void OnAddSubSectorOperationCompleted(object arg) {
            if ((this.AddSubSectorCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddSubSectorCompleted(this, new AddSubSectorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PopulateSubSectorsBySectorId", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable PopulateSubSectorsBySectorId(ComSubSector objComSubSector) {
            object[] results = this.Invoke("PopulateSubSectorsBySectorId", new object[] {
                        objComSubSector});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateSubSectorsBySectorIdAsync(ComSubSector objComSubSector) {
            this.PopulateSubSectorsBySectorIdAsync(objComSubSector, null);
        }
        
        /// <remarks/>
        public void PopulateSubSectorsBySectorIdAsync(ComSubSector objComSubSector, object userState) {
            if ((this.PopulateSubSectorsBySectorIdOperationCompleted == null)) {
                this.PopulateSubSectorsBySectorIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateSubSectorsBySectorIdOperationCompleted);
            }
            this.InvokeAsync("PopulateSubSectorsBySectorId", new object[] {
                        objComSubSector}, this.PopulateSubSectorsBySectorIdOperationCompleted, userState);
        }
        
        private void OnPopulateSubSectorsBySectorIdOperationCompleted(object arg) {
            if ((this.PopulateSubSectorsBySectorIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateSubSectorsBySectorIdCompleted(this, new PopulateSubSectorsBySectorIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class AuthSoapHd : System.Web.Services.Protocols.SoapHeader {
        
        private string strUserNameField;
        
        private string strPasswordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string strUserName {
            get {
                return this.strUserNameField;
            }
            set {
                this.strUserNameField = value;
            }
        }
        
        /// <remarks/>
        public string strPassword {
            get {
                return this.strPasswordField;
            }
            set {
                this.strPasswordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ComSubSector {
        
        private decimal subSectorIdField;
        
        private string subSectorEngNameField;
        
        private string subSectorNepNameField;
        
        private string subSectorCodeField;
        
        private decimal sectorIdField;
        
        private decimal isenableField;
        
        private decimal islockedField;
        
        private string modeField;
        
        private string langField;
        
        /// <remarks/>
        public decimal SubSectorId {
            get {
                return this.subSectorIdField;
            }
            set {
                this.subSectorIdField = value;
            }
        }
        
        /// <remarks/>
        public string SubSectorEngName {
            get {
                return this.subSectorEngNameField;
            }
            set {
                this.subSectorEngNameField = value;
            }
        }
        
        /// <remarks/>
        public string SubSectorNepName {
            get {
                return this.subSectorNepNameField;
            }
            set {
                this.subSectorNepNameField = value;
            }
        }
        
        /// <remarks/>
        public string SubSectorCode {
            get {
                return this.subSectorCodeField;
            }
            set {
                this.subSectorCodeField = value;
            }
        }
        
        /// <remarks/>
        public decimal SectorId {
            get {
                return this.sectorIdField;
            }
            set {
                this.sectorIdField = value;
            }
        }
        
        /// <remarks/>
        public decimal Isenable {
            get {
                return this.isenableField;
            }
            set {
                this.isenableField = value;
            }
        }
        
        /// <remarks/>
        public decimal Islocked {
            get {
                return this.islockedField;
            }
            set {
                this.islockedField = value;
            }
        }
        
        /// <remarks/>
        public string Mode {
            get {
                return this.modeField;
            }
            set {
                this.modeField = value;
            }
        }
        
        /// <remarks/>
        public string Lang {
            get {
                return this.langField;
            }
            set {
                this.langField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void PopulateAllSubSectorsCompletedEventHandler(object sender, PopulateAllSubSectorsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateAllSubSectorsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateAllSubSectorsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void PopulateAllSectorsCompletedEventHandler(object sender, PopulateAllSectorsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateAllSectorsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateAllSectorsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void PopulateSubSectorByIdCompletedEventHandler(object sender, PopulateSubSectorByIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateSubSectorByIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateSubSectorByIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void AddSubSectorCompletedEventHandler(object sender, AddSubSectorCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddSubSectorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddSubSectorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void PopulateSubSectorsBySectorIdCompletedEventHandler(object sender, PopulateSubSectorsBySectorIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateSubSectorsBySectorIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateSubSectorsBySectorIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591