using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace Entities
{
    /// <summary>
    /// Represents a row of entity data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Setting : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Value")]
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Last Change Date")]
        public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Web Site Name")]
        public string WebSiteName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Web Site Url")]
        public string WebSiteUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Page Title")]
        public string PageTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Admin Email Address")]
        public string AdminEmailAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("SMTP")]
        public string SMTP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("SMTPUsername")]
        public string SMTPUsername { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("SMTPPassword")]
        public string SMTPPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("SMTPPort")]
        public string SMTPPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("SMTPEnable SSL")]
        public bool? SMTPEnableSSL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Theme")]
        public string Theme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Default Language Id")]
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created By")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed On")]
        public DateTime ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed By")]
        public int? ChangedBy { get; set; }


    }
}