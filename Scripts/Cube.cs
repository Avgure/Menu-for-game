using UnityEngine;
using Movement;

[RequireComponent(typeof(KinematicMovement))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _speedOfRotation;
    [SerializeField] private float _xComponentOfRotation;
    [SerializeField] private float _yComponentOfRotation;
    [SerializeField] private float _zComponentOfRotation;

    private KinematicMovement _kinematicMovement;

    public void ChangeRotation()
    {
        Vector3 rotation = new(_xComponentOfRotation, _yComponentOfRotation, _zComponentOfRotation);

        _kinematicMovement.ChangeRotation(rotation, _speedOfRotation);
    }

    private void Start()
    {
        _kinematicMovement = GetComponent<KinematicMovement>();

        Vector3 rotation = new(_xComponentOfRotation, _yComponentOfRotation, _zComponentOfRotation);

        _kinematicMovement.StartRotation(rotation, _speedOfRotation);
    }
}