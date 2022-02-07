using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel(createMetaModel: true)]
public partial class MusicManagerModel
{
    [RealtimeProperty(1, true, true)]
    private float _globalMusicTime;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class MusicManagerModel : RealtimeModel {
    public float globalMusicTime {
        get {
            return _globalMusicTimeProperty.value;
        }
        set {
            if (_globalMusicTimeProperty.value == value) return;
            _globalMusicTimeProperty.value = value;
            InvalidateReliableLength();
            FireGlobalMusicTimeDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(MusicManagerModel model, T value);
    public event PropertyChangedHandler<float> globalMusicTimeDidChange;
    
    public enum PropertyID : uint {
        GlobalMusicTime = 1,
    }
    
    #region Properties
    
    private ReliableProperty<float> _globalMusicTimeProperty;
    
    #endregion
    
    public MusicManagerModel() : base(new MetaModel()) {
        _globalMusicTimeProperty = new ReliableProperty<float>(1, _globalMusicTime);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _globalMusicTimeProperty.UnsubscribeCallback();
    }
    
    private void FireGlobalMusicTimeDidChange(float value) {
        try {
            globalMusicTimeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = MetaModelWriteLength(context);
        length += _globalMusicTimeProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        WriteMetaModel(stream, context);
        
        var writes = false;
        writes |= _globalMusicTimeProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case MetaModel.ReservedPropertyID: {
                    ReadMetaModel(stream, context);
                    break;
                }
                case (uint) PropertyID.GlobalMusicTime: {
                    changed = _globalMusicTimeProperty.Read(stream, context);
                    if (changed) FireGlobalMusicTimeDidChange(globalMusicTime);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _globalMusicTime = globalMusicTime;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */