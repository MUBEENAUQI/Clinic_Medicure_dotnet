﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinic_Automation.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MedicareEntities : DbContext
    {
        public MedicareEntities()
            : base("name=MedicareEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int Add_Doctor(string name, string speciality, Nullable<int> experience, string phone, string email, string qualification, Nullable<int> fees, string gender, string username, string password)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var specialityParameter = speciality != null ?
                new ObjectParameter("speciality", speciality) :
                new ObjectParameter("speciality", typeof(string));
    
            var experienceParameter = experience.HasValue ?
                new ObjectParameter("experience", experience) :
                new ObjectParameter("experience", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var qualificationParameter = qualification != null ?
                new ObjectParameter("qualification", qualification) :
                new ObjectParameter("qualification", typeof(string));
    
            var feesParameter = fees.HasValue ?
                new ObjectParameter("fees", fees) :
                new ObjectParameter("fees", typeof(int));
    
            var genderParameter = gender != null ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_Doctor", nameParameter, specialityParameter, experienceParameter, phoneParameter, emailParameter, qualificationParameter, feesParameter, genderParameter, usernameParameter, passwordParameter);
        }
    
        public virtual int Add_LoginData(string username, string password, Nullable<int> accountid)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var accountidParameter = accountid.HasValue ?
                new ObjectParameter("accountid", accountid) :
                new ObjectParameter("accountid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_LoginData", usernameParameter, passwordParameter, accountidParameter);
        }
    
        public virtual int DeleteDoctor(Nullable<int> doctorID)
        {
            var doctorIDParameter = doctorID.HasValue ?
                new ObjectParameter("DoctorID", doctorID) :
                new ObjectParameter("DoctorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteDoctor", doctorIDParameter);
        }
    
        public virtual ObjectResult<Get_Account_Type_Result> Get_Account_Type()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_Account_Type_Result>("Get_Account_Type");
        }
    
        public virtual ObjectResult<Get_DoctorData_Result> Get_DoctorData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_DoctorData_Result>("Get_DoctorData");
        }
    
        public virtual ObjectResult<Get_DoctorData_byID_Result> Get_DoctorData_byID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_DoctorData_byID_Result>("Get_DoctorData_byID", idParameter);
        }
    
        public virtual ObjectResult<Login_Check_Result> Login_Check(string username, string password, Nullable<int> accid)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var accidParameter = accid.HasValue ?
                new ObjectParameter("accid", accid) :
                new ObjectParameter("accid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Login_Check_Result>("Login_Check", usernameParameter, passwordParameter, accidParameter);
        }
    
        public virtual int Update_DoctorData(string name, string speciality, Nullable<int> experience, string phone, string email, string qualification, Nullable<int> fees, string gender, string username, string password, Nullable<int> loginid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var specialityParameter = speciality != null ?
                new ObjectParameter("speciality", speciality) :
                new ObjectParameter("speciality", typeof(string));
    
            var experienceParameter = experience.HasValue ?
                new ObjectParameter("experience", experience) :
                new ObjectParameter("experience", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var qualificationParameter = qualification != null ?
                new ObjectParameter("qualification", qualification) :
                new ObjectParameter("qualification", typeof(string));
    
            var feesParameter = fees.HasValue ?
                new ObjectParameter("fees", fees) :
                new ObjectParameter("fees", typeof(int));
    
            var genderParameter = gender != null ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var loginidParameter = loginid.HasValue ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_DoctorData", nameParameter, specialityParameter, experienceParameter, phoneParameter, emailParameter, qualificationParameter, feesParameter, genderParameter, usernameParameter, passwordParameter, loginidParameter);
        }
    }
}
