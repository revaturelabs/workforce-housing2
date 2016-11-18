﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workforce.Logic.Rest.HousingReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HousingReference.IGraceService")]
    public interface IGraceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetComplexes", ReplyAction="http://tempuri.org/IGraceService/GetComplexesResponse")]
        Workforce.Logic.Domain.HousingReference.HousingComplexDao[] GetComplexes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetComplexes", ReplyAction="http://tempuri.org/IGraceService/GetComplexesResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.HousingComplexDao[]> GetComplexesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetApartments", ReplyAction="http://tempuri.org/IGraceService/GetApartmentsResponse")]
        Workforce.Logic.Domain.HousingReference.ApartmentDao[] GetApartments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetApartments", ReplyAction="http://tempuri.org/IGraceService/GetApartmentsResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.ApartmentDao[]> GetApartmentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetHousingData", ReplyAction="http://tempuri.org/IGraceService/GetHousingDataResponse")]
        Workforce.Logic.Domain.HousingReference.HousingDataDao[] GetHousingData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetHousingData", ReplyAction="http://tempuri.org/IGraceService/GetHousingDataResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.HousingDataDao[]> GetHousingDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetStatuses", ReplyAction="http://tempuri.org/IGraceService/GetStatusesResponse")]
        Workforce.Logic.Domain.HousingReference.StatusDao[] GetStatuses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/GetStatuses", ReplyAction="http://tempuri.org/IGraceService/GetStatusesResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.StatusDao[]> GetStatusesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertApartment", ReplyAction="http://tempuri.org/IGraceService/InsertApartmentResponse")]
        bool InsertApartment(Workforce.Logic.Domain.HousingReference.ApartmentDao newapt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertApartment", ReplyAction="http://tempuri.org/IGraceService/InsertApartmentResponse")]
        System.Threading.Tasks.Task<bool> InsertApartmentAsync(Workforce.Logic.Domain.HousingReference.ApartmentDao newapt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingData", ReplyAction="http://tempuri.org/IGraceService/InsertHousingDataResponse")]
        bool InsertHousingData(Workforce.Logic.Domain.HousingReference.HousingDataDao newhdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingData", ReplyAction="http://tempuri.org/IGraceService/InsertHousingDataResponse")]
        System.Threading.Tasks.Task<bool> InsertHousingDataAsync(Workforce.Logic.Domain.HousingReference.HousingDataDao newhdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingComplex", ReplyAction="http://tempuri.org/IGraceService/InsertHousingComplexResponse")]
        bool InsertHousingComplex(Workforce.Logic.Domain.HousingReference.HousingComplexDao newhcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertHousingComplex", ReplyAction="http://tempuri.org/IGraceService/InsertHousingComplexResponse")]
        System.Threading.Tasks.Task<bool> InsertHousingComplexAsync(Workforce.Logic.Domain.HousingReference.HousingComplexDao newhcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertStatus", ReplyAction="http://tempuri.org/IGraceService/InsertStatusResponse")]
        bool InsertStatus(Workforce.Logic.Domain.HousingReference.StatusDao newstatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/InsertStatus", ReplyAction="http://tempuri.org/IGraceService/InsertStatusResponse")]
        System.Threading.Tasks.Task<bool> InsertStatusAsync(Workforce.Logic.Domain.HousingReference.StatusDao newstatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateApartment", ReplyAction="http://tempuri.org/IGraceService/UpdateApartmentResponse")]
        bool UpdateApartment(Workforce.Logic.Domain.HousingReference.ApartmentDao apt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateApartment", ReplyAction="http://tempuri.org/IGraceService/UpdateApartmentResponse")]
        System.Threading.Tasks.Task<bool> UpdateApartmentAsync(Workforce.Logic.Domain.HousingReference.ApartmentDao apt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateHousingData", ReplyAction="http://tempuri.org/IGraceService/UpdateHousingDataResponse")]
        bool UpdateHousingData(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateHousingData", ReplyAction="http://tempuri.org/IGraceService/UpdateHousingDataResponse")]
        System.Threading.Tasks.Task<bool> UpdateHousingDataAsync(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateHousingComplex", ReplyAction="http://tempuri.org/IGraceService/UpdateHousingComplexResponse")]
        bool UpdateHousingComplex(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateHousingComplex", ReplyAction="http://tempuri.org/IGraceService/UpdateHousingComplexResponse")]
        System.Threading.Tasks.Task<bool> UpdateHousingComplexAsync(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateStatus", ReplyAction="http://tempuri.org/IGraceService/UpdateStatusResponse")]
        bool UpdateStatus(Workforce.Logic.Domain.HousingReference.StatusDao status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/UpdateStatus", ReplyAction="http://tempuri.org/IGraceService/UpdateStatusResponse")]
        System.Threading.Tasks.Task<bool> UpdateStatusAsync(Workforce.Logic.Domain.HousingReference.StatusDao status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteApartment", ReplyAction="http://tempuri.org/IGraceService/DeleteApartmentResponse")]
        bool DeleteApartment(Workforce.Logic.Domain.HousingReference.ApartmentDao apt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteApartment", ReplyAction="http://tempuri.org/IGraceService/DeleteApartmentResponse")]
        System.Threading.Tasks.Task<bool> DeleteApartmentAsync(Workforce.Logic.Domain.HousingReference.ApartmentDao apt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingData", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingDataResponse")]
        bool DeleteHousingData(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingData", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingDataResponse")]
        System.Threading.Tasks.Task<bool> DeleteHousingDataAsync(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingComplex", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingComplexResponse")]
        bool DeleteHousingComplex(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteHousingComplex", ReplyAction="http://tempuri.org/IGraceService/DeleteHousingComplexResponse")]
        System.Threading.Tasks.Task<bool> DeleteHousingComplexAsync(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteStatus", ReplyAction="http://tempuri.org/IGraceService/DeleteStatusResponse")]
        bool DeleteStatus(Workforce.Logic.Domain.HousingReference.StatusDao status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGraceService/DeleteStatus", ReplyAction="http://tempuri.org/IGraceService/DeleteStatusResponse")]
        System.Threading.Tasks.Task<bool> DeleteStatusAsync(Workforce.Logic.Domain.HousingReference.StatusDao status);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGraceServiceChannel : Workforce.Logic.Rest.HousingReference.IGraceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GraceServiceClient : System.ServiceModel.ClientBase<Workforce.Logic.Rest.HousingReference.IGraceService>, Workforce.Logic.Rest.HousingReference.IGraceService {
        
        public GraceServiceClient() {
        }
        
        public GraceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GraceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GraceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GraceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Workforce.Logic.Domain.HousingReference.HousingComplexDao[] GetComplexes() {
            return base.Channel.GetComplexes();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.HousingComplexDao[]> GetComplexesAsync() {
            return base.Channel.GetComplexesAsync();
        }
        
        public Workforce.Logic.Domain.HousingReference.ApartmentDao[] GetApartments() {
            return base.Channel.GetApartments();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.ApartmentDao[]> GetApartmentsAsync() {
            return base.Channel.GetApartmentsAsync();
        }
        
        public Workforce.Logic.Domain.HousingReference.HousingDataDao[] GetHousingData() {
            return base.Channel.GetHousingData();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.HousingDataDao[]> GetHousingDataAsync() {
            return base.Channel.GetHousingDataAsync();
        }
        
        public Workforce.Logic.Domain.HousingReference.StatusDao[] GetStatuses() {
            return base.Channel.GetStatuses();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Domain.HousingReference.StatusDao[]> GetStatusesAsync() {
            return base.Channel.GetStatusesAsync();
        }
        
        public bool InsertApartment(Workforce.Logic.Domain.HousingReference.ApartmentDao newapt) {
            return base.Channel.InsertApartment(newapt);
        }
        
        public System.Threading.Tasks.Task<bool> InsertApartmentAsync(Workforce.Logic.Domain.HousingReference.ApartmentDao newapt) {
            return base.Channel.InsertApartmentAsync(newapt);
        }
        
        public bool InsertHousingData(Workforce.Logic.Domain.HousingReference.HousingDataDao newhdata) {
            return base.Channel.InsertHousingData(newhdata);
        }
        
        public System.Threading.Tasks.Task<bool> InsertHousingDataAsync(Workforce.Logic.Domain.HousingReference.HousingDataDao newhdata) {
            return base.Channel.InsertHousingDataAsync(newhdata);
        }
        
        public bool InsertHousingComplex(Workforce.Logic.Domain.HousingReference.HousingComplexDao newhcomplex) {
            return base.Channel.InsertHousingComplex(newhcomplex);
        }
        
        public System.Threading.Tasks.Task<bool> InsertHousingComplexAsync(Workforce.Logic.Domain.HousingReference.HousingComplexDao newhcomplex) {
            return base.Channel.InsertHousingComplexAsync(newhcomplex);
        }
        
        public bool InsertStatus(Workforce.Logic.Domain.HousingReference.StatusDao newstatus) {
            return base.Channel.InsertStatus(newstatus);
        }
        
        public System.Threading.Tasks.Task<bool> InsertStatusAsync(Workforce.Logic.Domain.HousingReference.StatusDao newstatus) {
            return base.Channel.InsertStatusAsync(newstatus);
        }
        
        public bool UpdateApartment(Workforce.Logic.Domain.HousingReference.ApartmentDao apt) {
            return base.Channel.UpdateApartment(apt);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateApartmentAsync(Workforce.Logic.Domain.HousingReference.ApartmentDao apt) {
            return base.Channel.UpdateApartmentAsync(apt);
        }
        
        public bool UpdateHousingData(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata) {
            return base.Channel.UpdateHousingData(hdata);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateHousingDataAsync(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata) {
            return base.Channel.UpdateHousingDataAsync(hdata);
        }
        
        public bool UpdateHousingComplex(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex) {
            return base.Channel.UpdateHousingComplex(hcomplex);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateHousingComplexAsync(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex) {
            return base.Channel.UpdateHousingComplexAsync(hcomplex);
        }
        
        public bool UpdateStatus(Workforce.Logic.Domain.HousingReference.StatusDao status) {
            return base.Channel.UpdateStatus(status);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateStatusAsync(Workforce.Logic.Domain.HousingReference.StatusDao status) {
            return base.Channel.UpdateStatusAsync(status);
        }
        
        public bool DeleteApartment(Workforce.Logic.Domain.HousingReference.ApartmentDao apt) {
            return base.Channel.DeleteApartment(apt);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteApartmentAsync(Workforce.Logic.Domain.HousingReference.ApartmentDao apt) {
            return base.Channel.DeleteApartmentAsync(apt);
        }
        
        public bool DeleteHousingData(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata) {
            return base.Channel.DeleteHousingData(hdata);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteHousingDataAsync(Workforce.Logic.Domain.HousingReference.HousingDataDao hdata) {
            return base.Channel.DeleteHousingDataAsync(hdata);
        }
        
        public bool DeleteHousingComplex(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex) {
            return base.Channel.DeleteHousingComplex(hcomplex);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteHousingComplexAsync(Workforce.Logic.Domain.HousingReference.HousingComplexDao hcomplex) {
            return base.Channel.DeleteHousingComplexAsync(hcomplex);
        }
        
        public bool DeleteStatus(Workforce.Logic.Domain.HousingReference.StatusDao status) {
            return base.Channel.DeleteStatus(status);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteStatusAsync(Workforce.Logic.Domain.HousingReference.StatusDao status) {
            return base.Channel.DeleteStatusAsync(status);
        }
    }
}
