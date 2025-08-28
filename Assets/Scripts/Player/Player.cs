using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(SpriteFlipper), typeof(CollectablePicker))]
[RequireComponent(typeof(InputHandler), typeof(Jumper), typeof(GroundChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpriteFlipper _flipper;
    [SerializeField] private CollectablePicker _collectablePicker;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private GroundChecker _groundChecker;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _flipper = GetComponent<SpriteFlipper>();
        _collectablePicker = GetComponent<CollectablePicker>();
        _inputHandler = GetComponent<InputHandler>();
        _jumper = GetComponent<Jumper>();
        _groundChecker = GetComponent<GroundChecker>();
    }
}