using UnityEngine;

public class MoveObjectAction : Action {
    public MoveObjectAction(GameObject ObjectToMove, float speed, Transform endPoint) {
        this.ObjectToMove = ObjectToMove;
        this.speed = speed;
        this.endPoint = endPoint;
    }

    public MoveObjectAction(GameObject ObjectToMove, float speed, Vector3 endPoint) {
        this.ObjectToMove = ObjectToMove;
        this.speed = speed;
        this.Vec3EndPoint = endPoint;
    }

    private readonly GameObject ObjectToMove;
    private readonly float speed;
    private readonly Transform endPoint;
    private readonly Vector3 Vec3EndPoint;

    public override void OnEnter() {
        ObjectToMove.SetActive(true);
    }

    public override void OnExit() { }

    public override void OnUpdate() {
        if (endPoint != null)
            MoveWithTransform();
        else
            MoveWithVector3();
    }

    public void MoveWithTransform() {
        if (ObjectToMove.transform.position != endPoint.position) {
            ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, endPoint.position, speed * Time.deltaTime);
            ObjectToMove.transform.rotation = Quaternion.Lerp(ObjectToMove.transform.rotation, endPoint.rotation, speed * 2 * Time.deltaTime);
        }
        else 
            IsDone = true;
    }

    public void MoveWithVector3() {
        if (ObjectToMove.transform.position != Vec3EndPoint) 
            ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, Vec3EndPoint, speed * Time.deltaTime);
        else 
            IsDone = true;
    }
}