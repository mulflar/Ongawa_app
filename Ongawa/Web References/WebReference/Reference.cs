﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Ongawa.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="encuestaSoap", Namespace="http://tempuri.org/")]
    public partial class encuesta : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback insertuserOperationCompleted;
        
        private System.Threading.SendOrPostCallback comprobaruserOperationCompleted;
        
        private System.Threading.SendOrPostCallback insertregOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public encuesta() {
            this.Url = "http://40.85.130.141/encuesta.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
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
        public event insertuserCompletedEventHandler insertuserCompleted;
        
        /// <remarks/>
        public event comprobaruserCompletedEventHandler comprobaruserCompleted;
        
        /// <remarks/>
        public event insertregCompletedEventHandler insertregCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/insertuser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void insertuser(string usuario, string contraseña, string email, int telefono, string zona) {
            this.Invoke("insertuser", new object[] {
                        usuario,
                        contraseña,
                        email,
                        telefono,
                        zona});
        }
        
        /// <remarks/>
        public void insertuserAsync(string usuario, string contraseña, string email, int telefono, string zona) {
            this.insertuserAsync(usuario, contraseña, email, telefono, zona, null);
        }
        
        /// <remarks/>
        public void insertuserAsync(string usuario, string contraseña, string email, int telefono, string zona, object userState) {
            if ((this.insertuserOperationCompleted == null)) {
                this.insertuserOperationCompleted = new System.Threading.SendOrPostCallback(this.OninsertuserOperationCompleted);
            }
            this.InvokeAsync("insertuser", new object[] {
                        usuario,
                        contraseña,
                        email,
                        telefono,
                        zona}, this.insertuserOperationCompleted, userState);
        }
        
        private void OninsertuserOperationCompleted(object arg) {
            if ((this.insertuserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insertuserCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/comprobaruser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int comprobaruser(string usuario, string pass, string zona) {
            object[] results = this.Invoke("comprobaruser", new object[] {
                        usuario,
                        pass,
                        zona});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void comprobaruserAsync(string usuario, string pass, string zona) {
            this.comprobaruserAsync(usuario, pass, zona, null);
        }
        
        /// <remarks/>
        public void comprobaruserAsync(string usuario, string pass, string zona, object userState) {
            if ((this.comprobaruserOperationCompleted == null)) {
                this.comprobaruserOperationCompleted = new System.Threading.SendOrPostCallback(this.OncomprobaruserOperationCompleted);
            }
            this.InvokeAsync("comprobaruser", new object[] {
                        usuario,
                        pass,
                        zona}, this.comprobaruserOperationCompleted, userState);
        }
        
        private void OncomprobaruserOperationCompleted(object arg) {
            if ((this.comprobaruserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.comprobaruserCompleted(this, new comprobaruserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/insertreg", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void insertreg(string encuesta_r, string zona) {
            this.Invoke("insertreg", new object[] {
                        encuesta_r,
                        zona});
        }
        
        /// <remarks/>
        public void insertregAsync(string encuesta_r, string zona) {
            this.insertregAsync(encuesta_r, zona, null);
        }
        
        /// <remarks/>
        public void insertregAsync(string encuesta_r, string zona, object userState) {
            if ((this.insertregOperationCompleted == null)) {
                this.insertregOperationCompleted = new System.Threading.SendOrPostCallback(this.OninsertregOperationCompleted);
            }
            this.InvokeAsync("insertreg", new object[] {
                        encuesta_r,
                        zona}, this.insertregOperationCompleted, userState);
        }
        
        private void OninsertregOperationCompleted(object arg) {
            if ((this.insertregCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insertregCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void insertuserCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void comprobaruserCompletedEventHandler(object sender, comprobaruserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class comprobaruserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal comprobaruserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void insertregCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591