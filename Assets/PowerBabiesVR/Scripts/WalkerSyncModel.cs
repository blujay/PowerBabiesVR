using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class WalkerSyncModel
{

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class WalkerSyncModel : IModel {
    public WalkerSyncModel() {
    }
    
    // Serialization
    enum PropertyID {
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Write all properties
        } else {
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
        } else {
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                default:
                    stream.SkipProperty();
                    break;
            }
        }
    }
}
/* ----- End Normal Autogenerated Code ----- */
