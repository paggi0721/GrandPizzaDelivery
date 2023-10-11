using System.Collections.Generic;
using UnityEngine;

public class RhythmStorage : MonoBehaviour
{
    public Note NotePrefab;                         // 노트
    public Bar BarPrefab;                           // 마디
    public AudioSource NoteSound;                   // 노트 소리

    public Queue<Bar> Bars = new Queue<Bar>();          // 마디 오브젝트 풀
    public Queue<Note> Notes = new Queue<Note>();       // 노트 오브젝트 풀

    public Queue<Bar>[] BarLoad = new Queue<Bar>[2];       // 나와있는 마디
    public Queue<Note>[] NoteLoad = new Queue<Note>[2];    // 나와있는 노트

    private void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            BarLoad[i] = new Queue<Bar>();
            NoteLoad[i] = new Queue<Note>();
        }
    }

    public Note DequeueNote()
    {
        Note note;

        // 오브젝트 풀에 노트가 존재 (재사용)
        if (Notes.Count > 0)
            note = Notes.Dequeue();

        // 오브젝트 풀에 노트가 존재하지 않음 (새로 생성)
        else
            note = Instantiate(NotePrefab, transform);

        return note;
    }

    public Bar DequeueBar()
    {
        Bar bar;

        // 오브젝트 풀에 마디가 존재 (재사용)
        if (Bars.Count > 0)
            bar = Bars.Dequeue();

        // 오브젝트 풀에 마디가 존재하지 않음 (새로 생성)
        else
            bar = Instantiate(BarPrefab, transform);

        return bar;
    }

    /// <summary>
    /// 노트 클리어 함수
    /// </summary>
    public void NoteClear(int line)
    {
        NoteSound.PlayOneShot(NoteSound.clip);
        Note n = NoteLoad[line].Peek();
        n.ActiveEffect();
        Notes.Enqueue(NoteLoad[line].Dequeue());
    }

    public void ReturnNote()
    {
        foreach(var load in NoteLoad)
        {
            if (load.Count > 0 && load.Peek().Timing < -0.12501m)
            {
                Notes.Enqueue(load.Dequeue());
                RhythmManager.Instance.Judges.Miss++;
                Debug.Log("Return Note");
            }
        }
    }

    /// <summary>
    /// 나와있는 모든 노트들을 풀에 돌려놓는 함수
    /// </summary>
    public void NoteLoadReset()
    {
        foreach (var load in NoteLoad)
        {
            while (load.Count > 0)
            {
                Note note = load.Peek();
                note.gameObject.SetActive(false);
                Notes.Enqueue(load.Dequeue());
            }
        }
    }

    /// <summary>
    /// 나와있는 모든 마디들을 풀에 돌려놓는 함수
    /// </summary>
    public void BarLoadReset()
    {
        foreach (var load in BarLoad)
        {
            while (load.Count > 0)
            {
                Bar bar = load.Peek();
                bar.gameObject.SetActive(false);
                Bars.Enqueue(load.Dequeue());
            }
        }
    }
}
