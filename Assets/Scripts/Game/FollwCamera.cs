using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

struct Size
{
    public float width;
    public float height;

    public Size(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

}

public class FollwCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] BoxCollider2D Homebackground;
    [SerializeField] BoxCollider2D Garden;
    [SerializeField] BoxCollider2D Stage1_1background;
    [SerializeField] BoxCollider2D Stage1_2background;
    [SerializeField] BoxCollider2D Stage1_3background;
    [SerializeField] BoxCollider2D Stage1_4background;
    [SerializeField] BoxCollider2D Stage1_5background;
    [SerializeField] BoxCollider2D Stage6background;
    [SerializeField] BoxCollider2D Stage2_1background;
    [SerializeField] BoxCollider2D Stage2_2background;
    [SerializeField] BoxCollider2D Stage2_3background;
    [SerializeField] BoxCollider2D Stage2_4background;
    [SerializeField] BoxCollider2D Stage2_5background;
    [SerializeField] BoxCollider2D Stage13background;

    Size camSize;
    Size backSize;

    private void Start()
    {
        Camera cam = GetComponent<Camera>();
        float ratio = Screen.width / (float)Screen.height;
        camSize = new Size(cam.orthographicSize * ratio, cam.orthographicSize);    //카메라 크기 구함
        //cam.orthographicSize * ratio 가 너비의 크기, cam.orthographicSize 가 높이의 크기
        //그냥 cam.orthographicSize 하면 y축 반지름의 길이니까 x축 반지름의 길이는 비율을 곱해줘야함
        float sizeX = Stage1_1background.size.x * Stage1_1background.transform.lossyScale.x;
        float sizeY = Stage1_1background.size.y * Stage1_1background.transform.lossyScale.y;
        backSize = new Size(sizeX / 2f, sizeY / 2f);

    }
    void Update()
    {
        switch(GameManager.Instance.StageNum)
        {
            case 0:
                HomeMovement();
                break;
            case 1:
                GardenMovement();
                break;
            case 2:
                Stage1_1Movement();
                break;
            case 3:
                Stage1_2Movement();
                break;
            case 4:
                Stage1_3Movement();
                break;
            case 5:
                Stage1_4Movement();
                break;
            case 6:
                Stage1_5Movement();
                break;
            case 7: //6-1
                Stage6Movement();
                break;
            case 8: //6-2
                Stage6Movement();
                break;
            case 9: //2-1
                Stage2_1Movement();
                break;
            case 10: //2-2
                Stage2_2Movement();
                break;
            case 11: //2-3
                Stage2_3Movement();
                break;
            case 12: //2-4
                Stage2_4Movement();
                break;
            case 13: //2-5
                Stage2_5Movement();
                break;
            case 14: //13-1
                Stage13Movement();
                break;
            case 15: //두번째 집
                HomeMovement();
                break;
            case 16: //두번째 정원
                GardenMovement();
                break;
            case 17: //세번째 집
                HomeMovement();
                break;
            case 18: //13-2
                Stage13Movement();
                break;
            case 19: //네번째 집
                HomeMovement();
                break;

        }
    }

    public void HomeMovement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Homebackground.transform.position.x; //배경의 x축 중심값
        float pivotY = Homebackground.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void GardenMovement()
    {
        float limitX = backSize.width  / Stage1_1background.transform.lossyScale.x - camSize.width;
        float limitY = backSize.height / Stage1_1background.transform.lossyScale.y - camSize.height;

        float pivotX = Garden.transform.position.x; //배경의 x축 중심값
        float pivotY = Garden.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage1_1Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage1_1background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage1_1background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage1_2Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage1_2background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage1_2background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage1_3Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage1_3background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage1_3background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage1_4Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage1_4background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage1_4background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage1_5Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage1_5background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage1_5background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage6Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage6background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage6background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage2_1Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage2_1background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage2_1background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage2_2Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage2_2background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage2_2background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage2_3Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage2_3background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage2_3background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }
    public void Stage2_4Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage2_4background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage2_4background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage2_5Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage2_5background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage2_5background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }

    public void Stage13Movement()
    {
        float limitX = backSize.width - camSize.width;
        float limitY = backSize.height - camSize.height;

        float pivotX = Stage13background.transform.position.x; //배경의 x축 중심값
        float pivotY = Stage13background.transform.position.y; //배경의 y축 중심값

        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.x = Mathf.Clamp(pos.x, pivotX - limitX, pivotX + limitX);
        pos.y = Mathf.Clamp(pos.y, pivotY - limitY, pivotY + limitY);

        transform.position = pos;
    }
}
