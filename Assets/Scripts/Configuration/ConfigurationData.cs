using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 300;
    static float ballLifeTime = 10;
    static float minSeconds = 5;
	static float maxSeconds = 10;
    static int standardBlocks = 10;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
	/// Gets the ball lifetime
	/// </summary>
	/// <value>ball lifetime</value>
	public float BallLifeTime
	{
		get { return ballLifeTime; }
		set { ballLifeTime = value; }
	}

    public float MinSeconds
	{
		get { return minSeconds; }
		set { minSeconds = value; }
	}

    public float MaxSeconds
	{
		get { return maxSeconds; }
		set { maxSeconds = value; }
	}

    public int StandardBlocks
	{
		get { return standardBlocks; }
		set { standardBlocks = value; }
	}




    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        //Read and Save Configuration Data from file
        StreamReader input  = null;
        try{
            //Create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            //Read names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            //set config data fields
            SetConfigurationDataFields(values);
        }
        catch(Exception e){
        }
        finally{
            // always close input file
		    if (input != null)
		    {
			    input.Close();
		    }
        }

    }

    /// <summary>
	/// Sets the configuration data fields from the provided
	/// csv string
	/// </summary>
	/// <param name="csvValues">csv string of values</param>
	static void SetConfigurationDataFields(string csvValues)
	{
		// the code below assumes we know the order in which the
		// values appear in the string. We could do something more
		// complicated with the names and values, but that's not
		// necessary here
		string[] values = csvValues.Split(',');

        //characteristics of breakout
		paddleMoveUnitsPerSecond = float.Parse(values[0]);
		ballImpulseForce = float.Parse(values[1]);
        minSeconds = float.Parse(values[2]);
        maxSeconds = float.Parse(values[3]);
	}

    #endregion
}
