using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openJournal : MonoBehaviour
{
    [SerializeField] Image white;

    private JournalManager jm;
    private Animator ani;
    private bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        jm = GameObject.FindGameObjectWithTag("Journal").GetComponent<JournalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            up = !up;
            ani.SetBool("up", up);
            GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().canMove = !up;
            GameObject.FindGameObjectWithTag("Player").GetComponent<interact>().canInteract = !up;

            if (up)
            {
                StartCoroutine(Lerp(0, 1, .5f, .5f));
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                jm.hideJournal();
                StartCoroutine(Lerp(1, 0, 0f, .5f));
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    IEnumerator Lerp(float start, float end, float wait, float lerpDuration)
    {
        yield return new WaitForSeconds(wait);
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            white.color = new Color(1,1,1, Mathf.Lerp(start, end, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        white.color = new Color(1, 1, 1, end);

        if (end > 0.5f)
        {
            jm.showJournal();
        }
    }
}
