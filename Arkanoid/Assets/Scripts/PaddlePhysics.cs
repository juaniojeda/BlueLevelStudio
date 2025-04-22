using UnityEngine;

public class PaddlePhysics
{
    private Transform paddleTransform;
    private float speed;
    private float width;
    private float height;

    private float screenLeft;
    private float screenRight;

    public void Initiate(Transform paddle, float speed, float width, float height, float screenLeft, float screenRight)
    {
        this.paddleTransform = paddle;
        this.speed = speed;
        this.width = width;
        this.height = height;
        this.screenLeft = screenLeft;
        this.screenRight = screenRight;
    }

    public void Frame()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;

        Vector3 pos = paddleTransform.position;
        pos.x += moveInput * speed * Time.deltaTime;

        // Limitar a los bordes de pantalla
        float halfWidth = width / 2f;
        pos.x = Mathf.Clamp(pos.x, screenLeft + halfWidth, screenRight - halfWidth);

        paddleTransform.position = pos;
    }

    public static bool CheckCollision(Vector3 ballPos, float ballRadius, ref Vector3 direction, out Vector3 correction)
    {
        correction = Vector3.zero;

        GameObject paddleObj = GameObject.FindWithTag("Paddle");
        if (paddleObj == null) return false;

        Transform paddle = paddleObj.transform;
        Vector3 paddlePos = paddle.position;
        Vector3 paddleScale = paddle.localScale;

        float paddleWidth = paddleScale.x;
        float paddleHeight = paddleScale.y;

        float halfWidth = paddleWidth / 2f;
        float halfHeight = paddleHeight / 2f;

        bool collisionX = ballPos.x + ballRadius > paddlePos.x - halfWidth &&
                          ballPos.x - ballRadius < paddlePos.x + halfWidth;

        bool collisionY = ballPos.y - ballRadius < paddlePos.y + halfHeight &&
                          ballPos.y + ballRadius > paddlePos.y;

        if (collisionX && collisionY)
        {
            // Rebote hacia arriba
            direction.y = Mathf.Abs(direction.y);

            // Ajuste de posición
            float penetration = (paddlePos.y + halfHeight) - (ballPos.y - ballRadius);
            correction = new Vector3(0f, penetration, 0f);

            return true;
        }

        return false;
    }
}