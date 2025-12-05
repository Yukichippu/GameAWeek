using UnityEngine;

public class HitBar_PACHI : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        // 衝突相手のRigidbodyを取得する
        Rigidbody otherRigidbody = coll.rigidbody;

        if (otherRigidbody != null)
        {
            // 衝突の相対速度に基づいて力を計算する一例
            // simplifiedForceは衝突速度の大きさに比例する
            float simplifiedForce = coll.relativeVelocity.magnitude * otherRigidbody.mass;

            // 衝突が発生したポイントと方向を取得する
            ContactPoint contact = coll.contacts[0];
            Vector3 forceDirection = contact.normal; // 衝突面に対する法線ベクトル

            // 相手オブジェクトに力を加える
            // ここではAddForceMode.Impulse（瞬間的な力）を使用するのが一般的です
            otherRigidbody.AddForce(forceDirection * simplifiedForce, ForceMode.Impulse);

            // または、衝突インパルスを直接利用する (より物理的に正確)
            // otherRigidbody.AddForce(collision.impulse, ForceMode.Impulse); // impulseは既に力の単位

            Debug.Log(this.gameObject.name + "が" + coll.gameObject.name + "に衝突しました。伝えた力: " + simplifiedForce);
        }
    }

}
