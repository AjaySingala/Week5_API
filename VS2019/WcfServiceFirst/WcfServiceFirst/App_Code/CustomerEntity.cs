using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for CustomerEntity
/// </summary>
[DataContract]
public class CustomerEntity
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Firstname { get; set; }
    [DataMember]
    public string Lastname { get; set; }
    public DateTime DOB { get; set; }
}