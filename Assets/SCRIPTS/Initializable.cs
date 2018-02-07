using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gives an object an initialization function that will be called by the Game. Must not be disabled on awake, though the Initialize () method may disable it.
/// </summary>
public interface Initializable {
	void Initialize ();
}
