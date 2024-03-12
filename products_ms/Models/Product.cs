using Google.Cloud.Firestore;

namespace products_ms.Models;

[FirestoreData]
public class Product : FirebaseDocument
{
    [FirestoreProperty]
    public string userID { get; set; }
    [FirestoreProperty]
    public string? type { get; set; }
    [FirestoreProperty]
    public string? ea { get; set; }
    [FirestoreProperty]
    public int? amount { get; set; }
    [FirestoreProperty]
    public int? installments { get; set; }
    [FirestoreProperty]
    public DateTime? dateTime { get; set; }
}