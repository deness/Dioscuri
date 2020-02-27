using UnityEngine;

public class TestGitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.Console.WriteLine("Hello Git World!");
    }

    // Update is called once per frame
    void Update()
    {
        // Local changes
        System.Console.WriteLine("Updated from a different local repo.");
    }
}
