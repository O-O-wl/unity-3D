/*
 * using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public float distance = 5.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f; // 화면 가로폭만큼 커서를 이동시켰을 때 몇 도 회전하는가.
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;
    public Vector3 initLoc;

	InputManager inputManager;
	void Start()
	{
        initLoc = transform.position;
		inputManager = FindObjectOfType<InputManager>();
	}

	// Update is called once per frame
	void LateUpdate () {
		// 드래그 입력으로 카메라 회전각을 갱신한다.
		if (inputManager.Moved()) {
			float anglePerPixel = rotAngle / (float)Screen.width;
			Vector2 delta = inputManager.GetDeltaPosition();
			horizontalAngle += delta.x * anglePerPixel;
			horizontalAngle = Mathf.Repeat(horizontalAngle,360.0f);
			verticalAngle -= delta.y * anglePerPixel;
			verticalAngle = Mathf.Clamp(verticalAngle,-60.0f,60.0f);
		}
		
		// 카메라의 위치와 회전각을 갱신한다.
		if (lookTarget != null) {
			Vector3 lookPosition = lookTarget.position + offset;
			// 주시 대상에서 상대 위치를 구한다.
			Vector3 relativePos = Quaternion.Euler(verticalAngle,horizontalAngle,0) *  new Vector3(0,0,-distance);
			
			// 주시 대상의 위치에 오프셋을 더한 위치로 이동시킨다.
			transform.position = lookPosition + relativePos ;
			
			// 주시 대상을 주시하게 한다.
			transform.LookAt(lookPosition);
			
			// 장애물을 피한다.
			RaycastHit hitInfo;
			if (Physics.Linecast(lookPosition,transform.position,out hitInfo,1<<LayerMask.NameToLayer("Ground")))
				transform.position = hitInfo.point;
		}


	}
}
*/
using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public bool getItem;
    Vector3 lookPosition;
    bool onBoss = false;
    const float RayCastMaxDistance = 100.0f;
    public float distance = 5.0f;
     float delta = 0;
    float span = 11f;
    public float horizontalAngle = 0.0f;
    public float rotAngle = 180.0f; // 화면 가로폭만큼 커서를 이동시켰을 때 몇 도 회전하는가.
    public float verticalAngle = 10.0f;
    public Transform lookTarget;
    public Vector3 offset = Vector3.zero;
    public Vector3 initLoc;
    //   public GameObject bamsongi;
    InputManager inputManager;

    // public Vector3 initV;

    void Start()
    {

        getItem = false;
        initLoc = transform.position;
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
     
        // 드래그 입력으로 카메라 회전각을 갱신한다.
        if (inputManager.Moved())
        {
            float anglePerPixel = rotAngle / (float)Screen.width;
            Vector2 delta = inputManager.GetDeltaPosition();
            horizontalAngle += delta.x * anglePerPixel;
            horizontalAngle = Mathf.Repeat(horizontalAngle, 360.0f);
            verticalAngle -= delta.y * anglePerPixel;
            verticalAngle = Mathf.Clamp(verticalAngle, -60.0f, 60.0f);
        }
        if (lookTarget.GetComponent<CharacterStatus>().trans)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                horizontalAngle -= 8;
            }
            if (Input.GetKey(KeyCode.E))
            {
                horizontalAngle += 8;
            }
        }

        // 카메라의 위치와 회전각을 갱신한다.
        if (lookTarget != null)
        {
            lookPosition = lookTarget.position + offset;
            // 주시 대상에서 상대 위치를 구한다.
            Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);

            // 주시 대상의 위치에 오프셋을 더한 위치로 이동시킨다.
            transform.position = lookPosition + relativePos;

            // 주시 대상을 주시하게 한다.
            transform.LookAt(lookPosition);

            // 장애물을 피한다.
            RaycastHit hitInfo;
            if (Physics.Linecast(lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer("Ground")))
                transform.position = hitInfo.point;
        }
    

        
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(lookTarget.transform.position.x, lookTarget.transform.position.y+2, lookTarget.transform.position.z);
            /*if(lookTarget.GetComponent<CharacterStatus>().trans){
                if (Input.GetMouseButtonDown(0))
                {
                    lookTarget.FindChild("").GetComponent<Animator>().SetBool("Fire", true);
                    Ray ray = Camera.main.ScreenPointToRay(inputManager.GetCursorPosition());
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("EnemyHit"))))
                    {

                        GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().setTarget(hitInfo.point);
                        GameObject.Find("bulletGenerater").GetComponent<BamsongiGenerator>().shoot();
                    }
                }
            }*/
        }
        if (onBoss)
        {
            delta += Time.deltaTime;
            transform.position = new Vector3(transform.position.x + Random.RandomRange(-1, 1), transform.position.y + Random.RandomRange(-1, 1), transform.position.z + Random.RandomRange(-1, 1));
            if (delta > span) { onBoss = false; }


        }

    }

    private void Update()
{

}

    public void BossStage(){
        onBoss = true;


    }
}




