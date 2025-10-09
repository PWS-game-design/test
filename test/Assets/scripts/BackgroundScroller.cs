using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]

    public float scrollspeed;
    public int scale;
    private float offset;
    private Material mat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        scrollspeed = Input.GetAxisRaw("Horizontal");
        offset += (Time.deltaTime * scrollspeed) / scale;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
