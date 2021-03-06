using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel(createMetaModel: true)]
public partial class NetworkedAudioModel
{
    [RealtimeProperty(1, true, true)]
    private float _audioTime;

    [RealtimeProperty(2, true, true)]
    private float _speedFraction;

    [RealtimeProperty(3, true, true)]
    private bool _isPlaying;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class NetworkedAudioModel : RealtimeModel {
    public float audioTime {
        get {
            return _audioTimeProperty.value;
        }
        set {
            if (_audioTimeProperty.value == value) return;
            _audioTimeProperty.value = value;
            InvalidateReliableLength();
            FireAudioTimeDidChange(value);
        }
    }
    
    public float speedFraction {
        get {
            return _speedFractionProperty.value;
        }
        set {
            if (_speedFractionProperty.value == value) return;
            _speedFractionProperty.value = value;
            InvalidateReliableLength();
            FireSpeedFractionDidChange(value);
        }
    }
    
    public bool isPlaying {
        get {
            return _isPlayingProperty.value;
        }
        set {
            if (_isPlayingProperty.value == value) return;
            _isPlayingProperty.value = value;
            InvalidateReliableLength();
            FireIsPlayingDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(NetworkedAudioModel model, T value);
    public event PropertyChangedHandler<float> audioTimeDidChange;
    public event PropertyChangedHandler<float> speedFractionDidChange;
    public event PropertyChangedHandler<bool> isPlayingDidChange;
    
    public enum PropertyID : uint {
        AudioTime = 1,
        SpeedFraction = 2,
        IsPlaying = 3,
    }
    
    #region Properties
    
    private ReliableProperty<float> _audioTimeProperty;
    
    private ReliableProperty<float> _speedFractionProperty;
    
    private ReliableProperty<bool> _isPlayingProperty;
    
    #endregion
    
    public NetworkedAudioModel() : base(new MetaModel()) {
        _audioTimeProperty = new ReliableProperty<float>(1, _audioTime);
        _speedFractionProperty = new ReliableProperty<float>(2, _speedFraction);
        _isPlayingProperty = new ReliableProperty<bool>(3, _isPlaying);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _audioTimeProperty.UnsubscribeCallback();
        _speedFractionProperty.UnsubscribeCallback();
        _isPlayingProperty.UnsubscribeCallback();
    }
    
    private void FireAudioTimeDidChange(float value) {
        try {
            audioTimeDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireSpeedFractionDidChange(float value) {
        try {
            speedFractionDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireIsPlayingDidChange(bool value) {
        try {
            isPlayingDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = MetaModelWriteLength(context);
        length += _audioTimeProperty.WriteLength(context);
        length += _speedFractionProperty.WriteLength(context);
        length += _isPlayingProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        WriteMetaModel(stream, context);
        
        var writes = false;
        writes |= _audioTimeProperty.Write(stream, context);
        writes |= _speedFractionProperty.Write(stream, context);
        writes |= _isPlayingProperty.Write(stream, context);
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
                case (uint) PropertyID.AudioTime: {
                    changed = _audioTimeProperty.Read(stream, context);
                    if (changed) FireAudioTimeDidChange(audioTime);
                    break;
                }
                case (uint) PropertyID.SpeedFraction: {
                    changed = _speedFractionProperty.Read(stream, context);
                    if (changed) FireSpeedFractionDidChange(speedFraction);
                    break;
                }
                case (uint) PropertyID.IsPlaying: {
                    changed = _isPlayingProperty.Read(stream, context);
                    if (changed) FireIsPlayingDidChange(isPlaying);
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
        _audioTime = audioTime;
        _speedFraction = speedFraction;
        _isPlaying = isPlaying;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
