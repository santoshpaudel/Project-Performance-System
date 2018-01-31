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

namespace MISUI.ServiceBudgetDonar {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="BudgetDonarServiceSoap", Namespace="http://tempuri.org/")]
    public partial class BudgetDonarService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private AuthSoapHd authSoapHdValueField;
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback PopulateDonarDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddDonarOperationCompleted;
        
        private System.Threading.SendOrPostCallback PopulateAllDonarsOperationCompleted;
        
        private System.Threading.SendOrPostCallback deleteDonarOperationCompleted;
        
        private System.Threading.SendOrPostCallback LockBudgetDonarOperationCompleted;
        
        private System.Threading.SendOrPostCallback UnlockBudgetDonarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BudgetDonarService() {
            this.Url = global::MISUI.Properties.Settings.Default.MISUI_ServiceBudgetDonar_BudgetDonarService;
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
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event PopulateDonarDetailsCompletedEventHandler PopulateDonarDetailsCompleted;
        
        /// <remarks/>
        public event AddDonarCompletedEventHandler AddDonarCompleted;
        
        /// <remarks/>
        public event PopulateAllDonarsCompletedEventHandler PopulateAllDonarsCompleted;
        
        /// <remarks/>
        public event deleteDonarCompletedEventHandler deleteDonarCompleted;
        
        /// <remarks/>
        public event LockBudgetDonarCompletedEventHandler LockBudgetDonarCompleted;
        
        /// <remarks/>
        public event UnlockBudgetDonarCompletedEventHandler UnlockBudgetDonarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PopulateDonarDetails", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable PopulateDonarDetails(int donarId) {
            object[] results = this.Invoke("PopulateDonarDetails", new object[] {
                        donarId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateDonarDetailsAsync(int donarId) {
            this.PopulateDonarDetailsAsync(donarId, null);
        }
        
        /// <remarks/>
        public void PopulateDonarDetailsAsync(int donarId, object userState) {
            if ((this.PopulateDonarDetailsOperationCompleted == null)) {
                this.PopulateDonarDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateDonarDetailsOperationCompleted);
            }
            this.InvokeAsync("PopulateDonarDetails", new object[] {
                        donarId}, this.PopulateDonarDetailsOperationCompleted, userState);
        }
        
        private void OnPopulateDonarDetailsOperationCompleted(object arg) {
            if ((this.PopulateDonarDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateDonarDetailsCompleted(this, new PopulateDonarDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddDonar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int AddDonar(ComBudgetDonar objComBudgetDonar, int donarId) {
            object[] results = this.Invoke("AddDonar", new object[] {
                        objComBudgetDonar,
                        donarId});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddDonarAsync(ComBudgetDonar objComBudgetDonar, int donarId) {
            this.AddDonarAsync(objComBudgetDonar, donarId, null);
        }
        
        /// <remarks/>
        public void AddDonarAsync(ComBudgetDonar objComBudgetDonar, int donarId, object userState) {
            if ((this.AddDonarOperationCompleted == null)) {
                this.AddDonarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddDonarOperationCompleted);
            }
            this.InvokeAsync("AddDonar", new object[] {
                        objComBudgetDonar,
                        donarId}, this.AddDonarOperationCompleted, userState);
        }
        
        private void OnAddDonarOperationCompleted(object arg) {
            if ((this.AddDonarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddDonarCompleted(this, new AddDonarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PopulateAllDonars", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable PopulateAllDonars(string lang) {
            object[] results = this.Invoke("PopulateAllDonars", new object[] {
                        lang});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void PopulateAllDonarsAsync(string lang) {
            this.PopulateAllDonarsAsync(lang, null);
        }
        
        /// <remarks/>
        public void PopulateAllDonarsAsync(string lang, object userState) {
            if ((this.PopulateAllDonarsOperationCompleted == null)) {
                this.PopulateAllDonarsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPopulateAllDonarsOperationCompleted);
            }
            this.InvokeAsync("PopulateAllDonars", new object[] {
                        lang}, this.PopulateAllDonarsOperationCompleted, userState);
        }
        
        private void OnPopulateAllDonarsOperationCompleted(object arg) {
            if ((this.PopulateAllDonarsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PopulateAllDonarsCompleted(this, new PopulateAllDonarsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/deleteDonar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void deleteDonar(int donarId) {
            this.Invoke("deleteDonar", new object[] {
                        donarId});
        }
        
        /// <remarks/>
        public void deleteDonarAsync(int donarId) {
            this.deleteDonarAsync(donarId, null);
        }
        
        /// <remarks/>
        public void deleteDonarAsync(int donarId, object userState) {
            if ((this.deleteDonarOperationCompleted == null)) {
                this.deleteDonarOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteDonarOperationCompleted);
            }
            this.InvokeAsync("deleteDonar", new object[] {
                        donarId}, this.deleteDonarOperationCompleted, userState);
        }
        
        private void OndeleteDonarOperationCompleted(object arg) {
            if ((this.deleteDonarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteDonarCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LockBudgetDonar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int LockBudgetDonar(int donarId) {
            object[] results = this.Invoke("LockBudgetDonar", new object[] {
                        donarId});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void LockBudgetDonarAsync(int donarId) {
            this.LockBudgetDonarAsync(donarId, null);
        }
        
        /// <remarks/>
        public void LockBudgetDonarAsync(int donarId, object userState) {
            if ((this.LockBudgetDonarOperationCompleted == null)) {
                this.LockBudgetDonarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLockBudgetDonarOperationCompleted);
            }
            this.InvokeAsync("LockBudgetDonar", new object[] {
                        donarId}, this.LockBudgetDonarOperationCompleted, userState);
        }
        
        private void OnLockBudgetDonarOperationCompleted(object arg) {
            if ((this.LockBudgetDonarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LockBudgetDonarCompleted(this, new LockBudgetDonarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthSoapHdValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UnlockBudgetDonar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UnlockBudgetDonar(int donarId) {
            object[] results = this.Invoke("UnlockBudgetDonar", new object[] {
                        donarId});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UnlockBudgetDonarAsync(int donarId) {
            this.UnlockBudgetDonarAsync(donarId, null);
        }
        
        /// <remarks/>
        public void UnlockBudgetDonarAsync(int donarId, object userState) {
            if ((this.UnlockBudgetDonarOperationCompleted == null)) {
                this.UnlockBudgetDonarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUnlockBudgetDonarOperationCompleted);
            }
            this.InvokeAsync("UnlockBudgetDonar", new object[] {
                        donarId}, this.UnlockBudgetDonarOperationCompleted, userState);
        }
        
        private void OnUnlockBudgetDonarOperationCompleted(object arg) {
            if ((this.UnlockBudgetDonarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UnlockBudgetDonarCompleted(this, new UnlockBudgetDonarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class ComBudgetDonar {
        
        private string donarEngNameField;
        
        private string donarNepNameField;
        
        private string donarCodeField;
        
        private int donarTypeField;
        
        private int isEnableField;
        
        private int isLockedField;
        
        /// <remarks/>
        public string DonarEngName {
            get {
                return this.donarEngNameField;
            }
            set {
                this.donarEngNameField = value;
            }
        }
        
        /// <remarks/>
        public string DonarNepName {
            get {
                return this.donarNepNameField;
            }
            set {
                this.donarNepNameField = value;
            }
        }
        
        /// <remarks/>
        public string DonarCode {
            get {
                return this.donarCodeField;
            }
            set {
                this.donarCodeField = value;
            }
        }
        
        /// <remarks/>
        public int DonarType {
            get {
                return this.donarTypeField;
            }
            set {
                this.donarTypeField = value;
            }
        }
        
        /// <remarks/>
        public int IsEnable {
            get {
                return this.isEnableField;
            }
            set {
                this.isEnableField = value;
            }
        }
        
        /// <remarks/>
        public int IsLocked {
            get {
                return this.isLockedField;
            }
            set {
                this.isLockedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void PopulateDonarDetailsCompletedEventHandler(object sender, PopulateDonarDetailsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateDonarDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateDonarDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void AddDonarCompletedEventHandler(object sender, AddDonarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddDonarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddDonarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void PopulateAllDonarsCompletedEventHandler(object sender, PopulateAllDonarsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PopulateAllDonarsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PopulateAllDonarsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void deleteDonarCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void LockBudgetDonarCompletedEventHandler(object sender, LockBudgetDonarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LockBudgetDonarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LockBudgetDonarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void UnlockBudgetDonarCompletedEventHandler(object sender, UnlockBudgetDonarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UnlockBudgetDonarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UnlockBudgetDonarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591