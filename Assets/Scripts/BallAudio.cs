using UnityEngine;

public class BallAudio : MonoBehaviour
{
    private AudioSource audioSource;
    
    private Ball ball;

    public AudioClip[] audioClips;

    private void Awake()
    {
        ball = GetComponentInParent<Ball>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        ball.OnBallCollision += BallOnOnBallCollision;
    }

    private void OnDisable()
    {
        ball.OnBallCollision -= BallOnOnBallCollision;
    }
    
    private void BallOnOnBallCollision(Vector2 collisionpoint)
    {
        audioSource.PlayOneShot(GetRandomClip());
    }

    private AudioClip GetRandomClip()
    {
        if (audioClips == null) return null;
        if (audioClips.Length < 1) return null;
        
        int index = Random.Range(0, audioClips.Length);
        return audioClips[index];
    }
}
