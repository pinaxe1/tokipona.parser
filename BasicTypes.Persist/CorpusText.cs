//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicTypes.Persist
{
    using System;
    using System.Collections.Generic;
    
    public partial class CorpusText
    {
        public System.Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public string SnippetText { get; set; }
        public string ShortUrl { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}