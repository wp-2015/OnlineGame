//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: message.proto
namespace message
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"msgcharinfo")]
  public partial class msgcharinfo : global::ProtoBuf.IExtensible
  {
    public msgcharinfo() {}
    

    private uint _uaid = default(uint);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"uaid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint uaid
    {
      get { return _uaid; }
      set { _uaid = value; }
    }

    private uint _charid = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"charid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint charid
    {
      get { return _charid; }
      set { _charid = value; }
    }

    private uint _kind = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"kind", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint kind
    {
      get { return _kind; }
      set { _kind = value; }
    }

    private string _name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    private string _head = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"head", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string head
    {
      get { return _head; }
      set { _head = value; }
    }

    private uint _level = default(uint);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint level
    {
      get { return _level; }
      set { _level = value; }
    }

    private uint _exp = default(uint);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint exp
    {
      get { return _exp; }
      set { _exp = value; }
    }

    private uint _phypower = default(uint);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"phypower", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint phypower
    {
      get { return _phypower; }
      set { _phypower = value; }
    }

    private uint _leadership = default(uint);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"leadership", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint leadership
    {
      get { return _leadership; }
      set { _leadership = value; }
    }

    private uint _friendnum = default(uint);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"friendnum", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint friendnum
    {
      get { return _friendnum; }
      set { _friendnum = value; }
    }

    private uint _gamecoin = default(uint);
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"gamecoin", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint gamecoin
    {
      get { return _gamecoin; }
      set { _gamecoin = value; }
    }

    private uint _diamond = default(uint);
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"diamond", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint diamond
    {
      get { return _diamond; }
      set { _diamond = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}