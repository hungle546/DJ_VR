using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    private InputDevice targetDevice;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;
    private GameObject spawnedHandModel;
    private GameObject spawnedController;
    public InputDeviceCharacteristics controllerCharacteristics;
    
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            /*GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find controller");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }*/

            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
        }*/
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            Debug.Log("Pressing primary button");
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
        {
            Debug.Log("Pressing secondary button");
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            Debug.Log("Trigger pressed " + triggerValue);
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue) && gripButtonValue)
        {
            Debug.Log("Pressing grip button");
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
        }
    }
}
