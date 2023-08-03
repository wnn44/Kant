using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class PlayerNetwork : NetworkBehaviour
{
    public  Text TextVol;
    
    public NetworkVariable<int> xNet = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public NetworkVariable<int> yNet = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

   

    public void NetVol(int x, int y)
    {
             xNet.Value = x;
             yNet.Value = y;
             //TextVol.text = "x="+xNet.Value; 
             //Debug.Log(TextVol.text);
             //Debug.Log(OwnerClientId + ", "+xNet.Value);
       
    }

    public void NetVolUp(int x, int y)
    {
        x = xNet.Value;
        y = yNet.Value;

    }

}
