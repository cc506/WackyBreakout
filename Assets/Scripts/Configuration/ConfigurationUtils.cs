using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    private static ConfigurationData configurationData;

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets ball impulse force
    /// </summary>
    public static float BallImpulseForce
	{
		get { return configurationData.BallImpulseForce; }
	}

    /// <summary>
    /// Gets ball life time
    /// </summary>
    public static float BallLifeTime
		{
			get { return configurationData.BallLifeTime; }
		}


    public static float MinSeconds
		{
			get { return configurationData.MinSeconds; }
		}

    public static float MaxSeconds
		{
			get { return configurationData.MaxSeconds; }
		}
    public static int StandardBlocks
		{
			get { return configurationData.StandardBlocks; }
		}
    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
