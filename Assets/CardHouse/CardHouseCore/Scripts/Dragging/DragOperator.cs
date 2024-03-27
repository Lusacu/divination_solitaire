//using System.Diagnostics;
using UnityEngine;

namespace CardHouse
{
    [RequireComponent(typeof(Homing)), RequireComponent(typeof(Turning)), RequireComponent(typeof(Scaling))]
    public class DragOperator : MonoBehaviour
    {

        public AudioSource audioSource; // Ссылка на компонент AudioSource
        public AudioClip dragSound; // Звук, который вы хотите воспроизводить
        public AudioClip releaseSound; // Звук, который вы хотите воспроизводить при отпускании кнопки мыши

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
            // Получаем компонент AudioSource из объекта с именем "DragCard_Sound"
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

                // Воспроизводим звук, если audioSource найден и dragSound не равен null
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

                // Воспроизводим звук при отпускании кнопки мыши, если audioSource найден и releaseSound не равен null
                if (audioSource != null && releaseSound != null)
                {
                    audioSource.PlayOneShot(releaseSound);
                }
            }
        }

        bool UseDragSwell => DragSwell > 0 && DragSwell != 1;
    }
}
