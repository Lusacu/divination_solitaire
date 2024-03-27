//using System.Diagnostics;
using UnityEngine;

namespace CardHouse
{
    [RequireComponent(typeof(Homing)), RequireComponent(typeof(Turning)), RequireComponent(typeof(Scaling))]
    public class DragOperator : MonoBehaviour
    {

        public AudioSource audioSource; // ������ �� ��������� AudioSource
        public AudioClip dragSound; // ����, ������� �� ������ ��������������
        public AudioClip releaseSound; // ����, ������� �� ������ �������������� ��� ���������� ������ ����

        public DragDetector MyDragDetector;

        public DragAction DragAction;
        public float DragSwell = 1.2f;
        public bool PointUpWhenDragged = true;

        public SeekerScriptableSet PresentationSeekers;

        Homing MyHoming;
        Turning MyTurning;
        Scaling MyScaling;


        private void Awake()
        {
            MyHoming = GetComponent<Homing>();
            MyTurning = GetComponent<Turning>();
            MyScaling = GetComponent<Scaling>();
            if (MyDragDetector == null)
            {
                MyDragDetector = GetComponent<DragDetector>();
            }
        }

        void Start()
        {
            // �������� ��������� AudioSource �� ������� � ������ "DragCard_Sound"
            audioSource = GameObject.Find("DragCard_Sound").GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource found on object named 'DragCard_Sound'!");
            }
        }

        public void SetDragState(bool newState)
        {
            if (MyDragDetector == null)
                return;

            if (newState)
            {
                if (UseDragSwell)
                {
                    MyScaling.StartSeeking(DragSwell);
                }
                Dragging.Instance.BeginDragging(MyDragDetector, MyHoming, MyTurning, PointUpWhenDragged);

                // ������������� ����, ���� audioSource ������ � dragSound �� ����� null
                if (newState && audioSource != null && dragSound != null)
                {
                    audioSource.PlayOneShot(dragSound);
                }
            }
            else
            {
                if (UseDragSwell)
                {
                    MyScaling.StartSeeking(1f);
                }
                Dragging.Instance.StopDragging();

                // ������������� ���� ��� ���������� ������ ����, ���� audioSource ������ � releaseSound �� ����� null
                if (audioSource != null && releaseSound != null)
                {
                    audioSource.PlayOneShot(releaseSound);
                }
            }
        }

        bool UseDragSwell => DragSwell > 0 && DragSwell != 1;
    }
}
