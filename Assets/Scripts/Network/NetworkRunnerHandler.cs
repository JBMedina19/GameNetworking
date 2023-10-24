using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Linq;
using System;
using ExitGames.Client.Photon.StructWrapping;

public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;
    NetworkRunner newtorkRunner;
    // Start is called before the first frame update
    void Start()
    {
        #region create a Clone of this game object when we start unity, and set the name to "Network Runner"
        newtorkRunner = Instantiate(networkRunnerPrefab);
        newtorkRunner.name = "Network Runner";
        #endregion

        #region call after we have set game arguments, initialize network runner, if there are no host, the first player play will be the host,
        var clientTask = InitializeNetworkRunner(newtorkRunner, GameMode.AutoHostOrClient, NetAddress.Any(),SceneManager.GetActiveScene().buildIndex, null);
        Debug.Log($"Server NetworkRunner Started");
        #endregion

    }

    #region regular startup for photon, create a virtual task called InitializeNetworkRunner, and add some parameters
    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address, SceneRef scene, Action<NetworkRunner> initialized) 
    {
        //check if unity scene has a colliders so that networks can deal with them
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();
        if (sceneManager == null)
        {
            //Handle network objects that already exist in the scene
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }
        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = "TestRoom",
            Initialized = initialized,
            SceneManager = sceneManager
        }) ;
    }

    #endregion 


}
